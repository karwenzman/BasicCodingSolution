namespace BasicCodingConsole.ConsoleMessages;

public class SettingMessage : IMessage
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
