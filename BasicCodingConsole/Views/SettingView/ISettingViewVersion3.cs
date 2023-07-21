using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.SettingView;

public interface ISettingViewVersion3
{
    IMenu Menu { get; }
    IMessage Message { get; }
    IDisplay Display { get; }
    void Run();
}
