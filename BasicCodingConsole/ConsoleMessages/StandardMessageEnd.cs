namespace BasicCodingConsole.ConsoleMessages;

public class StandardMessageEnd : IMessageEnd
{
    public void End(bool showMessage = true, bool clearScreen = true)
    {
        if (showMessage)
        {
            Console.WriteLine($"\nYou have reached the end of this console output. Press ENTER to continue...");
            Console.ReadLine();
        }

        if (clearScreen)
        {
            Console.Clear();
        }
    }
}
