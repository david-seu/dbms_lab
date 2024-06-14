dbcc useroptions
go

set transaction isolation level read committed
go

--set transaction isolation level repeatable read
--go

delete from doctors
insert into doctors (name, date_of_birth, specialities) values ('Ionel', null, 'Cancer research')
go

select * from doctors


begin tran
waitfor delay '00:00:10'
update doctors set name='Ionel 2' where specialities='Cancer research'
commit tran



begin tran
update pilot
set name = 'Mihai'
where p_id = 2
update aircraft
set capacity= 400
where a_id = 3
commit tran





