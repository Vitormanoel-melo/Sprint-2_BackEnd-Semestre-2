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


-- Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar
-- todos os estúdios mesmo que eles não contenham nenhum jogo de referência
SELECT nomeEstudio, nomeJogo FROM estudios
LEFT JOIN jogos
ON estudios.idEstudio = jogos.idEstudio;


-- Buscar um usuário por e-mail e senha (login)
SELECT idUsuario, email, senha, idTipoUsuario FROM usuarios
WHERE email = 'cliente@cliente.com' AND senha = 'cliente';


-- Buscar um jogo por idJogo
SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogos
WHERE idJogo = 1;


-- Buscar um estúdio por idEstudio
SELECT idEstudio, nomeEstudio FROM estudios
WHERE idEstudio = 1;



-- Comandos Adicionais

SELECT * FROM tiposUsuarios;


SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, nomeEstudio FROM jogos
INNER JOIN estudios
ON jogos.idEstudio = estudios.idEstudio;


SELECT * FROM jogos
WHERE idEstudio = 1;


SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, estudios.idEstudio, nomeEstudio FROM jogos
INNER JOIN estudios
ON jogos.idEstudio = estudios.idEstudio
WHERE jogos.idEstudio = 2;