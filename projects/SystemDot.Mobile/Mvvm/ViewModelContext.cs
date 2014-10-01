using SystemDot.Domain.Commands;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Mvvm
{
    public class ViewModelContext
    {
        public IThrottleFactory ThrottleFactory { get; private set; }
        public ICommandBus CommandBus { get; private set; }
        public ViewModelLocator ViewModelLocator { get; private set; }

        public ViewModelContext(
            IThrottleFactory throttleFactory, 
            ICommandBus commandBus,
            ViewModelLocator viewModelLocator)
        {
            ThrottleFactory = throttleFactory;
            CommandBus = commandBus;
            ViewModelLocator = viewModelLocator;
        }
    }
}