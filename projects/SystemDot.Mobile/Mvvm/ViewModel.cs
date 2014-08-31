using System;
using System.Collections.Generic;
using SystemDot.Messaging;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Mobile.Throttling;
using Cirrious.MvvmCross.FieldBinding;
using Cirrious.MvvmCross.ViewModels;

namespace SystemDot.Mobile.Mvvm
{
    public class ViewModel<TViewModel> : MvxViewModel where TViewModel : ViewModel<TViewModel>
    {
        readonly IThrottleFactory throttleFactory;
        readonly List<IActionSubscriptionToken> tokens;

        public IBus Bus { get; private set; }

        public ViewModel(ViewModelContext context)
        {
            throttleFactory = context.ThrottleFactory;
            Bus = context.Bus;

            tokens = new List<IActionSubscriptionToken>();
        }

        public InputChangeOptions<TViewModel, TProperty> OnInputChangedFor<TProperty>(
            Func<TViewModel, INotifyChange<TProperty>> property)
        {
            return new InputChangeOptions<TViewModel, TProperty>((TViewModel)this, property, throttleFactory);
        }

        protected void When<T>(Action<T> whenAction)
        {
            tokens.Add(Bus.RegisterHandler(whenAction));
        }
    }
}