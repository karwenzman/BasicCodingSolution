namespace BasicCodingConsole.ConsoleMessages;

public interface IMessaging
{
    string CallingClass { get; }

    /// <summary>
    /// Writing a standard message to the console.
    /// <para></para>
    /// No <see cref="Console.Clear()"/> methods are called.
    /// </summary>
    void Show();
}