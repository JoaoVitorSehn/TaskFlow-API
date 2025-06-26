using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Text.Json;
using TaskFlow.Common.Validation;
using TaskFlow.WebApi.Features.Orders;

namespace TaskFlow.WebApi;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.RegisterDependencies();
        services.AddAuthorizationSettings();
        services.AddMySql(configuration);
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddAuditConfigs();
        services.AddSwaggerGen();
        services.AddRateLimiter();
        services.AddHttpConfigs();
        services.AddDefaultLogging();
        services.AddHttpClients(configuration);
        services.AddJwtAuthentication(builder.Configuration);

        services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRateLimiter();
        app.UseRouting();
        app.UseMiddleware<ExceptionsMiddleware>();

        app.UseEndpoints(action => 
        { 
            action.MapOrderEndpoints();
            /// other endpoints can be mapped here
        });

        builder.Services
        builder.Services.AddDbContext<DefaultContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
            )
        );
        app.UseAuthorization();
        app.UseAuthentication();
        app.UseEndpoints(action => { action.MapEndpoints(); });
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var error = new { message = contextFeature.Error.Message };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(error));
                    Console.WriteLine($"Stack Trace: {contextFeature.Error.StackTrace}");
                }
            });
        });

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}