using System;
using SystemDot.Core;
using SystemDot.Mobile.Mvvm;
using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace SystemDot.Mobile
{
    public abstract class TypedViewModelActivity<TViewModel> : MvxActivity
        where TViewModel : ViewModel<TViewModel>
    {
        ProgressDialog ringProgressDialog;
        
        readonly int layoutId;

        protected TypedViewModelActivity(int layoutId)
        {
            this.layoutId = layoutId;
        }

        protected TViewModel TypedViewModel
        {
            get { return ViewModel.As<TViewModel>(); }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(layoutId);
            SetupProgressIndication();
            AfterInitialContentSetup();
        }

        void SetupProgressIndication()
        {
            TypedViewModel.CurrentRunningTask.Status.Changed += (_, __) => OnTaskRunningChanged(TypedViewModel.CurrentRunningTask.Status.Value);
        }

        void OnTaskRunningChanged(CurrentRunningTaskStatus status)
        {
            switch (status)
            {
                case CurrentRunningTaskStatus.Running:
                    LaunchRingDialog();
                    break;
                case CurrentRunningTaskStatus.Finished:
                    ringProgressDialog.Dismiss();
                    break;
            }
        }

        void LaunchRingDialog()
        {
            ringProgressDialog = ProgressDialog.Show(this, String.Empty, String.Empty, true);
            ringProgressDialog.SetCancelable(false);
        }

        protected virtual void AfterInitialContentSetup()
        {
        }
    }
}