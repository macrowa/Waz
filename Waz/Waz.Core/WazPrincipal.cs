using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;
using Waz.Data;
using Newtonsoft.Json;

namespace Waz.Core
{

    public class WazPrincipal : IPrincipal
    {
        private IIdentity m_Identity;
        private T_UserInfo m_info;

        public T_UserInfo Info
        {
            get
            {
                return m_info;
            }
        }

        public List<T_Role> Roles = new List<T_Role>();

        public List<T_Permission> Permissions = new List<T_Permission>();

        public WazPrincipal(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("ticket");
            }
            if (!string.IsNullOrEmpty(ticket.UserData))
            {
                m_info = JsonConvert.DeserializeObject<T_UserInfo>(ticket.UserData);
                LoadUserInfo();
            }
            m_Identity = new FormsIdentity(ticket);
        }

        public void LoadUserInfo()
        {
            Roles = LoadRoles(m_info.Id).ToList();
            Permissions = LoadPermissions(m_info.Id).ToList();
        }

        private IEnumerable<T_Role> LoadRoles(long userId)
        {
            if (Info != null)
            {
                return WazDb.QueryRolesByUserInfoId(userId);
            }
            else
            {
                return new T_Role[] { };
            }
        }

        private IEnumerable<T_Permission> LoadPermissions(long userId)
        {
            if (Info != null)
            {
                return WazDb.QueryPermissionsByUserInfoId(userId);
            }
            else
            {
                return new T_Permission[] { };
            }
        }

        public IIdentity Identity
        {
            get
            {
                return m_Identity;
            }
        }

        public bool IsInRole(string role)
        {
            return Roles.Exists(x => x.Name == role);
        }

        public bool HasPermission(string permission)
        {
            return Permissions.Exists(x => x.Name == permission);
        }
    }
}