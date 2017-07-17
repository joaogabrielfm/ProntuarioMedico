CREATE TABLE [dbo].[tbl_data_agenda](
	[data] DATETIME NOT NULL,
	[id_agenda] INT NOT NULL,
	[CPF] VARCHAR(14) NOT NULL,
	CONSTRAINT FK_dataAgenda_Pessoa FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]),
	CONSTRAINT FK_dataAgenda_Agenda_Pessoa FOREIGN KEY ([CPF],[id_agenda]) REFERENCES [tbl_agenda]([CPF],[id_agenda]),
	CONSTRAINT PK_dataAgenda PRIMARY KEY ([id_agenda], [CPF], [data])
)