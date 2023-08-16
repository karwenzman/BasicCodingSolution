using PaperDeliveryLibrary.Models;

namespace PaperDeliveryLibrary.Providers;

public interface IPaperDeliveryProvider
{
    List<PaperDeliveryClient> GetClientList();
    List<PaperDeliveryContract> GetContractList();
    List<PaperDeliveryContract> GetContractList(string fileName);
    List<PaperDeliveryContractor> GetContractorList();
    List<PaperDeliveryFulfillment> GetFulfillmentList();
    void WriteToFile<T>(string fileName, List<T> listToSave);
}