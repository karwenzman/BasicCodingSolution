using BasicCodingLibrary.Models;

namespace BasicCodingLibrary.Providers;

/// <summary>
/// This interface is providing the access to the class <see cref="AppSettingModel"/>.
/// </summary>
public interface IAppSettingProviderVersion2
{
    /// <summary>
    /// This method is getting the current values from the configuration files.
    /// </summary>
    /// <returns>An instance of class <see cref="AppSettingModel"/> is returned.</returns>
    AppSettingModel Get();
}