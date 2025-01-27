using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class SimpleFiniteState<StateType>
	{
		private StateType mId;
        private float mStatingDuration = 0.0f;

        public SimpleFiniteState(StateType id)
        {
            this.mId = id;
        }
        
		public virtual void Update()
		{
            mStatingDuration += UnityEngine.Time.deltaTime;	
		}
		public virtual void Enter()
		{
            mStatingDuration = 0.0f;
		}
		
		public virtual void Exit()
		{
			
		}

        public StateType Id
		{
			get
			{
				return mId;
			}
		}

        /// <summary>
        /// 这个状态持续的时间
        /// </summary>
        public float StatingDuration
        {
            get
            {
                return mStatingDuration;
            }
            set
            {
                mStatingDuration = value;
            }
        }
	}
}
