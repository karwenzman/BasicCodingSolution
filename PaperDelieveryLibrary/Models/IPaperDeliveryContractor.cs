using BasicCodingLibrary.Enums;

namespace PaperDeliveryLibrary.Models;

public interface IPaperDeliveryContractor
{
    string City { get; set; }
    string ContractorID { get; set; }
    string Email { get; set; }
    string FirstName { get; set; }
    Gender Gender { get; set; }
    string LastName { get; set; }
    string Phone { get; set; }
    string PostalCode { get; set; }
    string Site { get; set; }
    string Street { get; set; }
}