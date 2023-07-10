namespace BasicCodingConsole.ConsoleMessages;

public class EndingView : IEnding
{
    public void End()
    {
        Console.WriteLine($"\nYou are going to leave the view. Press ENTER to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}
