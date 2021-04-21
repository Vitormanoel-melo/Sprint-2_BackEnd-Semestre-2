-- DQL

USE inlock_games_tarde;
GO

-- Listar todos os usuários
SELECT * FROM usuarios;
GO


-- Listar todos os estúdios
SELECT * FROM estudios;
GO


-- Listar todos os jogos
SELECT * FROM jogos;
GO


-- Listar todos os jogos e seus respectivos estúdios
SELECT nomeJogo, nomeEstudio FROM jogos
INNER JOIN estudios
ON jogos.idEstudio = estudios.idEstudio;
GO


-- Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar
-- todos os estúdios mesmo que eles não contenham nenhum jogo de referência
SELECT nomeEstudio, nomeJogo FROM estudios
LEFT JOIN jogos
ON estudios.idEstudio = jogos.idEstudio;
GO


-- Buscar um usuário por e-mail e senha (login)
SELECT idUsuario, email, senha, idTipoUsuario FROM usuarios
WHERE email = 'cliente@cliente.com' AND senha = 'cliente';
GO


-- Buscar um jogo por idJogo
SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogos
WHERE idJogo = 1;
GO


-- Buscar um estúdio por idEstudio
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


-- Mostrar a lista de todos os estúdios e incluir na lista a lista de jogos daquele determinado estúdio
SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, estudios.idEstudio, nomeEstudio FROM jogos
INNER JOIN estudios
ON jogos.idEstudio = estudios.idEstudio
WHERE jogos.idEstudio = 2;