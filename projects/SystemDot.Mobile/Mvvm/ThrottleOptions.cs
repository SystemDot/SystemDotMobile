using System;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Mvvm
{
    public class ThrottleOptions
    {
        readonly IThrottleFactory throttleFactory;
        readonly TimeSpan throttleTime;
        IThrottle throttle;

        public ThrottleOptions(IThrottleFactory throttleFactory, TimeSpan throttleTime, IInputChangeRunner runner)
        {
            this.throttleFactory = throttleFactory;
            this.throttleTime = throttleTime;
            runner.Run(() => throttle.Invoke());
        }
    
        public void ThenRunOnMainThread(Action toRun)
        {
            throttle = throttleFactory.CreateMainThreadMarshalledThrottle(toRun, throttleTime);
        }

        public void ThenRun(Action toRun)
        {
            throttle = throttleFactory.CreateThrottle(toRun, throttleTime);
        }
    }
}