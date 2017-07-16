CREATE TABLE [dbo].[tbl_plano_saude]
(
    [CodPlano] INT NOT NULL, 
    [Data_contratacao] DATETIME NOT NULL, 
    [Nome_operadora] VARCHAR(50) NOT NULL, 
    [Valor_atualizado] FLOAT NOT NULL, 
    [Carencia] DATE NOT NULL, 
    [Data_reajuste] DATE NOT NULL, 
    [Tipo_plano ] VARCHAR(20) NOT NULL, 
    [Valor_mensal] FLOAT NOT NULL, 
    [Nome] VARCHAR(40) NOT NULL, 
    PRIMARY KEY ([CPF],[CodPlano])
)
