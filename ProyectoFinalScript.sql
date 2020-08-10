USE Master
go

if exists(Select * FROM SysDataBases WHERE name='ProyectoFinalBios')
BEGIN
	DROP DATABASE ProyectoFinalBios
END
go

CREATE DATABASE ProyectoFinalBios -- agregar directorio para guardar BD (C:\ProyectoFinalBios)
GO

USE ProyectoFinalBios
GO

CREATE TABLE Farmaceutica
(
	RUC VARCHAR(12) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(20) NOT NULL,
	Email VARCHAR(30) NOT NULL,
	Direccion VARCHAR(30) NOT NULL
)
GO

CREATE TABLE Medicamento
(
	RUC VARCHAR(12) NOT NULL FOREIGN KEY REFERENCES Farmaceutica(RUC),
	Codigo INT NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(30) NOT NULL,
	Precio INT NOT NULL,
	Descripcion VARCHAR(50),
	PRIMARY KEY (RUC, Codigo)
)
GO

CREATE TABLE Usuario
(
	Login VARCHAR(30) NOT NULL PRIMARY KEY,
	Contraseña VARCHAR(30) NOT NULL UNIQUE,
	Nombre VARCHAR(20) NOT NULL,
	Apellido VARCHAR(20) NOT NULL
)
GO

CREATE TABLE Empleado
(
	Login VARCHAR(30) NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Usuario(Login),
	Hora_I TIME,
	Hora_F TIME
)
GO

CREATE TABLE Cliente 
(
	Login VARCHAR(30) NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Usuario(Login),
	Direccion VARCHAR(30) NOT NULL,
)
GO

CREATE TABLE Telefono 
(
	Login Varchar(30) NOT NULL FOREIGN KEY REFERENCES Cliente(Login),
	Numero INT NOT NULL,
	PRIMARY KEY (Login, Numero)
)
GO

CREATE TABLE Pedido 
(
	Num_Pedido INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Login VARCHAR(30) NOT NULL FOREIGN KEY REFERENCES Cliente(Login),
	RUC VARCHAR(12) NOT NULL,
	Codigo INT NOT NULL,
	Cantidad INT NOT NULL, 
	Estado VARCHAR(20),
	FOREIGN KEY (RUC, Codigo) REFERENCES Medicamento(RUC,Codigo)
)
GO


CREATE PROCEDURE AltaFarmaceutica @RUC VARCHAR(12), @Nombre VARCHAR(20), @Email VARCHAR(30), @direccion VARCHAR(30) AS
BEGIN
		if (EXISTS (SELECT * FROM Farmaceutica WHERE RUC=@RUC))
		RETURN -1
		
	DECLARE @Error int
	BEGIN TRAN

	INSERT Farmaceutica(RUC, Nombre, Email, Direccion) VALUES(@RUC,@Nombre,@Email,@direccion) 
	SET @Error=@@ERROR;
	
	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END 
GO


CREATE PROCEDURE AltaMedicamento @RUC VARCHAR(12), @Nombre VARCHAR(30), @Precio INT, @Descripcion VARCHAR(50) AS
BEGIN
		if NOT((EXISTS (SELECT * FROM Farmaceutica WHERE RUC=@RUC)))
		RETURN -1
		
		
	DECLARE @Error int
	BEGIN TRAN

	INSERT Medicamento(RUC, Nombre, Precio, Descripcion) VALUES(@RUC,@Nombre,@Precio,@Descripcion) 
	SET @Error=@@ERROR;
	
	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END 
GO


CREATE PROCEDURE AltaEmpleado @Login Varchar(30), @Contraseña VARCHAR(30), @Nombre VARCHAR(20), @Apellido VARCHAR(20), @HoraI TIME, @HoraF TIME AS
BEGIN
		if(EXISTS (SELECT * FROM Usuario WHERE Login=@Login ))
		RETURN -1

		
	DECLARE @Error int
	BEGIN TRAN

	INSERT Usuario(Login,Contraseña, Nombre, Apellido) VALUES(@Login,@Contraseña,@Nombre,@Apellido) 
	SET @Error=@@ERROR;
	
	INSERT Empleado(Login,Hora_I,Hora_F) VALUES(@Login,@HoraI,@HoraF) 
	SET @Error=@@ERROR + @Error;
	
	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END 
GO


