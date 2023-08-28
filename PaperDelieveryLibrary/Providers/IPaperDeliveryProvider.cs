﻿using CsvHelper.Configuration;
using PaperDeliveryLibrary.Models;

namespace PaperDeliveryLibrary.Providers;

public interface IPaperDeliveryProvider
{
    List<PaperDeliveryClient> GetClientList();

    /// <summary>
    /// This method returns a list that is hard coded.
    /// It is for testing reasons only.
    /// </summary>
    /// <returns></returns>
    List<PaperDeliveryContract> GetContractList();

    /// <summary>
    /// This method returns a list loaded from a csv-file.
    /// </summary>
    /// <param name="fileName">The complete path and file name with extension.</param>
    /// <returns></returns>
    List<PaperDeliveryContract> GetContractList(string fileName);

    List<PaperDeliveryContractor> GetContractorList();

    List<PaperDeliveryFulfillment> GetFulfillmentList();
    /// <summary>
    /// This generic method is reading a csv file.
    /// <para></para>
    /// This method is using the NuGet package <see cref="CsvHelper"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="fileName">
    /// The complete path and file name with extension.
    /// </param>
    /// <param name="classMap">
    /// A helper class to specify the column's order. 
    /// If null, then the class map will be handled automatically.
    /// </param>
    /// <returns>A <see cref="List{T}"/> object.</returns>
    List<T> ReadRecordsFromFile<T>(string fileName, ClassMap? classMap = null);

    IAsyncEnumerable<T> ReadRecordsFromFileAsync<T>(string fileName, ClassMap? classMap = null);

    void WriteRecordToFile<T>(string fileName, T recordToSave, ClassMap? classMap = null);

    void WriteRecordsToFile<T>(string fileName, List<T> recordsToSave, ClassMap? classMap = null);

    Task WriteRecordsToFileAsync<T>(string fileName, List<T> recordsToSave, ClassMap? classMap = null);
}