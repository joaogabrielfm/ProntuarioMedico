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
    class MedicoAccess : DBAccess
    {
        //Constructor function
        public MedicoAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um medico na base de dados
        public void InsertMedico(Medico newMedico)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_medico ";
            sSQL += " (CPF, CRM) ";
            sSQL += " Values ";
            sSQL += " (@CPF, @CRM) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", newMedico.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("CRM", newMedico.crm);
            sqlcomm.Parameters.Add(sqlparam);
            
            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações pessoais sobre um medico
        public Medico GetMedico(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT tbl_pessoa.*, tbl_medico.CRM FROM tbl_pessoa, tbl_medico WHERE tbl_medico.CPF = @cpf AND tbl_pessoa.CPF = tbl_medico.CPF;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Medico medico = new Medico();
            medico.prenome = dr["Prenome"].ToString();
            medico.sobrenome = dr["Sobrenome"].ToString();
            medico.estado = dr["Estado"].ToString();
            medico.cidade = dr["Cidade"].ToString();
            medico.pais = dr["Pais"].ToString();
            medico.rua = dr["Rua"].ToString();
            medico.cep = dr["CEP"].ToString();
            medico.cpf = cpf;
            medico.crm = dr["CRM"].ToString();

            return medico;
        }

        // Essa funcao retorna a lista de todos os medicos
        public List<Medico> GetAllMedicos()
        {
            string sql = "SELECT tbl_pessoa.*, tbl_medico.CRM FROM tbl_pessoa, tbl_medico;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Medico> medicos = new List<Medico>();
            foreach (DataRow dr in dt.Rows)
            {
                Medico medico = new Medico();
                medico.prenome = dr["Prenome"].ToString();
                medico.sobrenome = dr["Sobrenome"].ToString();
                medico.estado = dr["Estado"].ToString();
                medico.cidade = dr["Cidade"].ToString();
                medico.pais = dr["Pais"].ToString();
                medico.rua = dr["Rua"].ToString();
                medico.cep = dr["CEP"].ToString();
                medico.cpf = dr["CPF"].ToString();
                medico.crm = dr["CRM"].ToString();
                medicos.Add(medico);
            }
            return medicos;
        }

        // Essa funcao é chamada para atualizar os dados de um medico
        public void UpdateMedico(Medico medico)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_pessoa SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Prenome", medico.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Sobrenome", medico.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Estado", medico.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Cidade", medico.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Pais", medico.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Rua", medico.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CEP", medico.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", medico.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);

            sSQL = "";
            sSQL += " UPDATE tbl_medico SET CRM = @CRM WHERE CPF = @CPF";

            sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            sqlparam = new SqlParameter("@CMR", medico.crm);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um medico do banco de dados
        public void DeleteMedico(string cpf)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_medico WHERE CPF = @CPF ;";
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
