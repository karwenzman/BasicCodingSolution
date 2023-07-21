namespace BasicCodingConsole.ConsoleMessages;

public class EndingApp : IEnding
{
    public void End(bool showMessage = true, bool clearScreen = true)
    {
        if (showMessage)
        {
            Console.WriteLine($"\nYou are going to leave the app. Press ENTER to end the app...");
            Console.ReadLine();
        }

        if (clearScreen)
        {
            Console.Clear();
        }
    }
}
