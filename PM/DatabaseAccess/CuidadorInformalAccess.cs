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
    public class CuidadorInformalAccess : DBAccess
    {
        //Constructor function
        public CuidadorInformalAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um cuidador_informal na base de dados
        public void InsertCuidadorInformal(CuidadorInformal cuidador_informal)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_cuidador_informal ";
            sSQL += " (CPF) ";
            sSQL += " Values ";
            sSQL += " (@CPF) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", cuidador_informal.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações pessoais sobre um cuidador_informal
        public CuidadorInformal GetCuidadorInformal(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT tbl_pessoa.* FROM tbl_pessoa, tbl_cuidador_informal WHERE tbl_cuidador_informal.CPF = @cpf AND tbl_cuidador_informal.CPF = tbl_pessoa.CPF;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            CuidadorInformal cuidador_informal = new CuidadorInformal();
            cuidador_informal.prenome = dr["Prenome"].ToString();
            cuidador_informal.sobrenome = dr["Sobrenome"].ToString();
            cuidador_informal.estado = dr["Estado"].ToString();
            cuidador_informal.cidade = dr["Cidade"].ToString();
            cuidador_informal.pais = dr["Pais"].ToString();
            cuidador_informal.rua = dr["Rua"].ToString();
            cuidador_informal.cep = dr["CEP"].ToString();
            cuidador_informal.cpf = cpf;

            return cuidador_informal;
        }

        // Essa funcao retorna a lista de nomes e CPF de todos os cuidadores_informais
        public List<CuidadorInformal> GetAllCuidadorInformal()
        {
            string sql = "SELECT tbl_pessoa.* FROM tbl_pessoa, tbl_cuidador_informal WHERE tbl_pessoa.CPF = tbl_cuidador_informal.CPF;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<CuidadorInformal> cuidador_informals = new List<CuidadorInformal>();
            foreach (DataRow dr in dt.Rows)
            {
                CuidadorInformal cuidador_informal = new CuidadorInformal();
                cuidador_informal.prenome = dr["Prenome"].ToString();
                cuidador_informal.sobrenome = dr["Sobrenome"].ToString();
                cuidador_informal.estado = dr["Estado"].ToString();
                cuidador_informal.cidade = dr["Cidade"].ToString();
                cuidador_informal.pais = dr["Pais"].ToString();
                cuidador_informal.rua = dr["Rua"].ToString();
                cuidador_informal.cep = dr["CEP"].ToString();
                cuidador_informal.cpf = dr["CPF"].ToString();
                cuidador_informals.Add(cuidador_informal);
            }
            return cuidador_informals;
        }

        // Essa funcao é chamada para atualizar os dados de um cuidador_informal
        public void UpdateCuidadorInformal(CuidadorInformal cuidador_informal)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_pessoa SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Prenome", cuidador_informal.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Sobrenome", cuidador_informal.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Estado", cuidador_informal.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Cidade", cuidador_informal.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Pais", cuidador_informal.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Rua", cuidador_informal.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CEP", cuidador_informal.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", cuidador_informal.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um cuidador_informal do banco de dados
        public void DeleteCuidadorInformal(string cpf)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_cuidador_informal WHERE CPF = @CPF ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CPF", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }

    }
}

