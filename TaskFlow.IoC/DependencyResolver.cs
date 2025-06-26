using Microsoft.Extensions.DependencyInjection;
using TaskFlow.IoC.ModulesInitializers;

namespace TaskFlow.IoC;

public static class DependencyResolver
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        new WebEndpointsInitializer().Initialize(services);
        new ApplicationServicesInitializer().Initialize(services);
        new InfrastructureModuleInitializer().Initialize(services);
    }
}