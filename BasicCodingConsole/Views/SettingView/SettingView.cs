using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasicCodingConsole.Views.SettingView;

public class SettingView : ViewBase, ISettingView
{
    private readonly ILogger<SettingView> _logger;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;

    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="SettingMenuContent"/>.
    /// </summary>
    public IMenu Menu { get; set; }
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StandardMessageEnd"/>,
    /// <see cref="StandardMessageStart"/> and <see cref="StandardMessageContinue"/>
    /// </summary>
    public IMessage Message { get; set; }

    public SettingView(ILogger<SettingView> logger, IOptions<ConsoleSetting> optionsOfConsoleSetting)
    {
        _logger = logger;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(SettingView));

        Menu = new SettingMenu(_optionsOfConsoleSetting.Value);
        Message = new SettingMessage();
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(SettingView), nameof(Run));

        WriteMenu(Menu);
        WriteContent();
        Message.Continue(showMessage: true, clearScreen: true);
    }

    /// <summary>
    /// This method is writing the members of <see cref="AppSettingModel"/> to a console.
    /// </summary>
    private void WriteContent()
    {
        Console.WriteLine($"\nInformation about user is not available, yet.");
    }
}
