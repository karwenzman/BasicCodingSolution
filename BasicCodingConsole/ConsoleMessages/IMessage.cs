namespace BasicCodingConsole.ConsoleMessages;

/// <summary>
/// This interface is putting things together.
/// <br></br>- implementing <see cref="IContinueMessage"/>
/// <br></br>- implementing <see cref="IEndMessage"/>
/// <br></br>- implementing <see cref="IStartMessage"/>
/// </summary>
public interface IMessage : IContinueMessage, IEndMessage, IStartMessage
{
}
