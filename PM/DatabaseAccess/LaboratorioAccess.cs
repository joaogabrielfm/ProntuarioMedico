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
    public class LaboratorioAccess : DBAccess
    {
        //Constructor function
        public LaboratorioAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um laboratorio na base de dados
        public void InsertLaboratorio(Laboratorio laboratorio)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_laboratorio ";
            sSQL += " (CNPJ, rua, cidade, estado, cep, site, lista_servicos_prestados) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @rua, @cidade, @estado,  @cep, @site, @lista_servicos_prestados) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", laboratorio.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("rua", laboratorio.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("cidade", laboratorio.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("estado", laboratorio.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("cep", laboratorio.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("site", laboratorio.site);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("lista_servicos_prestados", laboratorio.lista_servicos_prestados);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações sobre um laboratorio
        public Laboratorio GetLaboratorio(string cnpj)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_laboratorio WHERE CNPJ = @cnpj ;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cnpj", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Laboratorio tempLaboratorio = new Laboratorio();
            tempLaboratorio.site = dr["site"].ToString();
            tempLaboratorio.estado = dr["estado"].ToString();
            tempLaboratorio.cidade = dr["cidade"].ToString();
            tempLaboratorio.rua = dr["rua"].ToString();
            tempLaboratorio.cep = dr["cep"].ToString();
            tempLaboratorio.lista_servicos_prestados = dr["lista_servicos_prestados"].ToString();
            tempLaboratorio.cnpj = cnpj;

            return tempLaboratorio;
        }

        // Essa funcao retorna a lista de todas os laboratorios 
        public List<Laboratorio> GetAllLaboratorio()
        {
            string sql = " SELECT * FROM tbl_laboratorio";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Laboratorio> laboratorios = new List<Laboratorio>();
            foreach (DataRow dr in dt.Rows)
            {
                Laboratorio tempLaboratorio = new Laboratorio();
                tempLaboratorio.site = dr["site"].ToString();
                tempLaboratorio.estado = dr["estado"].ToString();
                tempLaboratorio.cidade = dr["cidade"].ToString();
                tempLaboratorio.rua = dr["rua"].ToString();
                tempLaboratorio.cep = dr["cep"].ToString();
                tempLaboratorio.cnpj = dr["cnpj"].ToString();
                tempLaboratorio.lista_servicos_prestados = dr["lista_servicos_prestados"].ToString();
                laboratorios.Add(tempLaboratorio);
            }
            return laboratorios;
        }

        // Essa funcao é chamada para atualizar os dados de um laboratorio
        public void UpdateLaboratorio(Laboratorio laboratorio)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_laboratorio SET rua = @rua, cidade = @cidade, estado = @estado, cep = @cep, site = @site, lista_servicos_prestados = @lista_servicos_prestados WHERE CNPJ = @CNPJ";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@rua", laboratorio.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@cidade", laboratorio.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@estado", laboratorio.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@cep", laboratorio.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@site", laboratorio.site);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@lista_servicos_prestados", laboratorio.lista_servicos_prestados);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", laboratorio.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um laboratorio do banco de dados
        public void DeleteLaboratorio(string cnpj)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_laboratorio WHERE CNPJ = @CNPJ ;";
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
