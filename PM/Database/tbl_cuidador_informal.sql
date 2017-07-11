CREATE TABLE [dbo].[tbl_cuidador_informal]
(
	[CPF] VARCHAR(14) NOT NULL PRIMARY KEY,
    CONSTRAINT [FK_tbl_cuidador_informal_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]),
)
