using System;

namespace SystemDot.Mobile.Throttling
{
    public interface IThrottleFactory
    {
        IThrottle CreateThrottle(Action toRun, TimeSpan throttleTime);
        IThrottle CreateMainThreadMarshalledThrottle(Action toRun, TimeSpan throttleTime);
    }
}