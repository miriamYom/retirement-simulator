using BL.DTO;
using BL.PensionServices;
using System.Reflection;
using System.Text.Json;

namespace BL.Pension;
public class PensionFactory : IPensionFactory
{
    Employee Employee { get; set; }
    
    public object Create(string pensionType, object employee)
    {

        var json = JsonSerializer.Serialize(employee);
        //var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        switch (pensionType)
        {      
            case "AccrualPension":
                Employee = JsonSerializer.Deserialize<Employee>(json);
                break;
            case "BudgetPension":
                Employee = JsonSerializer.Deserialize<BudgetPensionEmployee>(json);
                break;
            case "BPSForSenior":
                Employee = JsonSerializer.Deserialize<BPEForSeniorSalary>(json);
                break;
            default:
                throw new InvalidParameterException();
        }
        Employee.PensionType = new AccrualPensionService();
        return Calculates(Employee);

    }

        public static object Calculates(Employee employee)
    {
        //    pensionType_ = pensionType_ + "Service";
            //Type.GetType(pensionType_); 
        PensionService.CurrentEmployee = employee;

        bool flag = false;
        string json = "{";
        //object[] param = { this };
        foreach (var methodInfo in employee.PensionType.GetType().GetMethods(BindingFlags.Static | BindingFlags.Public))
        {
            var result = methodInfo.Invoke(null, null);
            if (!flag)
            {
                flag = true;
                json += $" '{methodInfo.Name}' : '{result}'";

            }
            else json += $" ,'{methodInfo.Name}' : '{result}'";
        }
        json += "}";
        return json.Replace("'", "\"");
    }
}