namespace BasicCodingConsole.ConsoleMessages;

public interface IConsoleMessage
{
    IMessage StartMessage { get; }
    IMessage EndMessage { get; }
}