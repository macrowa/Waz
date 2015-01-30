using System;
using Dapper.Contrib.Extensions;

namespace Waz.Data
{

	
	[Table("T_Comment")]

	public class T_Comment
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public long ContentId
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public long AuthorId
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Text
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			
			get;set;
			
		}
		
	}
	
	[Table("T_Content")]

	public class T_Content
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public long AuthorId
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Text
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string CommentStatus
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			
			get;set;
			
		}
		
	}
	
	[Table("T_ContentMeta")]

	public class T_ContentMeta
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public long ContentId
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string MetaKey
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string MetaValue
		{
			
			get;set;
			
		}
		
	}
	
	[Table("T_Permission")]

	public class T_Permission
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			
			get;set;
			
		}
		
	}
	
	[Table("T_Role")]

	public class T_Role
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			
			get;set;
			
		}
		
	}
	
	[Table("T_Role_Permission")]

	public class T_Role_Permission
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public long RoleId
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public long PermissionId
		{
			
			get;set;
			
		}
		
	}
	
	[Table("T_Role_UserInfo")]

	public class T_Role_UserInfo
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public long RoleId
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public long UserInfoId
		{
			
			get;set;
			
		}
		
	}
	
	[Table("T_UserInfo")]

	public class T_UserInfo
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			
			get;set;
			
		}
		
	}
	
	[Table("T_UserInfoMeta")]

	public class T_UserInfoMeta
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public long UserInfo_Id
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string MetaKey
		{
			
			get;set;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string MetaValue
		{
			
			get;set;
			
		}
		
	}
	
}



