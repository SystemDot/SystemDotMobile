using System.Threading.Tasks;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm
{
    public class CurrentRunningTask
    {
        public readonly NotifyChange<CurrentRunningTaskStatus> Status = new NotifyChange<CurrentRunningTaskStatus>();
        Task task;

        public void SetTask(Task toSet)
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
            if (task == null)
                return;
            task.Wait();
        }
    }

    public enum CurrentRunningTaskStatus
    {
        NotRunning,
        Running,
        Finished
    }
}