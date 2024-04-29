select @@trancount
select @@spid
go

begin tran
declare @old_data varchar(50)
declare @new_data varchar(50)
update resources set @old_data=name,name = 'Resource 2 Updated', @new_data=name where resource_id = 2
exec sp_log_changes @old_data, @new_data, 'Deadlock 2: Update 1', null
exec sp_log_locks 'Deadlock 2: between updates'
waitfor delay '00:00:05'
update resources set @old_data=name,name = 'Resource 1 Updated', @new_data=name where resource_id = 1
exec sp_log_changes @old_data, @new_data, 'Deadlock 2: Update 2',  null
commit tran
go