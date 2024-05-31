dbcc useroptions
go

delete from wine_stores
insert into wine_stores (name, phone_number, website) values ('wine', 123456789, 'wine.com')
go

select * from wine_stores

set transaction isolation level read uncommitted

--tran 1
begin tran
select * from wine_stores
waitfor delay '00:00:10'
select * from wine_stores
commit tran