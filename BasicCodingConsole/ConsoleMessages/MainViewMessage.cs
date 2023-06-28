namespace BasicCodingConsole.ConsoleMessages;

public class MainViewMessage : IMainViewMessage
{
    public void ArgumentExceptionMessage(Exception e)
    {
        throw new NotImplementedException();
    }

    public void LeavingApp()
    {
        Console.WriteLine("Thank you, for using this application! Press ENTER to close the window.");
        Console.ReadLine();
    }

    public void LeavingScreen()
    {
        Console.WriteLine("Press ENTER to continue.");
        Console.ReadLine();
    }

    public void OverflowExceptionMessage(Exception e)
    {
        throw new NotImplementedException();
    }

    public void StartingApp()
    {
        Console.WriteLine("Welcome! Press ENTER to start the application.");
        Console.ReadLine();
    }

    public void UnhandledExceptionMessage(Exception e)
    {
        throw new NotImplementedException();
    }
}
