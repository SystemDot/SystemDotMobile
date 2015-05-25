using SystemDot.Core;
using SystemDot.Mobile.Mvvm;
using SystemDot.Mobile.Mvvm.Parallelism;
using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace SystemDot.Mobile
{
    using SystemDot.Mobile.Alerts;
    using SystemDot.Mobile.Lifecycle;

    public abstract class TypedViewModelActivity<TViewModel> : MvxActivity
        where TViewModel : ViewModel<TViewModel>
    {
        ProgressDialog ringProgressDialog;

        readonly int layoutId;
        readonly int waitProgressStyle;

        protected TypedViewModelActivity(int layoutId, int waitProgressStyle)
        {
            this.layoutId = layoutId;
            this.waitProgressStyle = waitProgressStyle;
        }

        protected TViewModel TypedViewModel
        {
            get { return ViewModel.As<TViewModel>(); }
        }

        protected override void OnStart()
        {
            TypedViewModel.MessageDispatcher.Send(new ViewStarted());
            base.OnStart();
        }

        protected override void OnRestart()
        {
            TypedViewModel.MessageDispatcher.Send(new ViewRestarted());
            base.OnRestart();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(layoutId);
            SetupProgressIndication();
            AfterInitialContentSetup();
        }

        protected override void OnResume()
        {
            TypedViewModel.ResumeInAsyncContext();
            base.OnResume();
        }

        protected override void OnStop()
        {
            TypedViewModel.MessageDispatcher.Send(new ViewStopped());
            base.OnStop();
        }

        void SetupProgressIndication()
        {
            TypedViewModel.CurrentRunningTask.Status.Changed +=
                (_, __) => OnTaskRunningChanged(TypedViewModel.CurrentRunningTask.Status.Value);
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
                case CurrentRunningTaskStatus.Error:
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