using CommandLine;

namespace AuroraPatched;

public class CliOptions
{
    [Option('f', "filepath",
        Default = "C:\\Program Files (x86)\\Aurora\\Aurora Character Builder\\Aurora Builder.exe",
        Required = false,
        HelpText = "Path to the main Aurora Builder executable")]
    public string ProcessPath { get; set; }

    [Option('d', "dllpath",
        Default = "/Patches.dll",
        Required = false,
        HelpText = "Path to the DLL to inject")]
    public string DllPath { get; set; }

    [Option('c', "clrinject",
        Default = "C:\\Program Files (x86)\\Aurora\\Aurora Character Builder\\clrinject-cli.exe",
        Required = false,
        HelpText = "Path to CLRInject CLI")]
    public string ClrInjectPath { get; set; }
}