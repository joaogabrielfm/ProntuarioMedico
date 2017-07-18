CREATE TABLE [dbo].[tbl_usada_na_compra]
(
	[id_receita] int NOT NULL,
	[Nro_registro] int NOT NULL,
	[data] DATETIME NOT NULL,
	CONSTRAINT [FK_usadaNaCompra_receita] FOREIGN KEY ([id_receita])
	REFERENCES [dbo].[tbl_receita]([id_receita]),
	CONSTRAINT [FK_usadaNaCompra_medicamento] FOREIGN KEY ([Nro_registro])
	REFERENCES [dbo].[tbl_medicamento]([Nro_registro]),
	CONSTRAINT PK_usadaNaCompra PRIMARY KEY ([id_receita],[Nro_registro])
);

