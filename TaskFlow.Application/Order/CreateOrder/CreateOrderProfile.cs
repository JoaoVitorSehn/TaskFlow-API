using TaskFlow.Domain.Entities;
using AutoMapper;

namespace TaskFlow.Application.Order.CreateOrder;

public class CreateOrderProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateOrder operation
    /// </summary>
    public CreateOrderProfile()
    {
        CreateMap<CreateOrderCommand, Order>();
        CreateMap<Order, CreateOrderResult>();
    }
}