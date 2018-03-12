using System;
using global::StyleCop;

    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;
    using System.Xml.Xsl;


namespace StyleCop.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyDirectory = "."; //AssemblyDirectory(Assembly.GetAssembly(typeof(StyleCopSettings)));
            var toolPath = "."; //context.File(assemblyDirectory).Path.GetDirectory();
            var defaultStyleSheet = ""; //context.File(toolPath + "/StyleCopStyleSheet.xslt");
            //context.Log.Information($"Stylecop: Default stylesheet {context.MakeAbsolute(defaultStyleSheet)}");

            var solutionFile = "./StyleCop.Runner.csproj";
            //var settingsFile = args[1];
            var outputPath = "Results.xml";
            //var addins = settings.Addins.Count == 0 ? null : settings.Addins.Select(x => x.FullPath).ToList();

            // var solutionParser = new SolutionParser(context.FileSystem, context.Environment);
            // var projectParser = new ProjectParser(context.FileSystem, context.Environment);

            // var projectPath = solutionFile.MakeAbsolute(context.Environment).GetDirectory();

            //context.Log.Information($"Stylecop: Found solution {projectPath.FullPath}");

            StyleCopConsole styleCopConsole = null;
            styleCopConsole = new StyleCopConsole(
                                      null,
                                      false,
                                      /* Input Cache Result */
                                      outputPath,
                                      /* Output file */
                                      null,
                                      false);

            var styleCopProjects = new List<CodeProject>();
            
            var styleCopProject = new CodeProject(0, args[0], new Configuration(null));
                styleCopProjects.Add(styleCopProject);
                styleCopConsole.Core.Environment.AddSourceCode(styleCopProject, args[1], null);

            //var handler = new StylecopHandlers(context, settings);

            //styleCopConsole.OutputGenerated += handler.OnOutputGenerated;
            //styleCopConsole.ViolationEncountered += handler.ViolationEncountered;
            //context.Log.Information($"Stylecop: Starting analysis");
            styleCopConsole.Start(styleCopProjects.ToArray(), true);
            //context.Log.Information($"Stylecop: Finished analysis");
            //styleCopConsole.OutputGenerated -= handler.OnOutputGenerated;
            //styleCopConsole.ViolationEncountered -= handler.ViolationEncountered;

            // if (settings.HtmlReportFile != null)
            // {
            //     settings.HtmlReportFile = settings.HtmlReportFile.MakeAbsolute(context.Environment);

            //     // copy default resources to output folder
            //     context.CopyDirectory(context.Directory(toolPath + "/resources"), settings.HtmlReportFile.GetDirectory() + "/resources");

            //     context.Log.Information($"Stylecop: Creating html report {settings.HtmlReportFile.FullPath}");
            //     Transform(context, settings.HtmlReportFile, settings.ResultsFile.MakeAbsolute(context.Environment), settings.StyleSheet ?? context.MakeAbsolute(defaultStyleSheet));
            // }

            // if (handler.TotalViolations > 0 && settings.FailTask)
            // {
            //     throw new Exception($"{handler.TotalViolations} StyleCop violations encountered.");
            // }
        }
    }
}
