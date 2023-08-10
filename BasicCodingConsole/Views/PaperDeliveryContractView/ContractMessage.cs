using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class ContractMessage : IMessage
{
    public void Continue(bool showMessage = true, bool clearScreen = true)
    {
        IContinueMessage continuing = new StandardContinueMessage();
        continuing.Continue(showMessage, clearScreen);
    }

    public void End(bool showMessage = true, bool clearScreen = true)
    {
        IEndMessage ending = new StandardEndMessage();
        ending.End(showMessage, clearScreen);
    }

    public void Start(bool showMessage = true, bool clearScreen = true)
    {
        IStartMessage starting = new StandardStartMessage();
        starting.Start(showMessage, clearScreen);
    }
}
