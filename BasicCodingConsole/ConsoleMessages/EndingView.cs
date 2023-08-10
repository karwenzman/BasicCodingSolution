namespace BasicCodingConsole.ConsoleMessages;

public class EndingView : IMessageEnd
{
    public void End(bool showMessage = true, bool clearScreen = true)
    {
        if (showMessage)
        {
            Console.WriteLine($"\nYou have reached the end of this view. Press ENTER to continue...");
            Console.ReadLine();
        }

        if (clearScreen)
        {
            Console.Clear();
        }
    }
}
