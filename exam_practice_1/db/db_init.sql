drop table if exists patients_pay_medications
drop table if exists patients_pay_treatments
drop table if exists patients_pay_appointments
drop table if exists payments
drop table if exists treatments
drop table if exists medications
drop table if exists appointments
drop table if exists nurses
drop table if exists patients
drop table if exists doctors
go


create table doctors(
    d_id int identity(1,1) primary key ,
    name varchar(255),
    date_of_birth datetime,
    specialities varchar(255),
)

create table patients
(
    p_id         int identity (1,1) primary key,
    name         varchar(255),
    address      varchar(255),
    phone_number int,
    d_id         int foreign key references doctors (d_id),
)

create table nurses
(
    n_id int identity (1,1) primary key ,
    name varchar(255),
    date_of_birth datetime,
    d_id int foreign key references doctors(d_id),
)

create table appointments
(
    a_id int identity (1,1) primary key ,
    p_id int foreign key references patients(p_id),
    d_id int foreign key references doctors(d_id),
    date date,
    time time,
    reason varchar(255),
)

create table treatments
(
    t_id int identity (1,1) primary key ,
    name varchar(255),
    p_id int foreign key references patients(p_id),
    d_id int foreign key references doctors(d_id),
)

create table medications(
    m_id int identity (1,1) primary key ,
    name varchar(255),
    dosage varchar(255),
    instructions varchar(255),
    t_id int foreign key references treatments(t_id),
)


create table payments
(
    py_id int identity (1,1) primary key ,
    date datetime,
    status varchar(255),
    type varchar(255),
    constraint type_valid check (status in ('card','cash','bank transfer')),
    constraint status_valid check (status in ('new', 'processing', 'completed')),
)

create table patients_pay_appointments
(
    p_id int foreign key references patients(p_id),
    a_id int foreign key references appointments(a_id),
    py_id int foreign key references payments(py_id),
    primary key (p_id, a_id, py_id),
)

create table patients_pay_treatments
(
    p_id int foreign key references patients(p_id),
    t_id int foreign key references treatments(t_id),
    py_id int foreign key references payments(py_id),
    primary key (p_id, t_id, py_id),
)

create table patients_pay_medications
(
    p_id int foreign key references patients(p_id),
    m_id int foreign key references medications(m_id),
    py_id int foreign key references payments(py_id),
    primary key (p_id, m_id, py_id),
)
go



create table pilot
(
    p_id int primary key ,
    name varchar(255),
)

create table aircraft
(
    a_id int primary key ,
    capacity int,
)
go


insert into doctors (name, date_of_birth, specialities) values ('Dr. John', '1980-01-01', 'Cardiologist')
insert into doctors (name, date_of_birth, specialities) values ('Dr. Smith', '1970-01-01', 'Dermatologist')


insert into patients (name, address, phone_number, d_id) values ('John Doe', '123 Main St', 1234567890, 1)
insert into patients (name, address, phone_number, d_id) values ('Jane Doe', '456 Main St', 1234567890, 2)
insert into patients (name, address, phone_number, d_id) values ('John Smith', '789 Main St', 1234567890, 1)


insert into appointments (p_id, d_id, date, time, reason) values (1, 1, '2021-01-01', '10:00', 'Checkup')
insert into appointments (p_id, d_id, date, time, reason) values (2, 2, '2021-01-02', '11:00', 'Checkup')
insert into appointments (p_id, d_id, date, time, reason) values (3, 1, '2021-01-03', '12:00', 'Checkup')
insert into appointments (p_id, d_id, date, time, reason) values (1, 1, '2021-01-04', '13:00', 'Checkup')
insert into appointments (p_id, d_id, date, time, reason) values (2, 2, '2021-01-05', '14:00', 'Checkup')
go



delete from pilot
delete from aircraft
insert into aircraft (a_id, capacity) values (3, 300)
insert into pilot (p_id, name) values (2, 'Alex')
go

select * from aircraft
select * from pilot

dbcc useroptions
set transaction isolation level repeatable read

begin tran
update aircraft
set capacity= 320
where a_id = 3
waitfor delay '00:00:05'
update pilot
set name = 'Vlad'
where p_id = 2
waitfor delay '00:00:05'
commit tran



