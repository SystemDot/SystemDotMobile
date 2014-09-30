using SystemDot.Domain.Commands;
using SystemDot.Mobile.Throttling;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm.Validation
{
    public abstract class ValidatableViewModel<TViewModel> : ViewModel<TViewModel>
        where TViewModel : ViewModel<TViewModel>
    {
        public ValidationPresenter<TViewModel> ValidationPresenter;
        public readonly NotifyChange<string> ValidationMessage;

        protected ValidatableViewModel(
            IThrottleFactory throttleFactory,
            ViewModelLocator viewModelLocator,
            ValidationPresenter<TViewModel> validationPresenter,
            ICommandBus commandBus)
            : base(throttleFactory, viewModelLocator, commandBus)
        {
            ValidationPresenter = validationPresenter;
            ValidationMessage = new NotifyChange<string>();
        }
    }
}