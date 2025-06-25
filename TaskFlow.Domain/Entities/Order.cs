using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

/// <summary>
/// Represents a service or product order within the system.
/// </summary>
public class Order : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique order number.
    /// Used to identify and track the order internally.
    /// </summary>
    [Required]
    public string Number { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the creation date and time of the order.
    /// This value is set when the order is first registered in the system.
    /// </summary>
    [Required]
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Gets or sets the last modification date and time of the order.
    /// Used for auditing and tracking changes over time.
    /// </summary>
    [Required]
    public DateTime ChangedAt { get; set; }

    /// <summary>
    /// Gets or sets the forecasted completion date and time of the order.
    /// This is an estimated value and may be adjusted during the order's lifecycle.
    /// </summary>
    [Required]
    public DateTime ForecastAt { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the order.
    /// Provides context and relevant information about the service or product requested.
    /// </summary>
    [Required]
    [MaxLength(1500)]
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the unique identifier of the user who created or is responsible for the order.
    /// This serves as a foreign key reference to the associated employee.
    /// </summary>
    [ForeignKey(nameof(Employee))]
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the customer associated with the order.
    /// Serves as a foreign key reference to the related customer entity.
    /// </summary>
    [ForeignKey(nameof(Customer))]
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the total price of the order.
    /// Represents the full amount to be charged for the products or services included in the order.
    /// </summary>
    public decimal Price { get; set; } = 0.0m;

    /// <summary>
    /// Gets or sets the current status of the order.
    /// Used to track the progress and lifecycle of the order (e.g., Pending, InProgress, Completed).
    /// </summary>
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    /// <summary>
    /// Gets or sets the employee responsible for the order.
    /// Represents the navigation property to the related user entity.
    /// </summary>
    public virtual User Employee { get; set; }

    /// <summary>
    /// Gets or sets the customer linked to the order.
    /// Represents the navigation property to the related customer entity.
    /// </summary>
    public virtual Customer Customer { get; set; }
}