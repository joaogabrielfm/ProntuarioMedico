CREATE TABLE [dbo].[tbl_laboratorista]
(
	[CPF] VARCHAR(14) NOT NULL PRIMARY KEY,
	[CNPJ] VARCHAR(18) NOT NULL, 
    CONSTRAINT [FK_tbl_laboratorista_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]),
)
