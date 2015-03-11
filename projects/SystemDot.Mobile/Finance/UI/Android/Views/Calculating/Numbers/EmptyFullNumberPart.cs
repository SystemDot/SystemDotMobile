namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers
{
    public class EmptyFullNumberPart : FullNumberPart
    {
        public EmptyFullNumberPart()
        {
            Number = 0;
        }

        public override string ToString()
        {
            return "0";
        }
    }
}