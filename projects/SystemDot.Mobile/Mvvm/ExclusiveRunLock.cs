using System;
using SystemDot.Core;

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
    }
}