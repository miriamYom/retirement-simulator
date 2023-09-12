using BL.Enums;
using BL.PensionServices;
using System.Reflection;

namespace BL.DTO;

public class BudgetPensionEmployee : Employee
{
    public BudgetPensionEmployee()
    {

    }
    public override string Clculates()
    {
        bool flag = false;
        string json = "{";
        object[] param = { this };
        foreach (var methodInfo in typeof(BudgetPensionService).GetMethods(BindingFlags.Static | BindingFlags.Public))
        {
            var result = methodInfo.Invoke(null, param);
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
    /// <summary>
    /// משכורת קובעת בגיל 60
    /// Determined salary
    /// </summary>
    public double SalaryDeterminesAtAge60 { get; set; }
    /// <summary>
    /// האם חתם על רציפות זכויות
    /// </summary>ly TransitionDateForSeniorSalaries { get; set; }
    public bool SignedCopyrightContinuity { get; set; }
    /// <summary>
    /// אם חתם על רציפות זכויות:
    /// </summary>
    private TheSignedOwnership ownership;
    public TheSignedOwnership Ownership
    {
        get { return ownership; }
        set { ownership = (TheSignedOwnership)Enum.Parse(typeof(TheSignedOwnership), value.ToString()); }
    }

    /// <summary>
    /// האם בחוזה העסקה נקבע כי פדיון ימי המחלה ישולם לפי משכורת אחרונה?
    /// Does the employment contract stipulate that sick pay will be paid according to the last salary?
    /// </summary>
    public bool IsSickDayPaidAccordingToLastSalary { get; set; }

    /// <summary>
    /// מתוך המשכורת הקובעת, סך תוספות השכר הפנסיוניות שאינן מחושבות לפנסיה התקציבית
    /// nullable
    /// From the determining salary, the total pensionable salary increases that are not calculated for the budget pension
    /// </summary>
    public double SalaryIncreasesThatAreNotCalculated { get; set; }


    /// <summary>
    /// אם נבחר המדינה \ הרשות המקומית \צה"ל \ כוחות בטחון
    /// <summary>
    private double percentagePensionFromPreviousWorkplace;
    public double PercentagePensionFromPreviousWorkplace
    {
        get { return percentagePensionFromPreviousWorkplace; }// PercentagePensionFromPreviousWorkplace; }
        set
        {
            if (value > 70)
            {
                throw new InvalidParameterException("Pension percentage from the previous workplace cannot be more than 70%.");
            }
            if (value < 0)
            {
                throw new InvalidParameterException("Pension percentage from the previous workplace cannot be less than 0.");
            }
            percentagePensionFromPreviousWorkplace = value;
        }
    }
    /// <summary>
    /// אם נבחר צה"ל / כוחות בטחון
    /// השכר קובע את הפנסיה בצה"ל:
    /// </summary>
    public double SalaryDeterminesPensionInIDF { get; set; }

    /// <summary>
    /// אם בחרו קרנות ותיקות:
    /// סכום הקצבה
    /// </summary>
    public double AmountOfAllowance { get; set; }
    /// <summary>
    /// אחוזי נכות- רק אם פורש מסיבות רפואיות
    /// </summary>
    public double DisabilityPercentages { get; set; }


    private FamilyStatus familyStatus;
    public FamilyStatus FamilyStatus
    {
        get { return familyStatus; }
        set { familyStatus = (FamilyStatus)Enum.Parse(typeof(FamilyStatus), value.ToString()); }
    }





}
