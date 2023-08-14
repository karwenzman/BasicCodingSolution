using BasicCodingLibrary.Enums;
using CsvHelper;
using PaperDeliveryLibrary.Models;
using System.Globalization;

namespace PaperDeliveryLibrary.Providers;

public class PaperDeliveryProvider : IPaperDeliveryProvider
{
    /// <summary>
    /// This method returns a list that is hard coded.
    /// It is for testing reasons only.
    /// </summary>
    /// <returns></returns>
    public List<PaperDeliveryContract> GetContractList()
    {
        return ReadFromContractList();
    }

    /// <summary>
    /// This method returns a list loaded from a csv-file.
    /// </summary>
    /// <param name="fileName">The complete path and file name with extension.</param>
    /// <returns></returns>
    public List<PaperDeliveryContract> GetContractList(string fileName)
    {
        return ReadFromContractFile(fileName);
    }

    /// <summary>
    /// This method ...
    /// <para></para>
    /// This method is using the NuGet package <see cref="CsvHelper"/>.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="contracts"></param>
    public void WriteContractList(string fileName, List<PaperDeliveryContract> contracts)
    {
        if (contracts == null)
        {
            // do something
        }

        if (string.IsNullOrEmpty(fileName))
        {
            // do something
        }

        if (Directory.Exists(Path.GetDirectoryName(fileName)))
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected Exception!");
                Console.WriteLine(e);
                Console.WriteLine($"\n***** Press ENTER To Continue *****");
                Console.ReadLine();
            }
        }

        if (Directory.Exists(Path.GetDirectoryName(fileName)))
        {
            using var writer = new StreamWriter(fileName);
            using var csvOut = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvOut.WriteRecords(contracts);
        }
        else
        {
            // do something
        }
    }

    public List<PaperDeliveryContractor> GetContractorList()
    {
        return ReadFromContractorList();
    }

    public List<PaperDeliveryFulfillment> GetFulfillmentList()
    {
        List<PaperDeliveryFulfillment> output = new ();

        return output;
    }

    /// <summary>
    /// This method is providing a hard coded list for testing.
    /// </summary>
    /// <returns></returns>
    private List<PaperDeliveryContract> ReadFromContractList()
    {
        List<PaperDeliveryContract> output = new()
        {
            new PaperDeliveryContract
            {
                ContractID = "20230812KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 25, 00),
            },
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
            },
            new PaperDeliveryContract
            {
                ContractID = "20230715KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 52, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230708KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 52, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230701KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230624KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(02, 19, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230617KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 35, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230610KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230603KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(02, 39, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230527KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(02, 05, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230520KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 35, 00),
            },
        };

        output.Sort();

        return output;
    }

    /// <summary>
    /// This method is actually reading the content from a csv-file.
    /// </summary>
    /// <param name="fileName">The complete path and file name with extension.</param>
    /// <returns></returns>
    private List<PaperDeliveryContract> ReadFromContractFile(string fileName)
    {
        List<PaperDeliveryContract> output = new();

        if (File.Exists(fileName))
        {
            using var reader = new StreamReader(fileName);
            using var csvIn = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csvIn.GetRecords<PaperDeliveryContract>();

            foreach (var item in records)
            {
                output.Add(item);
            }
        }

        output.Sort();

        return output;
    }

    private List<PaperDeliveryContractor> ReadFromContractorList()
    {
        List<PaperDeliveryContractor> output = new()
        {
            new PaperDeliveryContractor()
            {
                ContractorID = "0001",
                FirstName = "Thorsten",
                LastName = "Jenning",
                Street = "Breslauer Str. 7",
                PostalCode = "36251",
                City = "Bad Hersfeld",
                Phone = "015730602188",
                Email = "Jenning.Thorsten@gmx.net",
                Gender = Gender.male,
                Site = "Vor der Haustür",
            },
            new PaperDeliveryContractor()
            {
                ContractorID = "0003",
                FirstName = "Silvana",
                LastName = "Hainer",
                Street = "Breslauer Str. 7",
                PostalCode = "36251",
                City = "Bad Hersfeld",
                Phone = "01741985444",
                Email = "n/a",
                Gender = Gender.female,
                Site = "Vor der Haustür",
            },
            new PaperDeliveryContractor()
            {
                ContractorID = "0002",
                FirstName = "Melanie",
                LastName = "Jenning",
                Street = "Breslauer Str. 7",
                PostalCode = "36251",
                City = "Bad Hersfeld",
                Phone = "015756465178",
                Email = "Jenning.Melanie@Outlook.de",
                Gender = Gender.female,
                Site = "Vor der Haustür",
            },
        };

        output.Sort();

        return output;
    }
}
