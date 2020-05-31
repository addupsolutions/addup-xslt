using System;
using System.IO;
using System.Reflection;
using System.Xml.XPath;
using System.Xml.Xsl;
using Mvp.Xml.XInclude;

namespace AddUp.XslTransformer
{
    internal static class Program
    {
        [STAThread]
        private static int Main(string[] args)
        {
            bool helpRequested()
            {
                if (args.Length == 0) return true;
                if (args.Length == 1)
                {
                    var arg = args[0].ToLowerInvariant();
                    return arg == "-h" || arg == "--help";
                }

                return false;
            }

            bool versionRequested()
            {
                if (args.Length == 1)
                {
                    var arg = args[0].ToLowerInvariant();
                    return arg == "-v" || arg == "--version";
                }

                return false;
            }

            var appName = Assembly.GetExecutingAssembly().GetName().Name;

            var appFullVersion = ((AssemblyInformationalVersionAttribute)Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)))
                .InformationalVersion;

            var appVersion = appFullVersion.IndexOf('+') >= 0 ? appFullVersion.Substring(0, appFullVersion.IndexOf('+')) : appFullVersion;

            if (versionRequested())
            {
                Console.Out.WriteLine($"AddUp {appName} Version {appFullVersion}");
                return 0;
            }

            if (helpRequested())
            {
                Console.Out.WriteLine($"AddUp {appName} Version {appVersion}");
                Console.WriteLine("Usage:");
                Console.WriteLine($"\t{appName} -h (--help)              display this help and exit");
                Console.WriteLine($"\t{appName} -v (--version)           output version information and exit");
                Console.WriteLine($"\t{appName} source transform output  transform source XML file with transform XSL file into output file");

                return 0;
            }

            if (args.Length != 3)
            {
                Console.Error.WriteLine($"ERROR - Syntax is: {appName} source transform output");
                return -1;
            }

            try
            {
                var input = args[0];
                var xsl = args[1];
                var output = args[2];

                var transform = new XslCompiledTransform();
                transform.Load(xsl);

                using (var reader = new XIncludingReader(input))
                using (var writer = new StreamWriter(output))
                {
                    var xdoc = new XPathDocument(reader);
                    transform.Transform(xdoc, null, writer);
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ERROR - {ex.Message}");
                return -2;
            }
        }
    }
}
