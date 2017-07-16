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
    public class TelefoneHospitalAccess : DBAccess
    {
        //Constructor function
        public TelefoneHospitalAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um telefone_hospital na base de dados
        public void InsertTelefoneHospital(Telefone telefone_hospital, string cnpj)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_telefone_hospital ";
            sSQL += " (CNPJ, tipo, numero) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @tipo, @numero) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("tipo", telefone_hospital.tipo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("numero", telefone_hospital.numero);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todos os telefones de um hospital
        public List<Telefone> GetAllTelefonesHospital(string CNPJ)
        {
            string sql = "SELECT * FROM tbl_telefone_hospital WHERE tbl_telefone_hospital.CNPJ = @CNPJ;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("CNPJ", CNPJ);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = ExecReader(sqlcomm);
            List<Telefone> telefones_hospital = new List<Telefone>();
            foreach (DataRow dr in dt.Rows)
            {
                Telefone telefone_hospital = new Telefone();
                telefone_hospital.tipo = dr["tipo"].ToString();
                telefone_hospital.numero = Int32.Parse(dr["numero"].ToString());
                telefones_hospital.Add(telefone_hospital);
            }
            return telefones_hospital;
        }

        // Essa funcao é chamada para atualizar o tipo de telefone de um hospital
        public void UpdateTelefoneHospital(string cnpj, int numero, string tipo)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_telefone_hospital SET tipo = @tipo WHERE CNPJ = @CNPJ AND numero = @numero";

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

        // Essa funcao deleta um telefone de um hospital do banco de dados
        public void DeleteTelefoneHospital(string cnpj, int numero)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_telefone_hospital WHERE CNPJ = @CNPJ AND numero = @numero ;";
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
