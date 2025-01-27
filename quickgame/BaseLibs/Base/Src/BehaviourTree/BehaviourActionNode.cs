using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
    public class BehaviourActionNode : BehaviourWithParametersNode
    {
        /// <summary>
        /// 要执行的函数
        /// </summary>
        private string mActionFunctor;
        /// <summary>
        /// 空闲时期执行的Action
        /// </summary>
        private BehaviourNode mIntervalAction;
        /// <summary>
        /// 这个Action被连续执行时的固定时间间隔，当为0的时候表示无间隔
        /// </summary>
        private float mContinuousExecutionConstIntervalTime = 0.0f;
		private float mContinuousExecutionConstIntervalTimeBak;
        /// <summary>
        /// 随机执行时间的起点时间
        /// </summary>
        private float mBeginIntervalTime = 0.0f;
        /// <summary>
        /// 随机执行时间的终点时间
        /// </summary>
        private float mEndIntervalTime = 0.0f;
        /// <summary>
        /// 该Behaviour的启动时间
        /// </summary>
        private float mStartTime = 0.0f;
        /// <summary>
        /// 上一次执行的时间
        /// </summary>
        private float mLastExecutionTime = 0.0f;    /// <summary>
        /// 在这次执行循环中是否是第一次进入到Behave(因为延迟时间的考虑)
        /// </summary>
        private bool mIsFirstRunInThisCircle = true;
        /// <summary>
        /// 是否第一次运行就随机启动时间(0--间隔时间),如果不是就是0时间的时候启动
        /// </summary>
        private bool mIsRandomFirstRunTime = false;
		private bool mIsRandomFirstRunTimeBak ;
        /// <summary>
        /// 第一次真正执行的时间
        /// </summary>
        private float mFirstRunTime = 0.0f;
		
        public BehaviourActionNode(Hashtable options, IBehaviourEmployee employee)
            : base(employee)
        {
            mActionFunctor = options["action"] as string;

            // 解析是否随机第一次启动
            string randomFirstString = options["randomfirst"] as string;

            if (randomFirstString != null && randomFirstString == "true")
            {
                mIsRandomFirstRunTime = true;
            }
            else
            {
                mIsRandomFirstRunTime = false;
            }
			mIsRandomFirstRunTimeBak = mIsRandomFirstRunTime;

            // 解析间隔时间
            string intervalTime = options["interval"] as string;

            if (!String.IsNullOrEmpty(intervalTime))
            {
                string[] timesStr = intervalTime.Split('~');

                if (timesStr.Length > 1)
                {
                    mBeginIntervalTime = (float)(Convert.ToDouble(timesStr[0]));
                    mEndIntervalTime = (float)(Convert.ToDouble(timesStr[1]));

                    mContinuousExecutionConstIntervalTime = UnityEngine.Random.Range(mBeginIntervalTime, mEndIntervalTime);
                }
                else
                {
                    mContinuousExecutionConstIntervalTime = (float)(Convert.ToDouble(intervalTime));
                }
            }
            else
            {
                mContinuousExecutionConstIntervalTime = 0f;
            }
			mContinuousExecutionConstIntervalTimeBak = mContinuousExecutionConstIntervalTime;

            if (mIsRandomFirstRunTime)
            {
                mFirstRunTime = UnityEngine.Random.Range(0, mContinuousExecutionConstIntervalTime);
            }

            Hashtable table = options["intervalaction"] as Hashtable;

            if (table != null)
            {
                mIntervalAction = BehaviourNode.CreateNode(table, employee);
            }

            // 解析參數
            base.ParseParamters(options);
        }

		public override void Reset(IBehaviourEmployee employee)
		{
			base.mEmployee = employee;
			mContinuousExecutionConstIntervalTime = mContinuousExecutionConstIntervalTimeBak;
			mStartTime = 0.0f;
			mLastExecutionTime = 0.0f; 
			mIsFirstRunInThisCircle = true;
			mIsRandomFirstRunTime = mIsRandomFirstRunTimeBak;
			if(mIntervalAction != null)
				mIntervalAction.Reset (employee);
		}

        private BehaviourReturnCode RunImplenment()
        {
            // 默認成功執行
            mReturnCode = BehaviourReturnCode.Success;

            if (mActionFunctor != null && mEmployee != null)
            {
                object[] parameters = base.PackInvokeParamters(0);

                mReturnCode = mEmployee.RunAction(mActionFunctor, parameters);
            }

            return mReturnCode;

//             switch (result)
//             {
//                 case BehaviourReturnCode.Success:
//                     _ReturnCode = BehaviourReturnCode.Success;
//                     return _ReturnCode;
//                 case BehaviourReturnCode.Failure:
//                     _ReturnCode = BehaviourReturnCode.Failure;
//                     return _ReturnCode;
//                 case BehaviourReturnCode.Running:
//                     _ReturnCode = BehaviourReturnCode.Running;
//                     return _ReturnCode;
//                 default:
//                     _ReturnCode = BehaviourReturnCode.Failure;
//                     return _ReturnCode;
//             }
        }

        public override BehaviourReturnCode Run()
        {
            float currentTime = Time.time;

            if (mStartTime <= 0.0f)
            {
                mStartTime = currentTime;
            }

            if (mIsFirstRunInThisCircle)
            {
                // 是否需要随机第一次启动运行时间
                if (mIsRandomFirstRunTime)
                {
                    float deltaTime = currentTime - mStartTime;

                    if (deltaTime < mFirstRunTime)
                    {
                        if (mIntervalAction != null)
                        {
                            mIntervalAction.Run();
                        }

                        return BehaviourReturnCode.Running;
                    }
                    else
                    {
                        mIsRandomFirstRunTime = false;
                    }
                }

                mReturnCode = RunImplenment();

                //记录上次执行的时间
                mLastExecutionTime = currentTime;

                // 随机下次执行时间
                if (mEndIntervalTime > 0)
                {
                    mContinuousExecutionConstIntervalTime = UnityEngine.Random.Range(mBeginIntervalTime, mEndIntervalTime);
                }

                if (mContinuousExecutionConstIntervalTime <= 0)
                {
                    // 这个周期已经中止，下一个周期开始
                    mIsFirstRunInThisCircle = true;

                    //return BehaviourReturnCode.Success;
                    return mReturnCode;
                }
            }

            mIsFirstRunInThisCircle = false;

            if (mReturnCode == BehaviourReturnCode.Failure)
            {
                mIsFirstRunInThisCircle = true;
            }

            //判断当前执行的间隔有没有超过设定的间隔

            if (mContinuousExecutionConstIntervalTime > 0)
            {
                float deltaTime = currentTime - mLastExecutionTime;

                if (deltaTime < mContinuousExecutionConstIntervalTime)
                {
                    // 处在间隔时间内的Behaviour
                    // 要首先拿到当前Action的预期结束时间，目前设定暂时给ActionAttack所用
                    if (mIntervalAction != null)
                    {
                        mIntervalAction.Run();
                    }

                    return BehaviourReturnCode.Running;
                }
                else
                {
                    mIsFirstRunInThisCircle = true;
                    return BehaviourReturnCode.Success;
                }
            }

            return BehaviourReturnCode.Success;
        }
    }
}
