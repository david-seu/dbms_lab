create table producers(
    p_id int identity(1,1) primary key ,
    name varchar(255),
    phone_number int,
    website varchar(255),
)

create table varieties(
    v_id int identity(1,1) primary key ,
    name varchar(255),
    description varchar(255),
)

create table wines(
    w_id int identity(1,1) primary key ,
    name varchar(255),
    description varchar(255),
    p_id int foreign key references producers(p_id),
    v_id int foreign key references varieties(v_id),
)

create table wine_stores(
    ws_id int identity(1,1) primary key ,
    name varchar(255),
    phone_number int,
    website varchar(255),
)

create table offers(
    ws_id int foreign key references wine_stores(ws_id),
    w_id int foreign key references wines(w_id),
    constraint pk_o primary key (ws_id, w_id),
    price int,
)
go

insert into producers(name, phone_number, website) values('producer1', 1234567890, 'www.producer1.com')
insert into producers(name, phone_number, website) values('producer2', 1234567890, 'www.producer2.com')
insert into producers(name, phone_number, website) values('producer3', 1234567890, 'www.producer3.com')

insert into varieties(name, description) values('variety1', 'description1')
insert into varieties(name, description) values('variety2', 'description2')
insert into varieties(name, description) values('variety3', 'description3')

insert into wines(name, description, p_id, v_id) values('wine1', 'description1', 1, 1)
insert into wines(name, description, p_id, v_id) values('wine2', 'description2', 2, 2)
insert into wines(name, description, p_id, v_id) values('wine3', 'description3', 3, 3)
insert into wines(name, description, p_id, v_id) values('wine4', 'description4', 1, 2)
insert into wines(name, description, p_id, v_id) values('wine5', 'description5', 2, 3)
insert into wines(name, description, p_id, v_id) values('wine6', 'description6', 1, 1)
go