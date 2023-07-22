using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Models;

namespace BasicCodingConsole.Views.SettingView;

public interface ISettingViewVersion3
{
    IAppSettingModel AppSettingModel { get; }
    IMenu Menu { get; }
    IMessage Message { get; }
    IDisplay Display { get; }
    void Run();
}
