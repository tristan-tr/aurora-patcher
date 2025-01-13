using System.Diagnostics;
using CommandLine;

namespace AuroraPatched;

internal class Program
{
    private const string EntryPoint = "Patches.EntryPoint";

    private static void Main(string[] args)
    {
        Parser.Default.ParseArguments<CliOptions>(args).WithParsed(Run);
    }

    private static void Run(CliOptions cli)
    {
        Console.WriteLine("Run with --help for more information");
        if (!File.Exists(cli.ProcessPath))
        {
            Console.WriteLine($"Cannot find Aurora Builder executable at {cli.ProcessPath}, exiting...");
            return;
        }

        if (!File.Exists(cli.DllPath))
        {
            Console.WriteLine($"Cannot find DLL path at {cli.DllPath}, exiting...");
            return;
        }

        if (!File.Exists(cli.ClrInjectPath))
        {
            Console.WriteLine($"CLR Inject executable not found at {cli.ClrInjectPath}, exiting...");
            return;
        }

        var aurora = StartProcess(cli.ProcessPath);
        Thread.Sleep(10000);
        Console.WriteLine("Injecting...");
        var clrinject = StartProcess(cli.ClrInjectPath, $"-i {EntryPoint} -p {aurora.Id} -a {cli.DllPath}");
        Console.WriteLine("Done! exiting...");
    }

    private static Process StartProcess(string processPath, string arguments = "")
    {
        var process = new Process();
        process.StartInfo.FileName = processPath;
        process.StartInfo.Arguments = arguments;
        process.Start();
        return process;
    }
}