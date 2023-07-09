namespace BasicCodingConsole.ConsoleViews;

public interface IConsoleDisplay
{
    IDisplay Display { get; }
    void Run();
    void Run(string[] args);
}
