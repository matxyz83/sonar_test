using System.Diagnostics;

namespace SonarLauncher;

internal class SonarPhases
{
    private readonly Project project;
    private readonly string login;

    public SonarPhases(Project project, string login)
    {
        this.project = project;
        this.login = login;
    }

    public async Task StartAsync()
    {

        await BeginAsync();
        await BuildAsync();
        await CoverageAsync();
        await EndAsync();
        Clean();
    }
    private async Task BeginAsync()
    {
        await ExecuteProcessAsync("dotnet",
            $"sonarscanner begin /k:\"{project.Name}\" " +
            $"/d:sonar.host.url=\"http://localhost:9500\" " +
            $"/d:sonar.login=\"{login}\" " +
            $"/d:sonar.cs.vscoveragexml.reportsPaths={project.Path}/coverage.xml " +
            $"/s:{project.Path}/SonarQube.Analysis.xml");

    }
    private async Task BuildAsync()
    {
        await ExecuteProcessAsync("dotnet", "build --no-incremental");

    }
    private async Task CoverageAsync()
    {
        await ExecuteProcessAsync("dotnet-coverage", "collect -f xml  -o \"coverage.xml\" dotnet test"); // --filter \"Category!=Integration\"
    }



    private async Task EndAsync()
    {
        await ExecuteProcessAsync("dotnet", $"sonarscanner end /d:sonar.login=\"{login}\" ");
    }
    private async Task ExecuteProcessAsync(string exe, string args)
    {

        Process process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            WorkingDirectory = project.Path,
            FileName = exe,
            Arguments = args,
        };
        process.Start();
        await process.WaitForExitAsync();
    }
    private void Clean()
    {
        try
        {
            Directory.Delete($"{project.Path}\\.sonarqube", true);
        }
        catch
        { }
    }
}