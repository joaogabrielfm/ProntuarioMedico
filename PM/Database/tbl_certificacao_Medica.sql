CREATE TABLE [dbo].[tbl_certificacao_Medica]
(
	[id_certificado] INT NOT NULL,
	[nome_curso] varchar(50) NOT NULL,
	[grau_certificado] varchar(50) NOT NULL,
	[universidade] varchar(50) NOT NULL,
	[cpf_medico] varchar(14) NOT NULL,
	[crm_medico] varchar(7) NOT NULL,
	CONSTRAINT FK_certificacaoMedica_Medico FOREIGN KEY ([cpf_medico], [crm_medico]) REFERENCES [tbl_medico]([CPF], [CRM]),
	CONSTRAINT PK_certificacaoMedica PRIMARY KEY ([id_certificado], [cpf_medico])
)