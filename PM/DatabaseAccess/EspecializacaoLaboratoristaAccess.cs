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
    class EspecializacaoLaboratoristaAccess : DBAccess
    {
        //Constructor function
        public EspecializacaoLaboratoristaAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um especializacao_laboratorista na base de dados
        public void InsertEspecializacaoLaboratorista(string cpf, string especializacao)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_especializacao_laboratorista ";
            sSQL += " (CPF, Especializacao) ";
            sSQL += " Values ";
            sSQL += " (@CPF, @Especializacao) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Especializacao", especializacao);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }
        
        // Essa funcao retorna a lista de todas as especializacoes de um laboratorista
        public List<string> GetAllEspecializacaoLaboratoristas(string cpf)
        {
            string sql = "SELECT tbl_especializacao_laboratorista.* FROM tbl_especializacao_laboratorista, tbl_pessoa WHERE tbl_especializacao_laboratorista.CPF = @CPF;";
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

    }
}
