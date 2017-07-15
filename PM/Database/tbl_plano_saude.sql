CREATE TABLE [dbo].[tbl_plano_saude]
(
	[CPF] VARCHAR(14) NOT NULL , 
    [codPlano] INT NOT NULL, 
    [data_contratacao] DATETIME NOT NULL, 
    [nome_operadora] VARCHAR(50) NOT NULL, 
    [valor_atualizado] FLOAT NOT NULL, 
    [carencia] DATE NOT NULL, 
    [data_reajuste] DATE NOT NULL, 
    [tipo_plano ] VARCHAR(20) NOT NULL, 
    [valor_mensal] FLOAT NOT NULL, 
    [nome varchar] VARCHAR(40) NOT NULL, 
    CONSTRAINT [FK_tbl_plano_saude_pessoa_ToTable] FOREIGN KEY ([CPF]) REFERENCES [tbl_pessoa]([CPF]), 
    PRIMARY KEY ([CPF],[codPlano])
)
