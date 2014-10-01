using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemDot.Domain.Commands;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Mobile.Mvvm.Parallelism;
using Cirrious.MvvmCross.FieldBinding;
using Cirrious.MvvmCross.ViewModels;

namespace SystemDot.Mobile.Mvvm
{
    public class ViewModel<TViewModel> : MvxViewModel 
        where TViewModel : ViewModel<TViewModel>
    {
        readonly ViewModelContext context;
        readonly List<IActionSubscriptionToken> tokens;

        protected ICommandBus CommandBus { get { return context.CommandBus; } }

        public CurrentRunningTask CurrentRunningTask { get; private set; }

        protected ViewModel(ViewModelContext context)
        {
            this.context = context;
            CurrentRunningTask = new CurrentRunningTask();
            tokens = new List<IActionSubscriptionToken>();

            context.ViewModelLocator.SetLocation(this);
        }

        public InputChangeOptions<TViewModel, TProperty> OnInputChangedFor<TProperty>(
            Func<TViewModel, 
            INotifyChange<TProperty>> property)
        {
            return new InputChangeOptions<TViewModel, TProperty>((TViewModel)this, property, context.ThrottleFactory);
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