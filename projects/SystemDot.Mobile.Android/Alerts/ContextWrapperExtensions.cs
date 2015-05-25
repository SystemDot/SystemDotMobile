namespace SystemDot.Mobile.Alerts
{
    using Android.Content;

    public static class ContextWrapperExtensions
    {
        public static void NavigateToSendEmail(this ContextWrapper context, Email toSend)
        {
            var email = new Intent(Intent.ActionSend);
            email.PutExtra(Intent.ExtraEmail, new[] { toSend.To });
            email.PutExtra(Intent.ExtraSubject, toSend.Subject);
            email.PutExtra(Intent.ExtraText, toSend.Body);
            email.SetType("message/rfc822");
            context.StartActivity(email);
        }
    }
}