namespace BasicCodingConsole.ConsoleDisplays;

/// <summary>
/// This interface is providing members to resize a console.
/// </summary>
public interface IResizing
{
    /// <summary>
    /// Test - Test - Test!
    /// <para></para>
    /// Writing a standard message to the console that is simulating a resize of the window.
    /// Awaiting user input.
    /// Then, clearing the console.
    /// </summary>
    void Resize(int consoleWidth, int consoleHeight);
}
