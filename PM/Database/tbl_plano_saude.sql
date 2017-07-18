CREATE TABLE [dbo].[tbl_plano_saude]
(
	[CPF] VARCHAR(14) NOT NULL , 
    [CodPlano] INT NOT NULL, 
    [DataContratacao] DATETIME NOT NULL, 
    [NomeOperadora] VARCHAR(50) NOT NULL, 
    [ValorAtualizado] FLOAT NOT NULL, 
    [Carencia] DATE NOT NULL, 
    [DataReajuste] DATE NOT NULL, 
    [TipoPlano ] VARCHAR(20) NOT NULL, 
    [ValorMensal] FLOAT NOT NULL, 
    [Nome ] VARCHAR(40) NOT NULL, 
    CONSTRAINT [FK_tbl_plano_saude_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]), 
    PRIMARY KEY ([CPF],[CodPlano])
)
