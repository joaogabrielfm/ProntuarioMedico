CREATE TABLE [dbo].[tbl_email_farmacia]
(
	[CNPJ] VARCHAR(18) NOT NULL, 
    [email] VARCHAR(30) NOT NULL,
	CONSTRAINT [FK_tbl_email_farmacia_ToTable] FOREIGN KEY ([CNPJ]) REFERENCES [tbl_farmacia]([CNPJ]),
	CONSTRAINT [PK_tbl_email_farmacia] PRIMARY KEY ([CNPJ], [email])
)
