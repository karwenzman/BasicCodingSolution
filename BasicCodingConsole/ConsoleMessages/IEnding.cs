namespace BasicCodingConsole.ConsoleMessages;

public interface IEnding
{
    /// <summary>
    /// Writing a standard message to the console and awaiting user input.
    /// Then, clearing the console.
    /// </summary>
    void End(bool showMessage = true, bool clearScreen = true);
}
