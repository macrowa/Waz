using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using Dapper;


namespace Waz.Data
{
    public partial class WazDb
    {
        private static IDbConnection GetConnection()
        {
            return new SqlCeConnection("Data Source=./App_Data/WazDb.sdf");
        }

        public static T_UserInfo QueryUserInfoByNameAndPassword(string name, string password)
        {
            using (IDbConnection connection = GetConnection())
            {
                IEnumerable<T_UserInfo> userinfos = connection.Query<T_UserInfo>(Commands.QueryUserInfoByNameAndPassword, new { Name = name, Password = password });
                if (userinfos.Count() > 0)
                {
                    return userinfos.First();
                }
                else
                {
                    return null;
                }
            }
        }

        public static IEnumerable<T_Role> QueryRolesByUserInfoId(long userId)
        {
            using (IDbConnection connection = GetConnection())
            {
                return connection.Query<T_Role>(Commands.QueryRolesByUserInfoId, new { UserInfoId = userId });
            }
        }
        public static IEnumerable<T_Permission> QueryPermissionsByRoleId(long roleId)
        {
            using (IDbConnection connection = GetConnection())
            {
                return connection.Query<T_Permission>(Commands.QueryPermissionsByRoleId, new { RoleId = roleId });
            }
        }

        public static IEnumerable<T_Permission> QueryPermissionsByUserInfoId(long userId)
        {
            using (IDbConnection connection = GetConnection())
            {
                return connection.Query<T_Permission>(Commands.QueryPermissionsByUserInfoId, new { UserInfoId = userId });
            }
        }
    }
}
