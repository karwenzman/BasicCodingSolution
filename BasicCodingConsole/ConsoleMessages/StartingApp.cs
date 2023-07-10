namespace BasicCodingConsole.ConsoleMessages;

public class StartingApp : IStarting
{
    public void Start()
    {
        string message = $"You have started the app.";
        Console.WriteLine(message);
        Console.WriteLine("=".PadLeft(message.Length, '='));
    }
}
