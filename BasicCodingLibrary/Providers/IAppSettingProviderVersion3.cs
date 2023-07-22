using BasicCodingLibrary.Models;

namespace BasicCodingLibrary.Providers;

/// <summary>
/// This interface is providing the access to the class <see cref="AppSettingModel"/>.
/// </summary>
public interface IAppSettingProviderVersion3
{
    /// <summary>
    /// This property is providing user information received from configuration.
    /// </summary>
    public UserInformation UserInformation { get; set; }
    /// <summary>
    /// This property is providing application information received from configuration.
    /// </summary>
    public ApplicationInformation ApplicationInformation { get; set; }
    /// <summary>
    /// This property is providing the command line arguments received from configuration.
    /// </summary>
    public string CommandLineArgument { get; set; }
    /// <summary>
    /// This property is providing the connection string received from configuration.
    /// </summary>
    public string ConnectionString { get; set; }
}