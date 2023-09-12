using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class PaperDeliveryContractMessage : IMessage
{
    public void Continue(bool showMessage = true, bool clearScreen = true)
    {
        IMessageContinue continuing = new StandardMessageContinue();
        continuing.Continue(showMessage, clearScreen);
    }

    public void End(bool showMessage = true, bool clearScreen = true)
    {
        IMessageEnd ending = new StandardMessageEnd();
        ending.End(showMessage, clearScreen);
    }

    public void Start(bool showMessage = true, bool clearScreen = true)
    {
        IMessageStart starting = new StandardMessageStart();
        starting.Start(showMessage, clearScreen);
    }
}
