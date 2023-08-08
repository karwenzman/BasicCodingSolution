using PaperDeliveryLibrary.Models;

namespace PaperDeliveryLibrary.Providers;

public interface IPaperDeliveryProvider
{
    List<IPaperDeliveryContract> GetContractList();
    List<IPaperDeliveryContract> GetContractList(string fileName);
    PaperDeliveryContractor GetContractorList();
    PaperDeliveryFulfillment GetFulfillmentList();
}