
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
					return "SELECT * FROM [T_UserInfo] WHERE [Name]=@Name and [Password]=@Password";
				}
			}

		
	}
}
