using Soenneker.DropboxSign.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.DropboxSign.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IDropboxSignOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<DropboxSignOpenApiClient> Get(CancellationToken cancellationToken = default);
}
