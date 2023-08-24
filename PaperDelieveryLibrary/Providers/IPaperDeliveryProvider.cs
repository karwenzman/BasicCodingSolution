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
    List<T> ReadRecordsFromFile<T>(string fileName, ClassMap? classMap = null);
    IAsyncEnumerable<T> ReadRecordsFromFileAsync<T>(string fileName, ClassMap? classMap = null);
    void WriteRecordsToFile<T>(string fileName, List<T> recordsToSave, ClassMap? classMap = null);
    Task WriteRecordsToFileAsync<T>(string fileName, List<T> recordsToSave, ClassMap? classMap = null);
}