

using DL.Tables;
using System.Data;
using BL.PensionServices;
using BL.DTO;

namespace RetirementSimulatorTest;

[TestClass]
public class BudgetPensionServiceTests
{
    [TestMethod]
    public void TestMethod1()
    {
        BudgetPensionService service = new BudgetPensionService();
        BudgetPensionEmployee employee = new BudgetPensionEmployee();
        employee.IsMonthlyClothingPayment = false;
        employee.MonthOfClothingPayment = BL.Enums.Months.March;
        //DataTable table = ReadFromExcel.RaedToTable("S:/exel/e1.csv");
        //DataTable table2 = ReadFromExcel.RaedToTable("S:/exel/e2.csv");

        var actual = BudgetPensionService.ClothingForCurrentYear(employee);
        Assert.AreEqual(actual, 3);
        //Assert.AreSame(table2, actual);
    }

}