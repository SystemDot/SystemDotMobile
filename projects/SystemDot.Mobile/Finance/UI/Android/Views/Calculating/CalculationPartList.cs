using System.Collections.Generic;
using System.Linq;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating
{
    public class CalculationPartList : List<CalculationPart>
    {
        public CalculationPartList(IEnumerable<CalculationPart> inner) : base(inner)
        { 
        }

        CalculationPartList()
        {
        }

        public CalculationPartList Visit<T>() where T : CalculationVisitor, new()
        {
            var toOutputTo = new CalculationPartList();
            var visitor = SetupVisitor<T>(toOutputTo);

            ForEach(visitor.ProcessCharacter);

            return toOutputTo;
        }

        T SetupVisitor<T>(CalculationPartList toOutputTo) where T : CalculationVisitor, new()
        {
            var visitor = new T();
            visitor.OutputTo(toOutputTo);
            return visitor;
        }


        public override string ToString()
        {
            return string.Join(string.Empty, this.Select(c => c.ToString()));
        }
    }
}