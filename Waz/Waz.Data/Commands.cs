
using System;

namespace Waz.Data
{
	public static class Commands
	{
		
			public static string QueryLastInsertRowId
			{
				get
				{
					return "SELECT LAST_INSERT_ROWID() Id";
				}
			}

		
			public static string QueryUserInfoByNameAndPassword
			{
				get
				{
					return "SELECT * FROM T_UserInfo WHERE Name=@Name and Password=@Password";
				}
			}

		
			public static string QueryRolesByUserInfoId
			{
				get
				{
					return "SELECT T_Role.* FROM T_Role_UserInfo JOIN T_Role ON T_Role.Id=T_Role_UserInfo.RoleId WHERE T_Role_UserInfo.UserInfoId=@UserInfoId";
				}
			}

		
			public static string QueryPermissionsByRoleId
			{
				get
				{
					return "SELECT T_Permission.* FROM T_Role_Permission JOIN T_Permission ON T_Role_Permission.RoleId=T_Permission.Id WHERE T_Role_Permission.RoleId=@RoleId";
				}
			}

		
			public static string QueryPermissionsByUserInfoId
			{
				get
				{
					return "SELECT DISTINCT T_Permission.*  FROM T_Role_UserInfo JOIN T_Role_Permission ON T_Role_UserInfo.RoleId=T_Role_Permission.RoleId JOIN T_Permission ON T_Role_Permission.RoleId=T_Permission.Id WHERE T_Role_UserInfo.UserInfoId=@UserInfoId";
				}
			}

		
	}
}