CREATE PROCEDURE AltaCliente @Login VARCHAR(30), @Contraseña VARCHAR(30), @Nombre VARCHAR(20), @Apellido VARCHAR(20), @Direccion VARCHAR(30) AS
BEGIN
		IF (EXISTS (SELECT * FROM Usuario WHERE Login=@Login ))
		RETURN -1

		
	DECLARE @Error int
	BEGIN TRAN

	INSERT Usuario(Login,Contraseña, Nombre, Apellido) VALUES(@Login,@Contraseña,@Nombre,@Apellido) 
	SET @Error=@@ERROR;
	
	INSERT Cliente(Login,Direccion) VALUES(@Login,@Direccion) 
	SET @Error=@@ERROR + @Error;
	
	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END 
GO

CREATE PROCEDURE AltaTelefono @Login VARCHAR(30), @Numero INT AS
BEGIN
		if not(EXISTS (SELECT * FROM Cliente WHERE Login=@Login ))
		RETURN -1
		
		if (EXISTS (SELECT * FROM telefono WHERE Login=@Login AND Numero =@Numero ))
		RETURN -2

		
	DECLARE @Error int
	BEGIN TRAN

	INSERT Telefono(Login, Numero) VALUES(@Login,@Numero) 
	SET @Error=@@ERROR;
	
	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	
END 
GO


CREATE PROCEDURE AltaPedido @Ruc VARCHAR(12), @login VARCHAR(30), @Codigo int, @Cant int, @Estado VARCHAR(20) AS
BEGIN
		if not(EXISTS (SELECT * FROM Cliente WHERE Login=@login ))
		RETURN -1
		
		if not(EXISTS (SELECT * FROM Medicamento WHERE RUC = @Ruc AND Codigo =@Codigo ))
		RETURN -2

		
	DECLARE @Error int
	BEGIN TRAN

	INSERT Pedido(RUC,Codigo,Login,Cantidad,Estado) VALUES(@Ruc,@Codigo,@login,@Cant,@Estado) 
	SET @Error=@@ERROR;
	
	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	
END 
GO

CREATE PROCEDURE ModificarFarmaceutica @RUC VARCHAR(12), @Nombre VARCHAR(20), @Direccion VARCHAR(30), @Email VARCHAR(30) AS
BEGIN
	if Not(EXISTS (SELECT * FROM Farmaceutica WHERE RUC=@RUC))
		RETURN -1
		
	DECLARE @Error int
	BEGIN TRAN

	UPDATE Farmaceutica 
	SET Nombre = @Nombre, Email = @Email, Direccion = @Direccion
	WHERE RUC = @RUC
	SET @Error=@@ERROR;
   

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END 
GO


CREATE PROCEDURE ModificarMedicamento @RUC VARCHAR(12), @Codigo INT, @Nombre VARCHAR(30), @Precio INT, @Descripcion VARCHAR(50)  AS
BEGIN
	if Not(EXISTS (SELECT * FROM Farmaceutica WHERE RUC=@RUC))
		RETURN -1
	
	IF NOT (EXISTS (SELECT * FROM Medicamento WHERE RUC = @RUC AND Codigo = @COdigo))
		RETURN -2
		
	DECLARE @Error int
	BEGIN TRAN

	UPDATE Medicamento 
	SET Nombre = @Nombre, Precio = @precio, Descripcion = @Descripcion
	WHERE RUC = @RUC AND Codigo = @Codigo
	SET @Error=@@ERROR;
   

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	
END 
GO

CREATE PROCEDURE ModificarEmpleado @Login VARCHAR(30), @Contraseña VARCHAR(30), @Nombre VARCHAR(20), @Apellido VARCHAR(20), @HoraI TIME, @HoraF time AS
BEGIN
		if Not(EXISTS (SELECT * FROM Usuario WHERE login = @Login))
		RETURN -1
		
		if Not(EXISTS (SELECT * FROM Empleado WHERE login = @Login))
		RETURN -2
		
		
	DECLARE @Error int
	BEGIN TRAN
	
	UPDATE Usuario
	SET Contraseña = @Contraseña, Nombre = @Nombre, Apellido = @Apellido
	WHERE login = @Login
	SET @Error=@@ERROR;
	
	UPDATE Empleado
	SET Hora_I = @HoraI, Hora_F = @HoraF
	WHERE login = @Login 
	SET @Error=@@ERROR+@Error;

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -4
	END	
END 
GO

CREATE PROCEDURE ModificarCliente @Login VARCHAR(30), @Contraseña VARCHAR(30), @Nombre VARCHAR(20), @Apellido VARCHAR(20), @Direccion VARCHAR(30) AS 
BEGIN
		if Not(EXISTS (SELECT * FROM Usuario WHERE login = @Login))
		RETURN -1
		
		if Not(EXISTS (SELECT * FROM Cliente WHERE login = @Login))
		RETURN -2
		
		
	DECLARE @Error int
	BEGIN TRAN

	UPDATE Usuario
	SET Contraseña = @Contraseña, Nombre = @Nombre, Apellido = @Apellido
	WHERE login = @Login
	SET @Error=@@ERROR;
	
	UPDATE Cliente
	SET Direccion = @Direccion
	WHERE login = @Login 
	SET @Error=@@ERROR+@Error;

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	
END
GO

