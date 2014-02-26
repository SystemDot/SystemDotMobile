using System;
using SystemDot.Mobile.Throttling;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm
{
    public class ThrottleOptions<TViewModel, TProperty> where TViewModel : ViewModel<TViewModel>
    {
        readonly TViewModel model;
        readonly Func<TViewModel, INotifyChange<TProperty>> property;
        readonly IThrottler<TViewModel> throttler;
        readonly TimeSpan throttleTime;

        public ThrottleOptions(
            TViewModel model, 
            Func<TViewModel, INotifyChange<TProperty>> property, 
            IThrottler<TViewModel> throttler, 
            TimeSpan throttleTime)
        {
            this.model = model;
            this.property = property;
            this.throttler = throttler;
            this.throttleTime = throttleTime;
        }
    
        public void ThenRunOnMainThread(Action toRun)
        {
            throttler.ThrottleActionOnMainThreadOnPropertyChange(model, property, toRun, throttleTime);
        }
    }
}