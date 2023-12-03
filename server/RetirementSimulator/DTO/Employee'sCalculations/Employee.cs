using BL.Enums;
using BL.PensionServices;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace BL.DTO;

public class Employee
{
    public Employee()
    {
       
    }

    public virtual object Calculates()
    {
        PensionService.CurrentEmployee = this;

        bool flag = false;
        string json = "{";
        //object[] param = { this };
        foreach (var methodInfo in typeof(PensionService).GetMethods(BindingFlags.Static | BindingFlags.Public))
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
    public string Name { get; set; }
    public int ID { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime StartWorkDate { get; set; }
    /// <summary>
    /// תאריך פרישה צפוי
    /// </summary>
    public DateTime RetirementDate { get; set; }
    /// <summary>
    /// סוג הפרישה
    /// </summary>
    
    private RetirementReason reason;
    public RetirementReason Reason
    {
        get { return reason; }
        set { reason = (RetirementReason)Enum.Parse(typeof(RetirementReason), value.ToString()); }
    }
    

    /// <summary>
    /// בפיטורין
    /// חלף הודעה מוקדמת
    /// </summary>
    
    private MonthOrTwoOrTree advanceNotice;
    public MonthOrTwoOrTree AdvanceNotice
    {
        get { return advanceNotice; }
        set { advanceNotice = (MonthOrTwoOrTree)Enum.Parse(typeof(MonthOrTwoOrTree), value.ToString()); }
    }
    

    //ביגוד
    /// <summary>
    ///  זכאות העובד לביגוד
    ///   ביגוד למקבלי קהל או ביגוד לפועלים
    /// </summary>

    public bool IsClothingForAudienceMembers { get; set; }
    /// <summary>
    /// אופן תשלום הביגוד
    /// monthly / yearly
    /// </summary>
    public bool IsMonthlyClothingPayment { get; set; }

    /// <summary>
    /// רמת הביגוד
    /// רמה 3 או רמה 4
    /// </summary>
    public bool IsThreeLevel { get; set; }
    /// <summary>
    /// חודש תשלום הביגוד
    /// </summary>
    
    private Months monthOfClothingPayment;
    public Months MonthOfClothingPayment
    {
        get { return monthOfClothingPayment; }
        set { monthOfClothingPayment = (Months)Enum.Parse(typeof(Months), value.ToString()); }
    }

    /// <summary>
    /// השנה עבורה משולם הביגוד
    /// שנה נוכחית או שנה קנדרית קודמת
    /// </summary>
    public bool IsCurrentYear { get; set; }
    //הבראה
    /// <summary>
    /// monthly / yearly
    /// </summary>
    public bool IsMonthlyRecoveryPayment { get; set; }
    /// <summary>
    /// מספר ימי הבראה לתשלום
    /// </summary>
    
    private int numberOfDaysOfRecoveryToBePaid;
    public int NumberOfDaysOfRecoveryToBePaid
    {
        get { return numberOfDaysOfRecoveryToBePaid; }
        set
        {
            if (value > 13 || value < 8)
            {
                throw new InvalidParameterException("The number of recovery days to be paid must be between 8 and 13.");
            }
            numberOfDaysOfRecoveryToBePaid = value;
        }
    }
    
    
    private Months recoveryPaymentMonth;

    public Months RecoveryPaymentMonth
    {
        get { return recoveryPaymentMonth; }
        set { recoveryPaymentMonth = (Months)Enum.Parse(typeof(Months), value.ToString()); } 
    }


    /// <summary>
    /// תקופות עבודה- טבלה בעלת 4 עמודות-
    /// תאריך תחילת עבודה, תאריך סיום עבודה, סה"כ תקופת עבודה וחלקיות משרה  
    /// </summary>
     private DataTable workPeriods;

     public DataTable WorkPeriods
     {
         get { return workPeriods; }
         set { workPeriods = value; }//.ToDataTable(); }
     }
    /// <summary>
    /// חלקיות משרה אחרונה
    ///לשלוף נתון זה מהשורה האחרונה בטבלה
    ///אולי כדאי לעשות זאת בריאקט
    /// </summary>
    public double LastPartTimeJob { get; set; }
    /// <summary>
    /// חלקיות משרה בשנה הנוכחית
    /// </summary>
    public int PartTimeJobCurrentYear { get; set; }
    /// <summary>
    /// חלקיות משרה בשנה קודמת
    /// </summary>
    public int PartTimeJobLastYear { get; set; }
    public double SalaryDetermines { get; set; }
    /// <summary>
    /// יתרת ימי מחלה 
    /// </summary>
    public int RemainingSickDays { get; set; }
    /// <summary>
    /// אופן צבירת המחלה - צבירה מלאה / צבירה לפי חלקיות
    /// Full accrual / partial accrual
    /// </summary>
    public bool IsFullAccrual { get; set; }
    /// <summary>
    /// יתרת ימי חופשה בפרישה
    /// </summary>
    public int RemainingVacationDaysInRetirement { get; set; }
    /// <summary>
    /// מספר ימי העסקה בשבוע
    ///Number of business days per week
    /// 6 or 5
    /// </summary>
    public bool IsFiveBusinessDays { get; set; }
    /// <summary>
    /// אופן צבירת החופשה- צבירה מלאה  - ללא קשר לחלקיות / צבירה לפי חלקיות
    /// How the vacation is accrued
    /// </summary>
    public bool IsAggregationByParts { get; set; }
}
