CREATE TABLE [dbo].[tbl_medico]
(
	[CPF] VARCHAR(14) NOT NULL PRIMARY KEY,
    CONSTRAINT [FK_tbl_medico_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]),
)
