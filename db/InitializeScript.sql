declare @dbname nvarchar(128)
set @dbname = N'Accounting'

if not exists (select name from master.dbo.sysdatabases where name = @dbname)
begin
	create database Accounting;
end
go

