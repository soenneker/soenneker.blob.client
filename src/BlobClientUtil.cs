using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Soenneker.Blob.Client.Abstract;
using Soenneker.Blob.Container.Abstract;
using Soenneker.Extensions.ValueTask;

namespace Soenneker.Blob.Client;

///<inheritdoc cref="IBlobClientUtil"/>
public sealed class BlobClientUtil : IBlobClientUtil
{
    private readonly IBlobContainerUtil _blobContainerUtil;

    public BlobClientUtil(IBlobContainerUtil blobContainerUtil)
    {
        _blobContainerUtil = blobContainerUtil;
    }

    public async ValueTask<BlobClient> Get(string containerName, string relativeUrl, PublicAccessType publicAccessType = PublicAccessType.None, CancellationToken cancellationToken = default)
    {
        BlobContainerClient containerClient = await _blobContainerUtil.Get(containerName, publicAccessType, cancellationToken).NoSync();

        return containerClient.GetBlobClient(relativeUrl);
    }
}