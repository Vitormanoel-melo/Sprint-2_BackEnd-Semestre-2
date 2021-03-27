-- DML
USE T_Peoples;
GO

-- insere nome e sobrenome dos funcionários
INSERT INTO funcionarios (nome, sobrenome, dataNascimento)
VALUES		('Catarina', 'Strada', '20/09/1999')
		   ,('Tadeu', 'Vitelli', '06/01/1985');
GO