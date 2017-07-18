CREATE TABLE [dbo].[tbl_email_hospital]
(
	[CNPJ] VARCHAR(18) NOT NULL, 
    [email] VARCHAR(30) NOT NULL,
	CONSTRAINT [FK_tbl_email_hospital_ToTable] FOREIGN KEY ([CNPJ]) REFERENCES [tbl_hospital]([CNPJ]),
	CONSTRAINT [PK_tbl_email_hospital] PRIMARY KEY ([CNPJ], [email])
)
