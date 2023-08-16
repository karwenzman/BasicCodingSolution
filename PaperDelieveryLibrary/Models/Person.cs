using PaperDeliveryLibrary.Enums;

namespace PaperDeliveryLibrary.Models;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = "default";

    public string LastName { get; set; } = "default";

    public Gender Gender { get; set; } = Gender.unknown;

    public PostalAddress PostalAddress { get; set; } = new PostalAddress();

    public ContactDetails ContactDetails { get; set; } = new ContactDetails();
}
