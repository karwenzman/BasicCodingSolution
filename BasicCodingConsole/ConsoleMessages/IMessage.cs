namespace BasicCodingConsole.ConsoleMessages;

public interface IMessage
{
    string CallingClass { get; }
    void Message();
}