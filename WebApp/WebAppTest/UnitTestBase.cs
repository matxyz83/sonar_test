using Microsoft.Extensions.DependencyInjection;

namespace WebAppTest;

public abstract class UnitTestBase
{
    public IServiceProvider CreateServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureDependencies(serviceCollection);

        IServiceProvider provider = serviceCollection.BuildServiceProvider();

        return provider;
    }

    public virtual void ConfigureDependencies(IServiceCollection services)
    {
    }
}
