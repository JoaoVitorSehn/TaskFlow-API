using Audit.Core;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace TaskFlow.IoC.ModulesInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    /// <summary>
    /// Initializes the infrastructure modules for the application.
    /// </summary>
    public void Initialize(IServiceCollection services)
    {

    }

    public static void AddAuditConfigs(IServiceCollection _)
    {
        Configuration.Setup().UseEntityFramework(_ => _
        .AuditTypeExplicitMapper(_ => _
            .Map<License, AuditLog>()
            .AuditEntityAction<AuditLog>((evt, entry, log) => log.Fill(evt, entry)))
            .IgnoreMatchedProperties(true));
    }
}