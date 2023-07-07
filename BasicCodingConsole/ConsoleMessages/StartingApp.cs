namespace BasicCodingConsole.ConsoleMessages;

public class StartingApp : IMessaging
{
    public string CallingClass { get; }

    public StartingApp(string callingClass)
    {
        CallingClass = callingClass;
    }

    public void Show()
    {
        string message = $"You have started the app: {CallingClass}";
        Console.WriteLine(message);
        Console.WriteLine("=".PadLeft(message.Length, '='));
    }
}
