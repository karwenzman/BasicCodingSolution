using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.SettingView;

public interface ISettingView
{
    IMenu Menu { get; }
    IMessage Message { get; }
    IDisplay Display { get; }
    void Run();
    void Run(string[] args);
}
