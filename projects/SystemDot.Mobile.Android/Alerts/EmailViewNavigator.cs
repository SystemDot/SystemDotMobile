namespace SystemDot.Mobile.Alerts
{
    using SystemDot.ThreadMarshalling;
    using Android.Content;

    public class EmailViewNavigator : IEmailViewNavigator
    {
        public void Navigate(Email toSend)
        {
            var email = new Intent(Intent.ActionSend);
            email.PutExtra(Intent.ExtraEmail, new[] {toSend.To });
            email.PutExtra(Intent.ExtraSubject, toSend.Subject);
            email.PutExtra(Intent.ExtraText, toSend.Body);
            MainActivityLocator.Locate().StartActivity(email);
        }
    }
}