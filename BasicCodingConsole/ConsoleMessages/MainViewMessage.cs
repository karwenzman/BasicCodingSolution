using System.Diagnostics;

namespace BasicCodingConsole.ConsoleMessages;

public class MainViewMessage : IMainViewMessage
{
    public MainViewMessage()
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(MainViewMessage)}>.");
    }

    public void ArgumentExceptionMessage(Exception e)
    {
        throw new NotImplementedException();
    }

    public void EndingAppMessage()
    {
        Console.WriteLine("Thank you, for using this application! Press ENTER to close the window.");
        Console.ReadLine();
    }

    public void EndingViewMessage()
    {
        Console.WriteLine("Press ENTER to continue.");
        Console.ReadLine();
    }

    public void OverflowExceptionMessage(Exception e)
    {
        throw new NotImplementedException();
    }

    public void StartingAppMessage()
    {
        Console.WriteLine("Welcome! Press ENTER to start the application.");
        Console.ReadLine();
    }

    public void StartingViewMessage()
    {
        throw new NotImplementedException();
    }

    public void UnhandledExceptionMessage(Exception e)
    {
        throw new NotImplementedException();
    }
}
