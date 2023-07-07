namespace BasicCodingConsole.ConsoleMessages;

public class EndingView : IMessaging
{
    public string CallingClass { get; }

    public EndingView(string callingClass)
    {
        CallingClass = callingClass;
    }

    public void Show()
    {
        Console.WriteLine($"\nYou are going to leave the view: {CallingClass}. Press ENTER to continue...");
        Console.ReadLine();
    }
}
