CREATE TABLE [dbo].[tbl_pessoa]
(
    [CPF] VARCHAR(14) NOT NULL PRIMARY KEY, 
    [Prenome] VARCHAR(20) NOT NULL, 
    [Sobrenome] VARCHAR(20) NOT NULL, 
    [Estado] VARCHAR(2) NOT NULL, 
    [Cidade] VARCHAR(50) NOT NULL, 
    [Pais] VARCHAR(30) NOT NULL, 
    [Rua] VARCHAR(50) NOT NULL, 
    [CEP] VARCHAR(8) NOT NULL
)
