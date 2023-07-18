using BasicCodingLibrary.Models;

namespace BasicCodingLibrary.Providers;

/// <summary>
/// This interface is providing the access to the class <see cref="AppSettingModel"/>.
/// </summary>
public interface IAppSettingProvider
{
    /// <summary>
    /// This method is getting the current values of <see cref="AppSettingModel"/>.
    /// <para>
    /// A new snapshot of the file 'appsettings.json' should be implemented from derived classes.
    /// </para>
    /// </summary>
    /// <returns>An instance of class <see cref="AppSettingModel"/>.</returns>
    AppSettingModel Get();
}