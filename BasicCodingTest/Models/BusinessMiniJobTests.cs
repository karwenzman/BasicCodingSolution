using PaperDeliveryLibrary.Models;

namespace BasicCodingTest.Models;

public class BusinessMiniJobTests
{
    private static IEnumerable<double[]> SourceProvider()
    {
        // GrossSalary, Salary, EmployeeStatutoryPensionContribution, EmployerStatutoryPensionContribution
        yield return new[] { 175.00, 168.70, 6.30, 26.25 };
        yield return new[] { 150.00, 139.95, 10.05, 22.50 };
        yield return new[] { 25.00, -3.80, 28.80, 3.75 };
    }

    private static IEnumerable<double> SourceProviderException()
    {
        // GrossSalary
        yield return 0.0;
        yield return -10.0;
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void EmployeeStatutoryPensionContributionTest(double grossSalary, double salary, double employeeContribution, double employerContribution)
    {
        // ***** Arrange *****

        // ***** Act *****
        var result = BusinessMiniJob.CalculateEmployeeStatutoryPensionContribution(grossSalary);

        // ***** Assert *****
        Assert.That(result.ToString("c2"), Is.EqualTo(employeeContribution.ToString("c2")));
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void EmployerStatutoryPensionContributionTest(double grossSalary, double salary, double employeeContribution, double employerContribution)
    {
        // ***** Arrange *****

        // ***** Act *****
        var result = BusinessMiniJob.CalculateEmployerStatutoryPensionContribution(grossSalary);

        // ***** Assert *****
        Assert.That(result.ToString("c2"), Is.EqualTo(employerContribution.ToString("c2")));
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void EmployeeSalaryTest(double grossSalary, double salary, double employeeContribution, double employerContribution)
    {
        // ***** Arrange *****

        // ***** Act *****
        var result = BusinessMiniJob.CalculateEmployeeSalary(grossSalary);

        // ***** Assert *****
        Assert.That(result.ToString("c2"), Is.EqualTo(salary.ToString("c2")));
    }

    [TestCaseSource(nameof(SourceProviderException))]
    public void EmployeeStatutoryPensionContributionTest_ThrowsException(double grossSalary)
    {
        // ***** Arrange *****

        // ***** Act & Assert *****
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            BusinessMiniJob.CalculateEmployeeStatutoryPensionContribution(grossSalary);
        }, "The argument must have a positive value!");
    }

    [TestCaseSource(nameof(SourceProviderException))]
    public void EmployerStatutoryPensionContributionTest_ThrowsException(double grossSalary)
    {
        // ***** Arrange *****

        // ***** Act & Assert *****
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            BusinessMiniJob.CalculateEmployerStatutoryPensionContribution(grossSalary);
        }, "The argument must have a positive value!");
    }

    [TestCaseSource(nameof(SourceProviderException))]
    public void EmployeeSalaryTest_ThrowsException(double grossSalary)
    {
        // ***** Arrange *****

        // ***** Act & Assert *****
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            BusinessMiniJob.CalculateEmployeeSalary(grossSalary);
        }, "The argument must have a positive value!");
    }
}
