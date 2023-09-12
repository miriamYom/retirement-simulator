using BL.DTO;
using BL.Enums;
using DL.Tables;
using System;
using static BL.PensionServices.Consts;

namespace BL.PensionServices;
public class PensionService
{
    #region total years
    /// <summary>
    /// the func calculate the years between 2 dates
    /// </summary>
    /// <param name="date_1">from this date</param>
    /// <param name="date_2">to this date</param>
    /// <returns></returns>
    /// <exception cref="InvalidDateException"></exception>
    protected static double TotalYears(string date_1, string date_2)
    {
        // well done
        try
        {
            double result;
            var date1 = DateTime.Parse(date_1);
            var date2 = DateTime.Parse(date_2);
            TimeSpan interval = date2 - date1;
            result = interval.TotalDays / DaysAYear;
            return Math.Round(result, 5);
        }
        catch (InvalidDateException e)
        {
            throw e;
        }
        catch (Exception)
        {
            throw new InvalidDateException("the date format is invalid");
        }

    }
    protected static double TotalYears(DateTime start, DateTime end)
    {
        // well done
        try
        {
            //double result;
            //var date1 = DateTime.Parse(date_1);
            //var date2 = DateTime.Parse(date_2);
            TimeSpan interval = start - end;
            double result = interval.TotalDays / DaysAYear;
            return Math.Round(result, 5);
        }
        catch (InvalidDateException e)
        {
            throw e;
        }
        catch (Exception)
        {
            throw new InvalidDateException("the date format is invalid");
        }

    }
    #endregion
    /// <summary>
    /// function to calculate the age of the employee at retirment
    /// </summary>
    /// <returns></returns>
    public static double EmployeesAgeAtRetirement(Employee employee)
    {
        return TotalYears(employee.BirthDate, employee.RetirementDate);
    }
    /// <summary>
    /// function to calculate how time the employee worked in the authory
    /// </summary>
    /// <returns></returns>
    public static double YearsOfWorkAtTheAuthority(Employee employee)
    {
        return TotalYears(employee.StartWorkDate, employee.RetirementDate);
    }
    /// <summary>
    /// חלקיות משרה ממוצעת של העובד בכל תקופת העבודה
    /// נתון שצריך להיות מחושב מהטבלה המזעזעת
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double AveragePartTimeJobDuringTheEntireWorkPeriod(Employee employee)
    {
        //change it!!!
        return 80;
    }
    /// <summary>
    /// Total period of work for which he is entitled to compensation
    /// </summary>
    /// <returns>The total work periods in which the employee worked less than 1/3 of a job</returns>
    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    public static double WorkingPeriodForCompensation(Employee employee)
    {
        /*
        DataTable table = employee.WorkPeriods;
        var numOfRows = table.Rows.Count;
        double sumOfPeriods = 0;
        double doubleValue;
        double workPreiod;
        for (int i = 0; i < numOfRows; i++)
        {
            string cellValue = table.Rows[i][2].ToString();
            if (double.TryParse(cellValue, out doubleValue))
            {
                if (doubleValue < 0.3329)
                {
                    if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
                        sumOfPeriods += workPreiod;
                    else
                    {
                        throw new InvalidDataException("work period must be number");
                    }
                }
            }
            else
            {
                throw new InvalidDataException("work period must be number");
            }
        }
        return Math.Round(sumOfPeriods, 2);
        */
        return 3;
    }
    /// <summary>
    /// חלקיות משרה משוקללת
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double WeightedPartTimeJob(Employee employee)
    {
        //מתוך מסך 3, חלקיות משרה משוקללת מחושבת עבור תקופת עבודה של פחות מ-1/3 משרה
        return 1;
    }
    public static double NumberOfVacationDaysToBeRedeemed(BudgetPensionEmployee employee)
    {
        double days = employee.RemainingVacationDaysInRetirement;

        if (days < RemainingVacationDays + DateTime.Now.Month * 1.83)
        {
            return days;
        }
        return RemainingVacationDays + DateTime.Now.Month * 1.83;
    }

    /// <summary>
    /// ערך יום
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double ADaysWorth(BudgetPensionEmployee employee)
    {
        if (employee.IsFiveBusinessDays == true)
        {
            return employee.SalaryDetermines / AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs5Days;
        }

        return employee.SalaryDetermines / AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs6Days;
    }
    // --------------------------------חופשה-------------------------------
    /// <summary>
    /// מספר ימי חופשה לפדיון
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double NumberOfVacationDaysToBeRedeemed(Employee employee)
    {
        double days = employee.RemainingVacationDaysInRetirement;

        if (days < RemainingVacationDays + DateTime.Now.Month * 1.83)
        {
            return days;
        }
        return RemainingVacationDays + DateTime.Now.Month * 1.83;
    }

    /// <summary>
    /// ערך יום
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double ADaysWorth(Employee employee)
    {
        if (employee.IsFiveBusinessDays == true)
        {
            return employee.SalaryDetermines / AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs5Days;
        }

        return employee.SalaryDetermines / AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs6Days;
    }
    /// <summary>
    /// סה"כ פדיון ימי חופשה
    /// פונקציה חסרה
    /// מספר ימים לפדיון כפול ערך יום
    ///אם הצבירה היא מלאה, אז יש להכפיל בחלקיות משרה אחרונה
    /// </summary>
    /// <returns></returns>
    public static double TotalRedemptionOfVacationDays(Employee employee)
    {
        double redemption = NumberOfVacationDaysToBeRedeemed(employee) * ADaysWorth(employee);
        if (employee.IsAggregationByParts == false)
        {
            redemption *= employee.LastPartTimeJob; 
        }
        return redemption;
    }

