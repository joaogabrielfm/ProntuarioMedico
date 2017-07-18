CREATE TABLE [dbo].[tbl_questao_anamnese](
	[Id_anamnese] INT NOT NULL,
	[CPF] VARCHAR(14) NOT NULL,
	[pergunta] TEXT,
	[resposta] TEXT,
	CONSTRAINT [FK_questaoAnamnese_anamnese] FOREIGN KEY ([CPF], [Id_anamnese]) REFERENCES [tbl_anamnese]([CPF], [Id_anamnese]),
	CONSTRAINT PK_anamnese PRIMARY KEY ([Id_anamnese])
)