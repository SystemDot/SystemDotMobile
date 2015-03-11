namespace Rapidware.Financier.Finance.UI.Android.Views.Calculating.Numbers.Fractional
{
    public class FractionalNumericPart : NumericPart
    {
        public FractionalNumericPart(int number) : base(number)
        {
            AllowToBeFollowedBy<FractionalNumericPart>();
        }
    }
}