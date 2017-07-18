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
    public class TelefoneFarmaciaAccess : DBAccess
    {
        //Constructor function
        public TelefoneFarmaciaAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um telefone_farmacia na base de dados
        public void InsertTelefoneFarmacia(Telefone telefone_farmacia, string cnpj)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_telefone_farmacia ";
            sSQL += " (CNPJ, tipo, numero) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @tipo, @numero) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("tipo", telefone_farmacia.tipo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("numero", telefone_farmacia.numero);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todos os telefones de uma farmacia
        public List<Telefone> GetAllTelefonesClinica(string CNPJ)
        {
            string sql = "SELECT * FROM tbl_telefone_farmacia WHERE tbl_telefone_farmacia.CNPJ = @CNPJ;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("CNPJ", CNPJ);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = ExecReader(sqlcomm);
            List<Telefone> telefones_farmacia = new List<Telefone>();
            foreach (DataRow dr in dt.Rows)
            {
                Telefone telefone_farmacia = new Telefone();
                telefone_farmacia.tipo = dr["tipo"].ToString();
                telefone_farmacia.numero = Int32.Parse(dr["numero"].ToString());
                telefones_farmacia.Add(telefone_farmacia);
            }
            return telefones_farmacia;
        }

        // Essa funcao é chamada para atualizar o tipo de telefone de uma farmacia
        public void UpdateTelefoneFarmacia(string cnpj, int numero, string tipo)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_telefone_farmacia SET tipo = @tipo WHERE CNPJ = @CNPJ AND numero = @numero";

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

        // Essa funcao deleta um telefone de uma farmacia do banco de dados
        public void DeleteTelefoneFarmacia(string cnpj, int numero)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_telefone_farmacia WHERE CNPJ = @CNPJ AND numero = @numero ;";
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
