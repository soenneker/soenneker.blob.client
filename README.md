[![](https://img.shields.io/nuget/v/Soenneker.Blob.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blob.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Blob.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blob.client/actions/workflows/codeql.yml)

# Soenneker.Blob.Client

This should be used for any connection to Blob storage that is needed due to it's reuse of connections.

## Install

```bash
dotnet add package Soenneker.Blob.Client
```

## Quick start

```csharp
using Soenneker.Blob.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddBlobClientUtilAsSingleton();
```

Registers Blob Client Util with a singleton lifetime.

## What you get

- `IBlobClientUtil` — This should be used for any connection to Blob storage that is needed due to it's reuse of connections.
- `BlobClientUtilRegistrar` — A utility library for Azure Blob storage client operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IBlobClientUtil.Get(containerName, relativeUrl, publicAccessType, cancellationToken)` | Will create container if it doesn't exist (if we haven't accessed this container since app restart) NOTE: `containerName` will be converted to lowercase. | A task whose result is the requested blob Client. |
| `BlobClientUtilRegistrar.AddBlobClientUtilAsSingleton(services)` | Registers Blob Client Util with a singleton lifetime. | The same service collection, so additional registrations can be chained. |
| `BlobClientUtilRegistrar.AddBlobClientUtilAsScoped(services)` | Registers Blob Client Util with a scoped lifetime. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
