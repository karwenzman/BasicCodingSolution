using CsvHelper.Configuration;

namespace PaperDeliveryLibrary.Models;

public sealed class PaperDeliveryContractorMap : ClassMap<PaperDeliveryContractor>
{
    public PaperDeliveryContractorMap()
    {
        Map(m => m.Id).Index(0);
        Map(m => m.FirstName).Index(1);
        Map(m => m.LastName).Index(2);
        Map(m => m.PostalAddress.Street).Index(3);
        Map(m => m.PostalAddress.AdditionalInformation).Index(4);
        Map(m => m.PostalAddress.PostalCode).Index(5);
        Map(m => m.PostalAddress.City).Index(6);
        Map(m => m.PostalAddress.Country).Index(7);
        Map(m => m.Site).Index(8);
    }
}
