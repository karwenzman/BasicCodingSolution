namespace BasicCodingConsole.ConsoleMessages;

public class MainMessage : IMessage
{
    public void Continue(bool showMessage = true, bool clearScreen = true)
    {
        IContinuing continuing = new ContinueMessage();
        continuing.Continue(showMessage, clearScreen);
    }

    public void End(bool showMessage = true, bool clearScreen = true)
    {
        IEnding ending = new EndingApp();
        ending.End(showMessage, clearScreen);
    }

    public void Start(bool showMessage = true, bool clearScreen = true)
    {
        IStarting starting = new StartingApp();
        starting.Start(showMessage, clearScreen);
    }
}
