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
    public class LaboratoristaAccess : DBAccess
    {
        //Constructor function
        public LaboratoristaAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um laboratorista na base de dados
        public void InsertLaboratorista(Laboratorista newLaboratorista)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_laboratorista ";
            sSQL += " (CPF, CNPJ) ";
            sSQL += " Values ";
            sSQL += " (@CPF, @CNPJ) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", newLaboratorista.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("CNPJ", newLaboratorista.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações pessoais sobre um laboratorista
        public Laboratorista GetLaboratorista(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT tbl_pessoa.*, tbl_laboratorista.CNPJ FROM tbl_pessoa, tbl_laboratorista WHERE tbl_laboratorista.CPF = @cpf AND tbl_pessoa.CPF = tbl_laboratorista.CPF;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Laboratorista laboratorista = new Laboratorista();
            laboratorista.prenome = dr["Prenome"].ToString();
            laboratorista.sobrenome = dr["Sobrenome"].ToString();
            laboratorista.estado = dr["Estado"].ToString();
            laboratorista.cidade = dr["Cidade"].ToString();
            laboratorista.pais = dr["Pais"].ToString();
            laboratorista.rua = dr["Rua"].ToString();
            laboratorista.cep = dr["CEP"].ToString();
            laboratorista.cpf = cpf;
            laboratorista.cnpj = dr["CNPJ"].ToString();

            return laboratorista;
        }

        // Essa funcao retorna a lista de todos os laboratoristas
        public List<Laboratorista> GetAllLaboratoristas()
        {
            string sql = "SELECT tbl_pessoa.*, tbl_laboratorista.CNPJ FROM tbl_pessoa, tbl_laboratorista;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Laboratorista> laboratoristas = new List<Laboratorista>();
            foreach (DataRow dr in dt.Rows)
            {
                Laboratorista laboratorista = new Laboratorista();
                laboratorista.prenome = dr["Prenome"].ToString();
                laboratorista.sobrenome = dr["Sobrenome"].ToString();
                laboratorista.estado = dr["Estado"].ToString();
                laboratorista.cidade = dr["Cidade"].ToString();
                laboratorista.pais = dr["Pais"].ToString();
                laboratorista.rua = dr["Rua"].ToString();
                laboratorista.cep = dr["CEP"].ToString();
                laboratorista.cpf = dr["CPF"].ToString();
                laboratorista.cnpj = dr["CNPJ"].ToString();
                laboratoristas.Add(laboratorista);
            }
            return laboratoristas;
        }

        // Essa funcao é chamada para atualizar os dados de um laboratorista
        public void UpdateLaboratorista(Laboratorista laboratorista)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_pessoa SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Prenome", laboratorista.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Sobrenome", laboratorista.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Estado", laboratorista.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Cidade", laboratorista.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Pais", laboratorista.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Rua", laboratorista.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CEP", laboratorista.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", laboratorista.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);

            sSQL = "";
            sSQL += " UPDATE tbl_laboratorista SET CNPJ = @CNPJ WHERE CPF = @CPF";

            sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            sqlparam = new SqlParameter("@CNPJ", laboratorista.cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um laboratorista do banco de dados
        public void DeleteLaboratorista(string cpf)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_laboratorista WHERE CPF = @CPF ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CPF", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }

    }
}
