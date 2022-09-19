create database SmartElectronics
use SmartElectronics

create table Category(CategoryID int identity(1,1) primary key,CategoryName varchar(30))

create table Product(ProdID int identity(101,1) primary key,CategoryID int references Category(CategoryID),Brand varchar(20),Model varchar(100),Price float,Count int,img1 varchar(200),img2 varchar(200),img3 varchar(200))
create table TVDescription(ProdID int references Product(ProdID),Brand varchar(20),ScreenSize varchar(20),DisplayTechnology varchar(40),Hardware varchar(100),Services varchar(100),SpecialFeature varchar(100))
alter table TVDescription add Model varchar(40)
alter table TVDescription alter column Model varchar(100)
alter table TVDescription alter column SpecialFeature varchar(500)


create table AudioDescription(ProdID int references Product(ProdID),Brand varchar(20),Model varchar(40),Color varchar(20),ConnectorType varchar(30),SpecialFeature varchar(100))
drop table EarphonesDescription

create table Customer(CustomerID int identity(1001,1),CustomerName varchar(40),Email varchar(50),MobileNumber bigint,Password varchar(15))
alter table Customer alter column CustomerID int not null
alter table Customer add primary key(CustomerID)

create table OrderDetails(OrderID int identity(2001,1) primary key,ProdID int references Product(ProdID),CustomerID int references Customer(CustomerID),Price float ,DeliveryDate Date,Address varchar(500))

create table CartDetails(CustomerID int references Customer(CustomerID),ProdID int references Product(ProdID),Price float)