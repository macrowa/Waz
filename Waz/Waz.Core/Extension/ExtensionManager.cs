using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Waz.Core.Extension
{
    public static class ExtensionManager
    {
        private static IEnumerable<ExtensionDescriptor> _extensionDescriptors;

        public static IEnumerable<ExtensionDescriptor> ExtensionDescriptors
        {
            get
            {
                return _extensionDescriptors;
            }
        }

        public static void Initialize()
        {
            _extensionDescriptors = ExtensionsLoader.Load();
            Load();
        }

        public static ExtensionDescriptor GetExtensionDescriptor(string name)
        { 
            return _extensionDescriptors.SingleOrDefault(x => x.ExtensionInfo.Name == name);
        }

        public static void Load()
        {
            foreach (ExtensionDescriptor extensionDescriptor in _extensionDescriptors)
            {
                extensionDescriptor.Load();
            }
        }

        public static void Load(string name)
        {
            ExtensionDescriptor extensionDescriptor = _extensionDescriptors.SingleOrDefault(x => x.ExtensionInfo.Name == name);
            if (extensionDescriptor != null)
            {
                extensionDescriptor.Load();
            }
        }

    }
}
