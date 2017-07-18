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
    public class PacienteAccess : DBAccess
    {
        //Constructor function
        public PacienteAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um paciente na base de dados
        public void InsertPaciente(Paciente paciente)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_paciente ";
            sSQL += " (CPF) ";
            sSQL += " Values ";
            sSQL += " (@CPF) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", paciente.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        public bool VerificaPaciente(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT COUNT(*) from tbl_paciente WHERE CPF = @cpf;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            int count = (int)ExecScalar(sqlcomm);
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Esta funcao retorna todas as informações pessoais sobre um paciente
        public Paciente GetPaciente(string cpf)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_pessoa WHERE CPF = @cpf;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("cpf", cpf);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Paciente paciente = new Paciente();
            paciente.prenome = dr["Prenome"].ToString();
            paciente.sobrenome = dr["Sobrenome"].ToString();
            paciente.estado = dr["Estado"].ToString();
            paciente.cidade = dr["Cidade"].ToString();
            paciente.pais = dr["Pais"].ToString();
            paciente.rua = dr["Rua"].ToString();
            paciente.cep = dr["CEP"].ToString();
            paciente.cpf = cpf;

            return paciente;
        }

        // Essa funcao retorna a lista de nomes e CPF de todos os pacientes
        public List<Paciente> GetAllPacientes()
        {
            string sql = "SELECT tbl_pessoa.* FROM tbl_pessoa, tbl_paciente WHERE tbl_pessoa.CPF = tbl_paciente.CPF;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Paciente> pacientes = new List<Paciente>();
            foreach (DataRow dr in dt.Rows)
            {
                Paciente paciente = new Paciente();
                paciente.prenome = dr["Prenome"].ToString();
                paciente.sobrenome = dr["Sobrenome"].ToString();
                paciente.estado = dr["Estado"].ToString();
                paciente.cidade = dr["Cidade"].ToString();
                paciente.pais = dr["Pais"].ToString();
                paciente.rua = dr["Rua"].ToString();
                paciente.cep = dr["CEP"].ToString();
                paciente.cpf = dr["CPF"].ToString();
                pacientes.Add(paciente);
            }
            return pacientes;
        }

        // Essa funcao é chamada para atualizar os dados de um paciente
        public void UpdatePaciente(Paciente paciente)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_pessoa SET Prenome = @Prenome, Sobrenome = @Sobrenome, Estado = @Estado, Cidade = @Cidade, Pais = @Pais, Rua = @Rua, CEP = @CEP WHERE CPF = @CPF";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Prenome", paciente.prenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Sobrenome", paciente.sobrenome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Estado", paciente.estado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Cidade", paciente.cidade);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Pais", paciente.pais);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Rua", paciente.rua);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CEP", paciente.cep);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CPF", paciente.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um paciente do banco de dados
        public void DeletePaciente(string cpf)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_paciente WHERE CPF = @CPF ;";
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

