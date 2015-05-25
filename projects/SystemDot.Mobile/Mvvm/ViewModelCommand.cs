namespace SystemDot.Mobile.Mvvm
{
    using System;
    using SystemDot.Core;
    using Cirrious.MvvmCross.ViewModels;

    public abstract class ViewModelCommand<TViewModel> : MvxCommandBase, IMvxCommand
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
        }

        public void Execute()
        {
            OnExecute();
        }

        protected abstract void OnExecute();

        protected void SendCommandInAsyncContext<TCommand>(Action<TCommand> initaliseCommandAction)
            where TCommand : new()
        {
            ViewModel.SendCommandInAsyncContext(initaliseCommandAction);
        }

        protected void RaiseInAsyncContext<TEvent>(Action<TEvent> initialiseEvent) where TEvent : new()
        {
            ViewModel.RaiseInAsyncContext(initialiseEvent);
        }

        protected void RaiseInAsyncContext<TEvent>() where TEvent : new()
        {
            ViewModel.RaiseInAsyncContext<TEvent>();
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
            ViewModel.RaiseInAsyncContext(initialiseEvent);
        }
    }
}