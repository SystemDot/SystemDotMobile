using System;
using SystemDot.ThreadMarshalling;

namespace SystemDot.Mobile.Throttling
{
    public class MainThreadMarshalledThrottle : Throttle
    {
        public MainThreadMarshalledThrottle(
            IMainThreadMarshaller marshaller,
            Action toRun, TimeSpan throttleTime)
            : base(() => marshaller.RunOnMainThread(toRun), throttleTime)
        {
        }
    }
}