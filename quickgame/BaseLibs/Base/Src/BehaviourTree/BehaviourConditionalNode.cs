using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BehaviourTree
{
    public class BehaviourConditionalNode : BehaviourWithParametersNode
    {
        // <summary>
        /// 多個條件判斷句組合條件
        /// </summary>
        private enum EOperator : byte
        {
            And = 0,
            Or
        }
        //條件判斷句類型
        private enum EConditionType : byte
        {
            Function = 0,
            Expression,
            Null
        }
        /// <summary>
        /// 单个條件判斷
        /// </summary>
        private class Condition
        {
            public EConditionType Type = EConditionType.Null;
            public string FunctorByString;
            public bool IsNot = false;

            public string LeftValue;
            public string RightValue;
            public string Operator;
        }

        /// <summary>
        /// 需要判断的條件
        /// </summary>
        private LinkedList<Condition> mConditions = new LinkedList<Condition>();

        /// <summary>
        /// 判断条件
        /// </summary>
        private EOperator mOperator = EOperator.And;

        /// <summary>
        /// 条件成立的行为
        /// </summary>
        private BehaviourNode mTrueBehavior;

        /// <summary>
        /// 条件失败的行为
        /// </summary>
        private BehaviourNode mFalseBehavior;
        /// <summary>
        /// 切割字符串的正则表达式，用来判断条件是表达式语句还是直接的函数
        /// </summary>
        private const string mSplitRegularPattern = @"(.+?)\s*([!<>=]+)\s*(.+)";

        /// <summary>
        /// 是否打开缓冲模式，用来优化性能
        /// </summary>
        private bool mIsCacheTurnOn = false;
        /// <summary>
        /// 上一次执行的时间
        /// </summary>
        private float mLastExecutionTime = 0.0f;
        /// <summary>
        /// 固定的刷新时间
        /// </summary>
        private float mConstRefreshTime = 0.0f;
        /// <summary>
        /// 缓冲表達式執行的结果
        /// </summary>
        private bool mCachedExpressionResult;


        public BehaviourConditionalNode(Hashtable options, IBehaviourEmployee employee)
            : base(employee)
        {

            if (options == null)
            {
                return;
            }

            string conditionsString = options["condition"] as string;

            if (!String.IsNullOrEmpty(conditionsString))
            {
                string[] conditions = conditionsString.Split('|');
                for (int i = 0; i < conditions.Length; i++)
                {
                    string temp = conditions[i];

                    if (temp == null || temp == string.Empty)
                    {
                        continue;
                    }

                    // 試圖切割字符串，查看其是表達式還是函數
                    string[] condition = Regex.Split(conditions[i].Trim(), mSplitRegularPattern, RegexOptions.None);

                    if (condition.Length == 1)
                    {
                        Condition con = new Condition();
                        con.IsNot = false;

                        // 先判断是否取反
                        string method = condition[0];
                        char firstChar = method[0];

                        if (firstChar == '!')
                        {
                            con.IsNot = true;
                            method = method.Substring(1, method.Length - 1);
                        }

                        //                     MethodInfo functor = objType.GetMethod(method);
                        // 
                        //                     if (functor == null)
                        //                     {
                        //                         GameDebug.LogError(string.Format("{0} Conditional::Conditional can not get method:{1}", _Comment,  method));
                        //                     }

                        con.FunctorByString = method;
                        //con._Functor = functor;
                        con.Type = EConditionType.Function;

                        mConditions.AddLast(con);
                    }
                    else if (condition.Length >= 5)
                    {
                        Condition con = new Condition();
                        con.Type = EConditionType.Expression;
                        con.LeftValue = condition[1];
                        con.Operator = condition[2];
                        con.RightValue = condition[3];

                        mConditions.AddLast(con);
                    }
                    else
                    {
                        // Error
                        //GameDebug.LogError("Conditional::Conditional unknown string:" + conditionsString);
                    }
                }
            }

            Hashtable table = options["true"] as Hashtable;

            mTrueBehavior = BehaviourNode.CreateNode(table, employee);

            table = options["false"] as Hashtable;
            mFalseBehavior = BehaviourNode.CreateNode(table, employee);

            string operatorString = options["operator"] as string;
            if (operatorString != null && operatorString.ToLower() == "or")
            {
                mOperator = EOperator.Or;
            }
            else
            {
                mOperator = EOperator.And;
            }

            // 解析调用参数
            base.ParseParamters(options);

            // 解析缓冲模式
            string cacheModeString = options["cache"] as string;

            if (cacheModeString != null && cacheModeString.ToLower() == "true")
            {
                mIsCacheTurnOn = true;
            }
            else
            {
                mIsCacheTurnOn = false;
            }

            if (mIsCacheTurnOn)
            {
                string refreshTimeString = options["refresh"] as string;

                if (refreshTimeString == null)
                {
                    mIsCacheTurnOn = false;
                    return;
                }

                string[] timesStr = refreshTimeString.Split('~');

                if (timesStr.Length > 1)
                {
                    float begin = (float)(Convert.ToDouble(timesStr[0]));
                    float end = (float)(Convert.ToDouble(timesStr[1]));

                    mConstRefreshTime = UnityEngine.Random.Range(begin, end);
                }
                else
                {
                    mConstRefreshTime = (float)(Convert.ToDouble(refreshTimeString));
                }
            }
        }

		public override void Reset(IBehaviourEmployee employee)
		{
			base.mEmployee = employee;
			if (mTrueBehavior != null) 
			{
				mTrueBehavior.Reset(employee);
			}
			if (mFalseBehavior != null) 
			{
				mFalseBehavior.Reset(employee);
			}
			mLastExecutionTime = 0.0f;
			mCachedExpressionResult = false;
		}

        private bool IsNumeric(string value)
        {
            float result;
            return float.TryParse(value, out result);
            //return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

        private float GetFloat(string param)
        {
            float result = 0f;

            if (IsNumeric(param))
            {
                result = Convert.ToSingle(param);
            }
            else
            {
                result = mEmployee.RunGetProperty(param);
            }

            return result;
        }

        private bool DetectResult(float left, string operation, float right)
        {
            bool result = false;
            const float precision = 0.000001f;

            if (operation == ">")
                result = left > right;
            else if (operation == "<")
                result = left < right;
            else if (operation == "==")
                result = Math.Abs(left - right) <= precision;
            else if (operation == ">=")
                result = left >= right;
            else if (operation == "<=")
                result = left <= right;
            else if (operation == "!=" || operation == "<>" || operation == "><")
                result = (left - right) > precision;

            return result;
        }

		public override BehaviourReturnCode Run()
        {
            //判断当前执行的间隔有没有超过设定的间隔
            float currentTime = Time.time;

            float refreshTime = mConstRefreshTime;

            if (mIsCacheTurnOn && mCachedExpressionResult/* != null*/)
            {
                if (refreshTime > 0 && mLastExecutionTime > 0)
                {
                    float deltaTime = currentTime - mLastExecutionTime;

                    // 執行緩衝
                    if (deltaTime < refreshTime)
                    {
                        if (mCachedExpressionResult)
                        {
                            if (mTrueBehavior != null)
                            {
                                mReturnCode = mTrueBehavior.Run();

                                return mReturnCode;
                            }
                            else
                            {
                                mReturnCode = BehaviourReturnCode.Success;

                                return mReturnCode;
                            }
                        }
                        else
                        {
                            if (mFalseBehavior != null)
                            {
                                mReturnCode = mFalseBehavior.Run();

                                return mReturnCode;
                            }
                            else
                            {
                                mReturnCode = BehaviourReturnCode.Failure;

                                return mReturnCode;
                            }
                        }
                    }
                }
            }

            mLastExecutionTime = currentTime;

            bool result = false;

            int index = 0;

            foreach (Condition condition in mConditions)
            {
                if (condition.Type == EConditionType.Function)
                {
                    object[] parameters = base.PackInvokeParamters(index);

                    //object ret = condition._Functor.Invoke(_Target, parameters);

                    //result = Convert.ToBoolean(ret);

                    result = mEmployee.RunCondition(condition.FunctorByString, parameters);

                    if (condition.IsNot)
                    {
                        result = !result;
                    }
                }
                else if (condition.Type == EConditionType.Expression)
                {
                    float left = GetFloat(condition.LeftValue);
                    float right = GetFloat(condition.RightValue);

                    result = DetectResult(left, condition.Operator, right);
                }

                ++index;

                if (mOperator == EOperator.And)
                {
                    if (result == false)
                    {
                        mCachedExpressionResult = false;

                        if (mFalseBehavior != null)
                        {
                            mReturnCode = mFalseBehavior.Run();
                            //                             _CachedResult = ret;
                            //                             ReturnCode = _CachedResult;
                            // ReturnCode = ret;

                            return mReturnCode;
                        }
                        else
                        {
                            mReturnCode = BehaviourReturnCode.Failure;

                            return mReturnCode;
                        }
                    }
                }
                //Or
                else
                {
                    if (result)
                    {
                        mCachedExpressionResult = true;

                        if (mTrueBehavior != null)
                        {
                            mReturnCode = mTrueBehavior.Run();

                            return mReturnCode;
                        }
                        else
                        {
                            mReturnCode = BehaviourReturnCode.Success;

                            return mReturnCode;
                        }
                    }
                }
            }

            //最終結果是True
            if (mOperator == EOperator.And)
            {
                mCachedExpressionResult = true;

                if (mTrueBehavior != null)
                {
                    mReturnCode = mTrueBehavior.Run();

                    return mReturnCode;
                }
                else
                {
                    mReturnCode = BehaviourReturnCode.Success;

                    return mReturnCode;
                }
            }
            //最終結果是False
            else
            {
                mCachedExpressionResult = false;

                if (mFalseBehavior != null)
                {
                    mReturnCode = mFalseBehavior.Run();

                    return mReturnCode;
                }
                else
                {
                    mReturnCode = BehaviourReturnCode.Failure;

                    return mReturnCode;
                }
            }
        }
    }
}
