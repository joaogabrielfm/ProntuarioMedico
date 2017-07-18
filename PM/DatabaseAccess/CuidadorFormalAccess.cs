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
    public class CuidadorFormalAccess : DBAccess
    {
        //Constructor function
        public CuidadorFormalAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um cuidador_formal na base de dados
        public void InsertCuidadorFormal(CuidadorFormal cuidador_formal)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_cuidador_formal ";
            sSQL += " (CPF) ";
            sSQL += " Values ";
            sSQL += " (@CPF) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", cuidador_formal.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        public bool VerificaCuidador(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT COUNT(*) from tbl_cuidador_formal WHERE CPF = @cpf;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            int count = (int)ExecScalar(sqlcomm);
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Esta funcao retorna todas as informações pessoais sobre um cuidador_formal
        public CuidadorFormal GetCuidadorFormal(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT tbl_pessoa.* FROM tbl_pessoa, tbl_cuidador_formal WHERE tbl_cuidador_formal.CPF = @cpf AND tbl_cuidador_formal.CPF = tbl_pessoa.CPF;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            CuidadorFormal cuidador_formal = new CuidadorFormal();
            cuidador_formal.prenome = dr["Prenome"].ToString();
            cuidador_formal.sobrenome = dr["Sobrenome"].ToString();
            cuidador_formal.estado = dr["Estado"].ToString();
            cuidador_formal.cidade = dr["Cidade"].ToString();
            cuidador_formal.pais = dr["Pais"].ToString();
            cuidador_formal.rua = dr["Rua"].ToString();
            cuidador_formal.cep = dr["CEP"].ToString();
            cuidador_formal.cpf = cpf;

            return cuidador_formal;
        }

        // Essa funcao retorna a lista de nomes e CPF de todos os cuidadores_informais
        public List<CuidadorFormal> GetAllCuidadorFormal()
        {
            string sql = "SELECT tbl_pessoa.* FROM tbl_pessoa, tbl_cuidador_formal WHERE tbl_pessoa.CPF = tbl_cuidador_formal.CPF;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<CuidadorFormal> cuidador_formals = new List<CuidadorFormal>();
            foreach (DataRow dr in dt.Rows)
            {
                CuidadorFormal cuidador_formal = new CuidadorFormal();
                cuidador_formal.prenome = dr["Prenome"].ToString();
                cuidador_formal.sobrenome = dr["Sobrenome"].ToString();
                cuidador_formal.estado = dr["Estado"].ToString();
                cuidador_formal.cidade = dr["Cidade"].ToString();
                cuidador_formal.pais = dr["Pais"].ToString();
                cuidador_formal.rua = dr["Rua"].ToString();
                cuidador_formal.cep = dr["CEP"].ToString();
                cuidador_formal.cpf = dr["CPF"].ToString();
                cuidador_formals.Add(cuidador_formal);
            }
            return cuidador_formals;
        }

        // Essa funcao é chamada para atualizar os dados de um cuidador_formal
        public void UpdateCuidadorFormal(CuidadorFormal cuidador_formal)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_pessoa SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Prenome", cuidador_formal.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Sobrenome", cuidador_formal.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Estado", cuidador_formal.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Cidade", cuidador_formal.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Pais", cuidador_formal.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Rua", cuidador_formal.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CEP", cuidador_formal.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", cuidador_formal.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um cuidador_formal do banco de dados
        public void DeleteCuidadorFormal(string cpf)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_cuidador_formal WHERE CPF = @CPF ;";
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

