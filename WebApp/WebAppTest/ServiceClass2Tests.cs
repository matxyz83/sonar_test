using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NSubstitute;
using WebApp.Services;

namespace WebAppTest;

public class ServiceClass2Tests : UnitTestBase
{
    private readonly IServiceClass1 class1Mock;

    public ServiceClass2Tests()
    {
        class1Mock = Substitute.For<IServiceClass1>();
    }



    [Fact]
    public void Test1()
    {
        // Arrange
        var expected = "test1";


        var serviceProvider = CreateServiceProvider();

        var class2 = serviceProvider.GetRequiredService<IServiceClass2>();

        class1Mock
            .Test1()
            .Returns("test1");

        // Act
        var result = class2.Test2();

        // Assert
        Assert.NotNull(result);

        result.Should().Be(expected);

    }

    public override void ConfigureDependencies(IServiceCollection services)
    {
        base.ConfigureDependencies(services);

        services
            .AddScoped<IServiceClass2, ServiceClass2>()
            .AddScoped(x => class1Mock);
    }
}
