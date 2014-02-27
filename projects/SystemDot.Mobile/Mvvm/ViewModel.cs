using System;
using System.Collections.Generic;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Messaging.Simple;
using SystemDot.Mobile.Throttling;
using Cirrious.MvvmCross.FieldBinding;
using Cirrious.MvvmCross.ViewModels;

namespace SystemDot.Mobile.Mvvm
{
    public class ViewModel<TViewModel> : MvxViewModel where TViewModel : ViewModel<TViewModel>
    {
        readonly IThrottleFactory throttleFactory;
        readonly List<IActionSubscriptionToken> tokens;
        
        public ViewModel(IThrottleFactory throttleFactory)
        {
            this.throttleFactory = throttleFactory;
            tokens = new List<IActionSubscriptionToken>();
        }

        public InputChangeOptions<TViewModel, TProperty> OnInputChangedFor<TProperty>(
            Func<TViewModel, INotifyChange<TProperty>> property)
        {
            return new InputChangeOptions<TViewModel, TProperty>((TViewModel)this, property, throttleFactory);
        }

        protected void SendCommand<T>(Action<T> initaliseCommandAction) where T : new()
        {
            var command = new T();
            initaliseCommandAction(command);
            Messenger.Send(command);
        }

        protected void When<T>(Action<T> whenAction)
        {
            tokens.Add(Messenger.RegisterHandler(whenAction));
        }
    }
}