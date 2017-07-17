CREATE TABLE [dbo].[tbl_horario_atendimento]
(
	[Nro_registro] INT NOT NULL, 
    [Horario] TIME NOT NULL, 
    CONSTRAINT [FK_tbl_horario_Med_ToTable] FOREIGN KEY ([Nro_registro]) REFERENCES [tbl_medicamento]([Nro_registro]),
	CONSTRAINT PK_horarioMedicamento PRIMARY KEY ([Horario], [Nro_registro])
)
