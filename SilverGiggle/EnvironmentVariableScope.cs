using System;
using System.Collections.Generic;

namespace SilverGiggle
{
    public class EnvironmentVariableScope : IDisposable
    {
        public Dictionary<string, string> OriginalValues { get; }

        public EnvironmentVariableScope(params string[] environmentVariableNames)
        {
            OriginalValues = new Dictionary<string, string>();
            foreach (var environmentVariableName in environmentVariableNames)
            {
                BackupEnvironmentVariable(environmentVariableName);
            }
        }

        public void UpdateEnvironmentVariable(string name, string value)
        {
            if (!OriginalValues.ContainsKey(name))
            {
                BackupEnvironmentVariable(name);
            }

            Environment.SetEnvironmentVariable(name, value);
        }

        public void Dispose()
        {
            foreach (var kvp in OriginalValues)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
            }
        }

        private void BackupEnvironmentVariable(string name)
        {
            OriginalValues.Add(
                name,
                Environment.GetEnvironmentVariable(name));
        }
    }
}
