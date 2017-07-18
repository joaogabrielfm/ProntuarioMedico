CREATE TABLE [dbo].[tbl_email_clinica]
(
	[CNPJ] VARCHAR(18) NOT NULL, 
    [email] VARCHAR(30) NOT NULL,
	CONSTRAINT [FK_tbl_email_clinica_ToTable] FOREIGN KEY ([CNPJ]) REFERENCES [tbl_clinica]([CNPJ]),
	CONSTRAINT [PK_tbl_email_clinica] PRIMARY KEY ([CNPJ], [email])
)
