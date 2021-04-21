-- DQL

USE T_Peoples;
GO

-- Lista todos os funcion�rios
SELECT * FROM funcionarios;
GO


-- Lista todos os tipos de usu�rio
SELECT idTipoUsuario, descricao FROM tiposUsuarios;
GO


-- Busca um usu�rio pelo id
SELECT idTipoUsuario, descricao FROM tiposUsuarios
WHERE idTipoUsuario = 1;
GO


-- Deleta um tipoUsuario pelo id
DELETE FROM tiposUsuarios WHERE idTipoUsuario = 3;
GO


-- Atualiza um tipo usuario de acordo com o id
UPDATE tiposUsuarios
SET descricao = 'atualiza��o'
WHERE idTipoUsuario = 3;


-- Lista todos os usu�rios
SELECT idUsuario, nome, sobrenome, email, senha, permissao FROM usuarios;
GO


-- Lista todos os usu�rios com a descri��o de suas permiss�es
SELECT idUsuario, nome, sobrenome, email, senha, descricao FROM usuarios
INNER JOIN tiposUsuarios
ON usuarios.permissao = tiposUsuarios.idTipoUsuario;