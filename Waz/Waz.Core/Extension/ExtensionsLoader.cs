using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Waz.Core.Extension
{
    public class ExtensionsLoader
    {
        private string _modulePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"\Modules\");

        private string _shadowCopyPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"\App_Data\Modules\");

        public DirectoryInfo ModuleFolder;

        public DirectoryInfo ShadowCopyFolder;



        public ExtensionsLoader()
        {
            if (!Directory.Exists(_modulePath))
            {
                Directory.CreateDirectory(_modulePath);
            }
            if (!Directory.Exists(_shadowCopyPath))
            {
                Directory.CreateDirectory(_shadowCopyPath);
            }
            ModuleFolder = new DirectoryInfo(_modulePath);
            ShadowCopyFolder = new DirectoryInfo(_shadowCopyPath);
        }

        public IEnumerable<ExtensionDescriptor> Load()
        {
            List<ExtensionDescriptor> extensionDescriptors = new List<ExtensionDescriptor>();

            DirectoryInfo[] folders = ModuleFolder.GetDirectories();

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

        private void ShadowCopy(List<ExtensionDescriptor> extensionDescriptors)
        { 
            foreach(FileInfo file in ShadowCopyFolder.GetFiles("*.dll",SearchOption.AllDirectories)
            {
                try
                {
                file.Delete();
                }catch
                {
                
                }
            }


        }

    }
}
