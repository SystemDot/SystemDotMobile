using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm
{
    public abstract class ValidatableViewModel<TViewModel> : ViewModel<TViewModel>
        where TViewModel : ViewModel<TViewModel>
    {
        public readonly NotifyChange<string> ValidationMessage;

        protected ValidatableViewModel(ViewModelContext context, ViewModelLocator viewModelLocator)
            : base(context, viewModelLocator)
        {
            ValidationMessage = new NotifyChange<string>();
        }
    }
}