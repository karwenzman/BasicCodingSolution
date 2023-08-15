using System.Text;

namespace PaperDeliveryLibrary.Models;

public class PaperDeliveryContract : IComparable<PaperDeliveryContract>
{
    public string Id { get; set; } = "default";
    public double HourlyWageRate { get; set; }
    public int NumberOfPapers { get; set; }
    public string Region { get; set; } = "default";
    public string Route { get; set; } = "default";
    public string Site { get; set; } = "default";
    public TimeOnly StandardizedWorkingHours { get; set; }


    /// <summary>
    /// This method is providing logic to compare the instance's property <see cref="Id"/>.
    /// If comparison based solely on values returns zero, 
    /// indicating that two instances are equal in those fields they have in common, 
    /// only then we break the tie by comparing data types of the two instances.
    /// For reference of this implementation see:
    /// https://www.codinghelmet.com/articles/implement-icomparable-t
    /// <para></para>
    /// This method is implemented by the interface <see cref="IComparable{T}"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(PaperDeliveryContract? other)
    {
        int result = CompareToValues(other);

        if (result == 0)
        {
            result = CompareToTypes(other);
        }

        return result;
    }

    /// <summary>
    /// This method is comparing the property <see cref="Id"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    protected virtual int CompareToValues(PaperDeliveryContract? other)
    {
        return other == null ? 1 : Id.CompareTo(other.Id);
    }

    /// <summary>
    /// This method is comparing the type of the base class and its derived class.
    /// Base type is considered less than derived type
    /// when two instances have the same values of the property <see cref="Id"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    protected int CompareToTypes(PaperDeliveryContract? other)
    {
        int result = 0;

        Type thisType = this.GetType();
        Type otherType = other!.GetType();

        if (otherType.IsSubclassOf(thisType))
        {
            result = -1;
        }
        else if (thisType.IsSubclassOf(otherType))
        {
            result = 1;
        }
        else if (thisType != otherType)
        {
            result = thisType.FullName!.CompareTo(otherType.FullName);
        }

        return result;
    }

    /// <summary>
    /// This method returns the expression <b>ContractID</b>
    /// followed by the property <see cref="Id"/>.
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <returns>A nongeneric string.</returns>
    public override string ToString()
    {
        return $"ContractID {Id}";
    }

    /// <summary>
    /// <inheritdoc/>
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return CompareTo(obj as PaperDeliveryContract) == 0;
    }

    /// <summary>
    /// <inheritdoc/>
    /// <para></para>
    /// This method is overriding the base functionality of the type <see cref="object"/>.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// This method returns the content of the <see cref="PaperDeliveryContract"/> object.
    /// The content is formated in a way to be used on a concole application.
    /// </summary>
    /// <returns>A nongeneric <see cref="StringBuilder"/>.</returns>
    public StringBuilder ToConsole()
    {
        StringBuilder output = new();

        output.AppendLine($"\nContractID {Id} - Tour {Route} {Site} {Region}");
        output.AppendLine($"{"Workload",10} {"Schedule",10} {"HourlyWage",12}");
        output.AppendLine($"{NumberOfPapers,10} {StandardizedWorkingHours,10} {HourlyWageRate,12:c2}");
        return output;
    }
}
