using System.Threading.Tasks;
using Cirrious.MvvmCross.FieldBinding;

namespace SystemDot.Mobile.Mvvm.Parallelism
{
    public class CurrentRunningTask
    {
        readonly IAsyncContextExceptionHandler exceptionHandler;
        public readonly NotifyChange<CurrentRunningTaskStatus> Status = new NotifyChange<CurrentRunningTaskStatus>();
        Task task;
        
        public CurrentRunningTask(IAsyncContextExceptionHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
        }

        public void RunInAsyncContext(Task toSet)
        {
            Status.Value = CurrentRunningTaskStatus.Running;

            toSet
                .ContinueWith(
                    t =>
                    {
                        exceptionHandler.Handle(t.Exception);
                        Status.Value = CurrentRunningTaskStatus.Error;
                    },
                    TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnFaulted)
                .ContinueWith(
                    t =>
                    {
                        Status.Value = CurrentRunningTaskStatus.Finished;
                        Status.Value = CurrentRunningTaskStatus.NotRunning;
                    },
                    TaskContinuationOptions.ExecuteSynchronously);

            task = toSet;
        }

        public void WaitForCompletion()
        {
            if (task == null) return;
            task.Wait();
        }
    }
}