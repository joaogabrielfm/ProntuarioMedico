CREATE TABLE [dbo].[tbl_telefone_pessoa]
(
	[CPF] VARCHAR(14) NOT NULL, 
    [Tipo] VARCHAR(10) NOT NULL, 
    [Numero] INT NOT NULL, 
    CONSTRAINT [FK_tbl_telefone_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]),
    CONSTRAINT [PK_tbl_telefone_pessoa] PRIMARY KEY ([CPF], [Tipo], [Numero]), 
)
