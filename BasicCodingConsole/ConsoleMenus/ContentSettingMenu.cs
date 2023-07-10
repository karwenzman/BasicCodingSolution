namespace BasicCodingConsole.ConsoleMenus;

public class ContentSettingMenu : IMenuContent
{
    public string[]? CaptionItems { get; } =
    {
        "Main/Setting",
    };

    public string[]? MenuItems { get; } = null;

    public string[]? StatusItems { get; } = null;
}
