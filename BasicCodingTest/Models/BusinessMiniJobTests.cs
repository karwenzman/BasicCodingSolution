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
    public void EmployeeStatutoryPensionContributionExceptionTest(double grossSalary)
    {
        // ***** Arrange *****

        // ***** Act *****
        var result = Assert.Throws<ArgumentOutOfRangeException>(() => BusinessMiniJob.CalculateEmployeeStatutoryPensionContribution(grossSalary));

        // ***** Assert *****
        Assert.That(result.Message, Is.EqualTo("The argument must have a positive value! (Parameter 'grossSalary')"));
    }

    [TestCaseSource(nameof(SourceProviderException))]
    public void EmployerStatutoryPensionContributionExceptionTest(double grossSalary)
    {
        // ***** Arrange *****

        // ***** Act *****
        var result = Assert.Throws<ArgumentOutOfRangeException>(() => BusinessMiniJob.CalculateEmployerStatutoryPensionContribution(grossSalary));

        // ***** Assert *****
        Assert.That(result.Message, Is.EqualTo("The argument must have a positive value! (Parameter 'grossSalary')"));
    }

    [TestCaseSource(nameof(SourceProviderException))]
    public void EmployeeSalaryExceptionTest(double grossSalary)
    {
        // ***** Arrange *****

        // ***** Act *****
        var result = Assert.Throws<ArgumentOutOfRangeException>(() => BusinessMiniJob.CalculateEmployeeSalary(grossSalary));

        // ***** Assert *****
        Assert.That(result.Message, Is.EqualTo("The argument must have a positive value! (Parameter 'grossSalary')"));
        //Assert.Throws<ArgumentOutOfRangeException>(() => BusinessMiniJob.CalculateEmployeeSalary(grossSalary), "The parameter must have a positive value!");
        //Assert.That(() => Throws.TypeOf<ArgumentOutOfRangeException>().And.Property(nameof(grossSalary)).And.Message.Equals("The parameter must have a positive value!"));
    }


}
