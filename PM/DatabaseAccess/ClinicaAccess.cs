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
    public class ClinicaAccess : DBAccess
    {
        //Constructor function
        public ClinicaAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere uma clinica na base de dados
        public void InsertClinica(Clinica clinica)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_clinica ";
            sSQL += " (CNPJ, rua, cidade, estado, cep, site) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @rua, @cidade, @estado,  @cep, @site) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", clinica.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("rua", clinica.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("cidade", clinica.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("estado", clinica.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("cep", clinica.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("site", clinica.site);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações sobre uma clinica
        public Clinica GetClinica(string cnpj)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_clinica WHERE CNPJ = @cnpj ;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cnpj", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Clinica tempClinica = new Clinica();
            tempClinica.site = dr["site"].ToString();
            tempClinica.estado = dr["estado"].ToString();
            tempClinica.cidade = dr["cidade"].ToString();
            tempClinica.rua = dr["rua"].ToString();
            tempClinica.cep = dr["cep"].ToString();
            tempClinica.cnpj = cnpj;

            return tempClinica;
        }

        // Essa funcao retorna a lista de todas as clinicas 
        public List<Clinica> GetAllClinicas()
        {
            string sql = " SELECT * FROM tbl_clinica";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Clinica> clinicas = new List<Clinica>();
            foreach (DataRow dr in dt.Rows)
            {
                Clinica tempClinica = new Clinica();
                tempClinica.site = dr["site"].ToString();
                tempClinica.estado = dr["estado"].ToString();
                tempClinica.cidade = dr["cidade"].ToString();
                tempClinica.rua = dr["rua"].ToString();
                tempClinica.cep = dr["cep"].ToString();
                tempClinica.cnpj = dr["cnpj"].ToString();
                clinicas.Add(tempClinica);
            }
            return clinicas;
        }

        // Essa funcao é chamada para atualizar os dados de uma clinica
        public void UpdateClinica(Clinica clinica)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_clinica SET rua = @rua, cidade = @cidade, estado = @estado, cep = @cep, site = @site WHERE CNPJ = @CNPJ";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@rua", clinica.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@cidade", clinica.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@estado", clinica.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@cep", clinica.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@site", clinica.site);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", clinica.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta uma clinica do banco de dados
        public void DeleteClinica(string cnpj)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_clinica WHERE CNPJ = @CNPJ ;";
            SqlCommand sqlcomm = new SqlCommand();


            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
    }
}
