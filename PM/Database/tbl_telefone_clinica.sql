CREATE TABLE [dbo].[tbl_telefone_clinica]
(
	[CNPJ] VARCHAR(18) NOT NULL, 
    [tipo] VARCHAR(10) NOT NULL, 
    [numero] VARCHAR(16) NOT NULL,
	CONSTRAINT [FK_tbl_telefone_clinica_ToTable] FOREIGN KEY ([CNPJ]) REFERENCES [tbl_clinica]([CNPJ]),
	CONSTRAINT [PK_tbl_telefone_clinica] PRIMARY KEY ([CNPJ], [numero]) 
)
