using BasicCodingLibrary.Enums;

namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing members to describe a <see cref="Person"/>.
/// </summary>
public class Person
{
    #region ***** Property *****
    /// <summary>
    /// The person's unique ID.
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// The person's first name.
    /// </summary>
    public string FirstName { get; set; } = "default";
    /// <summary>
    /// The person's last name.
    /// </summary>
    public string LastName { get; set; } = "default";
    /// <summary>
    /// The person's gender.
    /// </summary>
    public Gender Gender { get; set; } = Gender.unknown;
    #endregion
}
