using BasicCodingLibrary.Models;

namespace BasicCodingLibrary.Providers;

/// <summary>
/// This interface is providing the access to the class <see cref="AppSettingModel"/>.
/// </summary>
public interface IAppSettingProvider
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

    /// <summary>
    /// This method is getting the current values of <see cref="AppSettingModel"/>.
    /// <para>
    /// A new snapshot of the file 'appsettings.json' should be implemented from derived classes.
    /// </para>
    /// </summary>
    /// <returns>An instance of class <see cref="AppSettingModel"/>.</returns>
    AppSettingModel Get();
}