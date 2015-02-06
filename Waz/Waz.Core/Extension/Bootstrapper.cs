using System.Web.Mvc;
using Waz.Core.Extension;
using Waz.Core.Extension.Mvc;
using System.Web.Routing;

[assembly: System.Web.PreApplicationStartMethod(typeof(Waz.Core.Extension.Bootstrapper), "Initialize")]
namespace Waz.Core.Extension
{


    /// <summary>
    /// 引导程序。
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        public static void Initialize()
        {
            ControllerBuilder.Current.SetControllerFactory(new ExtensionControllerFactory());
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new PluginRazorViewEngine());
            ExtensionManager.Initialize();
        }
    }
}