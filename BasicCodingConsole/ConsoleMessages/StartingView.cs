namespace BasicCodingConsole.ConsoleMessages;

public class StartingView : IStarting
{
    public void Start()
    {
        string message = $"You have started the view.";
        Console.WriteLine(message);
        Console.WriteLine("=".PadLeft(message.Length, '='));
    }
}
