namespace BasicCodingConsole.ConsoleMessages;

public class MessageApp : IMessageApp
{
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
