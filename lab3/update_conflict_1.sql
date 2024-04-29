select @@spid
select @@trancount
dbcc useroptions
go

delete from resources
delete from areas
insert into areas (area_id, name, description) values (1, 'Area 1', 'Area 1 description')
go

alter database app set allow_snapshot_isolation on
go

begin tran
declare @old_data varchar(50)
declare @new_data varchar(50)
update areas set @old_data=name, name = 'Area 2', @new_data=name where area_id = 1
waitfor delay '00:00:10'
exec sp_log_changes @old_data, @new_data, 'Update Conflict 1: update', null
exec sp_log_locks 'Update Conflict 1: after update'
select * from areas
commit tran
go