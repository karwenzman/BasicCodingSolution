using BasicCodingLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace BasicCodingLibrary.Providers;

/// <summary>
/// This class is providing services for instances of <see cref="AppSettingModel"/>.
/// </summary>
public class AppSettingProviderWithConstructorInjection : IAppSettingProvider
{
    private readonly IConfiguration _configuration;

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

    public AppSettingProviderWithConstructorInjection(IConfiguration configuration)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(AppSettingProviderWithConstructorInjection)}>.");
        _configuration = configuration;

        CommandLineArgument = _configuration.GetValue<string>("CommandLineArgument")!;
        ConnectionString = _configuration.GetConnectionString("Default")!;
        ApplicationInformation = _configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>()!;
        UserInformation = _configuration.GetSection("UserInformation").Get<UserInformation>()!;
    }

    /// <summary>
    /// This is an optional way to get data.
    /// If <see cref="AppSettingProviderWithConstructorInjection"/> is used via construtor injection,
    /// then this method is not necessary.
    /// </summary>
    /// <returns></returns>
    public AppSettingModel Get()
    {
        Debug.WriteLine($"Passing <{nameof(Get)}> in <{nameof(AppSettingProviderWithConstructorInjection)}>.");

        AppSettingModel output = new AppSettingModel();
        output.CommandLineArgument = CommandLineArgument;
        output.ConnectionString = ConnectionString;
        output.ApplicationInformation = ApplicationInformation;
        output.UserInformation = UserInformation;
        return output;
    }
}
