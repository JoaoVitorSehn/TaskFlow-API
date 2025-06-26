using Microsoft.Extensions.DependencyInjection;

namespace TaskFlow.IoC;

public interface IModuleInitializer
{
    void Initialize(IServiceCollection services);
}