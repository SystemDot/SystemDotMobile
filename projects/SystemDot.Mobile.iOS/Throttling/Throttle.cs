using System;
using System.Threading;
using SystemDot.Core;

namespace SystemDot.Mobile.Throttling
{
    public class Throttle : Disposable, IThrottle
    {
        readonly TimeSpan throttleTime;
        readonly Timer timer;

        public Throttle(
            Action toRun, 
            TimeSpan throttleTime)
        {
            this.throttleTime = throttleTime;
            timer = new Timer(ActionInvoker, toRun, GetInfiniteTime(), GetInfiniteTime());
        }

        static void ActionInvoker(object o)
        {
            ((Action)o).Invoke();
        }

        public void Invoke()
        {
            End();
            Start();
        }

        void Start()
        {
            timer.Change(throttleTime, GetInfiniteTime());
        }

        void End()
        {
            timer.Change(GetInfiniteTime(), GetInfiniteTime());
        }

        static TimeSpan GetInfiniteTime()
        {
            return TimeSpan.FromMilliseconds(-1.0);
        }

        protected override void DisposeOfManagedResources()
        {
            timer.Dispose();
            base.DisposeOfManagedResources();
        }
    }
}
