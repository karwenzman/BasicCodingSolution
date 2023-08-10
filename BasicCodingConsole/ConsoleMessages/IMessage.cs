namespace BasicCodingConsole.ConsoleMessages;

/// <summary>
/// This interface is putting things together.
/// <br></br>- implementing <see cref="IMessageContinue"/>
/// <br></br>- implementing <see cref="IMessageEnd"/>
/// <br></br>- implementing <see cref="IMessageStart"/>
/// </summary>
public interface IMessage : IMessageContinue, IMessageEnd, IMessageStart
{
}
