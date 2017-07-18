CREATE TABLE [dbo].[tbl_atendimentoCuidadorFormal]
(
	[CPF_paciente] varchar(14) NOT NULL,
	[CPF_cuidadorFormal] varchar(14) NOT NULL,
	[data_hora] datetime NOT NULL,
	CONSTRAINT [FK_atendimentoCuidadorFormal_Paciente] FOREIGN KEY ([CPF_paciente]) REFERENCES [tbl_paciente]([CPF]),
	CONSTRAINT [FK_atendimentoCuidadorFormal_CuidadorFormal] FOREIGN KEY ([CPF_cuidadorFormal]) REFERENCES [tbl_cuidador_formal]([CPF]),
	CONSTRAINT [PK_atendimentoCuidadorFormal] PRIMARY KEY ([CPF_paciente], [CPF_cuidadorFormal], [data_hora])
)
