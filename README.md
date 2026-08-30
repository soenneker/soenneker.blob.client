[![](https://img.shields.io/nuget/v/Soenneker.Blob.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blob.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Blob.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blob.client/actions/workflows/codeql.yml)

# Soenneker.Blob.Client

Resolves Azure `BlobClient` instances through a cached container client and creates a missing container before returning the blob client.

## Install

```bash
dotnet add package Soenneker.Blob.Client
```

Configure the Azure Storage connection string:

```json
{
  "Azure": {
    "Storage": {
      "Blob": {
        "ConnectionString": "<connection string>"
      }
    }
  }
}
```

Keep the real value in an environment-specific secret provider rather than committing it to configuration files.

Register the utility in `Program.cs`:

```csharp
using Soenneker.Blob.Client.Registrars;

builder.Services.AddBlobClientUtilAsSingleton();
```

The singleton registration is the usual choice. A scoped registration is available, but it still uses the singleton container cache.

## Resolve a blob client

```csharp
using Azure.Storage.Blobs;
using Soenneker.Blob.Client.Abstract;

public sealed class InvoiceStore(IBlobClientUtil blobClients)
{
    public async ValueTask<BlobClient> GetInvoice(
        Guid invoiceId,
        CancellationToken cancellationToken)
    {
        return await blobClients.Get(
            "invoices",
            $"2026/{invoiceId:N}.pdf",
            cancellationToken: cancellationToken);
    }
}
```

`relativeUrl` is an Azure blob name, not a URL. Slashes create a virtual hierarchy in tools and listings, but the name remains one blob key.

The returned `BlobClient` can be used with the Azure SDK directly:

```csharp
BlobClient blob = await blobClients.Get(
    "invoices",
    "2026/summary.pdf",
    cancellationToken: cancellationToken);

await blob.UploadAsync(stream, overwrite: true, cancellationToken);
```

## Container behavior

- Container names are converted to lowercase before lookup.
- The first lookup for a container checks Azure and creates it if missing.
- `PublicAccessType.None` is the default and keeps a newly created container private.
- `publicAccessType` is used only when creating a missing container. It does not inspect or change the access policy of an existing container.
- Container clients are cached by normalized container name. Use one consistent public-access choice for each container.

## Operational notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Resolving a blob client can perform a container existence check or creation, so it is not a purely local factory call.
- This utility does not upload, download, overwrite, delete, or authorize individual blobs; those behaviors come from the returned Azure SDK client and its credentials.
- Treat public container access as an explicit data-exposure decision. Prefer private containers and SAS URLs for limited external access.
