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
    public class TelefoneClinicaAccess : DBAccess
    {
        //Constructor function
        public TelefoneClinicaAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um telefone_clinica na base de dados
        public void InsertTelefoneClinica(Telefone telefone_clinica, string cnpj)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_telefone_clinica ";
            sSQL += " (CNPJ, tipo, numero) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @tipo, @numero) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("tipo", telefone_clinica.tipo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("numero", telefone_clinica.numero);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todos os telefones de uma clinica
        public List<Telefone> GetAllTelefonesClinica(string CNPJ)
        {
            string sql = "SELECT * FROM tbl_telefone_clinica WHERE tbl_telefone_clinica.CNPJ = @CNPJ;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("CNPJ", CNPJ);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = ExecReader(sqlcomm);
            List<Telefone> telefones_clinica = new List<Telefone>();
            foreach (DataRow dr in dt.Rows)
            {
                Telefone telefone_clinica = new Telefone();
                telefone_clinica.tipo = dr["tipo"].ToString();
                telefone_clinica.numero = Int32.Parse(dr["numero"].ToString());
                telefones_clinica.Add(telefone_clinica);
            }
            return telefones_clinica;
        }

        // Essa funcao é chamada para atualizar o tipo de telefone de uma clinica
        public void UpdateTelefoneClinica(string cnpj, int numero, string tipo)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_telefone_clinica SET tipo = @tipo WHERE CNPJ = @CNPJ AND numero = @numero";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@tipo", tipo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@numero", numero);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um telefone de uma clinica do banco de dados
        public void DeleteTelefoneClinica(string cnpj, int numero)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_telefone_clinica WHERE CNPJ = @CNPJ AND numero = @numero ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("numero", numero);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
    }
}
