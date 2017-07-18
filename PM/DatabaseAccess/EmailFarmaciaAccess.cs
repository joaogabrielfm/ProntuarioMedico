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
    public class EmailFarmaciaAccess : DBAccess
    {
        //Constructor function
        public EmailFarmaciaAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um email_farmacia na base de dados
        public void InsertEmailFarmacia(Email email_farmacia, string cnpj)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_email_farmacia ";
            sSQL += " (CNPJ, email) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @email) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("email", email_farmacia.email);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todos os emails de uma farmacia
        public List<Email> GetAllEmailsFarmacia(string CNPJ)
        {
            string sql = "SELECT * FROM tbl_email_farmacia WHERE tbl_email_farmacia.CNPJ = @CNPJ;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("CNPJ", CNPJ);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = ExecReader(sqlcomm);
            List<Email> emails_farmacia = new List<Email>();
            foreach (DataRow dr in dt.Rows)
            {
                Email email_farmacia = new Email();
                email_farmacia.email = dr["email"].ToString();
                emails_farmacia.Add(email_farmacia);
            }
            return emails_farmacia;
        }

        // Essa funcao é chamada para atualizar o tipo de email de uma farmacia
        public void UpdateEmailFarmacia(string cnpj, string email)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_email_farmacia SET tipo = @tipo WHERE CNPJ = @CNPJ AND email = @email";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@email", email);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um email de uma farmacia do banco de dados
        public void DeleteTelefoneFarmacia(string cnpj, string email)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_email_farmacia WHERE CNPJ = @CNPJ AND email = @email ;";
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
