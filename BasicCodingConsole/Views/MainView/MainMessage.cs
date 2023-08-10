using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.MainView;

public class MainMessage : IMessage
{
    public void Continue(bool showMessage = true, bool clearScreen = true)
    {
        IMessageContinue continuing = new StandardMessageContinue();
        continuing.Continue(showMessage, clearScreen);
    }

    public void End(bool showMessage = true, bool clearScreen = true)
    {
        IMessageEnd ending = new MainMessageEnd();
        ending.End(showMessage, clearScreen);
    }

    public void Start(bool showMessage = true, bool clearScreen = true)
    {
        IMessageStart starting = new MainMessageStart();
        starting.Start(showMessage, clearScreen);
    }
}
