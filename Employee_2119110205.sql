create database HR
go
use HR
go
create table Employee_2119110205(
	IdEmployee varchar(255), 
	Name nvarchar(255), 
	DateBirth date,
	Gender int,  
	PlaceBirth nvarchar(255), 
	IdDepartment varchar(255))
	go
	create table Department_2119110205(
	IdDepartment varchar(255),
	Name nvarchar(255))

	go
	insert into Employee_2119110205 values('53418',N'Trần Tiến','10/11/2000',	1,N'Hà Nội','IT')
	insert into Employee_2119110205 values('53416',N'Nguyễn Cường','07/21/1996',0,N'Đắk Lắk','KT')
	insert into Employee_2119110205 values('53417',N'Nguyễn Hào','12/25/1996',1,N'TP.Hồ Chí Minh','KSNB')
				
								
	select*from Employee_2119110205 
	go
	insert into Department_2119110205 values('IT',N'Công nghệ thông tin')		
	insert into Department_2119110205 values('KT',N'Kế toán')
	insert into Department_2119110205 values('KSNB',N'Kiểm soát nội bộ')
	
	go
--lấy dữ liệu
 create procedure SelectAllEmployee_2119110205
 as
 select*from Employee_2119110205
 go
 exec SelectAllEmployee_2119110205

 go
  create procedure SelectAllDepartment_2119110205
  as
 select*from Department_2119110205
 go
 exec SelectAllDepartment_2119110205
  go
  create procedure SelectDepartment_2119110205(@IdDepartment varchar(255))
 as
 select*from Department_2119110205 where IdDepartment = @IdDepartment
 go
 exec SelectDepartment_2119110205 'IT'
 go
 --thêm 1 hàng mới
 create procedure InsertEmployee_2119110205(			
	@IdEmployee varchar(255), 
	@Name nvarchar(255), 
	@DateBirth date,
	@Gender int,  
	@PlaceBirth nvarchar(255), 
	@IdDepartment varchar(255))
as
	insert into Employee_2119110205(IdEmployee, Name,DateBirth, Gender,PlaceBirth,IdDepartment) values(@IdEmployee, @Name,@DateBirth, @Gender,@PlaceBirth,@IdDepartment)
go
	exec InsertEmployee_2119110205 '53427',N'Nguyễn Hào','12/25/2001',1,N'TP.Hồ Chí Minh','KSNB'
	 select*from Employee_2119110205
go
 --Xóa 1 hàng
  create procedure DeleteEmployee_2119110205(
  @IdEmployee nvarchar(30))
  as
  delete Employee_2119110205 where IdEmployee=@IdEmployee
  go
  exec DeleteEmployee '53427'
   select*from Employee_2119110205
   drop proc  DeleteEmployee
go
--sửa 1 thông tin
 create proc UpdateEmployee_2119110205(
@IdEmployee varchar(255), 
	@Name nvarchar(255), 
	@DateBirth date,
	@Gender int,  
	@PlaceBirth nvarchar(255), 
	@IdDepartment varchar(255))
 
 as
 UPDATE Employee_2119110205 SET Name = @Name, DateBirth= @DateBirth, Gender =@Gender, PlaceBirth=@PlaceBirth, IdDepartment=@IdDepartment WHERE IdEmployee = @IdEmployee
 go
 exec UpdateEmployee_2119110205 '53427',N'Nguyễn An','12/25/2001',1,N'TP.Hồ Chí Minh','KSNB'
   select*from Employee_2119110205