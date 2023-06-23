using BasicCodingLibrary.Models;

namespace BasicCodingTest.Models;

/// <summary>
/// This class is hosting the unit tests for members in <see cref="Fibonacci"/>.
/// </summary>
public class FibonacciTests
{
    #region ***** Field *****
    private static IEnumerable<int[]> SourceProvider()
    {
        yield return new[] { 0, 0 };
        yield return new[] { 1, 1 };
        yield return new[] { 2, 1 };
        yield return new[] { 3, 2 };
        yield return new[] { 4, 3 };
        yield return new[] { 5, 5 };
        yield return new[] { 10, 55 };
    }
    #endregion

    #region ***** Test *****
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void FibonacciTest(int n, int expectedFibonacci)
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        var resultFibonacci = Fibonacci.F(n);
        #endregion

        #region ***** Assert *****
        Assert.That(resultFibonacci, Is.EqualTo(expectedFibonacci));
        #endregion
    }

    [Test]
    public void FibonacciArgumentExceptionTest()
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        #endregion

        #region ***** Assert *****
        Assert.Throws<ArgumentException>(() => Fibonacci.F(-1));
        #endregion
    }

    [Test]
    public void FibonacciOverflowExceptionTest()
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        #endregion

        #region ***** Assert *****
        Assert.Throws<OverflowException>(() => Fibonacci.F(Fibonacci.nMaximum + 1));
        #endregion
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void FibonacciRecursionTest(int n, int expectedFibonacci)
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        var resultFibonacci = Fibonacci.FibonacciRecursion(n);
        #endregion

        #region ***** Assert *****
        Assert.That(resultFibonacci, Is.EqualTo(expectedFibonacci));
        #endregion
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void FibonacciIterationTest(int n, int expectedFibonacci)
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        var resultFibonacci = Fibonacci.FibonacciIteration(n);
        #endregion

        #region ***** Assert *****
        Assert.That(resultFibonacci, Is.EqualTo(expectedFibonacci));
        #endregion
    }
    #endregion
}
