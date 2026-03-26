using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.DropboxSign.HttpClients.Registrars;
using Soenneker.DropboxSign.OpenApiClientUtil.Abstract;

namespace Soenneker.DropboxSign.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class DropboxSignOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="DropboxSignOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDropboxSignOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDropboxSignOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IDropboxSignOpenApiClientUtil, DropboxSignOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="DropboxSignOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDropboxSignOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddDropboxSignOpenApiHttpClientAsSingleton()
                .TryAddScoped<IDropboxSignOpenApiClientUtil, DropboxSignOpenApiClientUtil>();

        return services;
    }
}
