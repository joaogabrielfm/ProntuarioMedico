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
    class AnamneseAccess : DBAccess
    {
        //Constructor function
        public AnamneseAccess(string connectionString) : base(connectionString) { }
        /*
        //Esta funcao insere uma anamnese na base de dados
        public void InsertAnamnese(string CPF, int Id_anamnese)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_anamnese ";
            sSQL += " (CPF, Id_anamnese) ";
            sSQL += " Values ";
            sSQL += " (@CPF, @Id_anamnese) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", CPF);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Id_anamnese", Id_anamnese);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        // Essa funcao retorna a anamnese de um paciente
        public Anamnese GetAnamnese(string cpf)
        {
            string sql = "SELECT * FROM tbl_anamnese, tbl_questao_anamnese WHERE tbl_anamnese.CPF = @CPF AND tbl_questao_anamnese.CPF = @CPF;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<string> especializacao_laboratoristas = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                especializacao_laboratoristas.Add(dr["Especializacao"].ToString());
            }
            return especializacao_laboratoristas;
        }

        // Essa funcao deleta uma especializacao de um laboratorista do banco de dados
        public void DeleteEspecializacaoLaboratorista(string cpf, string especializacao)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_especializacao_laboratorista WHERE CPF = @CPF AND Especializacao = @especializacao ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CPF", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Especializacao", especializacao);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
        */
    }
}

