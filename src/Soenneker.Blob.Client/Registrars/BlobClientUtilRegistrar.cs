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
    public static IServiceCollection AddBlobClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton()
                .TryAddSingleton<IBlobClientUtil, BlobClientUtil>();

        return services;
    }

    public static IServiceCollection AddBlobClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton()
                .TryAddScoped<IBlobClientUtil, BlobClientUtil>();

        return services;
    }
}