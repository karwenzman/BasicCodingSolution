namespace BasicCodingConsole.ConsoleMessages;

public class StandardStartMessage : IStartMessage
{
    public void Start(bool showMessage = true, bool clearScreen = true)
    {
        if (showMessage)
        {
            string message = $"You are going to start the console output.";
            Console.WriteLine(message);
            Console.WriteLine("=".PadLeft(message.Length, '='));
            Console.WriteLine($"\nPress ENTER to continue...");
            Console.ReadLine();
        }

        if (clearScreen)
        {
            Console.Clear();
        }
    }
}
