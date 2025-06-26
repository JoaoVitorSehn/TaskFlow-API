using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Order.CreateOrder;
using TaskFlow.WebApi.Features.Orders.CreateOrder;

namespace TaskFlow.WebApi.Features.Orders;

public static class OrderExtension
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("orders").WithTags("Orders");

        group.MapPost("", async ([FromBody] CreateOrderRequest request, IMapper mapper, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var validator = new CreateOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors);

            var command = mapper.Map<CreateOrderCommand>(request);
            var result = await mediator.Send(command, cancellationToken);

            return Results.Created(
                uri: string.Empty,
                value: mapper.Map<CreateOrderResponse>(result));
        })
        .WithName("CreateSale")
        .WithTags("Sales");

        return app;
    }
}