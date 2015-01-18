using System;
using SystemDot.Core;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Mobile.Alerts;
using SystemDot.Mobile.Mvvm;
using SystemDot.Mobile.Mvvm.Parallelism;
using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;

namespace SystemDot.Mobile
{
    public abstract class TypedViewModelActivity<TViewModel> : MvxActivity
        where TViewModel : ViewModel<TViewModel>
    {
        ProgressDialog ringProgressDialog;
        
        readonly int layoutId;
        ActionHandlerSubscriptionToken<AlertUser> alertHandlerToken;

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
            RegisterAlertHandling();
            AfterInitialContentSetup();
        }

        void RegisterAlertHandling()
        {
            alertHandlerToken = TypedViewModel
                .MessageDispatcher
                .RegisterHandler<AlertUser>(message => Toast.MakeText(this, message.Message, ToastLength.Long).Show());
        }

        protected override void OnDestroy()
        {
            UnregisterAlertHandling();
            base.OnDestroy();
        }

        void UnregisterAlertHandling()
        {
            TypedViewModel.MessageDispatcher.UnregisterHandler(alertHandlerToken);
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