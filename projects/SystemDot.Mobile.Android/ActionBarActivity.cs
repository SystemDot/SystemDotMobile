using System;
using SystemDot.Mobile.Mvvm;
using Android.Views;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile
{
    public abstract class ActionBarActivity<TViewModel> : TypedViewModelActivity<TViewModel> 
        where TViewModel : ViewModel<TViewModel>
    {
        readonly int menuLayoutId;
        readonly Func<TViewModel, INotifyChange> menuInvalidatorAction;

        protected ActionBarActivity(int layoutId, int menuLayoutId, int waitProgressStyle)
            : base(layoutId, waitProgressStyle)
        {
            this.menuLayoutId = menuLayoutId;
        }

        protected ActionBarActivity(int layoutId, int menuLayoutId, int waitProgressStyle, Func<TViewModel, INotifyChange> menuInvalidatorAction)
            : this(layoutId, menuLayoutId, waitProgressStyle)
        {
            this.menuInvalidatorAction = menuInvalidatorAction;
        }

        protected override void AfterInitialContentSetup()
        {
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