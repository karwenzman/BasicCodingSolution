namespace BasicCodingConsole.ConsoleViews;

public interface IConsoleView
{
    IViewing Display { get; }
    void Run();
    void Run(string[] args);
}
