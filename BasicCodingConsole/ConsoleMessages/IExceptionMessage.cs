namespace BasicCodingConsole.ConsoleMessages;

public interface IExceptionMessage
{
    void UnhandledExceptionMessage(Exception e);
    void ArgumentExceptionMessage(Exception e);
    void OverflowExceptionMessage(Exception e);
}
