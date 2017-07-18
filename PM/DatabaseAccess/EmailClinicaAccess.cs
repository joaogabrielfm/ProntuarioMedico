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
    public class EmailClinicaAccess : DBAccess
    {
        //Constructor function
        public EmailClinicaAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um email_clinica na base de dados
        public void InsertEmailClinica(Email email_clinica, string cnpj)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_email_clinica ";
            sSQL += " (CNPJ, email) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @email) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("email", email_clinica.email);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todos os emails de uma clinica
        public List<Email> GetAllEmailsClinica(string CNPJ)
        {
            string sql = "SELECT * FROM tbl_email_clinica WHERE tbl_email_clinica.CNPJ = @CNPJ;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("CNPJ", CNPJ);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = ExecReader(sqlcomm);
            List<Email> emails_clinica = new List<Email>();
            foreach (DataRow dr in dt.Rows)
            {
                Email email_clinica = new Email();
                email_clinica.email = dr["email"].ToString();
                emails_clinica.Add(email_clinica);
            }
            return emails_clinica;
        }

        // Essa funcao é chamada para atualizar o tipo de email de uma clinica
        public void UpdateEmailClinica(string cnpj, string email)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_email_clinica SET tipo = @tipo WHERE CNPJ = @CNPJ AND email = @email";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@email", email);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um email de uma clinica do banco de dados
        public void DeleteTelefoneClinica(string cnpj, string email)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_email_clinica WHERE CNPJ = @CNPJ AND email = @email ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("email", email);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
    }
}
