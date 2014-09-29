using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemDot.Domain.Commands;
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

        public ICommandBus CommandBus { get; private set; }

        public CurrentRunningTask CurrentRunningTask { get; private set; }

        protected ViewModel(ViewModelContext context, ViewModelLocator viewModelLocator)
        {
            viewModelLocator.SetLocation(this);

            throttleFactory = context.ThrottleFactory;
            CommandBus = context.CommandBus;
            CurrentRunningTask = new CurrentRunningTask();

            tokens = new List<IActionSubscriptionToken>();
        }

        public InputChangeOptions<TViewModel, TProperty> OnInputChangedFor<TProperty>(
            Func<TViewModel, 
            INotifyChange<TProperty>> property)
        {
            return new InputChangeOptions<TViewModel, TProperty>((TViewModel)this, property, throttleFactory);
        }

        protected void When<T>(Action<T> whenAction)
        {
            tokens.Add(CommandBus.RegisterHandler(whenAction));
        }

        public void RunInAsyncContext(Func<Task> toRun)
        {
            CurrentRunningTask.RunInAsyncContext(toRun());
        }
    }
}