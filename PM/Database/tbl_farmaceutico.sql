CREATE TABLE [dbo].[tbl_farmaceutico]
(
	[CPF] VARCHAR(14) NOT NULL PRIMARY KEY,
    CONSTRAINT [FK_tbl_farmaceutico_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]),
)
