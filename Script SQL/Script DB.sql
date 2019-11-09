CREATE DATABASE LocalizaAmigos
GO

CREATE TABLE Amigos(
Id INT Primary key Identity(1,1) not null,
Nome VARCHAR(100) not null,
[Login] VARCHAR(100) not null,
Latitude FLOAT not null,
Longitude FLOAT not null

)
GO
CREATE TABLE CalculoHistoricoLog(
	[Login] VARCHAR(100) NOT NULL,
	AmigoNome VARCHAR(100),
	AmigoLogin VARCHAR(100),
	DataPesquisada DATETIME,
	Distancia FLOAT

)
GO
CREATE PROCEDURE CalculoHistoricoLog_Insert
(
	@Login VARCHAR(100) = 'Automatico',
	@AmigoNome VARCHAR(100),
	@AmigoLogin VARCHAR(100),
	@DataPesquisada DATETIME,
	@Distancia FLOAT

)
AS

INSERT INTO CalculoHistoricoLog
VALUES(@Login,@AmigoNome,@AmigoLogin,@DataPesquisada,@Distancia )
GO
CREATE PROCEDURE LocalizaAmigos_Select
AS
SELECT Id,Nome,[Login],Latitude,Longitude
FROM Amigos
GO
INSERT INTO Amigos(Nome ,[Login] ,Latitude ,Longitude)
VALUES ('Teste1','teste1@teste1.com',-23.569521, -46.516293),
	   ('Teste2','teste2@teste2.com',-23.568911, -46.513804),
	   ('Teste3','teste3@teste3.com',-23.567849, -46.507989),
	   ('Teste4','teste4@teste4.com',-23.567377, -46.502345),
	   ('Teste5','teste5@teste5.com',-23.567574, -46.522752),
	   ('Teste6','teste6@teste6.com',-23.557819, -46.527644),
	   ('Teste7','teste7@teste7.com',-23.577916, -46.536054)

	   --TRUNCATE TABLE Amigos