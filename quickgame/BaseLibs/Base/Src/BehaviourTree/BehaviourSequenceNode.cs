using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
    public class BehaviourSequenceNode : BehaviourNode
    {
        private List<BehaviourNode> mChildren = new List<BehaviourNode>();

        public BehaviourSequenceNode(Hashtable options, IBehaviourEmployee employee)
            : base(employee)
        {
            ArrayList queue = options["queue"] as ArrayList;

            if (queue == null)
            {
                return;
            }

            for (int i = 0; i < queue.Count; i++)
            {
                BehaviourNode node = BehaviourNode.CreateNode(queue[i] as Hashtable, employee);
                mChildren.Add(node);
            }
        }

		public override void Reset(IBehaviourEmployee employee)
		{
			base.mEmployee = employee;
			foreach (BehaviourNode node in mChildren) 
			{
				node.Reset(employee);
			}
		}

        public override BehaviourReturnCode Run()
        {
            for (int i = 0; i < mChildren.Count; i++)
            {
                switch (mChildren[i].Run())
                {
                    case BehaviourReturnCode.Failure:
                        mReturnCode = BehaviourReturnCode.Failure;
                        return mReturnCode;
                    case BehaviourReturnCode.Success:
                        continue;
                    case BehaviourReturnCode.Running:
                        mReturnCode = BehaviourReturnCode.Running;
                        return mReturnCode;
                }
            }

            mReturnCode = BehaviourReturnCode.Success;

            return mReturnCode;
        }
    }
}
