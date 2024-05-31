

--tran 2

begin tran
waitfor delay '00:00:05'
update wine_stores set phone_number=1 where name='wine'
waitfor delay '00:00:10'
commit tran