--[START]
--QueryLastInsertRowId
SELECT LAST_INSERT_ROWID() Id
--[END]
GO

--[START]
--QueryUserInfoByNameAndPassword
SELECT *
FROM [T_UserInfo]
WHERE [Name]=@Name and [Password]=@Password
--[END]
GO

