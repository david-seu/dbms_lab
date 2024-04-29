select @@spid
select @@trancount
dbcc useroptions
go

delete from resources
delete from areas
insert into areas (area_id, name, description) values (1, 'Area 1', 'Area 1 Description')
insert into resources (resource_id, area_id, name, description) values (1, 1, 'Resource 1', 'Resource 1 Description')
insert into resources (resource_id, area_id, name, description) values (2, 1, 'Resource 2', 'Resource 2 Description')
go

begin tran
declare @old_data varchar(50)
declare @new_data varchar(50)
waitfor delay '00:00:10'
update resources set @old_data=name, name = 'Resource 1 Updated', @new_data=name where resource_id = 1
exec sp_log_changes @old_data, @new_data, 'Non-Repeatable Reads 1: update', null
exec sp_log_locks 'Non-Repeatable Reads 1: after update'
commit tran
go