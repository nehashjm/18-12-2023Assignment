create database Day8AssignmentDb
on primary (name='Day8Assignment_Db', Filename='D:\mphasis Simplilearn\Phase2\Assignment\Day8\Day8Assignment_Db.mdf')
log on (name='Day8Assignment_Db_log',filename='D:\mphasis Simplilearn\Phase2\Assignment\Day8\Day8Assignment_Db_log.ldf')
COLLATE SQL_Latin1_General_CP1_CI_AS

use Day8AssignmentDb

create table Products
(PId nvarchar(50) primary key,
PName nvarchar(50) not null,
Price float not null,
MfgDate date not null,
ExpDate date not null
)
insert into Products values ('P00001','TV',20000.00,'12/12/2002','12/12/2022')
insert into Products values ('P00002','Mobile',25000.00,'02/02/2002','12/12/2003')
insert into Products values ('P00003','Oven',3000.00,'03/03/2003','03/03/2023')
insert into Products values ('P00004','washingmachine',29000.00,'04/04/2004','04/04/2014')
insert into Products values ('P00005','Laptop',35000.00,'10/10/2012','11/12/2021')
insert into Products values ('P00006','Desktop',24000.00,'09/09/2001','10/10/2011')
insert into Products values ('P00007','cpu',40000.00,'11/10/2012','12/12/2022')
insert into Products values ('P00008','printer',12000.00,'10/03/2022','12/12/2029')
insert into Products values ('P00009','fan',2000.00,'11/11/2002','12/12/2012')
insert into Products values ('P00010','joystick',21000.00,'10/12/2002','12/10/2022')

select * from Products order by PId desc