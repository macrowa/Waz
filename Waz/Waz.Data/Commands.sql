--[START]
--QueryLastInsertRowId
SELECT LAST_INSERT_ROWID() Id
--[END]
GO

--[START]
--QueryUserInfoByNameAndPassword
SELECT *
FROM T_UserInfo
WHERE Name=@Name and Password=@Password
--[END]
GO

--[START]
--QueryRolesByUserInfoId
SELECT T_Role.*
FROM T_Role_UserInfo
JOIN T_Role ON T_Role.Id=T_Role_UserInfo.RoleId
WHERE T_Role_UserInfo.UserInfoId=@UserInfoId
--[END]
GO

--[START]
--QueryPermissionsByRoleId
SELECT T_Permission.*
FROM T_Role_Permission
JOIN T_Permission ON T_Role_Permission.RoleId=T_Permission.Id
WHERE T_Role_Permission.RoleId=@RoleId
--[END]
GO


--[START]
--QueryPermissionsByUserInfoId
SELECT DISTINCT T_Permission.* 
FROM T_Role_UserInfo
JOIN T_Role_Permission ON T_Role_UserInfo.RoleId=T_Role_Permission.RoleId
JOIN T_Permission ON T_Role_Permission.RoleId=T_Permission.Id
WHERE T_Role_UserInfo.UserInfoId=@UserInfoId
--[END]
GO
