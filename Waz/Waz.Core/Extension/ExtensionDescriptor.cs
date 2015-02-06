using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Waz.Core.Extension
{
    public class ExtensionDescriptor
    {
        public DirectoryInfo ExtensionFolder
        {
            get;
            private set;
        }

        public ExtensionInfo ExtensionInfo
        {
            get;
            private set;
        }

        public IEnumerable<FileInfo> AssemblyFiles
        {
            get;
            private set;
        }

        public Assembly Assembly
        {
            get;
            private set;
        }

        public IEnumerable<Assembly> DependentAssemblies
        {
            get;
            private set;
        }

        public IExtension Extension
        {
            get;
            private set;
        }

        public ExtensionDescriptor(ExtensionInfo extensionInfo)
        {
            ExtensionInfo = extensionInfo;
            
            Initialize();
        }

        public void Initialize()
        {
            ExtensionFolder = new DirectoryInfo(Path.Combine(ExtensionUtils.ExtensionsFolder.FullName, ExtensionInfo.Name));

            string binPath = Path.Combine(ExtensionFolder.FullName, "bin");
            if (Directory.Exists(binPath))
            {
                AssemblyFiles = new DirectoryInfo(binPath).GetFiles("*.dll");
            }
            else
            {
                AssemblyFiles = new FileInfo[0];
            }

            CopyToShadowFolder();

            IEnumerable<Assembly> assemblies = LoadAssemblies();

            Assembly = SearchExtensionAssembly(assemblies);

            Extension = GetExtension(Assembly);

            DependentAssemblies = assemblies.Where(x => x != Assembly);
        }

        public void Load()
        {
            Extension.Initialize();
        }

        public void Reload()
        {
            UnLoad();
            Initialize();
            Load();
        }

        public void UnLoad()
        {
            Extension.UnInitialize();

            AssemblyFiles = null;
            Assembly = null;
            DependentAssemblies = null;
            Extension = null;
        }

        

        private IExtension GetExtension(Assembly assembly)
        {
            if (Assembly != null)
            {
                Type IExtensionType = Assembly.GetTypes().SingleOrDefault(type => type.GetInterface(typeof(IExtension).Name) != null && type.IsClass && !type.IsAbstract);
                return (IExtension)Activator.CreateInstance(IExtensionType);
            }
            return null;
        }

        private Assembly SearchExtensionAssembly(IEnumerable<Assembly> assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                Type IExtensionType = assembly.GetTypes().SingleOrDefault(type => type.GetInterface(typeof(IExtension).Name) != null && type.IsClass && !type.IsAbstract);
                if (IExtensionType != null)
                {
                    return assembly;
                }
            }
            return null;
        }

        private IEnumerable<Assembly> LoadAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (FileInfo file in AssemblyFiles)
            {
                if (ExtensionUtils.CoreAssemblyFiles.Count(x => x.Name == file.Name) > 0)
                {
                    string path = ExtensionUtils.CoreAssemblyFiles.First(x => x.Name == file.Name).FullName;
                    assemblies.Add(Assembly.LoadFile(path));
                    continue;
                }
                if (ExtensionUtils.ShadowAssemblyFiles.Count(x => x.Name == file.Name) > 0)
                {
                    string path = ExtensionUtils.ShadowAssemblyFiles.First(x => x.Name == file.Name).FullName;
                    assemblies.Add(Assembly.LoadFile(path));
                    continue;
                }
            }
            return assemblies;
        }

        private void CopyToShadowFolder()
        {
            foreach (FileInfo file in AssemblyFiles)
            {

                if (ExtensionUtils.CoreAssemblyFiles.Count(x => x.Name == file.Name) > 0)
                {
                    continue;
                }
                if (ExtensionUtils.ShadowAssemblyFiles.Count(x => x.Name == file.Name) > 0)
                {
                    continue;
                }
                try
                {
                    file.CopyTo(Path.Combine(ExtensionUtils.ShadowCopyFolder.FullName, file.Name));
                }
                catch (Exception)
                { }
            }
        }
    }
}
