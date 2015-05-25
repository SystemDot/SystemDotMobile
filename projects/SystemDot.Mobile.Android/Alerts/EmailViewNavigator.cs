namespace SystemDot.Mobile.Alerts
{
    using SystemDot.ThreadMarshalling;

    public class EmailViewNavigator : IEmailViewNavigator
    {
        public void Navigate(Email toSend)
        {
            MainActivityLocator.Locate().NavigateToSendEmail(toSend);
        }
    }
}