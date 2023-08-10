using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.SettingView;

public class SettingMessage : IMessage
{
    public void Continue(bool showMessage = true, bool clearScreen = true)
    {
        IMessageContinue continuing = new StandardContinueMessage();
        continuing.Continue(showMessage, clearScreen);
    }

    public void End(bool showMessage = true, bool clearScreen = true)
    {
        IMessageEnd ending = new StandardEndMessage();
        ending.End(showMessage, clearScreen);
    }

    public void Start(bool showMessage = true, bool clearScreen = true)
    {
        IMessageStart starting = new StandardStartMessage();
        starting.Start(showMessage, clearScreen);
    }
}
