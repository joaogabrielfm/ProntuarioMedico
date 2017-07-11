CREATE TABLE [dbo].[tbl_cuidador_formal]
(
	[CPF] VARCHAR(14) NOT NULL PRIMARY KEY,
    CONSTRAINT [FK_tbl_cuidador_formal_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]),
)
