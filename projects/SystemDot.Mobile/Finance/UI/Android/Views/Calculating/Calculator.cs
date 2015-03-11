using System;
using System.Linq;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Fractional;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Period;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Whole;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Addition;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Division;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Multiplication;
using Rapidware.Financier.Finance.UI.Android.Views.Calculating.Operations.Subtraction;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating
{
    public abstract class Calculator
    {
        Action<string> outputAction;
        protected readonly CalculationSequence Sequence;
        
        protected Calculator(decimal startValue)
        {
            Sequence = new CalculationSequence();

            AddFullNumber(startValue);
        }

        public void SetOutputAction(Action<string> toSet)
        {
            outputAction = toSet;
            OutputSequence();
        }

        void AddFullNumber(FullNumberPart fullNumber)
        {
            Sequence.AddPart(fullNumber);
        }

        public void AddNumber(int numberPart)
        {
            PushOrReplacePartIfPossible(GetNumberPartToAdd(numberPart));
        }

        protected abstract NumericPart GetNumberPartToAdd(int numberPart);

        public void AddPeriod()
        {
            if(CanAddPeriod()) PushOrReplacePartIfPossible<PeriodPart>();
        }

        protected abstract bool CanAddPeriod();

        public void Add()
        {
            PushOrReplacePartIfPossible<AddPart>();
        }

        public void Subtract()
        {
            PushOrReplacePartIfPossible<SubtractPart>();
        }

        public void Multiply()
        {
            PushOrReplacePartIfPossible<MultiplyPart>();
        }

        public void Divide()
        {
            PushOrReplacePartIfPossible<DividePart>();
        }

        public void Clear()
        {
            Sequence.RemoveLastPart();
            if (Sequence.IsEmpty()) AddFullNumber(0);
            OutputSequence();
        }

        public void AllClear()
        {
            Sequence.Clear();
            AddFullNumber(0);
            OutputSequence();
        }

        void PushOrReplacePartIfPossible<T>() where T : CalculationPart, new()
        {
            Sequence.PushOrReplacePartIfPossible<T>();
            OutputSequence();
        }

        void PushOrReplacePartIfPossible<T>(T part) where T : CalculationPart
        {
            Sequence.PushOrReplacePartIfPossible(part);
            OutputSequence();
        }

        public void Calculate()
        {
            CalculationPartList parts = Sequence.GetParts();

            parts = parts.Visit<WholeNumericCalculationVisitor>();
            parts = parts.Visit<FractionalNumericCalculationVisitor>();
            parts = parts.Visit<DivideCalculationVisitor>();
            parts = parts.Visit<MultiplyCalculationVisitor>();
            parts = parts.Visit<AddCalculationVisitor>();
            parts = parts.Visit<SubtractCalculationVisitor>();

            Sequence.Clear();
            Sequence.AddPart(parts.Single());

            OutputSequence();
        }

        void OutputSequence()
        {
            outputAction(Sequence.ToString());
        }

        public override string ToString()
        {
            return Sequence.ToString();
        }
    }
}