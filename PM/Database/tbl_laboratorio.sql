CREATE TABLE [dbo].[tbl_laboratorio]
(
	[CNPJ] VARCHAR(18) NOT NULL PRIMARY KEY, 
    [rua] VARCHAR(100) NOT NULL, 
    [cidade] VARCHAR(20) NOT NULL, 
    [estado] VARCHAR(20) NOT NULL, 
    [cep] VARCHAR(8) NOT NULL, 
    [site] VARCHAR(25) NOT NULL, 
    [lista_servicos_prestados] TEXT NOT NULL
)
