using System;
using System.IO;
using System.Reflection;

namespace SilverGiggle
{
    public class InternalResourceManager
    {

        public Assembly Assembly { get; }
        public string ResourceNamespace { get; }

        #if NETSTANDARD2_0
        public InternalResourceManager(Type rootType)
        {
            Assembly = rootType.Assembly;
            ResourceNamespace = rootType.Namespace;
        }
        #endif

        public InternalResourceManager(TypeInfo rootType)
        {
            Assembly = rootType.Assembly;
            ResourceNamespace = rootType.Namespace;
        }

        public string GetString(string name)
        {
            var resourceName = $"{ResourceNamespace}.{name}";
            using (var stream = Assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"{resourceName} is not found within the assembly.");
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

        }
    }
}
