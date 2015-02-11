namespace SystemDot.Mobile.Mvvm
{
    using SystemDot.Messaging.Simple;
    using SystemDot.Mobile.Alerts;

    public static class DispatcherExtensions
    {
        public static void SendAlert(this Dispatcher dispatcher, string message)
        {
            dispatcher.Send(new AlertUser { Message = message });
        }
    }
}