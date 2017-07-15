CREATE TABLE [dbo].[tbl_especializacao_laboratorista]
(
	[CPF] VARCHAR(14) NOT NULL,
    [Especializacao] VARCHAR(20) NOT NULL, 
    CONSTRAINT [FK_tbl_especializacao_laboratorista_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_laboratorista]([CPF]),
	CONSTRAINT [PK_tbl_especializacao_laboratorista] PRIMARY KEY ([CPF], [Especializacao]), 
)
