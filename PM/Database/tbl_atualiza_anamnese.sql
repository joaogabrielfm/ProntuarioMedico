CREATE TABLE [dbo].[tbl_atualiza_anamnese]
(
	[CPF] VARCHAR(14) NOT NULL, 
    [Id_anamnese] INT NOT NULL, 
    [CPF_medico] VARCHAR(14) NOT NULL, 
    CONSTRAINT [FK_atualizaAnamnese_anamnese] FOREIGN KEY ([CPF], [Id_anamnese]) REFERENCES [tbl_anamnese]([CPF], [Id_anamnese]),
    CONSTRAINT [FK_atualizaAnamnese_medico] FOREIGN KEY ([CPF_medico]) REFERENCES [tbl_medico]([CPF]),
    CONSTRAINT [PK_atualiza_anamnese] PRIMARY KEY ([CPF], [Id_anamnese], [CPF_medico])
)