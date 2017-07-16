CREATE TABLE [dbo].[tbl_laboratorio_telefone]
(
	[CNPJ] VARCHAR(18) NOT NULL, 
    [tipo] VARCHAR(10) NOT NULL, 
    [numero] VARCHAR(16) NOT NULL,
	CONSTRAINT [FK_tbl_telefone_laboratorio_ToTable] FOREIGN KEY ([CNPJ]) REFERENCES [tbl_laboratorio]([CNPJ]),
	CONSTRAINT [PK_tbl_telefone_laboratorio] PRIMARY KEY ([CNPJ], [numero])
)
