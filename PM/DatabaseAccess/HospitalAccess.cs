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
    public class HospitalAccess : DBAccess
    {
        public HospitalAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um hospital na base de dados
        public void InsertHospital(Hospital hospital)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_hospital ";
            sSQL += " (CNPJ, rua, cidade, estado, cep, site) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @rua, @cidade, @estado,  @cep, @site) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", hospital.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("rua", hospital.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("cidade", hospital.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("estado", hospital.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("cep", hospital.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("site", hospital.site);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações sobre uma clinica
        public Hospital GetHospital(string cnpj)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_hospital WHERE CNPJ = @cnpj ;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cnpj", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Hospital tempHospital = new Hospital();
            tempHospital.site = dr["site"].ToString();
            tempHospital.estado = dr["estado"].ToString();
            tempHospital.cidade = dr["cidade"].ToString();
            tempHospital.rua = dr["rua"].ToString();
            tempHospital.cep = dr["cep"].ToString();
            tempHospital.cnpj = cnpj;

            return tempHospital;
        }

        // Essa funcao retorna a lista de todas os hospitais 
        public List<Hospital> GetAllHospitais()
        {
            string sql = " SELECT * FROM tbl_hospital";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Hospital> hospitais = new List<Hospital>();
            foreach (DataRow dr in dt.Rows)
            {
                Hospital tempHospital = new Hospital();
                tempHospital.site = dr["site"].ToString();
                tempHospital.estado = dr["estado"].ToString();
                tempHospital.cidade = dr["cidade"].ToString();
                tempHospital.rua = dr["rua"].ToString();
                tempHospital.cep = dr["cep"].ToString();
                tempHospital.cnpj = dr["cnpj"].ToString();
                hospitais.Add(tempHospital);
            }
            return hospitais;
        }

        // Essa funcao é chamada para atualizar os dados de um hospital
        public void UpdateHospital(Hospital hospital)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_hospital SET rua = @rua, cidade = @cidade, estado = @estado, cep = @cep, site = @site WHERE CNPJ = @CNPJ";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@rua", hospital.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@cidade", hospital.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@estado", hospital.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@cep", hospital.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@site", hospital.site);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", hospital.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um hospital do banco de dados
        public void DeleteHospital(string cnpj)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_hospital WHERE CNPJ = @CNPJ ;";
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
