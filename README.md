[![](https://img.shields.io/nuget/v/soenneker.dropboxsign.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dropboxsign.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dropboxsign.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dropboxsign.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dropboxsign.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dropboxsign.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dropboxsign.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dropboxsign.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.DropboxSign.OpenApiClientUtil

Provides a lazily created, cached Dropbox Sign client backed by `Soenneker.DropboxSign.HttpClients`.

## Installation

```bash
dotnet add package Soenneker.DropboxSign.OpenApiClientUtil
```

## Configuration and registration

```json
{
  "DropboxSign": {
    "ApiKey": "your-api-key"
  }
}
```

```csharp
using Soenneker.DropboxSign.OpenApiClientUtil.Registrars;

services.AddDropboxSignOpenApiClientUtilAsScoped();
```

The underlying provider uses API-key Basic authentication by default. Set `DropboxSign:AuthHeaderValueTemplate` to `Bearer {token}` when `ApiKey` contains an OAuth access token.

## Usage

```csharp
using Soenneker.DropboxSign.OpenApiClientUtil.Abstract;

public sealed class DropboxSignAccountReader(IDropboxSignOpenApiClientUtil clients)
{
    public async Task Read(CancellationToken cancellationToken)
    {
        var client = await clients.Get(cancellationToken);
        var account = await client.Account.GetAsync(cancellationToken: cancellationToken);
    }
}
```

Use `AddDropboxSignOpenApiClientUtilAsSingleton()` when the application should share one generated client. Both registrations use a singleton HTTP provider, so disposing a scoped utility does not remove the shared transport; the provider owns and disposes it at application shutdown.
