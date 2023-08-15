namespace PaperDeliveryLibrary.Models;

public class PaperDeliveryClient : IComparable<PaperDeliveryClient>
{
    /// <summary>
    /// The client's additional name information.
    /// </summary>
    public string AdditionalInformation { get; set; } = "default";
    /// <summary>
    /// The client's contact details.
    /// </summary>
    public ContactDetails ContactDetails { get; set; } = new ContactDetails();
    /// <summary>
    /// The client's unique ID.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The client's name.
    /// </summary>
    public string Name { get; set; } = "default";
    /// <summary>
    /// The client's postal address.
    /// </summary>
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
    /// <returns>A nongeneric string.</returns>
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
}
