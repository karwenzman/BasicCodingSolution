using PaperDeliveryLibrary.Models;

namespace PaperDeliveryLibrary.Providers;

public interface IPaperDeliveryProvider
{
    List<PaperDeliveryContract> GetContractList();
    List<PaperDeliveryContract> GetContractList(string fileName);
    void WriteContractList(string fileName, List<PaperDeliveryContract> contracts);
    PaperDeliveryContractor GetContractorList();
    PaperDeliveryFulfillment GetFulfillmentList();
}