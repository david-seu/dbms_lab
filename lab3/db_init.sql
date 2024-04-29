
create table areas
(
area_id         int not null,
constraint pk_areas  primary key(area_id),
name        varchar(50) not null,
description varchar(max),
)
go

create table projects
(
project_id         int not null,
constraint pk_projects  primary key(project_id),
title       varchar(50) not null,
status      bit not null,
description varchar(max),
)
go

create table resources (
resource_id         int not null,
constraint pk_resources  primary key(resource_id),
name        varchar(50) not null,
description varchar(max),
area_id         int not null,
constraint fk_areas foreign key(area_id) references areas(area_id),
)
go

create table employee
(
    employee_id int            not null,
    constraint pk_employee primary key (employee_id),
    name        varchar(50)    not null,
    email       varchar(50)    not null,
    salary      decimal(18, 2) not null,
)

create table project_employee
(
    project_id  int not null,
    employee_id int not null,
    constraint pk_project_employee primary key (project_id, employee_id),
    constraint fk_project_employee_project foreign key (project_id) references projects (project_id),
    constraint fk_project_employee_employee foreign key (employee_id) references employee (employee_id),
)



