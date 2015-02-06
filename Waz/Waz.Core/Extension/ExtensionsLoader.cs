using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Waz.Core.Extension
{
    public static class ExtensionsLoader
    {

        public static IEnumerable<ExtensionDescriptor> Load()
        {
            List<ExtensionDescriptor> extensionDescriptors = new List<ExtensionDescriptor>();

            DirectoryInfo[] folders = ExtensionUtils.ExtensionsFolder.GetDirectories();

            foreach (DirectoryInfo folder in folders)
            {
                var descriptionPath = Path.Combine(folder.FullName, "Description.json");
                if (File.Exists(descriptionPath))
                {
                    string descriptionText = File.ReadAllText(descriptionPath);
                    ExtensionInfo extensionInfo = JsonConvert.DeserializeObject<ExtensionInfo>(descriptionText);
                    extensionDescriptors.Add(new ExtensionDescriptor(extensionInfo));
                }
            }
            return extensionDescriptors;
        }

    }
}
