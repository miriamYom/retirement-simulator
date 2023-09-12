using BL.Enums;
using System.Data;

namespace BL.DTO;

public class BPEForSeniorSalary : BudgetPensionEmployee
{

    public DateTime TransitionDateForSeniorSalaries { get; set; }
    /// <summary>
    /// משכורת קובעת
    /// </summary>
    public double DeterminedSalaryByCollectiveAgreement { get; set; }

    /// <summary>
    /// יתרת ימי מחלה במועד המעבר לשכר בכירים
    /// </summary>
    public int RemainingSickDaysAtTheTimeOfTransitionToSeniorSalary { get; set; }


    /*
    private DataTable workPriodsForSeniorSalary;

    public DataTable WorkPriodsForSeniorSalary
    {
        get { return workPriodsForSeniorSalary; }
        set { workPriodsForSeniorSalary = value; }
    }
    */

    /*
     *  לכאורה כל הנ"ל זה חישובים שיחזרו מפונקציות 
    /// <summary>
    /// נתון שיואתחל מהטבלה
    /// </summary>
    //public double YersInSeniorSalary { get; set; }
    //public double YersInACollectiveAgreement { get; set; }
    */
}

