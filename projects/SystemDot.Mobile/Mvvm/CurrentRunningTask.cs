using System.Threading.Tasks;

namespace SystemDot.Mobile.Mvvm
{
    public class CurrentRunningTask
    {
        readonly Task task;

        public static CurrentRunningTask WithTask(Task task)
        {
            return new CurrentRunningTask(task);
        }

        public static CurrentRunningTask None { get { return new CurrentRunningTask(null); } }

        CurrentRunningTask(Task task)
        {
            this.task = task;
        }

        public void WaitForCompletion()
        {
            if(task != null) task.Wait();
        }
    }
}