﻿using PaperDeliveryLibrary.Models;

namespace PaperDeliveryLibrary.Providers;

public class PaperDeliveryProvider : IPaperDeliveryProvider
{
    /// <summary>
    /// This method returns a list that is hard coded.
    /// It is for testing reasons only.
    /// </summary>
    /// <returns></returns>
    public List<IPaperDeliveryContract> GetContractList()
    {
        return ReadFromContractList();
    }
    /// <summary>
    /// This method returns a list loaded from a csv-file.
    /// </summary>
    /// <param name="fileName">The complete path and file name with extension.</param>
    /// <returns></returns>
    public List<IPaperDeliveryContract> GetContractList(string fileName)
    {
        return ReadFromContractFile(fileName);
    }
    public PaperDeliveryContractor GetContractorList()
    {
        PaperDeliveryContractor output = new PaperDeliveryContractor();

        return output;
    }
    public PaperDeliveryFulfillment GetFulfillmentList()
    {
        PaperDeliveryFulfillment output = new PaperDeliveryFulfillment();

        return output;
    }

    /// <summary>
    /// This method is providing a hard coded list for testing.
    /// </summary>
    /// <returns></returns>
    private List<IPaperDeliveryContract> ReadFromContractList()
    {
        List<IPaperDeliveryContract> output = new()
        {
            new PaperDeliveryContract
            {
                ContractID = "20230805KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230729KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230722KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 25, 00),
            }
        };

        return output;
    }
    /// <summary>
    /// This method is actually reading the content from a csv-file.
    /// </summary>
    /// <param name="fileName">The complete path and file name with extension.</param>
    /// <returns></returns>
    private List<IPaperDeliveryContract> ReadFromContractFile(string fileName)
    {
        List<IPaperDeliveryContract> output = new();

        return output;
    }
}
