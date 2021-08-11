--DQL
USE SPMed_Group;
GO

-- Mostrou a quantidade de usu�rios ap�s realizar a importa��o do banco de dados
SELECT COUNT(idUsuario) AS QtdUsuarios FROM usuarios;
GO


-- O m�dico poder� ver os agendamentos (consultas) associados a ele
SELECT nome AS NomeMedico, dataConsulta, CONVERT(VARCHAR(5), horaConsulta) AS HorarioConsulta, descricao FROM medicos
INNER JOIN consultas
ON medicos.idMedico = consultas.idMedico
WHERE medicos.idMedico = 1;
GO


-- O paciente poder� visualizar suas pr�prias consultas;
SELECT nome AS NomePaciente, dataConsulta, CONVERT(VARCHAR(5), horaConsulta) AS HorarioConsulta, descricao FROM pacientes
INNER JOIN consultas
ON pacientes.idPaciente = consultas.idPaciente
WHERE pacientes.idPaciente = 4;
GO


-- Converteu a data de nascimento do usu�rio para o formato (mm-dd-yyyy) na exibi��o
SELECT nome ,CONVERT (VARCHAR(10), dataNascimento, 101) AS DataNascimento FROM usuarios
INNER JOIN pacientes
ON usuarios.idUsuario = pacientes.idUsuario
GO


-- Criou uma fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
CREATE FUNCTION QtdMedicos(@idEspecialidade INT)
RETURNS INT
AS
BEGIN
	DECLARE @especialidade VARCHAR(100)
		   ,@quantidade INT

	SELECT @quantidade = COUNT(nome) FROM medicos
	WHERE medicos.idEspecialidade = @idEspecialidade

	RETURN @quantidade
END
GO

SELECT dbo.QtdMedicos(16) AS numero_medicos;
GO


-- Criou uma fun��o para que retorne a idade do usu�rio a partir de uma determinada stored procedure
CREATE PROCEDURE idade
AS
	SELECT nome, DATEPART(YEAR, DATEADD(YEAR, -1, GETDATE())) - DATEPART(YEAR, dataNascimento) AS Idade FROM pacientes

EXEC idade;