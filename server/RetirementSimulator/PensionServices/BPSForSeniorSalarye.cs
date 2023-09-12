using BL.DTO;
using static BL.PensionServices.Consts;

namespace BL.PensionServices;

/// <summary>
/// Budget Pension Service for Senior salary
/// </summary>
internal class BPSForSeniorSalarye : BudgetPensionService
{
    public BPSForSeniorSalarye()
    {
    }

    public static double WorkingPeriodInACollectiveAgreement(BPEForSeniorSalary employee)
    {
        return TotalYears(employee.StartWorkDate, employee.TransitionDateForSeniorSalaries);
    }

    public static double SeniorPaidWorkPeriod(BPEForSeniorSalary employee)
    {
        return TotalYears(employee.TransitionDateForSeniorSalaries, employee.RetirementDate);
    }

    public static double AnnuityPercentageInACollectiveAgreement(BPEForSeniorSalary employee)
    {
        return (WorkingPeriodInACollectiveAgreement(employee) * AnnualAnnuityPercentage);
    }

    public static double PensionPercentageInSeniorSalaries(BPEForSeniorSalary employee)
    {
        return SeniorPaidWorkPeriod(employee) * AnnualAnnuityPercentage;
    }

    public static double AllowanceAmount(BPEForSeniorSalary employee)
    {
        return (employee.SalaryDetermines * AnnuityPercentageInACollectiveAgreement(employee)) + (employee.DeterminedSalaryByCollectiveAgreement * PensionPercentageInSeniorSalaries(employee));
    }

    public static double CostOfLivingAllowance(BPEForSeniorSalary employee)
    {
        return (employee.SalaryDetermines * AnnuityPercentageInACollectiveAgreement(employee) * CostOfLiving);
    }


}