CREATE PROCEDURE ModificarPedido @Numero INT , @Login VARCHAR(30), @RUC VARCHAR(12), @Codigo INT, @Estado VARCHAR(20) AS
BEGIN
	   
	   	if Not(EXISTS (SELECT * FROM Pedido WHERE Num_pedido = @Numero))
		RETURN -1
		
		if Not(EXISTS (SELECT * FROM Cliente WHERE login = @Login))
		RETURN -2
		
		if Not(EXISTS (SELECT * FROM Medicamento WHERE RUC = @RUC AND Codigo = @Codigo))
		RETURN -3
		

	DECLARE @Error int
	BEGIN TRAN

	UPDATE Pedido
	SET Estado = @Estado
	WHERE Num_pedido = @Numero
	SET @Error=@@ERROR;

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -4
	END	
END 
GO

CREATE PROCEDURE BajaFarmaceutica @RUC VARCHAR(12) AS
BEGIN
	IF not(EXISTS(SELECT * FROM  Farmaceutica WHERE RUC = @RUC))
	RETURN -1

	DECLARE @Error int
	BEGIN TRAN

	DELETE Farmaceutica	WHERE RUC = @RUC
	SET @Error=@@ERROR;

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END 
GO


CREATE PROCEDURE BajaMedicamento @RUC VARCHAR(12), @Codigo INT AS
BEGIN

	IF not(EXISTS(SELECT * FROM Farmaceutica WHERE RUC = @RUC))
	RETURN -1
	
	IF not(EXISTS(SELECT * FROM Medicamento WHERE RUC = @RUC AND Codigo = @Codigo))
	RETURN -2

	DECLARE @Error int
	BEGIN TRAN

	DELETE Pedido WHERE RUC = @RUC AND Codigo = @Codigo
	SET @Error=@@ERROR
	
	DELETE Medicamento WHERE RUC = @RUC AND Codigo = @Codigo
	SET @Error=@@ERROR+@Error;

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	
END 
GO

CREATE PROCEDURE BajaEmpleado @Login VARCHAR(30)AS
BEGIN
		IF not(EXISTS(SELECT * FROM Usuario WHERE Login = @Login))
	RETURN -1
	
	IF not(EXISTS(SELECT * FROM Empleado WHERE Login = @Login))
	RETURN -2

	DECLARE @Error int
	BEGIN TRAN

	DELETE Empleado	WHERE Login = @Login
	SET @Error=@@ERROR;
	
	DELETE Usuario WHERE Login = @Login
	SET @Error =@@ERROR+@Error

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	
END 
GO


CREATE PROCEDURE BajaTelefono @Login VARCHAR(30), @Numero INT AS
BEGIN
	IF not(EXISTS(SELECT * FROM Cliente WHERE Login = @Login))
	RETURN -1
	
	IF not(EXISTS(SELECT * FROM Telefono WHERE Login = @Login AND Numero = @Numero))
	RETURN -2

	DECLARE @Error int
	BEGIN TRAN

	DELETE Telefono	WHERE Login = @Login AND Numero = @Numero
	SET @Error=@@ERROR;

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	
END 
GO


CREATE PROCEDURE BajaPedido @Numero INT AS
BEGIN
		IF not(EXISTS(SELECT * FROM  Pedido WHERE Num_pedido = @Numero))
	RETURN -1

	DECLARE @Error int
	BEGIN TRAN

	DELETE Pedido WHERE Num_pedido = @Numero
	SET @Error=@@ERROR;

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END 
GO



CREATE PROCEDURE BuscarPedido @Numero INT AS
BEGIN
	Select * FROM Pedido WHERE Num_pedido = @Numero
END 
GO


CREATE PROCEDURE LogueoCliente @Login VARCHAR(30), @Password VARCHAR(30) AS
BEGIN
	SELECT * FROM Cliente c INNER JOIN Usuario u ON c.Login = u.Login WHERE u.Login = @Login AND u.Contraseña = @Password 
END 
GO

CREATE PROCEDURE LogueoEmpleado @Login VARCHAR(30), @Password VARCHAR(30) AS
BEGIN
	SELECT * FROM Empleado e INNER JOIN Usuario u ON u.Login = e.Login WHERE u.Login = @Login AND u.Contraseña = @Password 
