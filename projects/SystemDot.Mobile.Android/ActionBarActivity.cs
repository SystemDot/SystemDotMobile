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
        readonly int layoutId;
        readonly Func<TViewModel, INotifyChange> menuInvalidatorAction;
        
        protected ActionBarActivity(int layoutId, int menuLayoutId) : base(layoutId)
        {
            this.menuLayoutId = menuLayoutId;
            this.layoutId = layoutId;
        }

        protected ActionBarActivity(int layoutId, int menuLayoutId, Func<TViewModel, INotifyChange> menuInvalidatorAction)
            : this(layoutId, menuLayoutId)
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