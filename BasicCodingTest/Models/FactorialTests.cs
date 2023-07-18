using BasicCodingLibrary.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCodingTest.Models;

public class FactorialTests
{
    #region ***** Field *****
    private static IEnumerable<int[]> SourceProvider()
    {
        yield return new[] { 0, 1 };
        yield return new[] { 1, 1 };
        yield return new[] { 2, 2 };
        yield return new[] { 3, 6 };
        yield return new[] { 4, 24 };
        yield return new[] { 5, 120 };
        yield return new[] { 10, 3628800 };
    }
    #endregion

    #region ***** Test *****
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void FactorialTest(int n, int expectedFactorial)
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        var resultFactorial = Factorial.F(n);
        #endregion

        #region ***** Assert *****
        Assert.That(resultFactorial, Is.EqualTo(expectedFactorial));
        #endregion
    }

    [Test]
    public void FactorialArgumentExceptionTest()
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        #endregion

        #region ***** Assert *****
        Assert.Throws<ArgumentException>(() => Factorial.F(-1));
        #endregion
    }

    [Test]
    public void FactorialOverflowExceptionTest()
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        #endregion

        #region ***** Assert *****
        Assert.Throws<OverflowException>(() => Factorial.F(Factorial.nMaximum + 1));
        #endregion
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void FactorialRecursionTest(int n, int expectedFactorial)
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        var resultFactorial = Factorial.FactorialRecursion(n);
        #endregion

        #region ***** Assert *****
        Assert.That(resultFactorial, Is.EqualTo(expectedFactorial));
        #endregion
    }

    [TestCaseSource(nameof(SourceProvider))]
    public void FactorialIterationTest(int n, int expectedFactorial)
    {
        #region ***** Arrange *****
        #endregion

        #region ***** Act *****
        var resultFactorial = Factorial.FactorialIteration(n);
        #endregion

        #region ***** Assert *****
        Assert.That(resultFactorial, Is.EqualTo(expectedFactorial));
        #endregion
    }
    #endregion

}
