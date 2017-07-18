CREATE TABLE [dbo].[tbl_certificacaoCuidadorFormal]
(
	[id_certificado] INT NOT NULL,
	[cpf_cuidadorFormal] varchar(14) NOT NULL,
	[nome_curso] varchar(25) NOT NULL,
	[grau_certificado] varchar(25) NOT NULL,
	[universidade] varchar(25) NOT NULL,
	CONSTRAINT FK_certificacaoCuidadorFormal_CuidadorFormal FOREIGN KEY ([cpf_cuidadorFormal]) REFERENCES [tbl_cuidador_formal]([CPF]),
	CONSTRAINT PK_certificacaoCuidadorFormal PRIMARY KEY ([cpf_cuidadorFormal], [id_certificado])
)
