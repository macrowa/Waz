
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;

namespace Waz.Core.Extension.Mvc
{
    /// <summary>
    /// 插件控制器工厂。
    /// </summary>
    public class ExtensionControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// 根据控制器名称及请求信息获得控制器类型。
        /// </summary>
        /// <param name="requestContext">请求信息</param>
        /// <param name="controllerName">控制器名称。</param>
        /// <returns>控制器类型。</returns>
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            if (requestContext.RouteData.Values.ContainsKey("Extension"))
            {
                string ExtensionName = requestContext.RouteData.GetRequiredString("Extension");
                Type controllerType = this.GetControllerType(ExtensionName, controllerName);
                if (controllerType != null)
                {
                    return controllerType;
                }
            }
            return base.GetControllerType(requestContext,controllerName);
        }

        /// <summary>
        /// 根据控制器名称获得控制器类型。
        /// </summary>
        /// <param name="controllerName">控制器名称。</param>
        /// <returns>控制器类型。</returns>
        private Type GetControllerType(string extensionName, string controller)
        {
            ExtensionDescriptor extensionDescriptor = ExtensionManager.GetExtensionDescriptor(extensionName);
            string controllerName = controller + "Controller";
            Type controllerType = extensionDescriptor.Assembly.GetTypes().FirstOrDefault(p => p.Name == controllerName); ;
            if (controllerType != null)
            {
                return controllerType;
            }
            else
            {
                return null;
            }
        }
    }
}