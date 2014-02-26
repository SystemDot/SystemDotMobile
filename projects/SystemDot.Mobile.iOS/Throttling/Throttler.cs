using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;
using SystemDot.Core;
using SystemDot.Mobile.Mvvm;
using SystemDot.ThreadMarshalling;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Throttling
{
    public class Throttler<TObserved> : 
        Disposable, 
        IThrottler<TObserved> where TObserved : ViewModel<TObserved>
    {
        readonly IMainThreadMarshaller mainThreadMarshaller;
        readonly Dictionary<object, Timer> activeTimers;
        readonly Dictionary<object, DateTime> timerCreation;
        readonly Random random;
        
        public Throttler(IMainThreadMarshaller mainThreadMarshaller)
        {
            Contract.Requires(mainThreadMarshaller != null);
            
            this.mainThreadMarshaller = mainThreadMarshaller;

            activeTimers = new Dictionary<object, Timer>();
            timerCreation = new Dictionary<object, DateTime>();
            random = new Random();
        }

        protected override void DisposeOfManagedResources()
        {
            UnloadTimers();
            base.DisposeOfManagedResources();
        }

        void UnloadTimers()
        {
            activeTimers.Values.ToList().ForEach(a => a.Dispose());
        }

        public void ThrottleActionOnPropertyChange<TProperty>(
            TObserved model,
            Func<TObserved, INotifyChange<TProperty>> property,
            Action throttleAction,
            TimeSpan throttleTime)
        {
            Guid jobKey = Guid.NewGuid();

            model.OnInputChanged(property).Run(() =>
            {
                EndJob(jobKey);
                StartJob(throttleAction, throttleTime, key: jobKey);
            });
        }

        public void ThrottleActionOnMainThreadOnPropertyChange<TProperty>(
            TObserved model,
            Func<TObserved, INotifyChange<TProperty>> property,
            Action throttleAction,
            TimeSpan throttleTime)
        {
            ThrottleActionOnPropertyChange(
                model,
                property,
                () => mainThreadMarshaller.RunOnMainThread(throttleAction),
                throttleTime);
        }

        void StartJob(Action action, TimeSpan delay, TimeSpan? onInterval = null, object key = null)
        {
            if (key == null) key = CreateDefaultKey();

            lock (activeTimers) AddTimer(action, delay, onInterval, key);
        }

        void AddTimer(Action action, TimeSpan delay, TimeSpan? onInterval, object key)
        {
            activeTimers.Add(key, new Timer(ActionInvoker, action, delay, GetInterval(onInterval)));
            timerCreation.Add(key, DateTime.Now);
        }

        static void ActionInvoker(object o)
        {
            ((Action)o).Invoke();
        }

        string CreateDefaultKey()
        {
            return string.Concat("Auto(", random.NextDouble(), ")");
        }

        static TimeSpan GetInterval(TimeSpan? onInterval)
        {
            return onInterval ?? TimeSpan.FromMilliseconds(-1.0);
        }

        Timer GetJobFor(object key)
        {
            lock (activeTimers) 
                return this.activeTimers.ContainsKey(key) == false 
                    ? null 
                    : activeTimers[key];
        }

        void EndJob(object key)
        {
            Timer timer = GetJobFor(key);

            if (timer == null) return;

            timer.Dispose();

            lock (activeTimers) RemoveTimer(key);
        }

        void RemoveTimer(object key)
        {
            activeTimers.Remove(key);
            timerCreation.Remove(key);
        }
    }
}
