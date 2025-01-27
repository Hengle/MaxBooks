using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
    public abstract class BehaviourNode
    {
        protected IBehaviourEmployee mEmployee;
        protected BehaviourReturnCode mReturnCode = BehaviourReturnCode.Success;

        public string Comment
        {
            get;
            set;
        }

        public BehaviourNode(IBehaviourEmployee employee)
        {
            mEmployee = employee;
        }

        public static BehaviourNode CreateNode(Hashtable options, IBehaviourEmployee employee)
        {
            if(options == null)
            {
                return null;
            }

            BehaviourNode behaviour = null;

            string typeStr = options["type"] as string;
            string comment = options["comment"] as string;
            // Sequence
            if (typeStr == "Sequence")
                behaviour = new BehaviourSequenceNode(options, employee);
            else if (typeStr == "Selector")
                behaviour = new BehaviourSelectorNode(options, employee);
            // Action
            else if (typeStr == "Action")
                behaviour = new BehaviourActionNode(options, employee);
            // Conditional
            else if (typeStr == "Conditional")
                behaviour = new BehaviourConditionalNode(options, employee);
            else if (typeStr == "Inverter")
                behaviour = new BehaviourInverterNode(options, employee);
            else if (typeStr == "Random")
                behaviour = new BehaviourRandomNode(options, employee);
            else
                return null;

            if (behaviour != null)
            {
                // 获取注释
                behaviour.Comment = comment;
            }

            return behaviour;
        }

		public abstract void Reset(IBehaviourEmployee employee);
        public abstract BehaviourReturnCode Run();
    }
}

