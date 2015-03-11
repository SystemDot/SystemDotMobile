using System;
using System.Collections.Generic;

namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating
{
    public abstract class CalculationPart
    {
        readonly List<Type> replacedByTypes;
        readonly List<Type> followedByTypes;

        protected CalculationPart()
        {
            replacedByTypes = new List<Type>();
            followedByTypes = new List<Type>();
        }

        public bool IsReplacedBy<T>(T part) where T : CalculationPart
        {
            return replacedByTypes.Contains(part.GetType());
        }

        public bool CanBeFollowedBy<T>(T part) where T : CalculationPart
        {
            return followedByTypes.Contains(part.GetType());
        }

        protected void AllowToBeFollowedBy<T>() where T : CalculationPart
        {
            followedByTypes.Add(typeof (T));
        }

        protected void AllowToBeReplacedBy<T>() where T : CalculationPart
        {
            replacedByTypes.Add(typeof (T));
        }

        public void Visit(CalculationVisitor visitor)
        {
            visitor.ProcessCharacter(this);
        }
    }
}