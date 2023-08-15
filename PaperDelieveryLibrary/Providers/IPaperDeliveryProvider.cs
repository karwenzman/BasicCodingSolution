using PaperDeliveryLibrary.Models;

namespace PaperDeliveryLibrary.Providers;

public interface IPaperDeliveryProvider
{
    List<PaperDeliveryClient> GetClientList();
    List<PaperDeliveryContract> GetContractList();
    List<PaperDeliveryContract> GetContractList(string fileName);
    List<PaperDeliveryContractor> GetContractorList();
    List<PaperDeliveryFulfillment> GetFulfillmentList();
    void WriteClientList(string fileName, List<PaperDeliveryClient> contracts);
    void WriteContractList(string fileName, List<PaperDeliveryContract> contracts);
    void WriteContractorList(string fileName, List<PaperDeliveryContractor> contracts);
}