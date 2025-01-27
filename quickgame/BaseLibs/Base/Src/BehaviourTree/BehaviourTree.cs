using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
    public enum BehaviourReturnCode : byte
    {
        Failure,
        Success,
        Running
    }

    public class BehaviourTree
    {
		private string mName;
        private BehaviourNode mRootNode;
        private IBehaviourEmployee mEmployee;

        public BehaviourTree(string name, Hashtable options, IBehaviourEmployee employee)
        {
			mName = name;
            mEmployee = employee;
            mRootNode = BehaviourNode.CreateNode(options, employee);
        }
        public BehaviourReturnCode Run()
        {
            if(mRootNode != null)
            {
                return mRootNode.Run();
            }

            return BehaviourReturnCode.Success;
        }
		public string GetName()
		{
			return mName;
		}

		public void Reset(IBehaviourEmployee employee)
		{
			mEmployee = employee;
			mRootNode.Reset (employee);
		}
    }
}
