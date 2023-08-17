namespace PaperDeliveryLibrary.Models;

/// <summary>
/// This class is providing members to calculate the salary, contribution and taxes 
/// of a minijobber in a business environment.
/// <br></br>
/// For minijobber in a private environment look at <see cref="PrivateMiniJob"/>.
/// <para></para>
/// These calculations are based on german law.
/// A detailed description is provided on this website:
/// https://www.minijob-zentrale.de/DE/fuer-gewerbetreibende/fuer-gewerbetreibende_node.html
/// </summary>
public class BusinessMiniJob : AccountingBase
{
    public const double Mindestbeitrag = Mindestbeitragsbemessungsgrundlage * (RentenversichungArbeitgeberPflichtanteil + RentenversichungArbeitnehmerPflichtanteil);
    public const double Mindestbeitragsbemessungsgrundlage = 175.00;
    public const double RentenversichungArbeitnehmerPflichtanteil = 0.036;
    public const double RentenversichungArbeitgeberPflichtanteil = 0.15;

    public static void Settings()
    {
        Console.WriteLine($"{nameof(RentenversichungArbeitgeberPflichtanteil)}: {RentenversichungArbeitgeberPflichtanteil}");
        Console.WriteLine($"{nameof(RentenversichungArbeitnehmerPflichtanteil)}: {RentenversichungArbeitnehmerPflichtanteil}");
        Console.WriteLine($"{nameof(Mindestbeitragsbemessungsgrundlage)}: {Mindestbeitragsbemessungsgrundlage}");
        Console.WriteLine($"{nameof(Mindestbeitrag)}: {Mindestbeitrag}");
    }

    public static double CalculateEmployerStatutoryPensionContribution(double grossSalary)
    {
        if (grossSalary <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(grossSalary), "The argument must have a positive value!");
        }

        return grossSalary * RentenversichungArbeitgeberPflichtanteil;
    }

    public static double CalculateEmployeeStatutoryPensionContribution(double grossSalary)
    {
        if (grossSalary <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(grossSalary), "The argument must have a positive value!");
        }

        double contributionEmployee = grossSalary * RentenversichungArbeitnehmerPflichtanteil;
        double remainingDifference = 0;

        if ((contributionEmployee + CalculateEmployerStatutoryPensionContribution(grossSalary)) < Mindestbeitrag)
        {
            remainingDifference = Mindestbeitrag - contributionEmployee - CalculateEmployerStatutoryPensionContribution(grossSalary);
        }

        return contributionEmployee + remainingDifference;
    }

    public static double CalculateEmployeeSalary(double grossSalary)
    {
        if (grossSalary <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(grossSalary), "The argument must have a positive value!");
        }

        return grossSalary - CalculateEmployeeStatutoryPensionContribution(grossSalary);
    }
}
