using SystemDot.Core;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers
{
    public class DecimalFullNumberPart : FullNumberPart
    {
        public DecimalFullNumberPart(decimal number)
        {
            Number = number.RoundUpTo(15);
        }

        public override string ToString()
        {
            return Number.ToFifteenPrecisionString();
        }
    }
}