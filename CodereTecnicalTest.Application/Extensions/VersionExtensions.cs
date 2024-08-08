using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Application.Extensions
{
    public static class VersionExtensions
    {
        public static string GetInformationalVersion(Assembly? assembly = null)
        {
            assembly ??= Assembly.GetEntryAssembly();
            if (assembly == null)
            {
                return string.Empty;
            }
            return FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion ?? string.Empty;
        }
    }
}
