-- DML
USE T_Peoples;
GO

-- Insere nome e sobrenome dos funcionários
INSERT INTO funcionarios (nome, sobrenome, dataNascimento)
VALUES		('Catarina', 'Strada', '20/09/1999')
		   ,('Tadeu', 'Vitelli', '06/01/1985');
GO

-- Insere tipos de usuários na tabela tiposUsuarios
INSERT INTO tiposUsuarios (descricao)
VALUES			('comum')
			   ,('administrador');
GO

-- Insere usuarios no banco de dados
INSERT INTO usuarios (nome, sobrenome, email, senha, permissao)
VALUES				('Vitor', 'Manoel', 'vitorm@gmail.com', '123', 1)
				   ,('Saulo', 'S.', 'adm@adm.com', '123456', 2);