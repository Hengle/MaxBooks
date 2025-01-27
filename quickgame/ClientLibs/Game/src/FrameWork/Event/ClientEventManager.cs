using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class ClientEventManager<EventType> : xc.Singleton<ClientEventManager<EventType>>
    {
        public delegate void ClientEventFunc(ClientEventBaseArgs arg);

        private Dictionary<EventType, List<ClientEventFunc>> mEventHandlers = new Dictionary<EventType, List<ClientEventFunc>>();

        class Message
        {
            public EventType e;
            public ClientEventBaseArgs arg = null;
        }
        private LinkedList<Message> mMsgLst = new LinkedList<Message>();

        public void SubscribeClientEvent(EventType eventID, ClientEventFunc func)
        {
            List<ClientEventFunc> funcs;
            if (!mEventHandlers.TryGetValue(eventID, out funcs))
            {
                funcs = new List<ClientEventFunc>();
                mEventHandlers.Add(eventID, funcs);
            }

            if (!funcs.Contains(func))
                funcs.Add(func);
        }

        public void UnsubscribeClientEvent(EventType eventID, ClientEventFunc func)
        {
            List<ClientEventFunc> funcs;
            if (mEventHandlers.TryGetValue(eventID, out funcs))
            {
                funcs.Remove(func);
            }
        }

        public void FireEvent(EventType eventID, ClientEventBaseArgs arg)
        {
            List<ClientEventFunc> funcs;

            if (mEventHandlers.TryGetValue(eventID, out funcs))
            {
                foreach (ClientEventFunc func in funcs)
                {
                    if (func != null)
                        func(arg);
                }
            }
        }

        public void PostEvent(EventType eventID, ClientEventBaseArgs arg)
        {
            Message msg = new Message();
            msg.e = eventID;
            msg.arg = arg;

            mMsgLst.AddLast(msg);
        }

        public void UpdateMsgPump()
        {
            while (mMsgLst.Count > 0)
            {
                Message msg = mMsgLst.First.Value;
                FireEvent(msg.e, msg.arg);

                mMsgLst.RemoveFirst();
            }
        }
    }
}
