CREATE TABLE [dbo].[tbl_telefone_hospital]
(
	[CNPJ] VARCHAR(18) NOT NULL, 
    [tipo] VARCHAR(10) NOT NULL, 
    [numero] NCHAR(16) NOT NULL,
	CONSTRAINT [FK_tbl_telefone_hospital_ToTable] FOREIGN KEY ([CNPJ]) REFERENCES [tbl_hospital]([CNPJ]),
	CONSTRAINT [PK_tbl_telefone_hospital] PRIMARY KEY ([CNPJ], [numero])
)
