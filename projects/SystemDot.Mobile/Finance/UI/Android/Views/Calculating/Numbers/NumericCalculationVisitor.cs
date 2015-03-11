using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Period;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers
{
    public abstract class NumericCalculationVisitor<T> : 
        CalculationVisitor 
        where T : CalculationPart
    {
        FullNumberPart currentNumber;

        public override void ProcessCharacter(CalculationPart toProcess)
        {
            if (IsCalculationPart<PeriodPart>(toProcess)) return;
            if (ProcessCalculationPartIfPossible<FullNumberPart>(toProcess, ProcessFullNumber)) return;
            if (ProcessCalculationPartIfPossible<T>(toProcess, ProcessNumericCharacter)) return;

            Reset();
            AddToOutput(toProcess);
        }

        protected virtual void Reset()
        {
            currentNumber = null;
        }

        void ProcessFullNumber(FullNumberPart toProcess)
        {
            currentNumber = toProcess;
            AddToOutput(toProcess);
        }

        void ProcessNumericCharacter(T toProcess)
        {
            if (currentNumber == null)
                ProcessFullNumber(ProcessNumericCharacter(0, toProcess));
            else
            {
                RemoveLastOutput();
                ProcessFullNumber(ProcessNumericCharacter(currentNumber, toProcess));
            }
        }
        
        protected abstract FullNumberPart ProcessNumericCharacter(FullNumberPart currentNumber, T toProcess);
    }
}