using System;
using SystemDot.Mobile.Throttling;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm
{
    public interface IInputChangeRunner
    {
        void Run(Action toRun);
    }

    public class InputChangeOptions<TViewModel, TProperty> : 
        IInputChangeRunner 
        where TViewModel : ViewModel<TViewModel>
    {
        readonly TViewModel model;
        readonly Func<TViewModel, INotifyChange<TProperty>> property;
        readonly IThrottleFactory throttleFactory;

        public InputChangeOptions(
            TViewModel model,
            Func<TViewModel, INotifyChange<TProperty>> property,
            IThrottleFactory throttleFactory)
        {
            this.model = model;
            this.property = property;
            this.throttleFactory = throttleFactory;
        }

        public virtual void Run(Action toRun)
        {
            property
                .Invoke(model)
                .Changed += (_, __) => toRun();
        }

        public InputChangeOptions<TViewModel, TOrProperty> OrInputChangedFor<TOrProperty>(
            Func<TViewModel, INotifyChange<TOrProperty>> orProperty)
        {
            return new OrInputChangeOptions<TViewModel, TOrProperty>(this, model, orProperty, throttleFactory);
        }

        public ThrottleOptions ThrottleFor(TimeSpan throttleTime)
        {
            return new ThrottleOptions(throttleFactory, throttleTime, this);
        }
    }
}