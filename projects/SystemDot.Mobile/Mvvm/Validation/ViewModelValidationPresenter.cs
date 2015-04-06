namespace SystemDot.Mobile.Mvvm.Validation
{
    using System;
    using System.Linq.Expressions;
    using SystemDot.Domain.Commands;

    public abstract class ViewModelValidationPresenter<TViewModel>
        where TViewModel : ValidatableViewModel<TViewModel>
    {
        readonly ViewModelLocator viewModelLocator;

        protected ViewModelValidationPresenter(ViewModelLocator viewModelLocator)
        {
            this.viewModelLocator = viewModelLocator;
        }

        protected void PresentFieldSpecificState<TCommand, TCommandProperty, TViewModelProperty>(
            CommandValidationState<TCommand> validationState,
            Expression<Func<TCommand, TCommandProperty>> commandProperty,
            Func<TViewModel, TViewModelProperty> viewModelProperty)
            where TViewModelProperty : IInvalidatableInput
        {
            validationState
                .GetMessagesForProperty(commandProperty)
                .OutputValidationToViewModel(GetViewModel(), viewModelProperty);
        }

        protected void PresentState<TCommand>(CommandValidationState<TCommand> validationState)
        {
            validationState.GetMessages().OutputValidationToViewModel(GetViewModel());
        }

        protected void PresentMessage(string message)
        {
            GetViewModel().ValidationMessage.Value = message;
        }

        TViewModel GetViewModel()
        {
            return viewModelLocator.Locate<TViewModel>();
        }
    }
}