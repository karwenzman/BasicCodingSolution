namespace BasicCodingLibrary.Models;

public static class Factorial
{
    /// <summary>
    /// Since there is a limit to n, this limit is stored here.
    /// </summary>
    public const int nMaximum = 20;

    /// <summary>
    /// This method is calculating the factorial of n.
    /// In this algorithm n is limited to the maximum value of 20.
    /// <para>
    /// <br></br>The pattern used is: <b>recursion</b>
    /// <br></br>+ if n &lt; 0 an exception is thrown
    /// <br></br>+ if n &gt; 20 an exception is thrown
    /// </para>
    /// </summary>
    /// <param name="n"></param>
    /// <returns>The result of n! is returned.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="OverflowException"></exception>
    public static ulong F(int n)
    {
        return FactorialRecursion(n);
    }
    /// <summary>
    /// This method is calculating the factorial of n.
    /// In this algorithm n is limited to the maximum value of 20.
    /// <para>
    /// <br></br>The pattern used is: <b>recursion</b>
    /// <br></br>+ if n &lt; 0 an exception is thrown
    /// <br></br>+ if n &gt; 20 an exception is thrown
    /// </para>
    /// </summary>
    /// <param name="n"></param>
    /// <returns>The result of n! is returned.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="OverflowException"></exception>
    public static ulong FactorialRecursion(int n)
    {
        //return f == 0 ? 1 : f * FactorialRecursion(f - 1);

        if (n < 0)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FactorialRecursion)}>. " +
                $"n can not be negative!";
            throw new ArgumentException(message);
        }
        else if (n == 0)
        {
            return 1;
        }
        else if (n > nMaximum)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FactorialRecursion)}>. " +
                $"n is out of range!";
            throw new OverflowException(message);
        }
        else
        {
            return (ulong)n * FactorialRecursion(n - 1);
        }
    }

    /// <summary>
    /// This method is calculating the factorial of n.
    /// In this algorithm n is limited to the maximum value of 20.
    /// <para>
    /// <br></br>The pattern used is: <b>iteration</b>
    /// <br></br>+ if n &lt; 0 an exception is thrown
    /// <br></br>+ if n &gt; 20 an exception is thrown
    /// </para>
    /// </summary>
    /// <param name="n"></param>
    /// <returns>The result of n! is returned.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="OverflowException"></exception>
    public static ulong FactorialIteration(int n)
    {
        if (n < 0)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FactorialIteration)}>. " +
                $"n can not be negative!";
            throw new ArgumentException(message);
        }
        else if (n == 0)
        {
            return 1;
        }
        else if (n > nMaximum)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FactorialIteration)}>. " +
                $"n is out of range!";
            throw new OverflowException(message);
        }

        ulong value = 1;

        for (int i = 1; i < n + 1; i++)
        {
            value *= (ulong)i;
        }
        return value;
    }

    /// <summary>
    /// This method is calculating the factorial of n.
    /// In this algorithm n is limited to the maximum value of 12.
    /// <para>
    /// <br></br>The pattern used is: <b>linq</b>
    /// <br></br>+ if n &lt; 0 an exception is thrown
    /// <br></br>+ if n &gt; 12 an exception is thrown
    /// </para>
    /// </summary>
    /// <param name="n"></param>
    /// <returns>The result of n! is returned.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="OverflowException"></exception>
    public static ulong FactorialLinq(int n)
    {
        if (n < 0)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FactorialLinq)}>. " +
                $"n can not be negative!";
            throw new ArgumentException(message);
        }
        else if (n > 12)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FactorialLinq)}>. " +
                $"n is out of range!";
            throw new OverflowException(message);
        }

        return (ulong)Enumerable.Range(1, n).Aggregate(1, (p, item) => p * item);
    }
}
