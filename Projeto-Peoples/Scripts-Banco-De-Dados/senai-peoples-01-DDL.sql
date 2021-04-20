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
GO


-- cria tabela tiposUsuarios
CREATE TABLE tiposUsuarios
(
	idTipoUsuario	INT PRIMARY KEY IDENTITY
	,descricao		VARCHAR(200) NOT NULL
);
GO


-- Cria tabela usuarios
CREATE TABLE usuarios
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,nome				VARCHAR(255) NOT NULL
	,sobrenome			VARCHAR(255) NOT NULL
	,email				VARCHAR(255) UNIQUE NOT NULL
	,senha				VARCHAR(255) NOT NULL
	,permissao			INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario)
);