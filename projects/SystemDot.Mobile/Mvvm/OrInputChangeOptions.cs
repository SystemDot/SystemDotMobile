using System;
using SystemDot.Mobile.Throttling;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm
{
    public class OrInputChangeOptions<TViewModel, TProperty> 
        : InputChangeOptions<TViewModel, TProperty> 
        where TViewModel : ViewModel<TViewModel>
    {
        readonly IInputChangeRunner parent;

        public OrInputChangeOptions(
            IInputChangeRunner parent, 
            TViewModel model, 
            Func<TViewModel, INotifyChange<TProperty>> orProperty,
            IThrottleFactory throttleFactory)
            : base(model, orProperty, throttleFactory)
        {
            this.parent = parent;
        }

        public override void Run(Action toRun)
        {
            parent.Run(toRun);
            base.Run(toRun);
        }
    }
}