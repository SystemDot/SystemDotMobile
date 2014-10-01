using System.Threading.Tasks;
using SystemDot.Domain.Commands;
using SystemDot.Domain.Events;
using SystemDot.Mobile.Mvvm.Validation;

namespace SystemDot.Mobile.Mvvm
{
    public abstract class CommandValidator<TCommand, TValidationFailedEvent> : IAsyncCommandHandler<TCommand>
        where TValidationFailedEvent : ValidationFailed, new()
    {
        readonly IEventBus eventBus;
        readonly IAsyncCommandHandler<TCommand> inner;

        protected CommandValidator(
            IEventBus eventBus, 
            IAsyncCommandHandler<TCommand> inner)
        {
            this.eventBus = eventBus;
            this.inner = inner;
        }

        public async Task Handle(TCommand command)
        {
            ValidationFailed failureEvent = new TValidationFailedEvent();

            Validate(command, failureEvent);

            if (failureEvent.IsEmpty())
                await inner.Handle(command);
            else
                eventBus.PublishEvent(failureEvent);
        }

        protected abstract void Validate(TCommand command, ValidationFailed failureEvent);
    }
}