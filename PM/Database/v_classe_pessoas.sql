CREATE VIEW [dbo].[v_classe_pessoas]
	AS SELECT Prenome, Sobrenome, tbl_medico.CPF, 'M' as tipo FROM [tbl_medico],[tbl_pessoa] WHERE tbl_pessoa.CPF = tbl_medico.CPF 
	UNION SELECT Prenome, Sobrenome, tbl_paciente.CPF, 'P' FROM [tbl_paciente],[tbl_pessoa] WHERE tbl_pessoa.CPF = tbl_paciente.CPF
	UNION SELECT Prenome, Sobrenome, tbl_cuidador_formal.CPF, 'CF' FROM [tbl_cuidador_formal],[tbl_pessoa] WHERE tbl_pessoa.CPF = tbl_cuidador_formal.CPF
	UNION SELECT Prenome, Sobrenome, tbl_cuidador_informal.CPF, 'CI' FROM [tbl_cuidador_informal],[tbl_pessoa] WHERE tbl_pessoa.CPF = tbl_cuidador_informal.CPF
	UNION SELECT Prenome, Sobrenome, tbl_farmaceutico.CPF, 'F' FROM [tbl_farmaceutico],[tbl_pessoa] WHERE tbl_pessoa.CPF = tbl_farmaceutico.CPF
	UNION SELECT Prenome, Sobrenome, tbl_laboratorista.CPF, 'L' FROM [tbl_laboratorista],[tbl_pessoa] WHERE tbl_pessoa.CPF = tbl_laboratorista.CPF;
