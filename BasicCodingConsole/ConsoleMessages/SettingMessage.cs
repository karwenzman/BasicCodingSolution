namespace BasicCodingConsole.ConsoleMessages;

public class SettingMessage : IMessage
{
    public void Continue(bool showMessage = true, bool clearScreen = true)
    {
        IContinuing continuing = new ContinueMessage();
        continuing.Continue(showMessage, clearScreen);
    }

    public void End(bool showMessage = true, bool clearScreen = true)
    {
        IEnding ending = new EndingView();
        ending.End(showMessage, clearScreen);
    }

    public void Start(bool showMessage = true, bool clearScreen = true)
    {
        IStarting starting = new StartingView();
        starting.Start(showMessage, clearScreen);
    }
}
