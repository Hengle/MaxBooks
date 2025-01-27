using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class SimpleFSMachine<StateType>
    {
        private Dictionary<StateType, SimpleFiniteState<StateType>> mStates = new Dictionary<StateType, SimpleFiniteState<StateType>>();
        private SimpleFiniteState<StateType> mCurrentState;

        public void AddState(StateType id, SimpleFiniteState<StateType> state)
        {
            if (state == null)
            {
                return;
            }

            mStates[id] = state;
        }
        public SimpleFiniteState<StateType> GetState(StateType id)
        {
            SimpleFiniteState<StateType> state = null;
            if (mStates.TryGetValue(id, out state))
            {
                return state;
            }

            return null;
        }
        public void Update()
        {
            if (mCurrentState == null)
            {
                return;
            }

            mCurrentState.Update();
        }

        public void SwitchToState(StateType id)
        {
            SimpleFiniteState<StateType> nextState = GetState(id);

            if (nextState == null)
            {
                //GameLog.LogError(string.Format("FSMachine.SwitchToState error,can not find {0} state", id));
                return;
            }

            if (nextState == mCurrentState)
            {
                return;
            }

            if (mCurrentState != null)
            {
                mCurrentState.Exit();
            }

            nextState.Enter();
            mCurrentState = nextState;
        }
        public SimpleFiniteState<StateType> GetCurrentState()
        {
            return mCurrentState;
        }

        public StateType GetCurrentStateId()
        {
            if (mCurrentState == null)
            {
                return default(StateType);
            }

            return mCurrentState.Id;
        }
    }
}
