using System;
using System.Linq;
using SystemDot.Core;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating
{
    public abstract class CalculationVisitor
    {
        CalculationPartList output;

        public void OutputTo(CalculationPartList toOutputTo)
        {
            output = toOutputTo;
        }

        public abstract void ProcessCharacter(CalculationPart toProcess);

        protected void OutputError()
        {
            output.Clear();
            AddToOutput(new ErrorPart());
        }

        protected void RemoveLastOutput()
        {
            output.Remove(output.Last());
        }

        protected void AddToOutput(CalculationPart toAdd)
        {
            output.Add(toAdd);
        }

        protected bool ProcessCalculationPartIfPossible<T>(CalculationPart toProcess, Action<T> processor) where T : CalculationPart
        {
            if (!IsCalculationPart<T>(toProcess)) return false;
            processor(toProcess.As<T>());
            return true;
        }

        protected bool IsCalculationPart<T>(CalculationPart toProcess) where T : CalculationPart
        {
            return toProcess is T;
        }
    }
}