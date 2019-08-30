Create Database M_Ekips

Use M_Ekips

				--//DDL

Create Table Departamentos
(
	IdDepartamento Int Primary Key Identity
	,Departamento Varchar (255) Not Null Unique
);

Create Table Cargos
(
	IdCargo Int Primary Key Identity
	,Cargo Varchar (255) Not Null
	,Statuss Varchar (255) Not Null
);

Create Table Usuarios
(
	IdUsuario Int Primary Key Identity
	,Email Varchar (255) Not Null Unique
	,Senha Varchar (255) Not Null
	,Permissao Varchar (255) Not Null
);

Create Table Funcionarios
(
	IdFuncionario Int Primary Key Identity
	,Funcionario Varchar (255) Not Null Unique
	,CPF Varchar (255) Not Null Unique
	,DataNascimento Date Not Null
	,Salario BigInt
	,IdDepartamento Int Foreign Key References Departamentos (IdDepartamento)
	,IdCargo Int Foreign Key References Cargos (IdCargo)
	,IdUsuario Int Foreign Key References Usuarios (IdUsuario)
);

				--//DML

Insert Into Departamentos	(Departamento)
	Values					('Jurídico ')
							,('Tecnologia')
							,('Limpeza');


Insert Into Cargos	(Cargo , Statuss)
	Values			('Advogado Trabalhista' , 'Ativo')
					,('Product Owner' , 'Ativo')
					,('Engenheiro' , 'Ativo')
					,('Lixeiro(gari)' , 'Desativado');

Insert Into Usuarios	(Email , Senha, Permissao)
	Values			('b@email.com', 12345, 'ADMINISTRADOR')
					,('f@email.com', 12345, 'COMUM')
					,('m@email.com', 12345, 'COMUM');

Insert Into Funcionarios(Funcionario , CPF , DataNascimento , Salario , IdDepartamento , IdCargo , IdUsuario)
	Values			('Bob' , 737759178-10, '1990-05-10', 1000, 1, 1, 1)
					,('Fernandao', 630097228-34, '1997-09-06', 3212, 2, 2, 2)
					,('Mario', 426569158-72, '2000-03-13', 9349024, 3, 4, 3);

				--//DQL

Select * From Permissoes

Select * From Departamentos

Select * From Cargos

Select * From Usuarios

Select * From Funcionarios

