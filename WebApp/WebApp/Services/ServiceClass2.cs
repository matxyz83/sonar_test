namespace WebApp.Services;
public interface IServiceClass2
{
    public string Test2();
}

public class ServiceClass2 : IServiceClass2
{
    private readonly IServiceClass1 class1;

    public ServiceClass2(IServiceClass1 class1)
    {
        this.class1 = class1;
    }

    public string Test2()
    {
        return class1.Test1();
    }
}