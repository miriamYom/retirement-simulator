using BL.DTO;
using BL.Enums;
using DL.Tables;
using System.Runtime.ConstrainedExecution;
using static BL.PensionServices.Consts;

namespace BL.PensionServices;

public class BudgetPensionService : PensionService
//תקציבית
{
    public BudgetPensionService()
    {
    }

    //    /// <summary>
    //    /// משכורת קובעת לפנסיה תקציבית למשרה מלאה
    //    /// </summary>
    //    /// <returns></returns>
    //    public static double SalaryDetermines(BudgetPensionEmployee employee)
    //    {
    //      /*  if (employee.SignedCopyrightContinuity)
    //        {
    //            if (employee.Ownership == TheSignedOwnership.IDFSecurityForces ||
    //                employee.Ownership == TheSignedOwnership.theStateOrLocalAuthority)
    //            {
    //                return employee.SalaryDeterminesPensionInIDF > employee.SalaryDetermines ?
    //                    employee.SalaryDeterminesPensionInIDF : employee.SalaryDetermines;
    //            }
    //        }*/
    //        return employee.SalaryDetermines;
    //    }
    //    /// <summary>
    //    /// רלוונטי אם חתם על הסכם רציפות זכויות עם המדינה או רשות מקומית או אם צה"ל 
    //    ///  הפונקציה מחזירה את המשכורת הגבוהה יותר- או בצהל או ברשות
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double HigherSalaryDetermines(BudgetPensionEmployee employee)
    //    {
    //        if (employee.SignedCopyrightContinuity)
    //        {
    //            if (employee.Ownership == TheSignedOwnership.IDFSecurityForces ||
    //                employee.Ownership == TheSignedOwnership.theStateOrLocalAuthority)
    //            {
    //                return employee.SalaryDeterminesPensionInIDF > employee.SalaryDetermines ?
    //                    employee.SalaryDeterminesPensionInIDF : employee.SalaryDetermines;
    //            }
    //        }
    //        return employee.SalaryDetermines;
    //    }
    //    /// <summary>
    //    /// get data table with start date, end date and part time job and calculate the work periods.
    //    /// </summary>
    //    /// <returns> data table with the calculated column</returns>
    //    //למה כל החישובים של התקופות עבודה נמצאים כאן? ולא באמפלויי רגיל?
    //    //חלק העברתי לאמפלויי רגיל כי נדרשתי אליהם
    //    public static void TotalWorkPeriods(BudgetPensionEmployee employee)
    //    {
    //        //שהפונקציה תעדכן את הטבלה (שנמצאת בפרופרטיז של האמפלויי), אין צורך בהחזרתה
    //        //DataTable table = employee.WorkPeriods;

    //        //try
    //        //{
    //        //    datacolumn column = table.columns.add("total work period", typeof(double));
    //        //    //column.allowdbnull = false;

    //        //    var numofrows = table.rows.count;
    //        //    for (int i = 0; i < numofrows; i++)
    //        //    {
    //        //        var totalworkperiod = workperiod(table.rows[i][0].tostring(), table.rows[i][1].tostring());
    //        //        table.rows[i][3] = math.round(totalworkperiod, 2);
    //        //    }
    //        //}
    //        //catch (exception ex) { }
    //        //employee.workperiods = table;

    //        //return table;

    //    }

    //    /// <summary>
    //    /// calculate the total periods of work at the authority
    //    /// </summary>
    //    /// <returns>sum of work periods work</returns>
    //    /// <exception cref="InvalidDataException">if the value in the table is not a number</exception>
    //    public static double TotalPeriodAtTheAuthority(BudgetPensionEmployee employee)
    //    {
    //        /*
    //        var numOfRows = table.Rows.Count;
    //        double sumOfWorkPeriods = 0;

    //        for (int i = 0; i < numOfRows; i++)
    //        {
    //            double doubleValue;
    //            string? cellValue = table?.Rows[i][3].ToString();
    //            if (double.TryParse(cellValue, out doubleValue))
    //            {
    //                sumOfWorkPeriods += doubleValue;
    //            }
    //            else
    //            {
    //                throw new InvalidDataException("work period must be number");
    //            }
    //        }
    //        return Math.Round(sumOfWorkPeriods, 2);
    //        */
    //        return 0;
    //    }

    //    /// <summary>
    //    /// function to calculate full work period according to partiality
    //    /// </summary>
    //    /// <param name="totalWorkPeriod"> work period in current job</param>
    //    /// <param name="partTimeJob">part time job</param>
    //    /// <returns></returns>
    //    public static void FullWorkPeriodAccordingToPartiality(BudgetPensionEmployee employee)
    //    {
    //        //שהפונקציה תעדכן את הטבלה (שנמצאת בפרופרטיז של האמפלויי), אין צורך בהחזרתה
    //    }

    //    /// <summary>
    //    /// calculate the work periods that accruals to pension
    //    /// The years of work must be added up according to whether the employee worked 1/3 of a job or more
    //    /// </summary>
    //    /// <returns>Total working period for retirement</returns>
    //    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    //    public static double TotalWorkingPeriodForRetirement(BudgetPensionEmployee employee)
    //    {
    //        /*
    //        DataTable table = employee.WorkPeriods;
    //        var numOfRows = table.Rows.Count;
    //        double sumOfPeriods = 0;
    //        double doubleValue;
    //        double workPreiod;
    //        for (int i = 0; i < numOfRows; i++)
    //        {
    //            string cellValue = table.Rows[i][2].ToString();
    //            if (double.TryParse(cellValue, out doubleValue))
    //            {
    //                if (doubleValue >= 0.3329)
    //                {
    //                    if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
    //                        sumOfPeriods += workPreiod;
    //                    else
    //                    {
    //                        throw new InvalidDataException("work period must be number");
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                throw new InvalidDataException("work period must be number");
    //            }
    //        }
    //        return Math.Round(sumOfPeriods, 2);
    //        */
    //        return 1;
    //    }

    //    /// <summary>
    //    /// Calculation of the periods in which the employee did not work at all
    //    /// </summary>
    //    /// <returns>The total number of periods in which the employee was on unpaid vacation</returns>
    //    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    //    public static double UnpaidVacation(BudgetPensionEmployee employee)
    //    {
    //        /*
    //        DataTable table = employee.WorkPeriods;
    //        var numOfRows = table.Rows.Count;
    //        double sumOfPeriods = 0;
    //        double doubleValue;
    //        double workPreiod;
    //        for (int i = 0; i < numOfRows; i++)
    //        {
    //            string cellValue = table.Rows[i][2].ToString();
    //            if (double.TryParse(cellValue, out doubleValue))
    //            {
    //                if (doubleValue == 0)
    //                {
    //                    if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
    //                        sumOfPeriods += workPreiod;
    //                    else
    //                    {
    //                        throw new InvalidDataException("work period must be number");
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                throw new InvalidDataException("work period must be number");
    //            }
    //        }
    //        return Math.Round(sumOfPeriods, 2);
    //        */
    //        return 2;
    //    }

    //    /// <summary>
    //    /// Total period of work for which he is entitled to compensation
    //    /// </summary>
    //    /// <returns>The total work periods in which the employee worked less than 1/3 of a job</returns>
    //    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    //    public static double WorkingPeriodForCompensation(BudgetPensionEmployee employee)
    //    {
    //        /*
    //        DataTable table = employee.WorkPeriods;
    //        var numOfRows = table.Rows.Count;
    //        double sumOfPeriods = 0;
    //        double doubleValue;
    //        double workPreiod;
    //        for (int i = 0; i < numOfRows; i++)
    //        {
    //            string cellValue = table.Rows[i][2].ToString();
    //            if (double.TryParse(cellValue, out doubleValue))
    //            {
    //                if (doubleValue < 0.3329)
    //                {
    //                    if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
    //                        sumOfPeriods += workPreiod;
    //                    else
    //                    {
    //                        throw new InvalidDataException("work period must be number");
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                throw new InvalidDataException("work period must be number");
    //            }
    //        }
    //        return Math.Round(sumOfPeriods, 2);
    //        */
    //        return 3;
    //    }

    //    /// <summary>
    //    /// Calculation of the part-time job for pension - for periods of work from 1/3 of a job and above
    //    /// </summary>
    //    /// <returns> the Average part-time job for retirement</returns>
    //    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    //    /// 
    //    public static double AveragePartTimeJobForRetirement(BudgetPensionEmployee employee)
    //    {
    //        return 4;//AveragePartTimeJob(employee.WorkPeriods);
    //    }

    //    //public static double AveragePartTimeJob(BudgetPensionEmployee employee)
    //    //{
    //    //    return AveragePartTimeJob(employee.WorkPeriods);
    //    //}
    //    //protected static double AveragePartTimeJob(DataTable table)
    //    //{
    //    //    /*
    //    //    var numOfRows = table.Rows.Count;
    //    //    double sumOfPeriods = 0;
    //    //    double doubleValue;
    //    //    double workPreiod;
    //    //    for (int i = 0; i < numOfRows; i++)
    //    //    {
    //    //        string cellValue = table.Rows[i][2].ToString();
    //    //        if (double.TryParse(cellValue, out doubleValue))
    //    //        {
    //    //            if (doubleValue >= 0.3329)
    //    //            {
    //    //                if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
    //    //                    sumOfPeriods += workPreiod * doubleValue;
    //    //                else
    //    //                {
    //    //                    throw new InvalidDataException("work period must be number");
    //    //                }
    //    //            }
    //    //        }
    //    //        else
    //    //        {
    //    //            throw new InvalidDataException("work period must be number");
    //    //        }
    //    //    }
    //    //    return Math.Round(sumOfPeriods, 2);
    //    //    */
    //    //    return 5;
    //    //}

    //    //------------------------------------------------------------------------------------------------------------------------------------------------
    //    // Calculating the allowance
    //    // חישוב הקצבה



    //    ///// <summary>
    //    ///// A fixed salary for a full-time budget pension,
    //    ///// It will appear only in the case that you have entered a pension salary supplement amount that is not calculated for the budget pension.
    //    ///// The calculation: the total determining salary for a full-time position minus a pension supplement that does not constitute a basis for the budget pension.
    //    ///// </summary>
    //    ///// <param name="fixedSalaryForAFullTimePosition">Salary Determines At Age 60</param>
    //    ///// <param name="pensionSupplement">Salary Increases That Are Not Calculated</param>
    //    ///// <returns>A fixed salary for a full-time budget pension</returns>
    //    //public static double FixedSalaryForAFullTimePosition(BudgetPensionEmployee employee)
    //    //{
    //    //    // well done ...
    //    //    return 0;// fixedSalaryForAFullTimePosition - pensionSupplement;
    //    //}

    //    /// <summary>
    //    /// calculate the full pension percentage
    //    /// אחוז קצבה מלא
    //    /// </summary>
    //    /// <param name="yearsOfWork"> sum of years that the employee worked</param>
    //    /// <returns>full pension percentage</returns>
    //    public static double FullPensionPercentage(BudgetPensionEmployee employee) 
    //        => Math.Round(TotalWorkingPeriodForRetirement(employee) * AnnualAnnuityPercentage, 2);

    //    /// <summary>
    //    /// calculate the annuity percentage calculated
    //    /// אחוז קצבה מחושב
    //    /// </summary>
    //    /// <returns> annuity percentage calculated </returns>
    //    public static double AnnuityPercentageCalculated(BudgetPensionEmployee employee)
    //    {
    //        double annuity;

    //        annuity = FullPensionPercentage(employee) * AveragePartTimeJobForRetirement(employee);

    //        return annuity;
    //    }

    //    public static double TotalAllowancePercentage(BudgetPensionEmployee employee)
    //    {
    //        double allowance = 0;
    //        if (employee.SignedCopyrightContinuity)
    //        {
    //            if(employee.Ownership ==TheSignedOwnership.theStateOrLocalAuthority) { 
    //            allowance = 6;
    //            }
    //        }
    //        return allowance;
    //    }

    //    /// <summary>
    //    /// sum of the allowance
    //    /// </summary>
    //    /// <returns>sum of the allowance</returns>
    //    public static double AllowanceAmount(BudgetPensionEmployee employee) 
    //        => AnnuityPercentageCalculated(employee) * SalaryDetermines(employee);

    //    /// <summary>
    //    /// cost of living allowance
    //    /// תוספת יוקר
    //    /// </summary>
    //    /// <returns>cost of living allowance</returns>
    //    public static double CostOfLivingAllowance(BudgetPensionEmployee employee)
    //    {
    //        double allowance;

    //        if (SalaryDetermines(employee) < SalaryLimitedToCostIncrease)
    //        {
    //            allowance = Math.Round(SalaryDetermines(employee) * CostOfLiving, 2);
    //        }
    //        else allowance = Math.Round(AllowanceLimitedToCostOfLiving * CostOfLiving, 2);
    //        return allowance;
    //    }
    //    /// <summary>
    //    /// Total estimated allowance amount
    //    /// סה"כ סכום הקצבה המשוערת
    //    /// </summary>
    //    /// <returns>Total estimated allowance amount</returns>
    //    public static  double TotalEstimatedAllowanceAmount(BudgetPensionEmployee employee)
    //    {
    //        double allowance = CostOfLivingAllowance(employee) + AllowanceAmount(employee);
    //        if (employee.SignedCopyrightContinuity == true)
    //        {
    //            if (employee.Ownership == TheSignedOwnership.theStateOrLocalAuthority) // או רשות מקומית חתם עם המדינה
    //            {
    //                allowance += employee.PercentagePensionFromPreviousWorkplace * HigherSalaryDetermines(employee);
    //            }
    //            else if (employee.Ownership == TheSignedOwnership.IDFSecurityForces) //חתם עם צה"ל
    //            {
    //                allowance += AllowanceIsPaidFromTheIDFAndOrTheSecurityForces(employee);
    //            }


    //        }
    //        return allowance;
    //    }
    //    /// <summary>
    //    /// סכום הקצבה המשוערת לאחר התאמה ל-70%
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double TotalEstimatedAllowanceAmountLimitedTo70Percentage(BudgetPensionEmployee employee)
    //    {
    //        if(TotalEstimatedAllowanceAmount(employee) > SeventyPercent)
    //        {
    //            //employee.SalaryDetermines * 
    //        }
    //        return 0;
    //    }
    //    /// <summary>
    //    /// קצבה משולמת מצה"ל ו/או כוחות הביטחון
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double AllowanceIsPaidFromTheIDFAndOrTheSecurityForces(BudgetPensionEmployee employee)
    //    {
    //        return employee.SalaryDeterminesPensionInIDF * employee.PercentagePensionFromPreviousWorkplace;
    //    }
    //    //---------------------------------------מחלה
    //    /// <summary>
    //    /// אחוז פיצוי
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double CompensationPercentage(BudgetPensionEmployee employee)
    //    {
    //        int age = (int)EmployeesAgeAtRetirement();
    //        double percentage;
    //        if (employee.Reason == Enums.RetirementReason.death || employee.Reason == Enums.RetirementReason.retirementForHealthReasons)
    //        {
    //            percentage = 1; // 100% compensation
    //        }
    //        else if (IsEntitled(employee)) // if eligible in terms of age and seniority 
    //        {
    //            CompensationPercentagesForSickness compensationPercentages = new(); //singleton
    //            percentage = compensationPercentages.AgesAndPercentsBudgetePension[age] / 100;
    //        }
    //        else if (age >= 57)
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
    //    public static double AmountToBePaidCompensationForUnusedSickDays(BudgetPensionEmployee employee)
    //    {
    //        return ADaysWorthOfSickness(employee) * DaysToMaturity(employee) * CompensationPercentage(employee);
    //    }
    //    //-------------------------------מענק שנים עודפות-----------------------------------
    //    /// <summary>
    //    /// מענק שנים עודפות - בדיקת זכאות אחוז קצבה וגיל
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static bool IsEntitledToAGrant(BudgetPensionEmployee employee)
    //    {
    //        if(EmployeesAgeAtRetirement() >= AgeLimitForExcessYearsGrant && TotalEstimatedAllowanceAmount(employee) > 0.7)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //    /// <summary>
    //    /// כמות שנים עודפות
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double AmountOfExcessYears(BudgetPensionEmployee employee)
    //    {
    //        if (employee.SignedCopyrightContinuity)
    //        {
    //            if(employee.Ownership == TheSignedOwnership.IDFSecurityForces)
    //            {
    //                return (FullPensionPercentage(employee) - AllowanceLimitationForTheIDF) / 0.02;
    //            }
    //        }
    //        return (FullPensionPercentage(employee) - AllowanceLimitation) / 0.02;
    //    }

    //    /// <summary>
    //    /// סה"כ מענק שנים עודפות
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double TotalSurplusYearsGrant(BudgetPensionEmployee employee)
    //    {
    //        return AmountOfExcessYears(employee) * DeterminedSalaryIncludingRecoveryAndClothing(employee);
    //    }
    //    //-------------------------------מענק פרישה--------------------------------------
    //    /// <summary>
    //    /// האם זכאי למענק פרישה מבחינת גיל וסיבת פרישה פיטורין
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static bool IsEntitledToARetirementGrant(BudgetPensionEmployee employee)
    //    {
    //        return EmployeesAgeAtRetirement() <= 60 && employee.Reason == Enums.RetirementReason.dismissal;
    //    }
    //    /// <summary>
    //    /// אופציה א - משכורת לשנה
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double OptionASalaryForYear(BudgetPensionEmployee employee)
    //    {
    //        return DeterminedSalaryIncludingRecoveryAndClothing(employee) * AveragePartTimeJobDuringTheEntireWorkPeriod(employee) * Consts.Months;
    //    }
    //    /// <summary>
    //    /// אופציה ב' - חצי משכורת לשנת עבודה
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double OptionBHalfSalaryForAYearOfWork(BudgetPensionEmployee employee)
    //    {
    //        double years = YearsOfWorkAtTheAuthority(employee);
    //        if (years > 24)
    //        {
    //            years = 24;
    //        }
    //        return DeterminedSalaryIncludingRecoveryAndClothing(employee) * AveragePartTimeJobDuringTheEntireWorkPeriod(employee) * 0.5 * years;
    //    }
    //    /// <summary>
    //    /// אופציה ג - היוון קצבה
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double OptionCAnnuityCapitalization(BudgetPensionEmployee employee)
    //    {
    //        //משכורת צפויה בגיל 60
    //        double salaryAtAge60 = employee.SalaryDeterminesAtAge60 + (1/Consts.Months * Clothing) + (1/Consts.Months * Recovery);
    //        //שנים עד שהעובד יהיה בן 60
    //        double yearsUntilAge60 = Age60 - EmployeesAgeAtRetirement();
    //        //אחוז קיצבה צפוי לגיל 60, מוגבל ב70%
    //        double pensionPercentageAtAge60 = AnnuityPercentageCalculated(employee) * yearsUntilAge60 * 0.02 * AveragePartTimeJobDuringTheEntireWorkPeriod(employee);
    //        if(pensionPercentageAtAge60 > 0.7)
    //        {
    //            pensionPercentageAtAge60 = 0.7;
    //        }
    //        //חישוב הקיצבה בגיל 60
    //        double calculatingThePensionAtAge60 = salaryAtAge60 * pensionPercentageAtAge60;
    //        //הפרש קצבה לפורש
    //        double pensionDifferenceForRetiree = calculatingThePensionAtAge60 - TotalEstimatedAllowanceAmount(employee);
    //        //הפרש לשנה
    //        double differencePerYear = pensionDifferenceForRetiree * Consts.Months; // להכפיל במקדם;

    //        if(employee.FamilyStatus == FamilyStatus.ManHavePartner)
    //        {

    //        }
    //        return 0;
    //    }
    //    /// <summary>
    //    /// סה"כ סכום היוון קצבה 
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double TotalAllowanceCapitalizationAmount(BudgetPensionEmployee employee)
    //    {
    //        double capitalization = Math.Min(OptionASalaryForYear(employee), OptionBHalfSalaryForAYearOfWork(employee));
    //        return Math.Min(capitalization, OptionCAnnuityCapitalization(employee));
    //    }

    //    //---------------------------------------------ביגוד--------------------------------------------
    //    /// <summary>
    //    /// קצובת הביגוד בגין שנה נוכחית 
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double ClothingForCurrentYear(BudgetPensionEmployee employee)
    //    {
    //        if (employee.IsMonthlyClothingPayment)
    //        {
    //            return 0;
    //        }
    //        int month = (int)employee.MonthOfClothingPayment;
    //        int currentMonth = employee.RetirementDate.Month;
    //        if(month < currentMonth) //אם עדיין לא שילמו לו השנה
    //        {
    //            return employee.IsThreeLevel ? employee.PartTimeJobCurrentYear * Level3Clothing :
    //                employee.PartTimeJobCurrentYear * Level4Clothing;
    //        }
    //        return 0; // כבר שילמו השנה

    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <returns></returns>
    //    public static double ClothingForLastYear(BudgetPensionEmployee employee)
    //    {
    //        if (employee.IsMonthlyClothingPayment)
    //        {
    //            return 0;
    //        }
    //        return employee.IsThreeLevel ? employee.PartTimeJobLastYear * Level3Clothing :
    //                employee.PartTimeJobLastYear * Level4Clothing;
    //    }

}
