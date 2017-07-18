CREATE VIEW [dbo].[v_ClasseProfissional]
	AS SELECT Prenome, tbl_medico.CPF, 'M' as tipo FROM [tbl_medico], [tbl_pessoa]
	WHERE tbl_pessoa.CPF = tbl_medico.CPF 
	UNION select Prenome, tbl_laboratorista.CPF, 'L' as tipo from [tbl_laboratorista], [tbl_pessoa]
	WHERE tbl_pessoa.CPF = tbl_laboratorista.CPF;
