namespace BasicCodingConsole.ConsoleMessages;

/// <summary>
/// This interface is providing members to continue a console.
/// </summary>
public interface IMessageContinue
{
    /// <summary>
    /// Writing a standard message to the console and awaiting user input.
    /// Then, clearing the console.
    /// </summary>
    /// <param name="showMessage">true, if message shall be written on the console.</param>
    /// <param name="clearScreen">true, if after user input the console shall be cleard.</param>
    void Continue(bool showMessage = true, bool clearScreen = false);
}
