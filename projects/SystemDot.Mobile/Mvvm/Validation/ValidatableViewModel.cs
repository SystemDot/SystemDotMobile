using SystemDot.Domain.Commands;
using SystemDot.Mobile.Throttling;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm.Validation
{
    public abstract class ValidatableViewModel<TViewModel> : ViewModel<TViewModel>
        where TViewModel : ViewModel<TViewModel>
    {
        public ValidationPresenter<TViewModel> ValidationPresenter { get; private set; }

        public readonly NotifyChange<string> ValidationMessage;

        protected ValidatableViewModel(
            ViewModelContext context, 
            ValidationPresenter<TViewModel> validationPresenter)
            : base(context)
        {
            ValidationPresenter = validationPresenter;
            ValidationMessage = new NotifyChange<string>();
        }
    }
}