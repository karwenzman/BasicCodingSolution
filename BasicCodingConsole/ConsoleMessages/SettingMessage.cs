﻿namespace BasicCodingConsole.ConsoleMessages;

public class SettingMessage : IMessage
{
    public void Continue(bool showMessage = true, bool clearScreen = true)
    {
        IContinueMessage continuing = new StandardContinueMessage();
        continuing.Continue(showMessage, clearScreen);
    }

    public void End(bool showMessage = true, bool clearScreen = true)
    {
        IEndMessage ending = new EndingView();
        ending.End(showMessage, clearScreen);
    }

    public void Start(bool showMessage = true, bool clearScreen = true)
    {
        IStartMessage starting = new StartingView();
        starting.Start(showMessage, clearScreen);
    }
}
