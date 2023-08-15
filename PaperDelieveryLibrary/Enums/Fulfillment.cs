namespace PaperDeliveryLibrary.Enums;

/// <summary>
/// This enum provides members to describe how a contract was fulfilled by the contractor.
/// </summary>
public enum Fulfillment
{
    None,
    PaidLeave,
    UnpaidLeave,
    SickLeave,
    Regular,
}
