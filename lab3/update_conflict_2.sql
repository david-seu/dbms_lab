select @@spid
select @@trancount
dbcc useroptions
go

--set transaction isolation level read uncommitted -- solution
set transaction isolation level snapshot
go

begin tran
declare @old_data varchar(50)
declare @new_data varchar(50)
update areas set @old_data=name, name='Area 2', @new_data=name where area_id=1
exec sp_log_changes @old_data, @new_data, 'Update Conflict 2: update', null
exec sp_log_locks 'Update Conflict 2: after update'
select * from areas
commit tran
go

