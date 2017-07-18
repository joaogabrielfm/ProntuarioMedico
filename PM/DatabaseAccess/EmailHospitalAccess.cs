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
    public class EmailHospitalAccess : DBAccess
    {
        //Constructor function
        public EmailHospitalAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um email_hospital na base de dados
        public void InsertEmailHospital(Email email_hospital, string cnpj)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_email_hospital ";
            sSQL += " (CNPJ, email) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @email) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("email", email_hospital.email);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todos os emails de um hospital
        public List<Email> GetAllEmailsHospital(string CNPJ)
        {
            string sql = "SELECT * FROM tbl_email_hospital WHERE tbl_email_hospital.CNPJ = @CNPJ;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("CNPJ", CNPJ);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = ExecReader(sqlcomm);
            List<Email> emails_hospital = new List<Email>();
            foreach (DataRow dr in dt.Rows)
            {
                Email email_hospital = new Email();
                email_hospital.email = dr["email"].ToString();
                emails_hospital.Add(email_hospital);
            }
            return emails_hospital;
        }

        // Essa funcao é chamada para atualizar o tipo de email de um hospital
        public void UpdateEmailHospital(string cnpj, string email)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_email_hospital SET tipo = @tipo WHERE CNPJ = @CNPJ AND email = @email";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@email", email);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um email de um hospital do banco de dados
        public void DeleteTelefoneHospital(string cnpj, string email)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_email_hospital WHERE CNPJ = @CNPJ AND email = @email ;";
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
