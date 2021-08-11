--DML
USE SPMed_Group;
GO

INSERT INTO tiposUsuarios (nomeTipo)
VALUES		('Administrador')
		   ,('M�dico')
		   ,('Paciente');
GO

INSERT INTO usuarios (idTipoUsuario, email, senha)
VALUES			(2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123')
			   ,(2, 'roberto.possarle@spmedicalgroup.com.br', 'possarle123')
			   ,(2, 'helena.souza@spmedicalgroup.com.br', 'helena123')
			   ,(3, 'ligia@gmail.com', 'ligia123')
			   ,(3, 'alexandre@gmail.com', 'alex123')
			   ,(3, 'fernando@gmail.com', 'fer123')
			   ,(3, 'henrique@gmail.com', 'henrique123')
			   ,(3, 'joao@hotmail.com', 'joao123')
			   ,(3, 'bruno@gmail.com', 'bruno123')
			   ,(3, 'mariana@outlook.com', 'mariana123')
			   ,(1, 'admin@spmedicalgroupadmin.com.br', 'adm123');
GO

INSERT INTO pacientes (idUsuario, nome, rg, cpf, telefone, dataNascimento, endereco)
VALUES			(4,	'Ligia', '435225435', '94839859000', '1134567654', '13/10/1983', 'Rua Estado de Israel 240,�S�o Paulo, Estado de S�o Paulo, 04022-000')
			   ,(5, 'Alexandre', '326543457', '73556944057', '11987656543', '23/07/2001', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200')
			   ,(6, 'Fernando', '546365253', '16839338002', '11972084453', '10/10/1978', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200')
			   ,(7, 'Henrique', '543663625', '14332654765', '34566543', '13/10/1985', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
			   ,(8, 'Jo�o', '325444441', '91305348010', '1176566377', '27/08/1975', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380')
			   ,(9, 'Bruno', '545662667', '79799299004', '954368769', '21/3/1972', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001' )
			   ,(10, 'Mariana', '545662668', '13771913039', '', '05/03/2018', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

INSERT INTO clinicas (nomeClinica, dataAbertura, horarioAbertura, horarioFechamento, cnpj, razaoSocial, endereco)
VALUES			('Cl�nica Possarle', 'domingo a domingo', '07:00',
				 '22:00', '86400902000130', 'SP Medical Group', 'Av. Bar�o Limeira, 532, S�o Paulo, SP');
GO

INSERT INTO especialidades (descricao)
VALUES		('Acupuntura')
		   ,('Anestesiologia')
		   ,('Angiologia')
		   ,('Cardiologia')
		   ,('Cirurgia Cardiovascular')
		   ,('Cirurgia da M�o')
		   ,('Cirurgia do Aparelho Digestivo')
		   ,('Cirurgia Geral')
		   ,('Cirurgia Pedi�trica')
		   ,('Cirurgia Pl�stica')
		   ,('Cirurgia Tor�cica')
		   ,('Cirurgia Vascular')
		   ,('Dermatologia')
		   ,('Radioterapia')
		   ,('Urologia')
		   ,('Pediatria')
		   ,('Psiquiatria');
GO

INSERT INTO medicos (idEspecialidade, idUsuario, idClinica, nome, crm)
VALUES
			   (2, 1, 1, 'Ricardo Lemos', '54356SP')
			  ,(17, 2, 1, 'Roberto Possarle', '53452SP')
			  ,(16, 3, 1, 'Helena Strada', '65463SP');
GO

INSERT INTO situacoes (descricao)
VALUES		('Realizada')
		   ,('Agendada')
		   ,('cancelada');
GO

INSERT INTO consultas (idMedico, idPaciente, idSituacao, dataConsulta, horaConsulta, descricao)
VALUES			(3, 7, 1, '20/01/20', '15:00', 'paciente com bronquite')
			   ,(2, 2, 3, '06/01/2020', '10:00', 'paciente com ansiedade')
			   ,(2, 3, 1, '07/02/2020', '11:00', 'Paciente com sintomas de depress�o')
			   ,(2, 2, 1, '06/02/2018', '10:00', 'paciente far� exame experimental')
			   ,(1, 4, 3, '07/02/2019', '11:00', 'o paciente far� um teste para ver se reage bem a anestesia')
			   ,(3, 7, 2, '08/03/2020', '15:00', 'paciente com pneumonia')
			   ,(1, 4, 2, '09/03/2020', '11:00', 'paciente far� exame experimental');
GO

-- Atualizou os registros que n�o possuem data de nascimento conforme especificado pelo cliente
UPDATE pacientes
SET dataNascimento = '20/01/2000'
WHERE dataNascimento = NULL;
