using System;
using System.Collections.Generic;
using SystemDot.Core.Collections;

namespace SystemDot.Mobile.Ioc
{
    class CallbackList : List<Action>
    {
        public void CallBack()
        {
            this.ForEach(callback => callback());
        }
    }
}