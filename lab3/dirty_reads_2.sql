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

set transaction isolation level read uncommitted
go
--set transaction isolation level read committed -- solution

begin tran
select * from resources
exec sp_log_locks  'Dirty reads 1: after select'
waitfor delay '00:00:10'
select * from resources
waitfor delay '00:00:10'
select * from resources
go


