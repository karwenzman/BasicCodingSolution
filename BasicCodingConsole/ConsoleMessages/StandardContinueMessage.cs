namespace BasicCodingConsole.ConsoleMessages;

public class StandardContinueMessage : IContinueMessage
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
