CREATE TABLE [dbo].[tbl_anamnese]
(
	[CPF] VARCHAR(14) NOT NULL , 
    [IdAnamnese] INT NOT NULL, 
    CONSTRAINT [FK_tbl_anamnese_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]), 
    CONSTRAINT [PK_tbl_anamnese] PRIMARY KEY ([CPF], [IdAnamnese]),
)