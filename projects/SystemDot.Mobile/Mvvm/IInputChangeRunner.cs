using System;
using System.Threading.Tasks;

namespace SystemDot.Mobile.Mvvm
{
    public interface IInputChangeRunner
    {
        void Run(Action toRun);
        void RunInAsyncContext(Func<Task> toRun);
    }
}