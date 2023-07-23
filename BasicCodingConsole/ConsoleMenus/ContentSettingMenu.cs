namespace BasicCodingConsole.ConsoleMenus;

public class ContentSettingMenu : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "Main/Setting",
    };

    public string[]? MenuItems { get; set; } = null;

    public string[]? StatusItems { get; set; } = null;
}
