using PaperDeliveryLibrary.Enums;

namespace PaperDeliveryLibrary.Models;

public class Person
{
    public ContactDetails ContactDetails { get; set; } = new ContactDetails();
    public string FirstName { get; set; } = "default";
    public Gender Gender { get; set; } = Gender.unknown;
    public int Id { get; set; }
    public string LastName { get; set; } = "default";
    public PostalAddress PostalAddress { get; set; } = new PostalAddress();
}
