using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm.Validation
{
    public abstract class ValidatableViewModel<TViewModel> : ViewModel<TViewModel>
        where TViewModel : ViewModel<TViewModel>
    {
        public readonly NotifyChange<string> ValidationMessage;

        protected ValidatableViewModel(ViewModelContext context)
            : base(context)
        {
            ValidationMessage = new NotifyChange<string>();
        }
    }
}