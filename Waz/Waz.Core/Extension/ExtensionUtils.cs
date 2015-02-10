using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Waz.Core.Extension
{
    public static class ExtensionUtils
    {

        public static DirectoryInfo ExtensionsFolder
        {
            get
            {
                string _extensionsPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"Extensions");
                if (!Directory.Exists(_extensionsPath))
                {
                    Directory.CreateDirectory(_extensionsPath);
                }
                return new DirectoryInfo(_extensionsPath);
            }
        }

        public static DirectoryInfo ShadowCopyFolder
        {
            get
            {
                string _shadowCopyPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"App_Data\ExtensionAssemblies");
                if (!Directory.Exists(_shadowCopyPath))
                {
                    Directory.CreateDirectory(_shadowCopyPath);
                }
                return new DirectoryInfo(_shadowCopyPath);
            }
        }

        public static DirectoryInfo CoreFolder
        {
            get
            {
                return new DirectoryInfo(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);
            }
        }

        public static IEnumerable<FileInfo> CoreAssemblyFiles
        {
            get
            {
                return CoreFolder.GetFiles("*.dll");
            }
        }

        public static IEnumerable<FileInfo> ShadowAssemblyFiles
        {
            get
            {
                return ShadowCopyFolder.GetFiles("*.dll");
            }
        }
        /// <summary>
        /// 清空临时目录
        /// </summary>
        public static void ClearShadowCopyFolder()
        {
            foreach (FileInfo file in ShadowCopyFolder.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception)
                { }
            }
        }

        public static IEnumerable<FileInfo> SearchAssemblyFiles(string path)
        {
            string assemblyPath = Path.Combine(path, "bin");
            DirectoryInfo assemblyFolder = new DirectoryInfo(assemblyPath);
            return assemblyFolder.GetFiles("*.dll");
        }

    }
}
