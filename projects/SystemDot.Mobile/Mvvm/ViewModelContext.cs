using SystemDot.Domain.Commands;
using SystemDot.Messaging.Simple;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Mvvm
{
    public class ViewModelContext
    {
        public IThrottleFactory ThrottleFactory { get; private set; }
        public ViewModelLocator ViewModelLocator { get; private set; }
        public Dispatcher Dispatcher { get; private set; }
        public ICommandBus CommandBus { get; private set; }

        public ViewModelContext(
            IThrottleFactory throttleFactory, 
            ViewModelLocator viewModelLocator,
            Dispatcher dispatcher, 
            ICommandBus commandBus)
        {
            ThrottleFactory = throttleFactory;
            ViewModelLocator = viewModelLocator;
            Dispatcher = dispatcher;
            CommandBus = commandBus;
        }
    }
}