using Soenneker.Blob.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Blob.Client.Tests;

[Collection("Collection")]
public class BlobClientUtilTests : FixturedUnitTest
{
    private readonly IBlobClientUtil _util;

    public BlobClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IBlobClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
