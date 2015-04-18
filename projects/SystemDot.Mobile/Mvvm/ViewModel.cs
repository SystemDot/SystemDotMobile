using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Mobile.Mvvm.Parallelism;
using Cirrious.MvvmCross.FieldBinding;
using Cirrious.MvvmCross.ViewModels;

namespace SystemDot.Mobile.Mvvm
{
    using SystemDot.Messaging.Simple;

    public abstract class ViewModel<TViewModel> : MvxViewModel 
        where TViewModel : ViewModel<TViewModel>
    {
        readonly ViewModelContext context;
        readonly List<IActionSubscriptionToken> tokens;

        public CurrentRunningTask CurrentRunningTask { get; private set; }       
        public Dispatcher MessageDispatcher { get { return context.Dispatcher; } }

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

        public void RaiseInAsyncContext<T>() where T : new()
        {
            RaiseInAsyncContext<T>(m => { });
        }

        public void RaiseInAsyncContext<T>(Action<T> initialiseEvent) where T : new()
        {
            var message = new T();
            initialiseEvent(message);
            RunInAsyncContext(() => context.Dispatcher.SendAsync(message));
        }

        public void SendCommandInAsyncContext<TCommand>(TCommand toSend)
        {
            RunInAsyncContext(() => context.CommandBus.SendCommandAsync(toSend));
        }

        public void SendCommandInAsyncContext<TCommand>(Action<TCommand> initaliseCommandAction) where TCommand : new()
        {
            RunInAsyncContext(() => context.CommandBus.SendCommandAsync(initaliseCommandAction));
        }

        public void ResumeInAsyncContext()
        {
            RunInAsyncContext(LoadDataAsync);
        }

        protected abstract Task LoadDataAsync();

        public void Alert(string message)
        {
            context.Dispatcher.SendAlert(message);
        }

        public void When<T>(Action<T> whenAction)
        {
            tokens.Add(context.Dispatcher.RegisterHandler(whenAction));
        }

        public void RunInAsyncContext(Func<Task> toRun)
        {
            CurrentRunningTask.RunInAsyncContext(toRun());
        }
    }
}