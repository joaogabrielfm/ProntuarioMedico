CREATE TABLE [dbo].[tbl_imagem_exame]
(
	[data_hora] datetime NOT NULL,  
	[imagem] image,
	CONSTRAINT FK_imagemExame_Exame FOREIGN KEY (data_hora) 
	REFERENCES [dbo].[tbl_exame](DataHora), 
	CONSTRAINT PK_imagemExame PRIMARY KEY (data_hora, imagem)

)
