select @@spid
select @@trancount
dbcc useroptions
go


set transaction isolation level repeatable read
--set transaction isolation level serializable -- solution
go

begin tran
select * from resources
exec sp_log_locks 'Phantom 2: between selects'
waitfor delay '00:00:10'
select * from resources
exec sp_log_locks 'Phantom 2: after both selects'
commit tran
go

begin tran
select * from resources
commit tran
go