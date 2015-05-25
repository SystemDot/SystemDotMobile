

namespace SystemDot.Mobile.Mvvm
{
    using SystemDot.Domain.Commands;
    using SystemDot.Messaging.Simple;
    using SystemDot.Mobile.Throttling;
    using SystemDot.Mobile.Mvvm.Parallelism;

    public class ViewModelContext
    {
        public IThrottleFactory ThrottleFactory { get; private set; }
        public ViewModelLocator ViewModelLocator { get; private set; }
        public Dispatcher Dispatcher { get; private set; }
        public ICommandBus CommandBus { get; private set; }
        public IAsyncContextExceptionHandler AsyncContextExceptionHandler { get; private set; }
        
        public ViewModelContext(
            IThrottleFactory throttleFactory, 
            ViewModelLocator viewModelLocator,
            Dispatcher dispatcher, 
            ICommandBus commandBus,
            IAsyncContextExceptionHandler asyncContextExceptionHandler)
        {
            AsyncContextExceptionHandler = asyncContextExceptionHandler;
            ThrottleFactory = throttleFactory;
            ViewModelLocator = viewModelLocator;
            Dispatcher = dispatcher;
            CommandBus = commandBus;
        }
    }
}