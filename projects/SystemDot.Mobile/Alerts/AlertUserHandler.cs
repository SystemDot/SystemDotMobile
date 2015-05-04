namespace SystemDot.Mobile.Alerts
{
    using SystemDot.Messaging.Handling;

    public class AlertUserHandler : IMessageHandler<AlertUser>
    {
        readonly IAlerter alerter;

        public AlertUserHandler(IAlerter alerter)
        {
            this.alerter = alerter;
        }

        public void Handle(AlertUser message)
        {
            alerter.Display(message.Message);
        }
    }
}