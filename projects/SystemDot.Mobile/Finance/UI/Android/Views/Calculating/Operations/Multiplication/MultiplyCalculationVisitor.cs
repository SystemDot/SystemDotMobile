using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Multiplication
{
    public class MultiplyCalculationVisitor : OperationCalculationVisitor<MultiplyPart>
    {
        protected override FullNumberPart Calculate(FullNumberPart leftSide, FullNumberPart toProcess)
        {
            return leftSide * toProcess.Number;
        }
    }
}