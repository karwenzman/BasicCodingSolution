namespace BasicCodingConsole.ConsoleMessages;

public interface IMessaging
{
    string CallingClass { get; }
    void Show();
}