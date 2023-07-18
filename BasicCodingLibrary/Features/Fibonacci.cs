namespace BasicCodingLibrary.Features;

public static class Fibonacci
{
    /// <summary>
    /// Since there is a limit to n, this limit is stored here.
    /// </summary>
    public const int nMaximum = 20;

    /// <summary>
    /// This method is calculating the fibonacci of n.
    /// In this algorithm n is limited to the maximum value of 20.
    /// And it is calling the method FibonacciIteration. That will be changed later.
    /// <para>
    /// <br></br>The pattern used is: <b>iteration</b>
    /// <br></br>+ if n &lt; 0 an exception is thrown
    /// <br></br>+ if n &gt; 20 an exception is thrown
    /// </para>
    /// </summary>
    /// <param name="n"></param>
    /// <returns>The result of F(n) is returned.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="OverflowException"></exception>
    public static int F(int n)
    {
        return FibonacciIteration(n);
    }

    /// <summary>
    /// This method is calculating the fibonacci of n.
    /// In this algorithm n is limited to the maximum value of 20.
    /// <para>
    /// <br></br>The pattern used is: <b>iteration</b>
    /// <br></br>+ if n &lt; 0 an exception is thrown
    /// <br></br>+ if n &gt; 20 an exception is thrown
    /// </para>
    /// </summary>
    /// <param name="n"></param>
    /// <returns>The result of F(n) is returned.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="OverflowException"></exception>
    public static int FibonacciRecursion(int n)
    {
        if (n < 0)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FibonacciRecursion)}>. " +
                $"n can not be negative!";
            throw new ArgumentException(message);
        }
        else if (n == 0)
        {
            return 0;
        }
        else if (n == 1)
        {
            return 1;
        }
        else if (n > nMaximum)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FibonacciRecursion)}>. " +
                $"n is out of range!";
            throw new OverflowException(message);
        }

        return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
    }

    /// <summary>
    /// This method is calculating the fibonacci of n.
    /// In this algorithm n is limited to the maximum value of 20.
    /// <para>
    /// <br></br>The pattern used is: <b>iteration</b>
    /// <br></br>+ if n &lt; 0 an exception is thrown
    /// <br></br>+ if n &gt; 20 an exception is thrown
    /// </para>
    /// </summary>
    /// <param name="n"></param>
    /// <returns>The result of F(n) is returned.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="OverflowException"></exception>
    public static int FibonacciIteration(int n)
    {
        if (n < 0)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FibonacciIteration)}>. " +
                $"n can not be negative!";
            throw new ArgumentException(message);
        }
        else if (n == 0)
        {
            return 0;
        }
        else if (n == 1)
        {
            return 1;
        }
        else if (n > nMaximum)
        {
            string message = $"f({n,2:00}) Exception in method <{nameof(FibonacciIteration)}>. " +
                $"n is out of range!";
            throw new OverflowException(message);
        }

        int value = 0;
        int valueA = 1;
        int valueB = 0;

        for (int counter = 2; counter < n + 1; counter++)
        {
            value = valueA + valueB;
            valueB = valueA;
            valueA = value;
        }

        return value;
    }
}
