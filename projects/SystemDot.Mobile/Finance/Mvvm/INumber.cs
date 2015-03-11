namespace Rapidware.Financier.Finance.Mvvm
{
    public interface INumber
    {
        bool HasValue { get; }

        string ZeroString { get; }

        InputStatus Status { get; }
    }
}