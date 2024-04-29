select @@spid
select @@trancount
dbcc useroptions
go

begin tran
declare @old_data varchar(50)
declare @new_data varchar(50)
update resources set @old_data=description, description = 'Resource 1 Description Updated', @new_data=description where resource_id = 1
exec sp_log_changes @old_data, @new_data, 'Dirty reads 1: update', null
exec sp_log_locks  'Dirty reads 1: after update'
waitfor delay '00:00:10'
update resources set description = 'Resource 1 Description Updated Again' where resource_id = 1
exec sp_log_changes @old_data, @new_data, 'Dirty reads 1: update again', null
exec sp_log_locks  'Dirty reads 1: after update again'
waitfor delay '00:00:10'
commit tran
go
