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
    public class FamiliarAccess : DBAccess
    {
        //Constructor function
        public FamiliarAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um familiar na base de dados
        public void InsertFamiliar(Familiar familiar)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_familiar ";
            sSQL += " (CPF) ";
            sSQL += " Values ";
            sSQL += " (@CPF) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", familiar.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações pessoais sobre um familiar
        public Familiar GetFamiliar(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_pessoa WHERE CPF = @cpf;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Familiar familiar = new Familiar();
            familiar.prenome = dr["Prenome"].ToString();
            familiar.sobrenome = dr["Sobrenome"].ToString();
            familiar.estado = dr["Estado"].ToString();
            familiar.cidade = dr["Cidade"].ToString();
            familiar.pais = dr["Pais"].ToString();
            familiar.rua = dr["Rua"].ToString();
            familiar.cep = dr["CEP"].ToString();
            familiar.cpf = cpf;

            return familiar;
        }

        // Essa funcao retorna a lista de nomes e CPF de todos os familiares
        public List<Familiar> GetAllFamiliares()
        {
            string sql = "SELECT tbl_pessoa.* FROM tbl_pessoa, tbl_familiar WHERE tbl_pessoa.CPF = tbl_familiar.CPF;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Familiar> familiars = new List<Familiar>();
            foreach (DataRow dr in dt.Rows)
            {
                Familiar familiar = new Familiar();
                familiar.prenome = dr["Prenome"].ToString();
                familiar.sobrenome = dr["Sobrenome"].ToString();
                familiar.estado = dr["Estado"].ToString();
                familiar.cidade = dr["Cidade"].ToString();
                familiar.pais = dr["Pais"].ToString();
                familiar.rua = dr["Rua"].ToString();
                familiar.cep = dr["CEP"].ToString();
                familiar.cpf = dr["CPF"].ToString();
                familiars.Add(familiar);
            }
            return familiars;
        }

        // Essa funcao é chamada para atualizar os dados de um familiar
        public void UpdateFamiliar(Familiar familiar)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_pessoa SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

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
        }

        // Essa funcao deleta um familiar do banco de dados
        public void DeleteFamiliar(string cpf)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_familiar WHERE CPF = @CPF ;";
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

