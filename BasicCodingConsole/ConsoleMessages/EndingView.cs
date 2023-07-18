namespace BasicCodingConsole.ConsoleMessages;

public class EndingView : IEnding
{
    public void End()
    {
        Console.WriteLine($"\nYou have reached the end of this view. Press ENTER to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}
