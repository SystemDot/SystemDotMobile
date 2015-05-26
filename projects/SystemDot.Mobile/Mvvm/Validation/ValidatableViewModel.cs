namespace SystemDot.Mobile.Mvvm.Validation
{
    using SystemDot.Mobile.Mvvm.Notification;

    public abstract class ValidatableViewModel<TViewModel> : ViewModel<TViewModel>
        where TViewModel : ViewModel<TViewModel>
    {
        public readonly StringNotifyChange ValidationMessage;

        protected ValidatableViewModel(ViewModelContext context) : base(context)
        {
            ValidationMessage = new StringNotifyChange();
        }

        public bool IsInvalid
        {
            get { return !string.IsNullOrEmpty(ValidationMessage.Value); }
        }

        protected override void OnSendingCommand()
        {
            ValidationMessage.Value = string.Empty;
        }
    }
}