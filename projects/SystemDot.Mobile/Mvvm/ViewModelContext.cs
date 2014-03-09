using SystemDot.Domain.Commands;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Mvvm
{
    public class ViewModelContext
    {
        public IThrottleFactory ThrottleFactory { get; private set; }
        public ICommandBus CommandBus { get; private set; }

        public ViewModelContext(IThrottleFactory throttleFactory, ICommandBus commandBus)
        {
            ThrottleFactory = throttleFactory;
            CommandBus = commandBus;
        }
    }
}