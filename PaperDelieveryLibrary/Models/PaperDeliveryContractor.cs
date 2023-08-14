using BasicCodingLibrary.Enums;
using System.Diagnostics.Contracts;

namespace PaperDeliveryLibrary.Models;

public class PaperDeliveryContractor : IPaperDeliveryContractor, IComparable<PaperDeliveryContractor>
{
    public string City { get; set; } = "default";
    public string ContractorID { get; set; } = "default";
    public string Email { get; set; } = "default";
    public string FirstName { get; set; } = "default";
    public Gender Gender { get; set; } = Gender.unknown;
    public string LastName { get; set; } = "default";
    public string Phone { get; set; } = "default";
    public string PostalCode { get; set; } = "default";
    public string Site { get; set; } = "default";
    public string Street { get; set; } = "default";

    /// <summary>
    /// This method is providing logic to compare the instance's property <see cref="ContractorID"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(PaperDeliveryContractor? other)
    {
        return other == null ? 1 : ContractorID.CompareTo(other.ContractorID);
    }

    /// <summary>
    /// This method returns the expression <b>ContractorID</b>
    /// followed by the property <see cref="ContractorID"/>.
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <returns>A nongeneric string.</returns>
    public override string ToString()
    {
        return $"ContractorID {ContractorID}";
    }

    /// <summary>
    /// <inheritdoc/>
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>The comparison result of two objects of <see cref="PaperDeliveryContractor"/>
    /// based on the property <see cref="ContractorID"/>.</returns>
    public override bool Equals(object? obj)
    {
        return CompareTo(obj as PaperDeliveryContractor) == 0;
    }

    /// <summary>
    /// <inheritdoc/>
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <returns>The hash value of <see cref="ContractorID"/></returns>
    public override int GetHashCode()
    {
        return ContractorID.GetHashCode();
    }
}
