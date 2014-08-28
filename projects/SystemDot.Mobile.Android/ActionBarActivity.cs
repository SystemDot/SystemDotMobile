using System;
using SystemDot.Core;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile
{
    public abstract class ActionBarActivity<TViewModel> : MvxActivity
    {
        readonly int menuLayoutId;
        readonly int layoutId;
        Func<TViewModel, INotifyChange> menuInvalidatorAction;

        protected TViewModel TypedViewModel
        {
            get { return ViewModel.As<TViewModel>(); }
        }

        protected ActionBarActivity(int layoutId, int menuLayoutId)
        {
            this.menuLayoutId = menuLayoutId;
            this.layoutId = layoutId;
        }

        protected ActionBarActivity(int layoutId, int menuLayoutId, Func<TViewModel, INotifyChange> menuInvalidatorAction)
            : this(layoutId, menuLayoutId)
        {
            this.menuInvalidatorAction = menuInvalidatorAction;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(layoutId);
            SetMenuInvalidator();
            AfterContentSetup();
        }

        protected virtual void AfterContentSetup()
        {
        }

        void SetMenuInvalidator()
        {
            if (menuInvalidatorAction == null) return;
            menuInvalidatorAction(TypedViewModel).Changed += (sender, args) => InvalidateOptionsMenu();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(menuLayoutId, menu);
            SetActionBarButtonState(menu);
            return true;
        }

        protected virtual void SetActionBarButtonState(IMenu menu)
        {
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return PerformViewModelAction(item) || base.OnOptionsItemSelected(item);
        }

        protected abstract bool PerformViewModelAction(IMenuItem menuItem);
    }
}