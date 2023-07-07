namespace BasicCodingConsole.ConsoleViews;

public interface IConsoleView
{
    IView Display { get; }
    void Run();
}
