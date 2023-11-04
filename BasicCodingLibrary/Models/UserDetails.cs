using BasicCodingLibrary.Enums;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing a section of the <b>appsettings.json</b> file.
/// </summary>
public partial class UserDetails : ModelBase
{
    [ObservableProperty]
    private int _Id;
    [ObservableProperty]
    private string _FirstName;
    [ObservableProperty]
    private string _LastName;
    [ObservableProperty]
    private Gender _Gender;

    public UserDetails()
    {
        Id = 0;
        FirstName = "default";
        LastName = "default";
        Gender = Gender.unknown;
    }
}
