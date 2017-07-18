CREATE TABLE [dbo].[tbl_receita]
(
	[id_receita] int IDENTITY(1,1) NOT NULL,
	[CPF_paciente] varchar(14) NOT NULL,
	[CPF_medico] varchar(14) NOT NULL,
	[data_hora] DATETIME NOT NULL,
	[Descricao] varchar(255),
	CONSTRAINT [FK_receita_atendimentoMedico] FOREIGN KEY ([CPF_paciente], [CPF_medico], [data_hora])
	REFERENCES [dbo].[tbl_atendimentoMedico]([CPF_paciente], [CPF_medico], [data_hora]),
	CONSTRAINT [PK_receita] PRIMARY KEY ([id_receita]),
	CONSTRAINT [UC_receita] UNIQUE ([CPF_paciente], [CPF_medico], [data_hora])
);

