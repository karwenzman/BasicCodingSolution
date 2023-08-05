using PaperDelieveryLibrary.Models;

namespace BasicCodingTest.Models;

public class PaperDeliveryContractTests
{
    private static IEnumerable<double[]> SourceProvider()
    {
        yield return new[] { 1.0, 0.0, 0.0, 12.00 };
        yield return new[] { 1.0, 30.0, 0.0, 18.00 };
        yield return new[] { 0.0, 45.0, 0.0, 9.00 };
        yield return new[] { 0.0, 30.0, 0.0, 6.00 };
        yield return new[] { 1.0, 58.0, 0.0, 23.60 };
    }

    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void PropertyWageCalculationTest(double hour, double minute, double second, double expectedWage)
    {
        // ***** Arrange *****
        PaperDeliveryContract contract = new()
        {
            HourlyWageRate = 12.00,
            StandardizedWorkingHours = new TimeOnly((int)hour, (int)minute, (int)second)
        };

        // ***** Act *****

        // ***** Assert *****
        Assert.That(contract.Wage, Is.EqualTo(expectedWage));
    }
}
