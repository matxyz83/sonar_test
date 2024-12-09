namespace WebApp.Services;


public interface IServiceClass1
{
    public string Test1();
}

public class ServiceClass1 : IServiceClass1
{
    public string Test1()
    {
        return "test1";
    }
}

