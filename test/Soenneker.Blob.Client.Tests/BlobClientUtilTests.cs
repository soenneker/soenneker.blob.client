using Soenneker.Blob.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blob.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class BlobClientUtilTests : HostedUnitTest
{
    private readonly IBlobClientUtil _util;

    public BlobClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<IBlobClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
