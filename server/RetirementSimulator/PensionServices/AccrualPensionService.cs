using BL.DTO;
using DL.Tables;
using System.Text.Json;

namespace BL.PensionServices;

internal class AccrualPensionService : PensionService
{

    //public void SetEmployee(string employee)
    //{
    //    var current  = JsonSerializer.Deserialize<Employee>(employee);
    //    this.Employee = current;
    //}
    /// <summary>
    /// חישוב הקצבה 
    /// סכום הקצבה יהיה: משכורת אחרונה * 2% לכל שנת עבודה * חלקיות המשרה
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, double> CalculatingAllowance()
    {
        //double lastSalary = CurrentEmployee.PensionSalaryFor100PercentPosition;
        double lastSalary = 12;
        //double partTime = CurrentEmployee.AverasionSalaryFor100PercentPosition;
        double partTime = 12;
        int years = CurrentEmployee.RetirementDate.Year - CurrentEmployee.StartWorkDate.Year;
        Dictionary<string, double> dict = new Dictionary<string, double>(); ;
        dict["FullPensionPercentage"] = lastSalary * partTime * 0.02 * years;
        dict["AveragePartiality"] = lastSalary * partTime * 0.02 * years;
        dict["AnnuityPercentageIsCalculated"] = lastSalary * partTime * 0.02 * years;
        dict["allowanceAmount"] = lastSalary * partTime * 0.02 * years;
        return dict;
    }


    //-------------------------------------------מחלה
    /// <summary>
    /// אחוז פיצוי
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    //    public static double CompensationPercentage(AccrualPensionEmployee employee)
    //    {
    //        int age = (int)EmployeesAgeAtRetirement(employee);
    //        double percentage;
    //        if (employee.Reason == Enums.RetirementReason.death || employee.Reason == Enums.RetirementReason.retirementForHealthReasons)
    //        {
    //            percentage = 1; //100% compensation
    //        }
    //        else if (IsEntitled(employee)) // if eligible in terms of age and seniority 
    //        {
    //            CompensationPercentagesForSickness compensationPercentages = new(); //singleton
    //            percentage = compensationPercentages.AgesAndPercentsAccrualPension[age] / 100;
    //        }
    //        else if(age >= 57)
    //        {
    //            percentage = 1; //100% compensation
    //        }
    //        else percentage = 0;
    //        return percentage;

    //    }
    //    /// <summary>
    //    /// סכום לתשלום - פיצוי ביגן ימי מחלה שלא נוצלו
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double AmountToBePaidCompensationForUnusedSickDays(AccrualPensionEmployee employee)
    //    {
    //        return ADaysWorthOfSickness(employee) * DaysToMaturity(employee) * CompensationPercentage(employee);
    //    }
}
