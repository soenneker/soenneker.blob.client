using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blob.Client.Abstract;
using Soenneker.Blob.Container.Registrars;

namespace Soenneker.Blob.Client.Registrars;

/// <summary>
/// A utility library for Azure Blob storage client operations
/// </summary>
public static class BlobClientUtilRegistrar
{
    /// <summary>
    /// Registers Blob Client Util with a singleton lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddBlobClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton()
                .TryAddSingleton<IBlobClientUtil, BlobClientUtil>();

        return services;
    }

    /// <summary>
    /// Registers Blob Client Util with a scoped lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddBlobClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton()
                .TryAddScoped<IBlobClientUtil, BlobClientUtil>();

        return services;
    }
}
