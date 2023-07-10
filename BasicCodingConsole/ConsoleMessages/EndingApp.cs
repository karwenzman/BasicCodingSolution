namespace BasicCodingConsole.ConsoleMessages;

public class EndingApp : IEnding
{
    public void End()
    {
        Console.WriteLine($"\nYou are going to leave the app. Press ENTER to end the app...");
        Console.ReadLine();
        Console.Clear();
    }
}
