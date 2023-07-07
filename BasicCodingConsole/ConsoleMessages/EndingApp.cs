namespace BasicCodingConsole.ConsoleMessages;

public class EndingApp : IMessaging
{
    public string CallingClass { get; }

    public EndingApp(string callingClass)
    {
        CallingClass = callingClass;
    }

    public void Show()
    {
        Console.WriteLine($"\nYou are going to leave the app: {CallingClass}. Press ENTER to end the app...");
        Console.ReadLine();
    }
}
