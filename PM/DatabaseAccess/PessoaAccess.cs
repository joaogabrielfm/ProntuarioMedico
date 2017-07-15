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
    public class PessoaAccess : DBAccess
    {
        //Constructor function
        public PessoaAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere uma pessoa na base de dados
        public void InsertPessoa(Pessoa pessoa)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_pessoa ";
            sSQL += " (CPF, Prenome, Sobrenome, Estado, Cidade, Pais, Rua, CEP) ";
            sSQL += " Values ";
            sSQL += " (@CPF, @Prenome, @Sobrenome, @Estado,  @Cidade, @Pais, @Rua, @CEP) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", pessoa.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Prenome", pessoa.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Sobrenome", pessoa.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Estado", pessoa.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Cidade", pessoa.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Pais", pessoa.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Rua", pessoa.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("CEP", pessoa.cep);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }


        //Esta funcao retorna todas as informações pessoais sobre uma pessoa
        public Pessoa GetPessoa(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_pessoa WHERE CPF = @cpf ;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Pessoa tempPessoa = new Pessoa();
            tempPessoa.prenome = dr["Prenome"].ToString();
            tempPessoa.sobrenome = dr["Sobrenome"].ToString();
            tempPessoa.estado = dr["Estado"].ToString();
            tempPessoa.cidade = dr["Cidade"].ToString();
            tempPessoa.pais = dr["Pais"].ToString();
            tempPessoa.rua = dr["Rua"].ToString();
            tempPessoa.cep = dr["CEP"].ToString();
            tempPessoa.cpf = cpf;

            return tempPessoa;
        }

        // Essa funcao retorna a lista de todas as pessoas 
        public List<Pessoa> GetAllPessoas()
        {
            string sql = " SELECT * FROM tbl_pessoa";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Pessoa> pessoas = new List<Pessoa>();
            foreach (DataRow dr in dt.Rows)
            {
                Pessoa tempPessoa = new Pessoa();
                tempPessoa.prenome = dr["Prenome"].ToString();
                tempPessoa.sobrenome = dr["Sobrenome"].ToString();
                tempPessoa.estado = dr["Estado"].ToString();
                tempPessoa.cidade = dr["Cidade"].ToString();
                tempPessoa.pais = dr["Pais"].ToString();
                tempPessoa.rua = dr["Rua"].ToString();
                tempPessoa.cep = dr["CEP"].ToString();
                tempPessoa.cpf = dr["CPF"].ToString();
                pessoas.Add(tempPessoa);
            }
            return pessoas;
        }

        // Essa funcao é chamada para atualizar os dados de uma pessoa
        public void UpdatePessoa(Pessoa pessoa)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_pessoa SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Prenome", pessoa.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Sobrenome", pessoa.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Estado", pessoa.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Cidade", pessoa.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Pais", pessoa.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Rua", pessoa.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CEP", pessoa.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", pessoa.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta uma pessoa do banco de dados
        public void DeletePessoa(string cpf)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_pessoa WHERE CPF = @CPF ;";
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
