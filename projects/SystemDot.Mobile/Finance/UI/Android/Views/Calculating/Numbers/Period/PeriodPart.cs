using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Fractional;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Addition;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Division;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Multiplication;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Subtraction;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Period
{
    public class PeriodPart : CalculationPart
    {
        public PeriodPart()
        {
            AllowToBeFollowedBy<FractionalNumericPart>();
            AllowToBeReplacedBy<AddPart>();
            AllowToBeReplacedBy<SubtractPart>();
            AllowToBeReplacedBy<MultiplyPart>();
            AllowToBeReplacedBy<DividePart>();
        }

        public override string ToString()
        {
            return ".";
        }
    }
}