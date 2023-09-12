namespace BL.Pension;

public interface IPensionFactory
{
    object Create(string pensionType, object employee);
}