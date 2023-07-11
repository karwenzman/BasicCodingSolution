namespace BasicCodingConsole.ConsoleMessages;

public class StartingView : IStarting
{
    public void Start()
    {
        string message = $"You are going to start the view.";
        Console.WriteLine(message);
        Console.WriteLine("=".PadLeft(message.Length, '='));

        Console.WriteLine($"\nPress ENTER to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}
