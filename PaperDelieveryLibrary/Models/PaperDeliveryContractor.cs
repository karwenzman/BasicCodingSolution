using BasicCodingLibrary.Enums;

namespace BasicCodingLibrary.Models;

public class PaperDeliveryContractor : IPaperDeliveryContractor
{
    public string City { get; set; } = "default";
    public string ContractorID { get; set; } = "default";
    public string FirstName { get; set; } = "default";
    public Gender Gender { get; set; } = Gender.unknown;
    public string LastName { get; set; } = "default";
    public string Phone { get; set; } = "default";
    public string PostalCode { get; set; } = "default";
    public string Site { get; set; } = "default";
    public string Street { get; set; } = "default";
}
