using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class ClientEventBaseArgs
    {
        public System.Object Arg;
        public ClientEventBaseArgs(System.Object obj)
        {
            Arg = obj;
        }

        public ClientEventBaseArgs()
        {
            Arg = null;
        }

        public System.Object GetArg()
        {
            return Arg;
        }
    }

    public class ClientEventUintArgs : ClientEventBaseArgs
    {
        public uint UintArgs;

        public ClientEventUintArgs(uint args)
        {
            UintArgs = args;
        }

        public ClientEventUintArgs()
        {

        }

        public uint GetUintArgs()
        {
            return UintArgs;
        }
    }
	public class ClientEventParamArgs : ClientEventBaseArgs
	{
		public  System.Object[] mMoreParam = null;
		public ClientEventParamArgs(params System.Object[] args)
		{
			mMoreParam = args;
		}
		
		public ClientEventParamArgs()
		{
			mMoreParam = null;
		}

        public System.Object GetMoreParam(uint index)
        {
            return mMoreParam[index];
        }
	}


    public class ClientEventBoolArgs : ClientEventBaseArgs
    {
        public bool BoolArgs;

        public ClientEventBoolArgs(bool args)
        {
            BoolArgs = args;
        }

        public ClientEventBoolArgs()
        {

        }
    }


    public class ClientEventStringArgs : ClientEventBaseArgs
    {
        private string mStirngArgs;
        public string StringArgs
        {
            set { mStirngArgs = value; }
            get
            {
                return mStirngArgs;
            }
        }

        public ClientEventStringArgs(string args)
        {
            mStirngArgs = args;
        }

        public ClientEventStringArgs()
        {

        }
    }

    public class ClientEventListArgs : ClientEventBaseArgs
    {
        public List<System.Object> ListArgs = new List<object>();

        public ClientEventListArgs()
        {

        }
    }
}