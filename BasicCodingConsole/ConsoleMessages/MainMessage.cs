namespace BasicCodingConsole.ConsoleMessages;

public class MainMessage : IMessage
{
    public void Continue(bool showMessage = true, bool clearScreen = true)
    {
        IContinueMessage continuing = new StandardContinueMessage();
        continuing.Continue(showMessage, clearScreen);
    }

    public void End(bool showMessage = true, bool clearScreen = true)
    {
        IEndMessage ending = new EndingApp();
        ending.End(showMessage, clearScreen);
    }

    public void Start(bool showMessage = true, bool clearScreen = true)
    {
        IStartMessage starting = new StartingApp();
        starting.Start(showMessage, clearScreen);
    }
}
