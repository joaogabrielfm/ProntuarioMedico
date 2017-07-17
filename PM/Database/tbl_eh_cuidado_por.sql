CREATE TABLE [dbo].[tbl_eh_cuidado_por]
(
	[CPF_paciente] varchar(14) NOT NULL,
	[CPF_cuidadorInformal] varchar(14) NOT NULL,
	CONSTRAINT [FK_ehCuidadoPor_Paciente] FOREIGN KEY ([CPF_paciente]) REFERENCES [tbl_paciente]([CPF]),
	CONSTRAINT [FK_ehCuidadoPor_CuidadorInformal] FOREIGN KEY ([CPF_cuidadorInformal]) REFERENCES [tbl_cuidador_informal]([CPF])
)
