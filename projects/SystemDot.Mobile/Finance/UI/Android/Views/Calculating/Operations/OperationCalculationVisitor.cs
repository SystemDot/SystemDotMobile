using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations
{
    public abstract class OperationCalculationVisitor<TOperation> : CalculationVisitor 
        where TOperation : CalculationPart
    {
        bool operationOccurred;
        FullNumberPart currentNumber;

        public override void ProcessCharacter(CalculationPart toProcess)
        {
            if (ProcessCalculationPartIfPossible<FullNumberPart>(toProcess, ProcessNumber)) return;
            if (ProcessCalculationPartIfPossible<TOperation>(toProcess, ProcessOperation)) return;
            AddToOutput(toProcess);
        }

        void ProcessNumber(FullNumberPart toProcess)
        {
            if (operationOccurred)
                ProcessNumberAfterOperation(toProcess);
            else
                ProcessNumberBeforeOperation(toProcess);
        }

        void ProcessNumberAfterOperation(FullNumberPart toProcess)
        {
            if (IsInError(toProcess))
            {
                OutputError();
                return;
            }

            RemoveLastOutput();
            ProcessNumberBeforeOperation(Calculate(currentNumber, toProcess));
            operationOccurred = false;
        }

        protected virtual bool IsInError(FullNumberPart toProcess)
        {
            return false;
        }

        protected abstract FullNumberPart Calculate(FullNumberPart leftSide, FullNumberPart toProcess);

        void ProcessNumberBeforeOperation(FullNumberPart toProcess)
        {
            currentNumber = toProcess;
            AddToOutput(toProcess);
        }

        void ProcessOperation(TOperation toProcess)
        {
            operationOccurred = true;
        }
    }
}