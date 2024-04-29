create or alter procedure add_row_projects(@title varchar(50), @status bit, @description varchar(max)) as
    declare @id int
    set @id = 0
    select top 1 @id = project_id + 1 from projects order by project_id desc
    if (@title is null)
    begin
        raiserror('Title cannot be null', 24, 1)
    end
    if(@status is null)
    begin
        raiserror('Status cannot be null', 24, 1)
    end
    if(@description is null)
    begin
        raiserror('Description cannot be null', 24, 1)
    end
    insert into projects values(@id, @title, @status, @description)
    exec sp_log_changes null, @title, 'Added row to projects', null
go

create or alter procedure add_row_employee(@name varchar(50), @email varchar(50), @salary int) as
    declare @id int
    set @id = 0
    select top 1 @id = employee_id + 1 from employee order by employee_id desc
    if (@name is null)
    begin
        raiserror('Name cannot be null', 24, 1)
    end
    if(@email is null)
    begin
        raiserror('Email cannot be null', 24, 1)
    end
    if(@salary < 0)
    begin
        raiserror('Salary cannot be lower then 0', 24, 1)
    end
    insert into employee values(@id, @name, @email, @salary)
    exec sp_log_changes null, @name, 'Added row to employee', null
go

create or alter procedure add_row_project_employee(@project_title varchar(50), @employee_name varchar(50)) as
    if(@project_title is null)
    begin
        raiserror('Project title cannot be null', 24, 1)
    end
    if(@employee_name is null)
    begin
        raiserror('Employee name cannot be null', 24, 1)
    end
    declare @project_id int
    declare @employee_id int
    select @project_id = project_id from projects where title = @project_title
    select @employee_id = employee_id from employee where name = @employee_name
    if (@project_id is null)
    begin
        raiserror('Project does not exist', 24, 1)
    end
    if (@employee_id is null)
    begin
        raiserror('Employee does not exist', 24, 1)
    end
    insert into project_employee values(@project_id, @employee_id)
    declare @new_data varchar(100)
    set @new_data = 'Project: ' + @project_title + ' Employee: ' + @employee_name
    exec sp_log_changes null, @new_data, 'Added row to project_employee', null
go

create or alter procedure rollback_scenario_no_fail
as
    begin tran
    begin try
        exec add_row_projects 'Test', 1, 'Test'
        exec add_row_employee 'Test', 'Test', 1000
        exec add_row_project_employee 'Test', 'Test'
    end try
    begin catch
        rollback tran
        return
    end catch
    commit tran
go

create or alter procedure rollback_scenario_fail
as
    begin tran
    begin try
        exec add_row_projects 'Test', 1, 'Test'
        exec add_row_employee 'Test', 'Test', -1
        exec add_row_project_employee 'Test', 'Test'
    end try
    begin catch
        rollback tran
        return
    end catch
    commit tran
go

create or alter procedure no_rollback_scenario_no_fail
as
    declare @errors int
    set @errors = 0
    begin try
        exec add_row_projects 'Test', 1, 'Test'
    end try
    begin catch
        set @errors = @errors + 1
    end catch
    begin try
        exec add_row_employee 'Test', 'Test', 1000
    end try
    begin catch
        set @errors = @errors + 1
    end catch

    if (@errors = 0) begin
        begin try
            exec add_row_project_employee 'Test', 'Test'
        end try
        begin catch
            set @errors = @errors + 1
        end catch
    end
go

create or alter procedure no_rollback_scenario_fail
as
    declare @errors int
    set @errors = 0
    begin try
        exec add_row_projects 'Test', 1, 'Test'
    end try
    begin catch
        set @errors = @errors + 1
    end catch
    begin try
        exec add_row_employee 'Test', 'Test', -1
    end try
    begin catch
        set @errors = @errors + 1
    end catch

    if (@errors = 0) begin
        begin try
            exec add_row_project_employee 'Test', 'Test'
        end try
        begin catch
            set @errors = @errors + 1
        end catch
    end
go

select * from projects
select * from employee
select * from project_employee


delete from projects
delete from employee
delete from project_employee


exec rollback_scenario_no_fail
exec rollback_scenario_fail
exec no_rollback_scenario_no_fail
exec no_rollback_scenario_fail
