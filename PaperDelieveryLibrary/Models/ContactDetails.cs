using BasicCodingLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperDeliveryLibrary.Models;

public class ContactDetails
{
    /// <summary>
    /// The contact's email address.
    /// </summary>
    public string Email { get; set; } = "default";
    /// <summary>
    /// The contact's mobile number.
    /// </summary>
    public string Mobile { get; set; } = "default";
    /// <summary>
    /// The contact's phone number.
    /// </summary>
    public string Phone { get; set; } = "default";
}
