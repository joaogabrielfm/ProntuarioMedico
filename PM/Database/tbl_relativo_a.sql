CREATE TABLE [dbo].[tbl_relativo_a]
(
	[CPF_Paciente] VARCHAR(14) NOT NULL, 
    [CPF_Familiar] VARCHAR(14) NOT NULL, 
    [Maior_idade] BIT NOT NULL, 
    [Responsavel] BIT NOT NULL, 
    [Parentesco] VARCHAR(15) NOT NULL,
	CONSTRAINT FK_relativoA_Paciente FOREIGN KEY ([CPF_Paciente]) REFERENCES tbl_paciente([CPF]),
	CONSTRAINT FK_relativoA_Familiar FOREIGN KEY ([CPF_Familiar]) REFERENCES tbl_familiar([CPF]),
	CONSTRAINT PK_relativoA PRIMARY KEY ([CPF_Paciente],[CPF_Familiar])
)
