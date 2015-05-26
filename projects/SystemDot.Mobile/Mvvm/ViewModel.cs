using System;
using System.Threading.Tasks;
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

        public CurrentRunningTask CurrentRunningTask { get; private set; }       
        public Dispatcher MessageDispatcher { get { return context.Dispatcher; } }

        protected ViewModel(ViewModelContext context)
        {
            this.context = context;
            CurrentRunningTask = new CurrentRunningTask(context.AsyncContextExceptionHandler);

            context.ViewModelLocator.SetLocation(this);
        }

        protected InputChangeOptions<TViewModel, TProperty> OnInputChangedFor<TProperty>(
            Func<TViewModel, 
            INotifyChange<TProperty>> property)
        {
            return new InputChangeOptions<TViewModel, TProperty>((TViewModel)this, property, context.ThrottleFactory);
        }

        public void RaiseViewEventInAsyncContext<TViewEvent>() 
            where TViewEvent : new()
        {
            RunInAsyncContext(() => context.Dispatcher.SendAsync(new TViewEvent()));
        }

        public void RaiseViewEventInAsyncContext<TViewEvent>(Action<TViewEvent> initialiseEvent) 
            where TViewEvent : new()
        {
            RunInAsyncContext(() => RaiseViewEventAsync(initialiseEvent));
        }

        public async Task RaiseViewEventAsync<TViewEvent>(Action<TViewEvent> initialiseEvent) where TViewEvent : new()
        {
            var message = new TViewEvent();
            initialiseEvent(message);
            await RaiseViewEventAsync(message);
        }

        async Task RaiseViewEventAsync<TViewEvent>(TViewEvent message) 
            where TViewEvent : new()
        {
            await context.Dispatcher.SendAsync(message);
        }

        public void SendCommandInAsyncContext<TCommand>(TCommand toSend)
        {
            RunInAsyncContext(() => SendCommandAsync(toSend));
        }

        public void SendCommandInAsyncContext<TCommand>(Action<TCommand> initaliseCommandAction) where TCommand : new()
        {
            RunInAsyncContext(() => SendCommandAsync(initaliseCommandAction));
        }

        public async Task SendCommandAsync<TCommand>(Action<TCommand> initaliseCommand) where TCommand : new()
        {
            var message = new TCommand();
            initaliseCommand(message);
            await SendCommandAsync(message);
        }

        async Task SendCommandAsync<TCommand>(TCommand toSend)
        {
            OnSendingCommand();
            await context.CommandBus.SendCommandAsync(toSend);
        }

        protected abstract void OnSendingCommand();

        public void ResumeInAsyncContext()
        {
            RunInAsyncContext(LoadDataAsync);
        }

        protected abstract Task LoadDataAsync();

        public void RunInAsyncContext(Func<Task> toRun)
        {
            CurrentRunningTask.RunInAsyncContext(toRun());
        }

        public void Alert(string message)
        {
            context.Dispatcher.SendAlert(message);
        }
    }
}