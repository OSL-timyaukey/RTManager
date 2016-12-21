using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RTUtilities
{
    public class RTSettings
    {
        public static string GetConfigFilePath(string fileName)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), fileName);
        }

        public static string GetTemplateDirectory()
        {
            return "H:\\RT_Templates";
        }

        public const string TemplateFileType = ".tpt";
    }
}
