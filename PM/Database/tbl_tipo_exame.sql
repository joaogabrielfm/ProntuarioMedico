CREATE TABLE [dbo].[tbl_tipo_exame]
(
	[data_hora] datetime,
	[id_tipo_exame] int,
	[tipo] varchar(100),
	[descricao] varchar(100),
	CONSTRAINT FK_TipoExame_Exame FOREIGN KEY ([data_hora]) 
	REFERENCES [dbo].[tbl_exame]([DataHora]), 
	CONSTRAINT PK_tipoExame PRIMARY KEY ([data_hora], [id_tipo_exame])
);

