CREATE TABLE [dbo].[tbl_familiar]
(
	[CPF] VARCHAR(14) NOT NULL PRIMARY KEY,
    CONSTRAINT [FK_tbl_familiar_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]),
)
