namespace SystemDot.Mobile.Mvvm.Parallelism
{
    using System;

    public interface IAsyncContextExceptionHandler
    {
        void Handle(AggregateException exception);
    }
}