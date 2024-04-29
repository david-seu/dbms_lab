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
waitfor delay '00:00:10'
insert into resources (resource_id, area_id, name, description) values (3, 1, 'Resource 3', 'Resource 3 Description')
exec sp_log_changes null, 3, 'Phantom 1: insert', null
exec sp_log_locks 'Phantom 1: after insert'
commit tran
go