using System;
using SystemDot.Mobile.Mvvm;
using Android.Widget;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile
{
    public abstract class ActionBarActivityWithValidation<TViewModel> : ActionBarActivity<TViewModel>
        where TViewModel : ValidatableViewModel<TViewModel>
    {
        protected ActionBarActivityWithValidation(int layoutId, int menuLayoutId)
            : base(layoutId, menuLayoutId)
        {
        }

        protected ActionBarActivityWithValidation(int layoutId, int menuLayoutId, Func<TViewModel, INotifyChange> menuInvalidatorAction)
            : base(layoutId, menuLayoutId, menuInvalidatorAction)
        {
        }

        protected override void AfterContentSetup()
        {
            TypedViewModel.ValidationMessage.Changed += ValidationMessage_Changed;
        }

        void ValidationMessage_Changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(TypedViewModel.ValidationMessage.Value)) return;

            Toast
                .MakeText(this, TypedViewModel.ValidationMessage.Value, ToastLength.Long)
                .Show();
        }
    }
}