   //-----------------------------פיצוי בגין ימי מחלה שלא נוצלו---------------------------------
   /// <summary>
   ///מבחינת גיל וותק- האם זכאי לפיצוי בכלל
   /// </summary>
   /// <param name="employee"></param>
   /// <returns></returns>
   public static bool IsEntitled(Employee employee)
    {
        bool flag = false;
        if (employee.Reason == Enums.RetirementReason.dismissal)
        {
            if(YearsOfWorkAtTheAuthority(employee) >= 3)
            {
                flag = true;
            }
        }
        else if(employee.Reason == Enums.RetirementReason.retirementForHealthReasons)
        {
            if(YearsOfWorkAtTheAuthority(employee) >= 5)
            {
                flag = true;
            }
        }
        else if (EmployeesAgeAtRetirement(employee) >= 50)
        {
            if(YearsOfWorkAtTheAuthority(employee) >= 10)
            {
                flag = true;
            }
        }
        return flag;
    }
    /// <summary>
    /// צבירת ימי מחלה
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double AccumulationOfSickDays(Employee employee)
    {
        double days = YearsOfWorkAtTheAuthority(employee) * SickDaysPerYear;
        if(employee.IsFullAccrual == false)
        {
            days *= AveragePartTimeJobDuringTheEntireWorkPeriod(employee);
        }
        return days;
    }
    /// <summary>
    /// ימי מחלה שנוצלו
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double SickDaysUsed(Employee employee)
    {
        return AccumulationOfSickDays(employee) - employee.RemainingSickDays;
    }
    /// <summary>
    /// אחוז ניצול
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double UtilizationPercentage(Employee employee)
    {
        return AccumulationOfSickDays(employee) - SickDaysUsed(employee);
    }
    /// <summary>
    /// ימים לפיצוי לכל 30 ימים שביתרה
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static int DaysForCompensationEvery30Days(Employee employee)
    {
        int days;
        if (UtilizationPercentage(employee) <= UtilizationPercentage35)
        {
            days = 8;
        }
        else if (UtilizationPercentage(employee) <= UtilizationPercentage65)
        {
            days = 6;
        }
        else days = 0;

        return days;
    }
    /// <summary>
    /// ימים לפדיון
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double DaysToMaturity(Employee employee)
    {
        return employee.RemainingSickDays / 30 * DaysForCompensationEvery30Days(employee);
    }
    /// <summary>
    /// משכורת קובעת כולל הבראה וביגוד
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double DeterminedSalaryIncludingRecoveryAndClothing(Employee employee)
    {
        return employee.SalaryDetermines + 1 / 12 * Clothing + 1 / 12 * Recovery;
    }
    /// <summary>
    /// ערך יום 
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double ADaysWorthOfSickness(Employee employee)
    {
        return DeterminedSalaryIncludingRecoveryAndClothing(employee) / WorthDayOfSickness;
    }
    //אחוז פיצוי- נמצא בקלאסים של פנסיה תקציבית וצוברת מכיון שמחושב באופן שונה
    //וגם סכום לתשלום - פיצוי בגין ימי מחלה שלא נוצלו

    //---------------------------------------- חלף הודעה מוקדמת-----------------------------------------------
    public static double TotalPaymentAdvanceNotice(Employee employee)
    {
        int months = 0;
        if(employee.AdvanceNotice == MonthOrTwoOrTree.month)
        {
            months = 1;
        }
        else if (employee.AdvanceNotice == MonthOrTwoOrTree.twoMonths)
        {
            months = 2;
        }
        else if (employee.AdvanceNotice == MonthOrTwoOrTree.treeMonths)
        {
            months = 3;
        }
        return months * DeterminedSalaryIncludingRecoveryAndClothing(employee);
    }
    //--------------------------------------הבראה------------------------------------------------
    /// <summary>
    /// קצובת ההבראה בגין שנה קודמת 
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double RecoveryForPreviousYear(Employee employee)
    {
        if (employee.IsMonthlyRecoveryPayment) 
        {
            return 0;
        }
        int month = (int)employee.RecoveryPaymentMonth;
        int currentMonth = employee.RetirementDate.Month;
        if (month < currentMonth) //אם עדיין לא שילמו לו 
        {
            return employee.NumberOfDaysOfRecoveryToBePaid * employee.PartTimeJobLastYear * Recovery;
        }
        return 0; // כבר שילמו 
    }
    /// <summary>
    /// הערה לעובד
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static string RecoveryNote(Employee employee)
    {
        int currentYear = employee.RetirementDate.Year;
        return $"הבראה בגין שנת הפרישה - {currentYear}, תשולם בשנת {currentYear + 1} בהתאם לחלקיות המשרה המשוקללת (חלקיות משרה בעבודה בפועל עד לחודש הפרישה, ולפי אחוז הקצבה ממועד הפרישה)";
    }

    //-----------------------------------פיצויים------------------------------------------
    /// <summary>
    /// פיצויים לתשלום
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double CompensationToBePaid(Employee employee)
    {
        return DeterminedSalaryIncludingRecoveryAndClothing(employee) * WorkingPeriodForCompensation(employee);
    }

    //------------------------------3 חודשי משכורת לשארים--------------------------------
    /// <summary>
    /// סכום לתשלום - 3 חודשי משכורת לשארים
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double TreeMonthsSalaryForHeirs(Employee employee)
    {
        return employee.SalaryDetermines * MonthsOfSalaryForHeirs;
    }
}

