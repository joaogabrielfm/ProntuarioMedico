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
    public class FarmaceuticoAccess : DBAccess
    {
        //Constructor function
        public FarmaceuticoAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um farmaceutico na base de dados
        public void InsertFarmaceutico(Farmaceutico farmaceutico)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_farmaceutico ";
            sSQL += " (CPF) ";
            sSQL += " Values ";
            sSQL += " (@CPF) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", farmaceutico.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        public bool VerificaFarmaceutico(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT COUNT(*) from tbl_farmaceutico WHERE CPF = @cpf;";
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

        //Esta funcao retorna todas as informações pessoais sobre um farmaceutico
        public Farmaceutico GetFarmaceutico(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT tbl_pessoa.* FROM tbl_pessoa, tbl_farmaceutico WHERE tbl_farmaceutico.CPF = @cpf AND tbl_farmaceutico.CPF = tbl_pessoa.CPF;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Farmaceutico farmaceutico = new Farmaceutico();
            farmaceutico.prenome = dr["Prenome"].ToString();
            farmaceutico.sobrenome = dr["Sobrenome"].ToString();
            farmaceutico.estado = dr["Estado"].ToString();
            farmaceutico.cidade = dr["Cidade"].ToString();
            farmaceutico.pais = dr["Pais"].ToString();
            farmaceutico.rua = dr["Rua"].ToString();
            farmaceutico.cep = dr["CEP"].ToString();
            farmaceutico.cpf = cpf;

            return farmaceutico;
        }

        // Essa funcao retorna a lista de nomes e CPF de todos os cuidadores_informais
        public List<Farmaceutico> GetAllFarmaceutico()
        {
            string sql = "SELECT tbl_pessoa.* FROM tbl_pessoa, tbl_farmaceutico WHERE tbl_pessoa.CPF = tbl_farmaceutico.CPF;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Farmaceutico> farmaceuticos = new List<Farmaceutico>();
            foreach (DataRow dr in dt.Rows)
            {
                Farmaceutico farmaceutico = new Farmaceutico();
                farmaceutico.prenome = dr["Prenome"].ToString();
                farmaceutico.sobrenome = dr["Sobrenome"].ToString();
                farmaceutico.estado = dr["Estado"].ToString();
                farmaceutico.cidade = dr["Cidade"].ToString();
                farmaceutico.pais = dr["Pais"].ToString();
                farmaceutico.rua = dr["Rua"].ToString();
                farmaceutico.cep = dr["CEP"].ToString();
                farmaceutico.cpf = dr["CPF"].ToString();
                farmaceuticos.Add(farmaceutico);
            }
            return farmaceuticos;
        }

        // Essa funcao é chamada para atualizar os dados de um farmaceutico
        public void UpdateFarmaceutico(Farmaceutico farmaceutico)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_pessoa SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Prenome", farmaceutico.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Sobrenome", farmaceutico.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Estado", farmaceutico.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Cidade", farmaceutico.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Pais", farmaceutico.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Rua", farmaceutico.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CEP", farmaceutico.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", farmaceutico.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um farmaceutico do banco de dados
        public void DeleteFarmaceutico(string cpf)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_farmaceutico WHERE CPF = @CPF ;";
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

