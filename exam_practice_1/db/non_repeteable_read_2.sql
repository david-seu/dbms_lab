begin tran
select * from doctors
waitfor delay '00:00:10'
select * from doctors
commit tran