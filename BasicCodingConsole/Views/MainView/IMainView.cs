using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.MainView;

public interface IMainView
{
    IMessageApp Message { get; }
    IDisplay Display { get; }
    void Run(string[] args);
}
