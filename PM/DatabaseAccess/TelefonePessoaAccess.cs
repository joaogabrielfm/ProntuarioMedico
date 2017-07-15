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
    public class TelefonePessoaAccess : DBAccess
    {
        //Constructor function
        public TelefonePessoaAccess(string connectionString) : base(connectionString) { }
/*
        //Esta funcao insere um telefone_pessoa na base de dados
        public void InsertTelefonePessoa(TelefonePessoa telefone_pessoa)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_telefone_pessoa ";
            sSQL += " (CPF) ";
            sSQL += " Values ";
            sSQL += " (@CPF) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", telefone_pessoa.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações pessoais sobre um telefone_pessoa
        public TelefonePessoa GetTelefonePessoa(string cpf)
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

            TelefonePessoa telefone_pessoa = new TelefonePessoa();
            telefone_pessoa.prenome = dr["Prenome"].ToString();
            telefone_pessoa.sobrenome = dr["Sobrenome"].ToString();
            telefone_pessoa.estado = dr["Estado"].ToString();
            telefone_pessoa.cidade = dr["Cidade"].ToString();
            telefone_pessoa.pais = dr["Pais"].ToString();
            telefone_pessoa.rua = dr["Rua"].ToString();
            telefone_pessoa.cep = dr["CEP"].ToString();
            telefone_pessoa.cpf = cpf;

            return telefone_pessoa;
        }

        // Essa funcao retorna a lista de nomes e CPF de todos os telefone_pessoas
        public List<TelefonePessoa> GetAllTelefonePessoas()
        {
            string sql = "SELECT tbl_pessoa.* FROM tbl_pessoa, tbl_telefone_pessoa WHERE tbl_pessoa.CPF = tbl_telefone_pessoa.CPF;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<TelefonePessoa> telefone_pessoas = new List<TelefonePessoa>();
            foreach (DataRow dr in dt.Rows)
            {
                TelefonePessoa telefone_pessoa = new TelefonePessoa();
                telefone_pessoa.prenome = dr["Prenome"].ToString();
                telefone_pessoa.sobrenome = dr["Sobrenome"].ToString();
                telefone_pessoa.estado = dr["Estado"].ToString();
                telefone_pessoa.cidade = dr["Cidade"].ToString();
                telefone_pessoa.pais = dr["Pais"].ToString();
                telefone_pessoa.rua = dr["Rua"].ToString();
                telefone_pessoa.cep = dr["CEP"].ToString();
                telefone_pessoa.cpf = dr["CPF"].ToString();
                telefone_pessoas.Add(telefone_pessoa);
            }
            return telefone_pessoas;
        }

        // Essa funcao é chamada para atualizar os dados de um telefone_pessoa
        public void UpdateTelefonePessoa(TelefonePessoa telefone_pessoa)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_pessoa SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Prenome", telefone_pessoa.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Sobrenome", telefone_pessoa.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Estado", telefone_pessoa.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Cidade", telefone_pessoa.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Pais", telefone_pessoa.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Rua", telefone_pessoa.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CEP", telefone_pessoa.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", telefone_pessoa.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um telefone_pessoa do banco de dados
        public void DeleteTelefonePessoa(string cpf)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_telefone_pessoa WHERE CPF = @CPF ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CPF", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
        */
    }
}

