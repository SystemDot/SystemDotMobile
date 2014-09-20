using System.Threading.Tasks;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm
{
    public class CurrentRunningTask
    {
        Task task;

        public readonly NotifyChange<CurrentRunningTaskStatus> Status = new NotifyChange<CurrentRunningTaskStatus>();

        public void RunInAsyncContext(Task toSet)
        {
            Status.Value = CurrentRunningTaskStatus.Running;
            toSet.ContinueWith(_ =>
            {
                Status.Value = CurrentRunningTaskStatus.Finished;
                Status.Value = CurrentRunningTaskStatus.NotRunning;
            });
            task = toSet;
        }

        public void WaitForCompletion()
        {
            if (task == null) return;
            task.Wait();
        }
    }
}