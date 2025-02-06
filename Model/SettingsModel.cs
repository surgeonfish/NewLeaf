using System;
using System.IO;
using System.Xml;

namespace NewLeaf.Model
{
    public partial class SettingsModel
    {
        private readonly string ConfigPath;

        protected readonly string SettingsNodeName = "Settings";
        protected readonly string ThemeNodeName = "Theme";

        public SettingsModel()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(appDataPath, "NewLeaf");
            ConfigPath = Path.Combine(appFolder, "settings.xml");
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }
            if (!File.Exists(ConfigPath))
            {
                XmlDocument xmlDoc = new XmlDocument();

                // Declaration
                XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(declaration);

                // Settings
                XmlNode settingsNode = xmlDoc.CreateElement(SettingsNodeName);
                xmlDoc.AppendChild(settingsNode);
                // Settings.Theme
                XmlNode themeNode = xmlDoc.CreateElement(ThemeNodeName);
                themeNode.InnerText = "Light";
                settingsNode.AppendChild(themeNode);

                xmlDoc.Save(ConfigPath);
            }
        }

        private string Get(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigPath);

            XmlNode settingsNode = xmlDoc.SelectSingleNode("/" + SettingsNodeName);
            foreach (XmlNode node in settingsNode.ChildNodes)
            {
                if (node.Name == name)
                {
                    return node.InnerText;
                }
            }

            return "";
        }

        protected void Set(string name, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigPath);

            XmlNode settingsNode = xmlDoc.SelectSingleNode("/" + SettingsNodeName);
            foreach (XmlNode node in settingsNode.ChildNodes)
            {
                if (node.Name == name)
                {
                    node.InnerText = value;
                    xmlDoc.Save(ConfigPath);
                    break;
                }
            }
        }

        public virtual string Theme
        {
            get
            {
                if (ThemeProperty == null)
                {
                    ThemeProperty = Get(ThemeNodeName);
                }
                return ThemeProperty;
            }
            set
            {
                ThemeProperty = value;
                Set(ThemeNodeName, value);
            }
        }
        private string ThemeProperty;
    }
}
