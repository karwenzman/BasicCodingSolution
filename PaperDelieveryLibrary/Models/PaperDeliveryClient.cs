﻿using System.Text;

namespace PaperDeliveryLibrary.Models;

public class PaperDeliveryClient : IComparable<PaperDeliveryClient>
{
    public int Id { get; set; }

    public string TradeName { get; set; } = "default";

    public string TradeNameAdditionalInformation { get; set; } = "default";

    public ContactDetails ContactDetails { get; set; } = new ContactDetails();

    public PostalAddress PostalAddress { get; set; } = new PostalAddress();

    /// <summary>
    /// This method is providing logic to compare the instance's property <see cref="Id"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(PaperDeliveryClient? other)
    {
        return other == null ? 1 : Id.CompareTo(other.Id);
    }

    /// <summary>
    /// This method returns the expression <b>ClientID</b>
    /// followed by the property <see cref="Id"/>.
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <returns>A nongeneric <see cref="string"/>.</returns>
    public override string ToString()
    {
        return $"ClientID {Id}";
    }

    /// <summary>
    /// <inheritdoc/>
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>The comparison result of two objects of <see cref="PaperDeliveryClient"/>
    /// based on the property <see cref="ContractorID"/>.</returns>
    public override bool Equals(object? obj)
    {
        return CompareTo(obj as PaperDeliveryClient) == 0;
    }

    /// <summary>
    /// <inheritdoc/>
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <returns>The hash value of <see cref="Id"/></returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// This method returns the content of the <see cref="PaperDeliveryClient"/> object.
    /// The content is formated in a way to be used on a concole application.
    /// </summary>
    /// <returns>A nongeneric <see cref="StringBuilder"/>.</returns>
    public StringBuilder ToConsole()
    {
        StringBuilder output = new();

        output.AppendLine(($"\nClientID {Id}"));
        output.AppendLine($"\t{TradeName}");
        if (!string.IsNullOrEmpty(TradeNameAdditionalInformation))
        {
            output.AppendLine($"\t{TradeNameAdditionalInformation}");
        }
        output.AppendLine($"\t{PostalAddress.Street}");
        if (!string.IsNullOrEmpty(PostalAddress.StreetAdditionalInformation))
        {
            output.AppendLine($"\t{PostalAddress.StreetAdditionalInformation}");
        }
        output.AppendLine($"\t{PostalAddress.PostalCode} {PostalAddress.City}");
        output.AppendLine($"\t{PostalAddress.Country}");
        if (!string.IsNullOrEmpty(ContactDetails.Email))
        {
            output.AppendLine($"\tEmail: {ContactDetails.Email}");
        }
        if (!string.IsNullOrEmpty(ContactDetails.Mobile))
        {
            output.AppendLine($"\tMobile: {ContactDetails.Mobile}");
        }
        if (!string.IsNullOrEmpty(ContactDetails.Phone))
        {
            output.AppendLine($"\tPhone: {ContactDetails.Phone}");
        }

        return output;
    }
}
