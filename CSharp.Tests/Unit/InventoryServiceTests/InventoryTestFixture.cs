using GildedRose;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;

namespace CSharp.Tests.Unit.InventoryServiceTests;

public class InventoryTestFixture : TestBedFixture
{
    protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
    {
        AppDI.AddServices(services);
    }

    protected override ValueTask DisposeAsyncCore() => new();
    
    protected override IEnumerable<TestAppSettings> GetTestAppSettings()
    {
        yield return new() { Filename = "appsettings.json", IsOptional = true };
    }
}
