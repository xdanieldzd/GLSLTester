using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Nini.Config;

namespace GLSLTester
{
    static class Configuration
    {
        static readonly string ConfigName = "Main";

        static string configPath;
        static string configFilename;

        static IConfigSource source;

        public static string FullConfigFilename { get { return (Path.Combine(configPath, configFilename)); } }

        public static System.Drawing.Color BackgroundColor
        {
            get { return System.Drawing.Color.FromArgb((int)source.Configs[ConfigName].GetLong("BackgroundColor", 0xFF000000)); }
            set { source.Configs[ConfigName].Set("BackgroundColor", (long)value.ToArgb()); }
        }

        public static bool VSync
        {
            get { return source.Configs[ConfigName].GetBoolean("VSync", false); }
            set { source.Configs[ConfigName].Set("VSync", value); }
        }

        static Configuration()
        {
            PrepareConfig();

            source = new XmlConfigSource(FullConfigFilename);
            source.AutoSave = true;

            CreateConfigSections();
        }

        static void CreateConfigSections()
        {
            if (source.Configs[ConfigName] == null) source.AddConfig(ConfigName);
        }

        static void PrepareConfig()
        {
            configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), System.Windows.Forms.Application.ProductName);
            configFilename = String.Format("{0}.xml", ConfigName);
            Directory.CreateDirectory(configPath);

            if (!File.Exists(FullConfigFilename)) File.WriteAllText(FullConfigFilename, "<Nini>\n</Nini>\n");
        }
    }
}
