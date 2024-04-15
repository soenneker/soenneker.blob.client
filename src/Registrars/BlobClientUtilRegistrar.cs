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
    public static void AddBlobClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton();
        services.TryAddSingleton<IBlobClientUtil, BlobClientUtil>();
    }

    public static void AddBlobClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton();
        services.TryAddScoped<IBlobClientUtil, BlobClientUtil>();
    }
}
