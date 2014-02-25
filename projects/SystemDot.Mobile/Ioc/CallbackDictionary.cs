using System;
using System.Collections.Generic;

namespace SystemDot.Mobile.Ioc
{
    class CallbackDictionary : Dictionary<Type, CallbackList>
    {
        public void Register<T>(Action callback)
        {
            Register(typeof(T), callback);
        }

        public void Register(Type forType, Action callback)
        {
            if(!ContainsKey(forType)) Add(forType, new CallbackList());

            this[forType].Add(callback);
        }

        public void CallBack<T>()
        {
            CallBack(typeof(T));
        }

        public void CallBack(Type toCallbackFor)
        {
            if (!ContainsKey(toCallbackFor)) return;
            this[toCallbackFor].CallBack();
        }
    }
}