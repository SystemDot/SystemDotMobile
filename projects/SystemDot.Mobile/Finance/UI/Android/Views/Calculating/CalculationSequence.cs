using System.Collections.Generic;
using System.Linq;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating
{
    public class CalculationSequence
    {
        readonly Stack<CalculationPart> stack;
        
        public CalculationSequence()
        {
            stack = new Stack<CalculationPart>();
            Clear();
        }

        public void Clear()
        {
            stack.Clear();
        }

        public void PushOrReplacePartIfPossible<T>() where T : CalculationPart, new()
        {
            PushOrReplacePartIfPossible(new T());
        }

        public void PushOrReplacePartIfPossible<T>(T character) where T : CalculationPart
        {
            if (GetLastPart().IsReplacedBy(character)) 
                ReplacePart(character);
            else if (GetLastPart().CanBeFollowedBy(character)) 
                AddPart(character);
        }

        public CalculationPart GetLastPart()
        {
            return stack.Peek();
        }

        void ReplacePart(CalculationPart part)
        {
            RemoveLastPart();
            AddPart(part);
        }

        public void RemoveLastPart()
        {
            stack.Pop();
        }

        public void AddPart(CalculationPart part)
        {
            stack.Push(part);
        }

        public override string ToString()
        {
            return GetParts().ToString();
        }

        public CalculationPartList GetParts()
        {
            return new CalculationPartList(stack.Reverse());
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public bool IsLastPart<T>()
        {
            return !IsEmpty() && GetLastPart() is T;
        }
    }
}