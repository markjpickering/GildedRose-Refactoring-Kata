using Microsoft.Extensions.DependencyInjection;

namespace CSharp.Tests.Unit;

public abstract class Testbase
{
    public IServiceProvider ServiceProvider { get; set; }

    public Testbase()
    {
        var services = new ServiceCollection();
        CreateServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    public abstract IServiceCollection CreateServices(IServiceCollection services);
}
