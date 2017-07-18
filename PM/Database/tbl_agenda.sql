CREATE TABLE [dbo].[tbl_agenda] 
(
	[CPF] VARCHAR(14) NOT NULL,
	[id_agenda] INT NOT NULL,
	CONSTRAINT FK_Agenda_Pessoa FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]),
	CONSTRAINT PK_Agenda PRIMARY KEY ([CPF],[id_agenda])
)