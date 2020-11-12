using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Axis.PipefySdk
{
    public static class EmbeddedManager
    {
        internal readonly static IDictionary<string, string> CommandDictionary = new Dictionary<string, string>();

        static EmbeddedManager()
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var resourceName in assembly.GetManifestResourceNames())
            {
                using var stream = assembly.GetManifestResourceStream(resourceName);
                using var reader = new StreamReader(stream);
                CommandDictionary.Add(resourceName, reader.ReadToEnd());
            }
        }
    }
}
