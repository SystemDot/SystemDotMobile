using System;
using SystemDot.Mobile.Throttling;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm
{
    public class InputChangeOptions<TViewModel, TProperty> where TViewModel : ViewModel<TViewModel>
    {
        readonly TViewModel model;
        readonly Func<TViewModel, INotifyChange<TProperty>> property;
        readonly IThrottler<TViewModel> throttler;

        public InputChangeOptions(
            TViewModel model,
            Func<TViewModel, INotifyChange<TProperty>> property,
            IThrottler<TViewModel> throttler)
        {
            this.model = model;
            this.property = property;
            this.throttler = throttler;
        }

        public void Run(Action toRun)
        {
            property
                .Invoke(model)
                .Changed += (_, __) => toRun();
        }

        public ThrottleOptions<TViewModel, TProperty> ThrottleFor(TimeSpan throttleTime)
        {
            return new ThrottleOptions<TViewModel, TProperty>(
                model,
                property,
                throttler,
                throttleTime);
        }
    }
}