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

        //Esta funcao insere um telefone_pessoa na base de dados
        public void InsertTelefonePessoa(Telefone telefone_pessoa, string cpf)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_telefone_pessoa ";
            sSQL += " (CPF, Tipo, Numero) ";
            sSQL += " Values ";
            sSQL += " (@CPF, @Tipo, @Numero) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Tipo", telefone_pessoa.tipo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Numero", telefone_pessoa.numero);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todos os telefones de uma pessoa
        public List<Telefone> GetAllTelefonesPessoa(string CPF)
        {
            string sql = "SELECT * FROM tbl_telefone_pessoa WHERE tbl_telefone_pessoa.CPF = @CPF;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("CPF", CPF);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = ExecReader(sqlcomm);
            List<Telefone> telefones_pessoa = new List<Telefone>();
            foreach (DataRow dr in dt.Rows)
            {
                Telefone telefone_pessoa = new Telefone();
                telefone_pessoa.tipo = dr["Tipo"].ToString();
                telefone_pessoa.numero = Int32.Parse(dr["Numero"].ToString());
                telefones_pessoa.Add(telefone_pessoa);
            }
            return telefones_pessoa;
        }

        // Essa funcao é chamada para atualizar o tipo de telefone de uma pessoa
        public void UpdateTelefonePessoa(string cpf, int numero, string tipo)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_telefone_pessoa SET Tipo = @Tipo WHERE CPF = @CPF AND Numero = @Numero";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Tipo", tipo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Numero", numero);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", cpf);
            sqlcomm.Parameters.Add(sqlparam);
            
            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um telefone de uma pessoa do banco de dados
        public void DeleteTelefonePessoa(string cpf, int numero)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_telefone_pessoa WHERE CPF = @CPF AND Numero = @Numero ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CPF", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Numero", numero);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
        
    }
}

