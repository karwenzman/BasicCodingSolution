namespace BasicCodingConsole.ConsoleMessages;

public class MainMessage : IMessage
{
    public void Continue()
    {
        IContinuing continuing = new ContinueMessage();
        continuing.Continue();
    }

    public void End()
    {
        IEnding ending = new EndingApp();
        ending.End();
    }

    public void Start()
    {
        IStarting starting = new StartingApp();
        starting.Start();
    }
}
