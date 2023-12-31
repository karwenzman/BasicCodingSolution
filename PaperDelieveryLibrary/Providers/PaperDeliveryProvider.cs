﻿using CsvHelper;
using CsvHelper.Configuration;
using PaperDeliveryLibrary.Enums;
using PaperDeliveryLibrary.Models;
using System.Globalization;

namespace PaperDeliveryLibrary.Providers;

/// <summary>
/// This class is providing read/write members.
/// <para></para>
/// This class is using the NuGet package <see cref="CsvHelper"/>.
/// Homepage: https://joshclose.github.io/CsvHelper/
/// </summary>
public class PaperDeliveryProvider : IPaperDeliveryProvider
{
    public List<PaperDeliveryClient> GetClientList()
    {
        return ReadFromClientList();
    }

    public List<PaperDeliveryContract> GetContractList()
    {
        return ReadFromContractList();
    }

    public List<PaperDeliveryContractor> GetContractorList()
    {
        return ReadFromContractorList();
    }

    public List<T> ReadRecordsFromFile<T>(string fileName, ClassMap? classMap = null)
    {
        //throw new ArgumentNullException(nameof(fileName), "String cannot be null or empty!");

        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName), "String cannot be null or empty!");
        }

        if (!Directory.Exists(Path.GetDirectoryName(fileName)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
        }

        if (!File.Exists(fileName))
        {
            return new List<T>();
        }

        var config = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ",",
        };
        using var reader = new StreamReader(fileName);
        using var csv = new CsvReader(reader, config);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }

        return csv.GetRecords<T>().ToList<T>();
    }

    /// <summary>
    /// This generic method is reading a csv file.
    /// <para></para>
    /// This method is using the NuGet package <see cref="CsvHelper"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="fileName"></param>
    /// <param name="classMap">
    /// A helper class to specify the column's order. 
    /// If null, then the class map will be handled automatically.
    /// </param>
    /// <returns>A <see cref="IAsyncEnumerable{T}"/> object.</returns>
    public async IAsyncEnumerable<T> ReadRecordsFromFileAsync<T>(string fileName, ClassMap? classMap = null)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName), "String cannot be null or empty!");
        }

        if (!Directory.Exists(Path.GetDirectoryName(fileName)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
        }

        //List<T> output = new();

        if (Directory.Exists(Path.GetDirectoryName(fileName)))
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
            };

            using var reader = new StreamReader(fileName);
            using var csv = new CsvReader(reader, config);
            if (classMap != null)
            {
                csv.Context.RegisterClassMap(classMap);
            }
            await foreach (var record in csv.GetRecordsAsync<T>())
            {
                yield return record;
            }
        }
        else
        {
            throw new Exception(nameof(fileName) + ": File or Directory does not exist!");
        }
    }

    public void WriteRecordToFile<T>(string fileName, T recordToSave, ClassMap? classMap = null)
    {
        if (recordToSave == null)
        {
            throw new ArgumentNullException(nameof(recordToSave), "Object cannot be null!");
        }

        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName), "String cannot be null or empty!");
        }

        if (!Directory.Exists(Path.GetDirectoryName(fileName)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
        }

        var config = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            Delimiter = ",",
        };

        if (File.Exists(fileName))
        {
            config.HasHeaderRecord = false;
        }
        else
        {
            config.HasHeaderRecord = true;
        }

        using var writer = new StreamWriter(fileName, true);
        using var csv = new CsvWriter(writer, config);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }
        csv.WriteRecord<T>(recordToSave);
        csv.NextRecord();
    }

    public void WriteRecordsToFile<T>(string fileName, List<T> recordsToSave, ClassMap? classMap = null)
    {
        if (recordsToSave == null)
        {
            throw new ArgumentNullException(nameof(recordsToSave), "Collection cannot be null!");
        }

        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName), "String cannot be null or empty!");
        }

        if (!Directory.Exists(Path.GetDirectoryName(fileName)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
        }

        var config = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ",",
        };

        using var writer = new StreamWriter(fileName);
        using var csv = new CsvWriter(writer, config);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }
        csv.WriteRecords<T>(recordsToSave);
    }

    /// <summary>
    /// This generic method is writing a <see cref="List{T}"/> to a csv file.
    /// <para></para>
    /// This method is using the NuGet package <see cref="CsvHelper"/>.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="recordsToSave"></param>
    /// <param name="classMap">
    /// A helper class to specify the column's order. 
    /// If null, then the class map will be handled automatically.
    /// </param>
    public async Task WriteRecordsToFileAsync<T>(string fileName, List<T> recordsToSave, ClassMap? classMap = null)
    {
        if (recordsToSave == null)
        {
            throw new ArgumentNullException(nameof(recordsToSave), "Collection cannot be null!");
        }

        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName), "String cannot be null or empty!");
        }

        if (!Directory.Exists(Path.GetDirectoryName(fileName)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
        }

        if (Directory.Exists(Path.GetDirectoryName(fileName)))
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
            };

            await using var writer = new StreamWriter(fileName);
            await using var csv = new CsvWriter(writer, config);
            if (classMap != null)
            {
                csv.Context.RegisterClassMap(classMap);
            }
            await csv.WriteRecordsAsync<T>(recordsToSave);
        }
        else
        {
            throw new Exception(nameof(fileName) + ": File or Directory does not exist!");
        }
    }

    /// <summary>
    /// This method is providing a hard coded list for testing.
    /// </summary>
    /// <returns></returns>
    private List<PaperDeliveryClient> ReadFromClientList()
    {
        List<PaperDeliveryClient> output = new()
        {
            new PaperDeliveryClient
            {
                Id = 2,
                TradeName = "Top Direkt Marktservice GmbH",
                TradeNameAdditionalInformation = string.Empty,
                PostalAddress = new PostalAddress()
                {
                    Street = "Frankfurter Str. 168",
                    StreetAdditionalInformation = string.Empty,
                    PostalCode = "34121",
                    City = "Kassel",
                    Country = "Germany",
                },
                ContactDetails = new ContactDetails()
                {
                    Email = string.Empty,
                    Mobile = string.Empty,
                    Phone = "0561 / 92094-0",
                },
            },
            new PaperDeliveryClient
            {
                Id = 1,
                TradeName = "Amazon Logistik GmbH",
                TradeNameAdditionalInformation = "Site - FRA1",
                PostalAddress = new PostalAddress()
                {
                    Street = "Am Schloss Eichhof 1",
                    StreetAdditionalInformation = string.Empty,
                    PostalCode = "36251 ",
                    City = "Bad Hersfeld",
                    Country = "Germany",
                },
                ContactDetails = new ContactDetails()
                {
                    Email = string.Empty,
                    Mobile = string.Empty,
                    Phone = "06621 / 956-0",
                },
            },
        };

        output.Sort();

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
                Id = "20230812KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 25, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230805KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230729KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230722KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 25, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230715KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 52, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230708KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 52, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230701KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230624KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(02, 19, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230617KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 35, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230610KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230603KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(02, 39, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230527KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(02, 05, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230520KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 35, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230819KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 25, 00),
            },
            new PaperDeliveryContract
            {
                Id = "20230826KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 52, 00),
            },
        };

        output.Sort();

        return output;
    }

    private List<PaperDeliveryContractor> ReadFromContractorList()
    {
        List<PaperDeliveryContractor> output = new()
        {
            new PaperDeliveryContractor()
            {
                Id = 1,
                FirstName = "Thorsten",
                LastName = "Jenning",
                Gender = Gender.male,
                Site = "Vor der Haustür",
                ContactDetails = new ContactDetails()
                {
                    Email = "jenning.thorsten@gmx.net",
                    Mobile = "01573 / 06 02 188",
                    Phone = "06621 / 96 66 52",
                },
                PostalAddress = new PostalAddress()
                {
                    Street = "Breslauer Str. 7",
                    StreetAdditionalInformation = string.Empty,
                    PostalCode = "36251 ",
                    City = "Bad Hersfeld",
                    Country = "Germany",
                },
            },
            new PaperDeliveryContractor()
            {
                Id = 3,
                FirstName = "Silvana",
                LastName = "Hainer",
                Gender = Gender.female,
                Site = "Vor der Haustür",
                ContactDetails = new ContactDetails()
                {
                    Email = "s.hainer@icloud.com",
                    Mobile = "0174 / 19 85 444",
                    Phone = string.Empty,
                },
                PostalAddress = new PostalAddress()
                {
                    Street = "Breslauer Str. 7",
                    StreetAdditionalInformation = string.Empty,
                    PostalCode = "36251 ",
                    City = "Bad Hersfeld",
                    Country = "Germany",
                },
            },
            new PaperDeliveryContractor()
            {
                Id = 2,
                FirstName = "Melanie",
                LastName = "Jenning",
                Gender = Gender.female,
                Site = string.Empty,
                ContactDetails = new ContactDetails()
                {
                    Email = "jenning.melanie@outlook.de",
                    Mobile = "01575 / 64 65 178",
                    Phone = "06621 / 96 66 52",
                },
                PostalAddress = new PostalAddress()
                {
                    Street = "Breslauer Str. 7",
                    StreetAdditionalInformation = string.Empty,
                    PostalCode = "36251 ",
                    City = "Bad Hersfeld",
                    Country = "Germany",
                },
            },
        };

        output.Sort();

        return output;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="test"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Test(string test)
    {
        throw new NotImplementedException();
    }
}
