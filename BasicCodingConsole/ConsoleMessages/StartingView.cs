namespace BasicCodingConsole.ConsoleMessages;

public class StartingView : IMessaging
{
    public string CallingClass { get; }

    public StartingView(string callingClass)
    {
        CallingClass = callingClass;
    }

    public void Show()
    {
        string message = $"You have started the view: {CallingClass}";
        Console.WriteLine(message);
        Console.WriteLine("=".PadLeft(message.Length, '='));
    }
}