END 
GO

CREATE PROCEDURE BuscarCliente @Login VARCHAR(30) AS
BEGIN
	SELECT * FROM Cliente c INNER JOIN Usuario u ON c.Login = u.Login WHERE u.Login = @Login 
END 
GO


CREATE PROCEDURE BuscarEmpleado @Login VARCHAR(30) AS
BEGIN
	SELECT * FROM Empleado e INNER JOIN Usuario u ON e.Login = u.Login WHERE u.Login = @Login 
END 
GO

CREATE PROCEDURE BuscarTelefono @Login VARCHAR(30), @Numero INT AS
BEGIN
	SELECT * FROM Telefono WHERE login = @Login and numero = @Numero
END 
GO

CREATE PROCEDURE ListarTelefono @Login VARCHAR(30) AS
BEGIN
	SELECT Numero FROM Telefono WHERE login = @Login 
END 
GO

CREATE PROCEDURE BuscarFarmaceutica @RUC VARCHAR(12) AS
BEGIN 
	SELECT * FROM Farmaceutica WHERE RUC = @RUC
END 
GO

CREATE PROCEDURE BuscarMedicamento @RUC VARCHAR(12), @Codigo INT AS
BEGIN 
	SELECT * FROM Medicamento WHERE RUC = @RUC AND Codigo = @Codigo
END 
GO

CREATE PROCEDURE ListarPedidoPorCliente @Login VARCHAR(30)AS
BEGIN
	SELECT * FROM Pedido WHERE Login = @Login AND Estado = 'Generado'
END 
GO

CREATE PROCEDURE ListarPedidoGenerado @Login VARCHAR(30)AS
BEGIN
	SELECT * FROM Pedido WHERE Estado = 'Generado' OR Estado = 'Enviado'
END 
GO

CREATE PROCEDURE ListarPedidoPorMedicamento @Ruc VARCHAR(12), @Codigo INT AS
BEGIN
	SELECT * FROM pedido WHERE RUC = @RUC AND Codigo = @Codigo
END 
GO

CREATE PROCEDURE ListarPedidoPorMedicamentoGenerados @Ruc VARCHAR(12), @Codigo INT AS
BEGIN
	SELECT * FROM pedido WHERE RUC = @RUC AND Codigo = @Codigo AND Estado= 'Generado'
END 
GO

CREATE PROCEDURE ListarPedidoPorMedicamentoEntregados @Ruc VARCHAR(12), @Codigo INT AS
BEGIN
	SELECT * FROM pedido WHERE RUC = @RUC AND Codigo = @Codigo AND Estado = 'Entregado'
END 
GO


CREATE PROCEDURE ListarFarmaceutica  AS
BEGIN
	SELECT * FROM Farmaceutica 
END 
GO

CREATE PROCEDURE ListarMedicamentoPorFarmaceutica @RUC VARCHAR(12) AS
BEGIN
	SELECT * FROM Medicamento WHERE RUC = @RUC
END 
GO

CREATE PROCEDURE ListarMedicamentoPorNombre @Nombre INT AS
BEGIN
	SELECT * FROM Medicamento WHERE Nombre = @Nombre
END 
GO

CREATE PROCEDURE ListarMedicamento AS
BEGIN
	SELECT * FROM Medicamento 
END 
GO

CREATE PROCEDURE ListarMedicamentoPorPedido @Numero INT AS
BEGIN
	SELECT M.* FROM Medicamento M INNER JOIN Pedido P ON P.RUC = M.RUC AND P.Codigo = M.Codigo WHERE P.Num_pedido = @Numero
END 
GO


INSERT INTO Usuario(Login,Contraseña,Nombre,Apellido) VALUES('emp1', 'empleado12', 'Antonio', 'Roca')
INSERT INTO Usuario(Login,Contraseña,Nombre,Apellido) VALUES('emp2', 'empleado123', 'Felipe', 'Roca')
INSERT INTO Usuario(Login,Contraseña,Nombre,Apellido) VALUES('emp3', 'empleado1234', 'Marcos', 'Costa')
INSERT INTO Usuario(Login,Contraseña,Nombre,Apellido) VALUES('emp4', 'empleado12345', 'Ignacio', 'Fernandez')
Go

