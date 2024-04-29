create table log_locks(
	currentTime datetime,
	info varchar(100),

	resource_type varchar(100),
	request_mode varchar(100),
	request_type varchar(100),
	request_status varchar(100),
	request_session_id int
)

create table log_changes(
	currentTime datetime,
	info varchar(100),
	old_data varchar(100),
	new_data varchar(100),
	error varchar(1000)
)
go

CREATE OR ALTER PROCEDURE sp_log_locks
	@info VARCHAR(100)
AS
BEGIN
	INSERT INTO log_locks (currentTime, info, resource_type, request_mode, request_type, request_status, request_session_id)
	SELECT GETDATE(), @info, resource_type, request_mode, request_type, request_status, request_session_id
	FROM sys.dm_tran_locks
	WHERE request_owner_type = 'TRANSACTION'

END
GO

CREATE OR ALTER PROCEDURE sp_log_changes
	@old_data VARCHAR(100),
	@new_data VARCHAR(100),
	@info VARCHAR(100),
	@error VARCHAR(100)
AS
BEGIN
	INSERT INTO log_changes (currentTime, old_data, new_data, error, info) VALUES
	(GETDATE(), @old_data, @new_data, @error, @info)
END
GO

select * from log_locks
select * from log_changes