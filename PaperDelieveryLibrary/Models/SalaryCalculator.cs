namespace PaperDeliveryLibrary.Models;

public class SalaryCalculator
{
    public double GrossSalary { get; set; }
    public double Salary { get; set; }
    public double TaxEmployer { get; set; }
    public double TaxRateEmployer { get; set; } = 0.15;
    public double TaxEmployee { get; set; }
    public double TaxRateEmployee { get; set; } = 0.036;
    public double TaxRate { get; set; }
    public double Mindestbeitragsbemessungsgrundlage { get; set; } = 175.00;
    public double Mindestbeitrag { get; set; } = 32.55;
    public double Differenzbeitrag { get; set; }

    public SalaryCalculator(double grossSalary)
    {
        TaxRate = TaxEmployee + TaxEmployer;
        TaxEmployee = grossSalary * TaxRateEmployee;
        TaxEmployer = grossSalary * TaxRateEmployer;

        if ((TaxEmployee + TaxEmployer) < Mindestbeitrag)
        {
            Differenzbeitrag = Mindestbeitrag - TaxEmployer - TaxEmployee;
            Salary = grossSalary - Differenzbeitrag - TaxEmployee;
        }
        else
        {
            Salary = grossSalary - TaxEmployee;
        }

        Console.WriteLine($"Brutto:           {grossSalary,8:c2} => AG-Anteil: {TaxEmployer,8:c2}");
        Console.WriteLine($"AN-Anteil:        {TaxEmployee * -1,8:c2}");
        Console.WriteLine($"Differenzbeitrag: {Differenzbeitrag * -1,8:c2} => AN-Anteil: {TaxEmployee + Differenzbeitrag,8:c2}");
        Console.WriteLine($"Netto:            {Salary,8:c2}");

    }
}
