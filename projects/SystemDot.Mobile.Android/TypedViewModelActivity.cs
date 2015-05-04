using SystemDot.Core;
using SystemDot.Mobile.Mvvm;
using SystemDot.Mobile.Mvvm.Parallelism;
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