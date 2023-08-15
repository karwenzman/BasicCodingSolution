namespace PaperDeliveryLibrary.Models;

public class PaperDeliveryContractor : Person, IComparable<PaperDeliveryContractor>
{
    /// <summary>
    /// The information where the carrier shall drop the papers.
    /// </summary>
    public string Site { get; set; } = "default";

    /// <summary>
    /// This method is providing logic to compare the instance's property <see cref="Person.Id"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(PaperDeliveryContractor? other)
    {
        return other == null ? 1 : Id.CompareTo(other.Id);
    }

    /// <summary>
    /// This method returns the expression <b>ContractorID</b>
    /// followed by the property <see cref="Person.Id"/>.
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <returns>A nongeneric string.</returns>
    public override string ToString()
    {
        return $"ContractorID {Id}";
    }

    /// <summary>
    /// <inheritdoc/>
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>The comparison result of two objects of <see cref="PaperDeliveryContractor"/>
    /// based on the property <see cref="Person.Id"/>.</returns>
    public override bool Equals(object? obj)
    {
        return CompareTo(obj as PaperDeliveryContractor) == 0;
    }

    /// <summary>
    /// <inheritdoc/>
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <returns>The hash value of <see cref="Person.Id"/></returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
