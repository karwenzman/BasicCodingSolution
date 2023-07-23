namespace BasicCodingConsole.ConsoleMessages;

/// <summary>
/// This interface is putting things together.
/// <br></br>- implementing <see cref="IContinuing"/>
/// <br></br>- implementing <see cref="IEnding"/>
/// <br></br>- implementing <see cref="IStarting"/>
/// </summary>
public interface IMessage : IContinuing, IEnding, IStarting
{
}
