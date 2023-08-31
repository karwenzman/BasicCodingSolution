﻿namespace PaperDeliveryLibrary.Models;

public class PaperDeliverySetting
{
    public string ContractFile { get; set; } = "default";
    public string ContractorFile { get; set; } = "default";
    public string ClientFile { get; set; } = "default";
    public string FulfillmentFile { get; set; } = "default";
    public string PaperDeliveryDirectory { get; set; } = "default";

    public PaperDeliverySetting()
    {
    }

    //public PaperDeliverySetting(PaperDeliverySetting paperDeliverySetting)
    //{
    //    ClientFile = paperDeliverySetting.ClientFile;
    //    ContractFile = paperDeliverySetting.ContractFile;
    //    ContractorFile = paperDeliverySetting.ContractorFile;
    //    FulfillmentFile = paperDeliverySetting.FulfillmentFile;
    //    PaperDeliveryDirectory = paperDeliverySetting.PaperDeliveryDirectory;
    //}

    //public PaperDeliverySetting(IAppSettingModel appSettingModel)
    //{
    //    appSettingModel ??= new AppSettingModel();

    //    ContractFile = appSettingModel.PaperDeliverySetting.ContractFile;
    //    ContractorFile = appSettingModel.PaperDeliverySetting.ContractorFile;
    //    ClientFile = appSettingModel.PaperDeliverySetting.ClientFile;
    //    FulfillmentFile = appSettingModel.PaperDeliverySetting.FulfillmentFile;
    //    PaperDeliveryDirectory = appSettingModel.PaperDeliverySetting.PaperDeliveryDirectory;
    //}
}