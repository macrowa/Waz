namespace Waz.Core.Extension.Mvc
{
    using System;
    using System.Web.Mvc;
    using System.Web.WebPages.Razor;
    using Waz.Core.Extension;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public class PluginRazorViewEngine : RazorViewEngine
    {
        /// <summary>
        /// 定义区域视图页所在地址。
        /// </summary>
        private string[] _areaViewLocationFormats = new[]
        {
            "~/Views/Parts/{0}.cshtml",
            "~/Extensions/{2}/Views/{1}/{0}.cshtml",
            "~/Extensions/{2}/Views/Shared/{0}.cshtml",
            "~/{2}/Views/{1}/{0}.cshtml",
            "~/{2}/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
        };

        /// <summary>
        /// 定义视图页所在地址。
        /// </summary>
        private string[] _viewLocationFormats = new[]
        {
            "~/Views/Parts/{0}.cshtml",
            "~/Extensions/{Extension}/Views/{1}/{0}.cshtml",
            "~/Extensions/{Extension}/Views/Shared/{0}.cshtml",
            "~/{Extension}/Views/{1}/{0}.cshtml",
            "~/{Extension}/Views/Shared/{0}.cshtml",
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml",
        };

        /// <summary>
        /// 搜索部分视图页。
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="partialViewName"></param>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {

            if (controllerContext.RouteData.Values.ContainsKey("Extension"))
            {
                string extensionName = controllerContext.RouteData.GetRequiredString("Extension");

                this.AreaViewLocationFormats = this._areaViewLocationFormats;
                this.AreaMasterLocationFormats = this._areaViewLocationFormats;
                this.AreaPartialViewLocationFormats = this._areaViewLocationFormats;

                this.ViewLocationFormats = this._viewLocationFormats;
                this.MasterLocationFormats = this.ViewLocationFormats;
                this.PartialViewLocationFormats = this.ViewLocationFormats;

                this.CodeGeneration(extensionName);

                this.UpdatePath(extensionName);
            }

            return base.FindPartialView(controllerContext, partialViewName, useCache);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {

            if (controllerContext.RouteData.Values.ContainsKey("Extension"))
            {
                string extensionName = controllerContext.RouteData.GetRequiredString("Extension");

                this.AreaViewLocationFormats = this._areaViewLocationFormats;
                this.AreaMasterLocationFormats = this._areaViewLocationFormats;
                this.AreaPartialViewLocationFormats = this._areaViewLocationFormats;

                this.ViewLocationFormats = this._viewLocationFormats;
                this.MasterLocationFormats = this.ViewLocationFormats;
                this.PartialViewLocationFormats = this.ViewLocationFormats;

                this.CodeGeneration(extensionName);

                this.UpdatePath(extensionName);
            }

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        /// <summary>
        /// 更新路径中的插件名称参数。
        /// </summary>
        /// <param name="moduleName"></param>
        private void UpdatePath(string moduleName)
        {
            string[] viewLocationFormats = new string[this._viewLocationFormats.Length];
            string[] areaViewLocationFormats = new string[this._areaViewLocationFormats.Length];

            if (areaViewLocationFormats != null)
            {
                for (int index = 0; index < areaViewLocationFormats.Length; index++)
                {
                    areaViewLocationFormats[index] = this._areaViewLocationFormats[index].Replace("{Extension}", moduleName);
                }

                this.AreaViewLocationFormats = areaViewLocationFormats;
                this.AreaMasterLocationFormats = areaViewLocationFormats;
                this.AreaPartialViewLocationFormats = areaViewLocationFormats;
            }

            if (viewLocationFormats != null)
            {
                for (int index = 0; index < viewLocationFormats.Length; index++)
                {
                    viewLocationFormats[index] = this._viewLocationFormats[index].Replace("{Extension}", moduleName);
                }

                this.ViewLocationFormats = viewLocationFormats;
                this.MasterLocationFormats = viewLocationFormats;
                this.PartialViewLocationFormats = viewLocationFormats;
            }
        }

        /// <summary>
        /// 给运行时编译的页面加了引用程序集。
        /// </summary>
        /// <param name="pluginName"></param>
        private void CodeGeneration(string extensionName)
        {
            RazorBuildProvider.CodeGenerationStarted += (object sender, EventArgs e) =>
            {
                RazorBuildProvider provider = (RazorBuildProvider)sender;

                ExtensionDescriptor extensionDescriptor = ExtensionManager.GetExtensionDescriptor(extensionName);

                if (extensionDescriptor.Assembly != null)
                {
                    provider.AssemblyBuilder.AddAssemblyReference(extensionDescriptor.Assembly);
                }

                if (extensionDescriptor.DependentAssemblies != null)
                {
                    foreach (Assembly assembly in extensionDescriptor.DependentAssemblies)
                    {
                        provider.AssemblyBuilder.AddAssemblyReference(extensionDescriptor.Assembly);
                    }
                }
            };
        }
    }
}