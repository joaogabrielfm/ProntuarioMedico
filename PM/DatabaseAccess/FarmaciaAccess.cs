using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//comentario para teste de commit
namespace DatabaseAccess
{
    public class FarmaciaAccess : DBAccess
    {
        //Constructor function
        public FarmaciaAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere uma farmacia na base de dados
        public void InsertFarmacia(Farmacia farmacia)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_farmacia ";
            sSQL += " (CNPJ, rua, cidade, estado, cep, site, horario_funcionamento) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @rua, @cidade, @estado,  @cep, @site, @horario_funcionamento) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", farmacia.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("rua", farmacia.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("cidade", farmacia.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("estado", farmacia.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("cep", farmacia.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("site", farmacia.site);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("horario_funcionamento", farmacia.horario_funcionamento);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações sobre uma farmacia
        public Farmacia GetFarmacia(string cnpj)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_farmacia WHERE CNPJ = @cnpj ;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cnpj", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Farmacia tempFarmacia = new Farmacia();
            tempFarmacia.site = dr["site"].ToString();
            tempFarmacia.estado = dr["estado"].ToString();
            tempFarmacia.cidade = dr["cidade"].ToString();
            tempFarmacia.rua = dr["rua"].ToString();
            tempFarmacia.cep = dr["cep"].ToString();
            tempFarmacia.horario_funcionamento = dr["horario_funcionamento"].ToString();
            tempFarmacia.cnpj = cnpj;

            return tempFarmacia;
        }

        // Essa funcao retorna a lista de todas as farmacias 
        public List<Farmacia> GetAllFarmacia()
        {
            string sql = " SELECT * FROM tbl_farmacia";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Farmacia> farmacias = new List<Farmacia>();
            foreach (DataRow dr in dt.Rows)
            {
                Farmacia tempFarmacia = new Farmacia();
                tempFarmacia.site = dr["site"].ToString();
                tempFarmacia.estado = dr["estado"].ToString();
                tempFarmacia.cidade = dr["cidade"].ToString();
                tempFarmacia.rua = dr["rua"].ToString();
                tempFarmacia.cep = dr["cep"].ToString();
                tempFarmacia.cnpj = dr["cnpj"].ToString();
                tempFarmacia.horario_funcionamento = dr["horario_funcionamento"].ToString();
                farmacias.Add(tempFarmacia);
            }
            return farmacias;
        }

        // Essa funcao é chamada para atualizar os dados de uma farmacia
        public void UpdateFarmacia(Farmacia farmacia)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_farmacia SET rua = @rua, cidade = @cidade, estado = @estado, cep = @cep, site = @site, horario_funcionamento = @horario_funcionamento WHERE CNPJ = @CNPJ";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@rua", farmacia.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@cidade", farmacia.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@estado", farmacia.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@cep", farmacia.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@site", farmacia.site);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@horario_funcionamento", farmacia.horario_funcionamento);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", farmacia.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta uma farmacia do banco de dados
        public void DeleteFarmacia(string cnpj)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_farmacia WHERE CNPJ = @CNPJ ;";
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
