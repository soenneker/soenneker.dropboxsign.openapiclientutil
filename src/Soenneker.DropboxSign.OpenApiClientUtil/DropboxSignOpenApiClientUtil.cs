using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.DropboxSign.HttpClients.Abstract;
using Soenneker.DropboxSign.OpenApiClientUtil.Abstract;
using Soenneker.DropboxSign.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.DropboxSign.OpenApiClientUtil;

///<inheritdoc cref="IDropboxSignOpenApiClientUtil"/>
public sealed class DropboxSignOpenApiClientUtil : IDropboxSignOpenApiClientUtil
{
    private readonly AsyncSingleton<DropboxSignOpenApiClient> _client;

    public DropboxSignOpenApiClientUtil(IDropboxSignOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<DropboxSignOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("DropboxSign:ApiKey");
            string authHeaderValueTemplate = configuration["DropboxSign:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new DropboxSignOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<DropboxSignOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
