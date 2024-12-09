using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarLauncher;
internal record Project(string Name, string Path);

internal class SonarProject
{

    public string Login { get; set; } = String.Empty;
    public IEnumerable<Project> Projects { get; set; } = new List<Project>();


    public async Task Start()
    {

        foreach (var p in Projects)
        {
            Console.WriteLine(p.Name);
            await new SonarPhases(p, Login).StartAsync();
            Console.WriteLine("");
        }

    }
}


