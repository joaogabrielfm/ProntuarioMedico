using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class RelativoaAccess : DBAccess
    {

        public RelativoaAccess(string connectionString) : base(connectionString) { }

        //Insere informações na tabela
        public void InsertRelativoa(Relativoa newRelativoa)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_Relativoa ";
            sSQL += " (CPF_Paciente, CPF_Familiar, Maior_idade, Responsavel, Parentesco) ";
            sSQL += " Values ";
            sSQL += " (@CPF_Paciente, @CPF_Familiar, @Maior_idade, @Responsavel, @Parentesco) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF_Paciente", newRelativoa.cpf_paciente);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("CPF_Familiar", newRelativoa.cpf_familiar);
            sqlcomm.Parameters.Add(sqlparam);
            
            ExecNonQuery(sqlcomm);
        }

        //Retorna as informações do familiar de um paciente
        public Relativoa GetRelativoa(string cpf_familiar)
        {
            string sSQL = "";
            sSQL += " SELECT tbl_familiar.*, tbl_relativoa.CPF_Familiar FROM tbl_familiar, tbl_relativoa WHERE tbl_relativoa.CPF_Familiar = @cpf_familiar AND tbl_familiar.CPF = tbl_Relativoa.CPF_Familiar;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf_familiar", cpf_familiar);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Relativoa Relativoa = new Relativoa();
            Relativoa.cpf_familiar = cpf_familiar;
            Relativoa.cpf_paciente = dr["CPF_Paciente"].ToString();
            Relativoa.responsavel = dr["Responsavel"].ToString();
            Relativoa.parentesco = dr["Parentesco"].ToString();
            Relativoa.maior_idade = dr["Maior_idade"].ToString();

            return Relativoa;
        }

        //Atualiza o familiar relativo a um paciente
        public void UpdateFamiliarRelativoa(Familiar familiar)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_familiar SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Prenome", familiar.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Sobrenome", familiar.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Estado", familiar.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Cidade", familiar.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Pais", familiar.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Rua", familiar.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CEP", familiar.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", familiar.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);

            sSQL = "";
            sSQL += " UPDATE tbl_Relativoa SET CPF_Familiar = @CPF WHERE CPF = @CPF";

            sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            sqlparam = new SqlParameter("@CPF_Familiar", familiar.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        //Deleta 
        public void DeleteRelativoa(string cpf_paciente)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_Relativoa WHERE CPF_Paciente = @CPF ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CPF", cpf_paciente);
            sqlcomm.Parameters.Add(sqlparam);
            
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }

    }
}
