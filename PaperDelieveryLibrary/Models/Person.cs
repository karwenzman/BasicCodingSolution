using BasicCodingLibrary.Enums;

namespace PaperDeliveryLibrary.Models;

public class Person
{
    /// <summary>
    /// The person's contact details.
    /// </summary>
    public ContactDetails ContactDetails { get; set; } = new ContactDetails();
    /// <summary>
    /// The person's first name.
    /// </summary>
    public string FirstName { get; set; } = "default";
    /// <summary>
    /// The person's gender.
    /// </summary>
    public Gender Gender { get; set; } = Gender.unknown;
    /// <summary>
    /// The person's unique ID.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The person's last name.
    /// </summary>
    public string LastName { get; set; } = "default";
    /// <summary>
    /// The person's address.
    /// </summary>
    public PostalAddress PostalAddress { get; set; } = new PostalAddress();
}
