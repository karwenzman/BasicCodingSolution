using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.MainView;

public interface IMainView : IConsoleMessage
{
    void Run(string[] args);
}
