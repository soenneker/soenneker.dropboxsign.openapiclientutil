using Soenneker.DropboxSign.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.DropboxSign.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class DropboxSignOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IDropboxSignOpenApiClientUtil _openapiclientutil;

    public DropboxSignOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IDropboxSignOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
