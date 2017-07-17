CREATE TABLE [dbo].[tbl_atendimentoMedico]
(
	[CPF_paciente] varchar(14) NOT NULL,
	[CPF_medico] varchar(14) NOT NULL,
	[CRM_medico] varchar(7) NOT NULL,
	[data_hora] DATETIME NOT NULL,
	[valor] FLOAT,
	CONSTRAINT [FK_atendimentoMedico_Paciente] FOREIGN KEY ([CPF_paciente]) REFERENCES [tbl_paciente]([CPF]),
	CONSTRAINT [FK_atendimentoMedico_Medico] FOREIGN KEY ([CPF_medico], [CRM_medico]) REFERENCES [tbl_medico]([CPF],[CRM]),
	CONSTRAINT [PK_atendimentMedico] PRIMARY KEY ([CPF_paciente], [CPF_medico], [data_hora])
)
