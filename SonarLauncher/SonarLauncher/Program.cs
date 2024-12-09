using SonarLauncher;

var projects = new List<Project>
{
    new Project("webapp", "D:\\Projects\\Sonar\\WebApp"),

};

var sonarProject = new SonarProject { Login = "sqp_0993e2a6c8a9939adbaf5d4e1199e5a66d8a172a", Projects = projects };

await sonarProject.Start();

class A
{

    public ICollection<string> Login { get; } = new List<string>();
}



/*

 https://docs.sonarsource.com/sonarqube-server/9.7/analyzing-source-code/test-coverage/dotnet-test-coverage/

 dotnet tool install --global dotnet-sonarscanner
 dotnet tool install --global dotnet-coverage

 
 */