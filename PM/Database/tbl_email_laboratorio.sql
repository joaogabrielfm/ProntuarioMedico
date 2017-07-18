CREATE TABLE [dbo].[tbl_email_laboratorio]
(
	[CNPJ] VARCHAR(18) NOT NULL, 
    [email] VARCHAR(30) NOT NULL,
	CONSTRAINT [FK_tbl_email_laboratorio_ToTable] FOREIGN KEY ([CNPJ]) REFERENCES [tbl_laboratorio]([CNPJ]),
	CONSTRAINT [PK_tbl_email_laboratorio] PRIMARY KEY ([CNPJ], [email])
)
