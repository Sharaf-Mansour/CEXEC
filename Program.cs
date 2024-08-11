using Microsoft.Win32;
using System.Diagnostics;
using System.Web;
Console.WriteLine("started");
if (args.Length is not 0 && args[0].StartsWith("cexec:"))
{
    Process.Start(HttpUtility.UrlDecode(args[0][6..]));
}
else
{
    Registry.SetValue("HKEY_CLASSES_ROOT\\cexec", "", (object)"URL:cexec Protocol");
    Registry.SetValue("HKEY_CLASSES_ROOT\\cexec", "URL Protocol", (object)"");
    Registry.SetValue("HKEY_CLASSES_ROOT\\cexec\\shell\\open\\command", "", (object)("\"" + typeof(Program).Assembly.Location + "\" \"%1\""));
}