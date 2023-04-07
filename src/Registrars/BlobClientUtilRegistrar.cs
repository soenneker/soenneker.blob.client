using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blob.Client.Abstract;

namespace Soenneker.Blob.Client.Registrars;

/// <summary>
/// A utility library for Azure Blob storage client operations
/// </summary>
public static class BlobClientUtilRegistrar
{
    /// <summary>
    /// Recommended
    /// </summary>
    public static void AddBlobClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IBlobClientUtil, BlobClientUtil>();
    }

    public static void AddBlobClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IBlobClientUtil, BlobClientUtil>();
    }
}
