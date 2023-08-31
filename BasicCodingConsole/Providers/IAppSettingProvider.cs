using BasicCodingConsole.Models;
using PaperDeliveryLibrary.Models;

namespace BasicCodingConsole.Providers;

/// <summary>
/// This interface is providing the access to the class <see cref="AppSettingModel"/>.
/// </summary>
public interface IAppSettingProvider
{
    /// <summary>
    /// This method is getting the current values from the configuration files.
    /// </summary>
    /// <returns>An instance of class <see cref="AppSettingModel"/> is returned.</returns>
    AppSettingModel Get();

    /// <summary>
    /// This method is getting the current values from the configuration files.
    /// </summary>
    /// <returns>An instance of class <see cref="PaperDeliverySetting"/> is returned.</returns>
    PaperDeliverySetting GetPaperDeliverySetting();
}
