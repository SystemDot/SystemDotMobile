using SystemDot.Domain.Commands;
using SystemDot.Messaging;
using SystemDot.Mobile.Throttling;

namespace SystemDot.Mobile.Mvvm
{
    public class ViewModelContext
    {
        public IThrottleFactory ThrottleFactory { get; private set; }
        public IBus Bus { get; private set; }

        public ViewModelContext(IThrottleFactory throttleFactory, IBus bus)
        {
            ThrottleFactory = throttleFactory;
            Bus = bus;
        }
    }
}