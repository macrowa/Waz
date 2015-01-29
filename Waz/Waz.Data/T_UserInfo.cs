using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;


namespace Waz.Data
{
    public partial class T_UserInfo
    {
        private static IDbConnection GetConnection()
        {
            return new SqlConnection();
        }

        public static T_UserInfo QueryByNameAndPassword(string name, string password)
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
    }
}
