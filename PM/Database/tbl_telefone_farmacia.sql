CREATE TABLE [dbo].[tbl_telefone_farmacia]
(
	[CNPJ] VARCHAR(18) NOT NULL, 
    [tipo] VARCHAR(10) NOT NULL, 
    [numero] VARCHAR(16) NOT NULL,
	CONSTRAINT [FK_tbl_telefone_farmacia_ToTable] FOREIGN KEY ([CNPJ]) REFERENCES [tbl_farmacia]([CNPJ]),
	CONSTRAINT [PK_tbl_telefone_farmacia] PRIMARY KEY ([CNPJ], [numero])
)
