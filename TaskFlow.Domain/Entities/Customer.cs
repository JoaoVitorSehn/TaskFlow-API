using System.ComponentModel.DataAnnotations;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities;

/// <summary>
/// Represents a customer in the system, responsible for create orders.
/// This entity follows the External Identities pattern.
/// </summary>
public class Customer : BaseEntity
{
    /// <summary>
    /// Gets or sets the customer's CPF or CNPJ document number.
    /// This value is used for identification and may represent either an individual (CPF) or a company (CNPJ).
    /// </summary>
    [Required] 
    public string CpfCnpj { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the customer's full name.
    /// This value is denormalized for quick access and reporting purposes.
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the customer's email address.
    /// This value is stored for notification and contact purposes.
    /// </summary>
    public string Email { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the phone number of the customer.
    /// This can be used for verification or customer support purposes.
    /// </summary>
    public string PhoneNumber { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the date when the customer was registered.
    /// This information is useful for tracking customer history.
    /// </summary>
    public DateTime RegisteredAt { get; set; }

    /// <summary>
    /// Gets or sets the date that last change was made.
    /// This information is useful for tracking customer history.
    /// </summary>
    public DateTime ChangedAt { get; set; }
}