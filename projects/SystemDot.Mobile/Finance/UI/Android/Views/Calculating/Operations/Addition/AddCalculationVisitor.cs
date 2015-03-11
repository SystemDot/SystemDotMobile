using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Addition
{
    public class AddCalculationVisitor : OperationCalculationVisitor<AddPart>
    {
        protected override FullNumberPart Calculate(FullNumberPart leftSide, FullNumberPart toProcess)
        {
            return leftSide + toProcess.Number;
        }
    }
}