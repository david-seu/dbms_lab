select @@trancount
select @@spid
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
update resources set @old_data=name,name = 'Resource 1 Updated', @new_data=name where resource_id = 1
exec sp_log_changes @old_data, @new_data, 'Deadlock 1: Update 1', null
exec sp_log_locks 'Deadlock 1: between updates'
waitfor delay '00:00:10'
update resources set @old_data=name,name = 'Resource 2 Updated', @new_data=name where resource_id = 2
exec sp_log_changes @old_data, @new_data, 'Deadlock 1: Update 2', null
commit tran
go

--solution -> update in the same order
--solution -> retry the transaction

begin tran
begin try
declare @old_data varchar(50)
declare @new_data varchar(50)
update resources set @old_data=name,name = 'Resource 1 Updated', @new_data=name where resource_id = 1
exec sp_log_changes @old_data, @new_data, 'Deadlock 1: Update 1', null
exec sp_log_locks 'Deadlock 1: between updates'
waitfor delay '00:00:10'
update resources set @old_data=name,name = 'Resource 2 Updated', @new_data=name where resource_id = 2
exec sp_log_changes @old_data, @new_data, 'Deadlock 1: Update 2', null
commit tran
end try
begin catch
    if ERROR_NUMBER() = 1205
    begin
        rollback tran
        print 'Deadlock detected, retrying transaction'
        waitfor delay '00:00:05'
        --retry the transaction
    end
    else
    begin
        print ERROR_MESSAGE()
    end
end catch



