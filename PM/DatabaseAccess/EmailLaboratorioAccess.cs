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
    public class EmailLaboratorioAccess :DBAccess
    {
        //Constructor function
        public EmailLaboratorioAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um email_laboratorio na base de dados
        public void InsertEmailLaboratorio(Email email_laboratorio, string cnpj)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_email_laboratorio ";
            sSQL += " (CNPJ, email) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @email) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("email", email_laboratorio.email);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todos os emails de um laboratorio
        public List<Email> GetAllEmailsLaboratorio(string CNPJ)
        {
            string sql = "SELECT * FROM tbl_email_laboratorio WHERE tbl_email_laboratorio.CNPJ = @CNPJ;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("CNPJ", CNPJ);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = ExecReader(sqlcomm);
            List<Email> emails_laboratorio = new List<Email>();
            foreach (DataRow dr in dt.Rows)
            {
                Email email_laboratorio = new Email();
                email_laboratorio.email = dr["email"].ToString();
                emails_laboratorio.Add(email_laboratorio);
            }
            return emails_laboratorio;
        }

        // Essa funcao é chamada para atualizar o tipo de email de um laboratorio
        public void UpdateEmailLaboratorio(string cnpj, string email)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_email_laboratorio SET tipo = @tipo WHERE CNPJ = @CNPJ AND email = @email";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@email", email);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um email de um laboratorio do banco de dados
        public void DeleteTelefoneLaboratorio(string cnpj, string email)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_email_laboratorio WHERE CNPJ = @CNPJ AND email = @email ;";
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
