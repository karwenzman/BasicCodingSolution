using CsvHelper.Configuration;
using PaperDeliveryLibrary.Models;

namespace PaperDeliveryLibrary.Providers;

public interface IPaperDeliveryProvider
{
    List<PaperDeliveryClient> GetClientList();
    List<PaperDeliveryContract> GetContractList();
    List<PaperDeliveryContract> GetContractList(string fileName);
    List<PaperDeliveryContractor> GetContractorList();
    List<PaperDeliveryFulfillment> GetFulfillmentList();
    void WriteRecordsToFile<T>(string fileName, List<T> recordsToSave, ClassMap? classMap = null);
    Task WriteRecordsToFileAsync<T>(string fileName, List<T> recordsToSave, ClassMap? classMap = null);
}