INSERT INTO Usuario(Login,Contraseña,Nombre,Apellido) VALUES('Cliente1', 'Cliente1', 'Lucas', 'Gonzalez')
INSERT INTO Usuario(Login,Contraseña,Nombre,Apellido) VALUES('Cliente2', 'Cliente2', 'Juan', 'Lopez')
INSERT INTO Usuario(Login,Contraseña,Nombre,Apellido) VALUES('Cliente3', 'Cliente3', 'Ana', 'Hernandez')
INSERT INTO Usuario(Login,Contraseña,Nombre,Apellido) VALUES('Cliente4', 'Cliente4', 'Maria', 'Rodrigez')
Go

INSERT INTO Cliente(Login,Direccion) VALUES('Cliente1', 'Bulevar Artigas 2154')
INSERT INTO Cliente(Login,Direccion) VALUES('Cliente2', 'Luis Alberto de Herrera 1545')
INSERT INTO Cliente(Login,Direccion) VALUES('Cliente3', 'José Batlle y Ordóñez 2546')
INSERT INTO Cliente(Login,Direccion) VALUES('Cliente4', 'Av. 18 de Julio 1325')
Go 

INSERT INTO Telefono(Login,Numero) VALUES('Cliente1',099100100)
INSERT INTO Telefono(Login,Numero) VALUES('Cliente2',099200200)
INSERT INTO Telefono(Login,Numero) VALUES('Cliente3',099300300)
INSERT INTO Telefono(Login,Numero) VALUES('Cliente4',099400400)
Go

INSERT INTO Empleado(Login, Hora_I, Hora_F) VALUES('emp1', '18:30', '2:30')
INSERT INTO Empleado(Login, Hora_I, Hora_F) VALUES('emp2', '9:30', ' 16:30')
INSERT INTO Empleado(Login, Hora_I, Hora_F) VALUES('emp3', '16:30', '1:30')
INSERT INTO Empleado(Login, Hora_I, Hora_F) VALUES('emp4', '2:30', '10:30')
Go

INSERT INTO Farmaceutica(RUC, Nombre, Email, Direccion) VALUES('123456789123', 'LosAngeles', 'Almieda@gmail', 'Alverto Ruiz 5234')
INSERT INTO Farmaceutica(RUC, Nombre, Email, Direccion) VALUES('098765432123', 'FarmaShop', 'FarmaShop@gmail', 'Bulevar España 2648')
INSERT INTO Farmaceutica(RUC, Nombre, Email, Direccion) VALUES('324516278943', 'FramaciaLopez', 'FramaciaLopez@gmail', 'Av. Ramón Anador 3845')
INSERT INTO Farmaceutica(RUC, Nombre, Email, Direccion) VALUES('555554444637', 'MediAll', 'MediAll@gmail', 'José Batlle y Ordóñez 1458')
Go

INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('123456789123', 'Amoxidal',150, 'Amoxidal 500 mg Comprimidos x 21')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('123456789123', 'Dorixina',200, 'Dorixina 125 mg Comprimidos recubiertos x 20')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('123456789123', 'Bronax',50, 'Bronax 15 mg Comprimidos x 30')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('123456789123', 'Dexopral',300, 'Dexopral 60 mg Cápsulas x 30')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('098765432123', 'Amoxidal',200, 'Amoxidal 500 mg Comprimidos x 21')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('098765432123', 'Dorixina',160, 'Dorixina 125 mg Comprimidos recubiertos x 20')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('098765432123', 'Bronax',140, 'Bronax 15 mg Comprimidos x 30')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('098765432123', 'Dexopral',310, 'Dexopral 60 mg Cápsulas x 30')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('324516278943', 'Amoxidal',100, 'Amoxidal 500 mg Comprimidos x 21')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('324516278943', 'Dorixina',105, 'Dorixina 125 mg Comprimidos recubiertos x 20')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('324516278943', 'Bronax',115, 'Bronax 15 mg Comprimidos x 30')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('324516278943', 'Dexopral',120, 'Dexopral 60 mg Cápsulas x 30')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('555554444637', 'Amoxidal',100, 'Amoxidal 500 mg Comprimidos x 21')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('555554444637', 'Dorixina',200, 'Dorixina 125 mg Comprimidos recubiertos x 20')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('555554444637', 'Bronax',300, 'Bronax 15 mg Comprimidos x 30')
INSERT INTO Medicamento(RUC, Nombre, Precio, Descripcion) VALUES ('555554444637', 'Dexopral',310, 'Dexopral 60 mg Cápsulas x 30')
Go

INSERT INTO Pedido(Login, RUC, Codigo, Cantidad, Estado) VALUES ('Cliente2', '123456789123', 1,1, 'Generado')
INSERT INTO Pedido(Login, RUC, Codigo, Cantidad, Estado) VALUES ('Cliente4', '123456789123', 4,60, 'Entregado')
Go

select * from usuario