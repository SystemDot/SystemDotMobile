using System.Threading.Tasks;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm.Parallelism
{
    public class CurrentRunningTask
    {
        Task task;

        public readonly NotifyChange<CurrentRunningTaskStatus> Status = new NotifyChange<CurrentRunningTaskStatus>();

        public void RunInAsyncContext(Task toSet)
        {
            Status.Value = CurrentRunningTaskStatus.Running;

            toSet
                .ContinueWith(t =>
                {
                    Status.Value = CurrentRunningTaskStatus.Finished;
                    Status.Value = CurrentRunningTaskStatus.NotRunning;
                })
            .ContinueWith(t => 
                t.Exception.Handle(ex => { throw ex; }), 
                TaskContinuationOptions.OnlyOnFaulted);

            task = toSet;
        }

        public void WaitForCompletion()
        {
            if (task == null) return;
            task.Wait();
        }
    }
}