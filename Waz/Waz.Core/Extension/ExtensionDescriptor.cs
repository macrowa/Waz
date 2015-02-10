using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Waz.Core.Extension
{
    public class ExtensionDescriptor
    {
        private ExtensionInfo _extensionInfo;

        public string Name
        {
            get
            {
                return _extensionInfo.Name;
            }
        }

        public string FriendlyName
        {
            get
            {
                return _extensionInfo.FriendlyName;
            }
        }

        public string Author
        {
            get
            {
                return _extensionInfo.Author;
            }
        }

        public string Version
        {
            get
            {
                return _extensionInfo.Version;
            }
        }



        public ExtensionDescriptor(ExtensionInfo extensionInfo)
        {
            _extensionInfo = extensionInfo;
        }



    }
}
