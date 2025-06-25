namespace TaskFlow.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// Represents a request to create a new order in the system.
/// </summary>
public class CreateOrderRequest
{
    /// <summary>
    /// Gets or sets the unique order number. Must be unique within the system.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the forecasted completion date for the order.
    /// Used to estimate delivery or finalization.
    /// </summary>
    public DateTime ForecastAt { get; set; } = DateTime.Now.AddDays(7);

    /// <summary>
    /// Gets or sets the order description. Limited to 1500 characters.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier of the user responsible for the order.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the customer associated with the order.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the total price of the order.
    /// Represents the full amount to be charged for the products or services included in the order.
    /// </summary>
    public decimal Price { get; set; } = 0.0m;
}