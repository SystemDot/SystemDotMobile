using System;
using SystemDot.Mobile.Mvvm;

namespace SystemDot.Mobile.Throttling
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