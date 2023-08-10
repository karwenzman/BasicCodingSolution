using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.SettingView;

public class SettingMenuContent : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "",
        "Main / Setting",
        "",
    };

    public string[]? MenuItems { get; set; } = null;

    public string[]? StatusItems { get; set; } = null;
}
