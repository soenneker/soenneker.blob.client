using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Soenneker.Blob.Client.Abstract;

/// <summary>
/// Resolves Azure Blob clients through the shared container-client cache.
/// </summary>
public interface IBlobClientUtil
{
    /// <summary>
    /// Gets a client for a blob, creating the container when the shared container utility first resolves it and it does not exist.
    /// </summary>
    /// <param name="containerName">Name of the container to target.</param>
    /// <param name="relativeUrl">Blob name within the container. The name may contain slash-separated virtual path segments.</param>
    /// <param name="publicAccessType">Public access level to use only if the container must be created.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A client targeting the requested blob.</returns>
    ValueTask<BlobClient> Get(string containerName, string relativeUrl, PublicAccessType publicAccessType = PublicAccessType.None, CancellationToken cancellationToken = default);
}
