using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Subtraction
{
    public class SubtractCalculationVisitor : OperationCalculationVisitor<SubtractPart>
    {
        protected override FullNumberPart Calculate(FullNumberPart leftSide, FullNumberPart toProcess)
        {
            return leftSide - toProcess.Number;
        }
    }
}