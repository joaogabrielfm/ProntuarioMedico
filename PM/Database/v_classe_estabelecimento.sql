CREATE VIEW [dbo].[v_classe_estabelecimento]
	AS SELECT CNPJ, 'H' as tipo FROM [tbl_hospital] 
	UNION SELECT CNPJ, 'L' as tipo FROM [tbl_laboratorio] 
	UNION SELECT CNPJ, 'C' as tipo FROM [tbl_clinica]
	UNION SELECT CNPJ, 'F' as tipo FROM [tbl_email_farmacia]

