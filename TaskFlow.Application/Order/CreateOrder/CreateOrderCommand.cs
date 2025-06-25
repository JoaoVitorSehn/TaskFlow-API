namespace TaskFlow.Application.Order.CreateOrder;

/// <summary>
/// Command for creating a new order.
/// </summary>
/// <remarks>
/// This command captures the necessary data to create a new order,
/// including number, description, creation and forecast dates, user and customer identifiers, and status.
/// 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// that returns a <see cref="CreateOrderResult"/>.
/// 
/// The data provided in this command is validated using the
/// <see cref="CreateOrderValidator"/>, which extends
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
/// populated and follow the required business rules.
/// </remarks>
public class CreateOrderCommand
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
}