namespace BasicCodingConsole.ConsoleMessages;

public interface IConsoleMessage
{
    IMessaging StartMessage { get; }
    IMessaging EndMessage { get; }
}