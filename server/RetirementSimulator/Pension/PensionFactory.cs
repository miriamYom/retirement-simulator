using BL.DTO;
using System.Text.Json;

namespace BL.Pension;
public class PensionFactory : IPensionFactory
{
    public PensionFactory()
    {
    }
    public object Create(string pensionType, object employee)
    {
        Employee pensionEmployee;

        var json = JsonSerializer.Serialize(employee);
        //var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        switch (pensionType)
        {
            case "AccrualPension":
                pensionEmployee = JsonSerializer.Deserialize<Employee>(json);
                break;
            case "BudgetPension":
                pensionEmployee  = JsonSerializer.Deserialize<BudgetPensionEmployee>(json);
                break;
            case "BPSForSenior":
                pensionEmployee = JsonSerializer.Deserialize<BPEForSeniorSalary>(json);
                break;
            default:
                throw new InvalidParameterException();
        }
        return pensionEmployee.Calculates();
    }
}