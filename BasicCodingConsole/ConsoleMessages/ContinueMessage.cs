namespace BasicCodingConsole.ConsoleMessages;

public class ContinueMessage : IContinuing
{
    public void Continue()
    {
        Console.WriteLine($"\nPress ENTER to continue...");
        Console.ReadLine();
    }
}
