using Microsoft.Win32;
using System.Diagnostics;
using System.Web;
Console.WriteLine("started");
if (args.Length is not 0 && args[0].StartsWith("cexec:"))
{

    ProcessStartInfo processStartInfo = new()
    {
        FileName = "cmd.exe",
        Arguments = $"/c {HttpUtility.UrlDecode(args[0][6..])}",
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true
    };
    Process process = new() { StartInfo = processStartInfo };
    process.Start();
}
else
{
    Registry.SetValue("HKEY_CLASSES_ROOT\\cexec", "", (object)"URL:cexec Protocol");
    Registry.SetValue("HKEY_CLASSES_ROOT\\cexec", "URL Protocol", (object)"");
    Registry.SetValue("HKEY_CLASSES_ROOT\\cexec\\shell\\open\\command", "", (object)("\"" + System.AppContext.BaseDirectory + "cexec.exe\"  \"%1\""));
}