using FluentValidation;

namespace TaskFlow.Application.Order.CreateOrder;

/// <summary>
/// Validator for CreateOrderCommand that defines validation rules for Order creation command.
/// </summary>
public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateOrderRequestValidator"/> class with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Number: Must not be empty.
    /// - ForecastAt: Must be greater than or equal to now.
    /// - Description: Must not be empty and up to 1500 characters.
    /// - Price: Must be greater than zero.
    /// - UserId: Must not be empty.
    /// - CustomerId: Must not be empty.
    /// </remarks>
    public CreateOrderValidator()
    {
        RuleFor(order => order.Number)
            .NotEmpty()
            .WithMessage("Order number is required.");

        RuleFor(order => order.ForecastAt)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Forecast date must be greater than or equal to the current date.");

        RuleFor(order => order.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(1500)
            .WithMessage("Description must be 1500 characters or less.");

        RuleFor(order => order.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");

        RuleFor(order => order.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.");

        RuleFor(order => order.CustomerId)
            .NotEmpty()
            .WithMessage("Customer ID is required.");
    }
}