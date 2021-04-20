-- DML

USE inlock_games_tarde;
GO

INSERT INTO tiposUsuarios (titulo)
VALUES		('Admistrador')
		   ,('Cliente');
GO


INSERT INTO usuarios (email, senha, idTipoUsuario)
VALUES			('admin@admin.com', 'admin', 1)
			   ,('cliente@cliente.com', 'cliente', 2);
GO


INSERT INTO estudios (nomeEstudio)
VALUES			('Blizzard')
			   ,('Rockstar Studios')
			   ,('Square Enix');
GO


INSERT INTO jogos (nomeJogo, descricao, valor, dataLancamento, idEstudio)
VALUES			('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', 99, '15/05/2012', 1)
			   ,('Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western', 120, '26/10/2018', 2);
GO