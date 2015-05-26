namespace SystemDot.Mobile.Mvvm
{
    using System;
    using System.Threading.Tasks;
    using SystemDot.Core;
    using SystemDot.Mobile.Mvvm.Validation;
    using Cirrious.MvvmCross.ViewModels;

    public abstract class ViewModelCommand<TViewModel> : MvxCommandBase, IMvxCommand
        where TViewModel : ValidatableViewModel<TViewModel>
    {
        public TViewModel ViewModel { get; private set; }

        protected ViewModelCommand(TViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute(object parameter)
        {
        }

        public void Execute()
        {
            OnExecute();
        }

        protected abstract void OnExecute();

        protected void RunInAsyncContext(Func<Task> toRun)
        {
            ViewModel.RunInAsyncContext(toRun);
        }

        protected void SendCommandInAsyncContext<TCommand>(Action<TCommand> initaliseCommandAction)
            where TCommand : new()
        {
            ViewModel.SendCommandInAsyncContext(initaliseCommandAction);
        }

        protected async Task SendCommandAsync<TCommand>(Action<TCommand> initaliseCommandAction)
            where TCommand : new()
        {
            await ViewModel.SendCommandAsync(initaliseCommandAction);
        }

        protected void RaiseViewEventInAsyncContext<TViewEvent>(Action<TViewEvent> initialiseEvent) 
            where TViewEvent : new()
        {
            ViewModel.RaiseViewEventInAsyncContext(initialiseEvent);
        }

        protected void RaiseViewEventInAsyncContext<TViewEvent>() where TViewEvent : new()
        {
            ViewModel.RaiseViewEventInAsyncContext<TViewEvent>();
        }

        protected async Task RaiseEventIfViewValidAsync<TViewEvent>(Action<TViewEvent> initialiseEvent) where TViewEvent : new()
        {
            if (ViewModel.IsInvalid)
            {
                return;
            }

            await ViewModel.RaiseViewEventAsync(initialiseEvent);
        }
    }

    public abstract class ViewModelCommand<TParameter, TViewModel> : MvxCommandBase, IMvxCommand
        where TViewModel : ViewModel<TViewModel>
    {
        public TViewModel ViewModel { get; private set; }

        protected ViewModelCommand(TViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OnExecute(parameter.As<TParameter>());
        }

        public void Execute()
        {
        }

        protected abstract void OnExecute(TParameter parameter);

        protected void RaiseInAsyncContext<TEvent>(Action<TEvent> initialiseEvent) where TEvent : new()
        {
            ViewModel.RaiseViewEventInAsyncContext(initialiseEvent);
        }
    }
}