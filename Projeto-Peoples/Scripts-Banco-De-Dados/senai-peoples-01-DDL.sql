-- DDL
CREATE DATABASE T_Peoples
GO

USE T_Peoples;
GO

-- Cria a tabela funcionarios
CREATE TABLE funcionarios
(
	idFuncionario	INT PRIMARY KEY IDENTITY
	,nome			VARCHAR(200)
	,sobrenome		VARCHAR(200)
	,dataNascimento	DATE
);