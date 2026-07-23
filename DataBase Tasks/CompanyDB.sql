
USE CompanyDB;
GO
-- 1. Create Tables
create table Employee(
    Fname nvarchar(20) not null,
    Mname nvarchar(20),
    Lname nvarchar(20) not null,
    Ssn int primary key identity(1,1),
    Bdate date,
    EmployeeAddress nvarchar(100),
    Gender bit default 0,
    Salary int CONSTRAINT CK_Employee_Salary check(Salary between 500 and 3500),
    Super_ssn int,
    foreign key (Super_ssn) references Employee(Ssn)
)

create table Department(
    Dname nvarchar(20) not null,
    Dnumber int primary key identity(1, 1),
    Mgr_ssn int,
    Mgr_start_date date not null,
    foreign key (Mgr_ssn) references Employee(Ssn)
)

create table Dept_Location(
    Dnumber int,
    Dlocation nvarchar(100),
    Foreign key (Dnumber) references Department(Dnumber),
    primary key (Dnumber, Dlocation)
)

create table Project(
    Pname nvarchar(50) not null,
    Pnumber int primary key identity(1,1),
    Plocation nvarchar(100) not null,
    Dnum int,
    foreign key (Dnum) references Department(Dnumber)
)

create table Works_on(
    Essn int,
    Pno int,
    Hrs int not null,
    foreign key (Essn) references Employee(Ssn),
    foreign key (Pno) references Project(Pnumber),
    primary key (Essn, Pno)
)

create table EmployeeDependent(
    Essn int,
    Dependent_name nvarchar(50) not null,
    gender bit default 0,
    Bdate date,
    Relationship nvarchar(10),
    foreign key (Essn) references Employee(Ssn),
    primary key (Essn, Dependent_name)
)
GO

-- 2. Alterations
alter table Employee add Dno int foreign key references Department(Dnumber)
ALTER TABLE Employee ALTER COLUMN Mname nvarchar(10);
EXEC sp_rename 'Employee.Mname', 'Midname', 'COLUMN';
GO

-- 3. Inserts
insert into Employee(Fname, Lname, Bdate, Gender, Salary)
values('karim', 'salah', '2001-10-11', 1, 3000)

insert into Employee(Fname, Lname, Bdate, Gender, Salary, Super_ssn)
values('ali', 'ahmed', '2001-10-11', 1, 2400, 1)

insert into Department(Dname, Mgr_ssn, Mgr_start_date)
values('IT Department', 1, '2023-01-01')

-- Dno will now be recognized here because of GO above
update Employee set Dno = 1 where Ssn IN (1, 2)

insert into Project(Pname, Plocation, Dnum)
values('Database', 'Muscat', 1)

insert into Works_on(Essn, Pno, Hrs)
values(2, 1, 40)

insert into EmployeeDependent(Essn, Dependent_name, gender, Bdate, Relationship)
values(2, 'Sara', 0, '2015-05-12', 'Daughter')
GO

-- 4. Updates
update Employee set Salary += 200 where Ssn = 2
update Employee set EmployeeAddress = 'Muscat' where Ssn = 1
update Project set Plocation = 'Seeb' where Pnumber = 1
update Works_on set Hrs = 45 where Essn = 2 AND Pno = 1
update EmployeeDependent set Relationship = 'Child' where Essn = 2 AND Dependent_name = 'Sara'
GO

-- 5. Deletes
delete from EmployeeDependent where Essn = 2 AND Dependent_name = 'Sara'
delete from Works_on where Essn = 2 AND Pno = 1
delete from Employee where Ssn = 2
GO