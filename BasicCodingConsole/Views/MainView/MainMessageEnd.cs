using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.MainView;

public class MainMessageEnd : IMessageEnd
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
