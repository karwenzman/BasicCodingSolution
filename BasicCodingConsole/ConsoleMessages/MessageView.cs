namespace BasicCodingConsole.ConsoleMessages;

public class MessageView : IMessageView
{
    public void Continue()
    {
        IContinuing continuing = new ContinueMessage();
        continuing.Continue();
    }

    public void End()
    {
        IEnding ending = new EndingView();
        ending.End();
    }

    public void Start()
    {
        IStarting starting = new StartingView();
        starting.Start();
    }
}
