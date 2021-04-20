-- DQL

USE T_Peoples;
GO

-- Lista todos os funcionários
SELECT * FROM funcionarios;
GO


-- Lista todos os tipos de usuário
SELECT idTipoUsuario, descricao FROM tiposUsuarios;
GO


-- Busca um usuário pelo id
SELECT idTipoUsuario, descricao FROM tiposUsuarios
WHERE idTipoUsuario = 1;
GO


-- Deleta um tipoUsuario pelo id
DELETE FROM tiposUsuarios WHERE idTipoUsuario = 3;
GO


-- Atualiza um tipo usuario de acordo com o id
UPDATE tiposUsuarios
SET descricao = 'atualização'
WHERE idTipoUsuario = 3;


-- Lista todos os usuários
SELECT idUsuario, nome, sobrenome, email, senha, permissao FROM usuarios;
GO


-- Lista todos os usuários com a descrição de suas permissões
SELECT idUsuario, nome, sobrenome, email, senha, descricao FROM usuarios
INNER JOIN tiposUsuarios
ON usuarios.permissao = tiposUsuarios.idTipoUsuario;