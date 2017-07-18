CREATE TABLE [dbo].[tbl_farmacia]
(
	[CNPJ] VARCHAR(18) NOT NULL PRIMARY KEY, 
    [rua] VARCHAR(100) NOT NULL, 
    [cidade] VARCHAR(100) NOT NULL, 
    [estado] VARCHAR(20) NOT NULL, 
    [cep] VARCHAR(8) NOT NULL, 
    [site] VARCHAR(25) NOT NULL, 
    [horario_funcionamento] VARCHAR(40) NOT NULL
)
