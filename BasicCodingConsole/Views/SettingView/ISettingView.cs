using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.SettingView;

public interface ISettingView
{
    IMessageView Message { get; }
    IDisplay Display { get; }
    void Run();
    void Run(string[] args);
}
