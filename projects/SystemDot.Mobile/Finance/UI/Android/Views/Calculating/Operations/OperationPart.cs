using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Whole;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Addition;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Division;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Multiplication;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Subtraction;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations
{
    public abstract class OperationPart : CalculationPart
    {
        protected OperationPart()
        {
            AllowToBeFollowedBy<WholeNumericPart>();
            AllowToBeReplacedBy<AddPart>();
            AllowToBeReplacedBy<SubtractPart>();
            AllowToBeReplacedBy<MultiplyPart>();
            AllowToBeReplacedBy<DividePart>();
        }
    }
}