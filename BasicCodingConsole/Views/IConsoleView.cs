using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views;

public interface IConsoleView : IView
{
    void ClearView();
    void ShowView();
}
