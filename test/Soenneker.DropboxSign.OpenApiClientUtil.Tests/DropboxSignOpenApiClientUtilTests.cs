using Soenneker.DropboxSign.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.DropboxSign.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class DropboxSignOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IDropboxSignOpenApiClientUtil _openapiclientutil;

    public DropboxSignOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IDropboxSignOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
