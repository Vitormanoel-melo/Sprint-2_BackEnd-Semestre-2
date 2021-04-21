-- DDL

CREATE DATABASE inlock_games_tarde;
GO

USE inlock_games_tarde;
GO


CREATE TABLE estudios
(
	idEstudio		INT PRIMARY KEY IDENTITY
	,nomeEstudio	VARCHAR(150) UNIQUE NOT NULL
);
GO


CREATE TABLE jogos
(
	idJogo			INT PRIMARY KEY IDENTITY
	,nomeJogo		VARCHAR(200) UNIQUE NOT NULL
	,descricao		VARCHAR(200) NOT NULL
	,dataLancamento	DATE NOT NULL
	,valor			SMALLMONEY NOT NULL
	,idEstudio		INT FOREIGN KEY REFERENCES estudios(idEstudio)
);
GO


CREATE TABLE tiposUsuarios
(
	idTipoUsuario	INT PRIMARY KEY IDENTITY
	,titulo			VARCHAR(200) NOT NULL
);
GO


CREATE TABLE usuarios
(
	idUsuario		INT PRIMARY KEY IDENTITY
	,email			VARCHAR(200) UNIQUE NOT NULL
	,senha			VARCHAR(200) NOT NULL
	,idTipoUsuario	INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario)
);
GO