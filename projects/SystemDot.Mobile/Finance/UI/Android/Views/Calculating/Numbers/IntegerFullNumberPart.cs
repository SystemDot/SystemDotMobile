using SystemDot.Core;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers
{
    public class IntegerFullNumberPart : FullNumberPart
    {
        public IntegerFullNumberPart(decimal number)
        {
            Number = number.RoundUpTo(0);
        }

        public override string ToString()
        {
            return Number.ToString("0");
        }
    }
}