using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Period;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Whole
{
    public class WholeNumericPart : NumericPart
    {
        public WholeNumericPart(int number)
            : base(number)
        {
            AllowToBeFollowedBy<WholeNumericPart>();
            AllowToBeFollowedBy<PeriodPart>();
        }
    }
}