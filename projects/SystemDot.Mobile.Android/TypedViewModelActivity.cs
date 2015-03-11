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
        readonly int waitProgressStyle;
        ActionHandlerSubscriptionToken<AlertUser> alertHandlerToken;

        protected TypedViewModelActivity(int layoutId, int waitProgressStyle)
        {
            this.layoutId = layoutId;
            this.waitProgressStyle = waitProgressStyle;
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
            ringProgressDialog = new ProgressDialog(this, waitProgressStyle);
            ringProgressDialog.SetCancelable(false);
            ringProgressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            ringProgressDialog.Show();
        }

        protected virtual void AfterInitialContentSetup()
        {
        }
    }
}