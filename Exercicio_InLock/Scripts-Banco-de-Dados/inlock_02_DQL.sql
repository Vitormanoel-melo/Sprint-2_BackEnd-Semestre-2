-- DQL

USE inlock_games_tarde;
GO

-- Listar todos os usu�rios
SELECT * FROM usuarios;
GO


-- Listar todos os est�dios
SELECT * FROM estudios;
GO


-- Listar todos os jogos
SELECT * FROM jogos;
GO


-- Listar todos os jogos e seus respectivos est�dios
SELECT nomeJogo, nomeEstudio FROM jogos
INNER JOIN estudios
ON jogos.idEstudio = estudios.idEstudio;
GO


-- Buscar e trazer na lista todos os est�dios com os respectivos jogos. Obs.: Listar
-- todos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia
SELECT nomeEstudio, nomeJogo FROM estudios
LEFT JOIN jogos
ON estudios.idEstudio = jogos.idEstudio;
GO


-- Buscar um usu�rio por e-mail e senha (login)
SELECT idUsuario, email, senha, idTipoUsuario FROM usuarios
WHERE email = 'cliente@cliente.com' AND senha = 'cliente';
GO


-- Buscar um jogo por idJogo
SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogos
WHERE idJogo = 1;
GO


-- Buscar um est�dio por idEstudio
SELECT idEstudio, nomeEstudio FROM estudios
WHERE idEstudio = 1;
GO


-- Comandos Adicionais

SELECT * FROM tiposUsuarios;
GO


SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, nomeEstudio FROM jogos
INNER JOIN estudios
ON jogos.idEstudio = estudios.idEstudio;
GO


SELECT * FROM jogos
WHERE idEstudio = 1;
GO


-- Mostrar a lista de todos os est�dios e incluir na lista a lista de jogos daquele determinado est�dio
SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, estudios.idEstudio, nomeEstudio FROM jogos
INNER JOIN estudios
ON jogos.idEstudio = estudios.idEstudio
WHERE jogos.idEstudio = 2;