using System;
using SystemDot.ThreadMarshalling;

namespace SystemDot.Mobile.Throttling
{
    public class ThrottleFactory : IThrottleFactory
    {
        readonly IMainThreadMarshaller marshaller;

        public ThrottleFactory(IMainThreadMarshaller marshaller)
        {
            this.marshaller = marshaller;
        }

        public IThrottle CreateThrottle(Action toRun, TimeSpan throttleTime)
        {
            return new Throttle(toRun, throttleTime);
        }
        
        public IThrottle CreateMainThreadMarshalledThrottle(Action toRun, TimeSpan throttleTime)
        {
            return new MainThreadMarshalledThrottle(marshaller, toRun, throttleTime);
        }
    }
}