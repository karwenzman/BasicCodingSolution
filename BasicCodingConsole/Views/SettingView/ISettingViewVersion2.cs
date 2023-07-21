using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Models;

namespace BasicCodingConsole.Views.SettingView;

public interface ISettingViewVersion2
{
    IAppSettingModel AppSettingModel { get; }
    IDisplay Display { get; }
    IMenu Menu { get; }
    IMessage Message { get; }
    void Run();
}
