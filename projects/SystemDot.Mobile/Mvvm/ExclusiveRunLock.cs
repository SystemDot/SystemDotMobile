using System;
using System.Threading.Tasks;

namespace SystemDot.Mobile.Mvvm
{
    public class ExclusiveRunLock
    {
        static bool isRunning;

        public static void Run(Action toRun)
        {
            if (isRunning) return;

            isRunning = true;
            toRun();
            isRunning = false;
        }

        public static async Task RunAsync(Func<Task> toRun)
        {
            if (isRunning) return;

            isRunning = true;
            await toRun();
            isRunning = false;
        }
    }
}