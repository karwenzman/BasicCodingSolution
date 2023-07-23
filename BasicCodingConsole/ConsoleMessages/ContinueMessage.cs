namespace BasicCodingConsole.ConsoleMessages;

public class ContinueMessage : IContinuing
{
    public void Continue(bool showMessage = true, bool clearScreen = false)
    {
        if (showMessage)
        {
            Console.WriteLine($"\nPress ENTER to continue...");
            Console.ReadLine();
        }

        if (clearScreen)
        {
            Console.Clear();
        }
    }
}
