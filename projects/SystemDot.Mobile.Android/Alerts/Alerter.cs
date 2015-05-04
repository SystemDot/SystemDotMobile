namespace SystemDot.Mobile.Alerts
{
    using SystemDot.ThreadMarshalling;
    using Android.Widget;

    public class Alerter : IAlerter
    {
        public void Display(string message)
        {
            Toast.MakeText(MainActivityLocator.Locate(), message, ToastLength.Long).Show();
        }
    }
}