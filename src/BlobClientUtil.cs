using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Soenneker.Blob.Client.Abstract;
using Soenneker.Blob.Container.Abstract;

namespace Soenneker.Blob.Client;

///<inheritdoc cref="IBlobClientUtil"/>
public class BlobClientUtil : IBlobClientUtil
{
    private readonly IBlobContainerUtil _blobContainerUtil;

    public BlobClientUtil(IBlobContainerUtil blobContainerUtil)
    {
        _blobContainerUtil = blobContainerUtil;
    }

    public async ValueTask<BlobClient> GetClient(string containerName, string relativeUrl, PublicAccessType publicAccessType = PublicAccessType.None)
    {
        string containerLower = containerName.ToLowerInvariant();

        BlobContainerClient containerClient = await _blobContainerUtil.GetClient(containerLower, publicAccessType);

        BlobClient client = containerClient.GetBlobClient(relativeUrl);

        return client;
    }
}