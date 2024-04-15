using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Soenneker.Blob.Client.Abstract;

/// <summary>
/// This should be used for any connection to Blob storage that is needed due to it's reuse of connections. <para/>
/// </summary>
public interface IBlobClientUtil
{
    /// <summary>
    /// Will create container if it doesn't exist (if we haven't accessed this container since app restart)
    /// NOTE: <paramref name="containerName"/> will be converted to lowercase. 
    /// </summary>
    ValueTask<BlobClient> Get(string containerName, string relativeUrl, PublicAccessType publicAccessType = PublicAccessType.None);
}