CREATE TABLE [dbo].[tbl_medico]
(
	[CPF] VARCHAR(14) NOT NULL,
    [CRM] VARCHAR(7) NOT NULL, 
    CONSTRAINT [FK_tbl_medico_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]), 
    CONSTRAINT [PK_tbl_medico] PRIMARY KEY ([CPF], [CRM]),
)
