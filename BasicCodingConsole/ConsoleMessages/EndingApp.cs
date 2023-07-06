namespace BasicCodingConsole.ConsoleMessages;

public class EndingApp : IMessage
{
    public string CallingClass { get; }

    public EndingApp(string callingClass)
    {
        CallingClass = callingClass;
    }

    public void Message()
    {
        Console.WriteLine($"\nYou are going to leave the app: {CallingClass}. Press ENTER to end the app...");
        Console.ReadLine();
    }
}
