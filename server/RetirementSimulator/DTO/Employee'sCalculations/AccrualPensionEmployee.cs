using BL.Enums;

namespace BL.DTO;

internal class AccrualPensionEmployee : Employee
{
    /// <summary>
    /// אחוז הפרשה לפיצויים
    /// Percentage provision for compensation
    /// 6% or 8.33%
    /// </summary>
    private PercentageProvisionForCompensation percentageProvisionForCompensation;
    public PercentageProvisionForCompensation PercentageProvisionForCompensation
    {
        get { return percentageProvisionForCompensation; }
        set { percentageProvisionForCompensation = (PercentageProvisionForCompensation)Enum.Parse(typeof(PercentageProvisionForCompensation), value.ToString()); }
    }
    /// <summary>
    /// יתרת פיצויים בקופה
    /// </summary>
    public double CompensationBalanceInTheCashRegister { get; set; }
    /// <summary>
    /// רק אם הזינו שיעור הפרשה של 8.33%
    /// חתימה על סעיף 14 לחוק פיצויי הפיטורין ? 
    /// </summary>
    public bool SigningTheSeveranceCompensationLaw { get; set; }
}

