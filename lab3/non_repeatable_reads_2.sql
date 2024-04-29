select @@spid
select @@trancount
dbcc useroptions
go


set transaction isolation level read committed
--set transaction isolation level repeatable read -- solution
go

begin tran
select * from resources
exec sp_log_locks 'Non-Repeatable Reads 2: between the two selects'
waitfor delay '00:00:10'
select * from resources
exec sp_log_locks 'Non-Repeatable Reads 2: after the two selects'
commit tran
go

select * from resources
