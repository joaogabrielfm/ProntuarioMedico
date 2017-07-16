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
    public class MedicamentoAccess : DBAccess
    {
        //Constructor function
        public MedicamentoAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um laboratorista na base de dados
        public void InsertLaboratorista(Medicamento newMedicamento)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_medicamento ";
            sSQL += " (Nro_registro, Nome, Posologia, Principio_ativo) ";
            sSQL += " Values ";
            sSQL += " (@Nro_registro, @Nome, @Posologia, @Principio_ativo) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("Nro_registro", newMedicamento.nro_registro);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Nome", newMedicamento.nome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Posologia", newMedicamento.posologia);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Principio_ativo", newMedicamento.principio_ativo);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todas as informações pessoais sobre um laboratorista
        public Medicamento GetMedicamento(string nro_registro)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_medicamento WHERE Nro_registro = @nro_registro";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("Nro_registro", nro_registro);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Medicamento medicamento = new Medicamento();
            medicamento.nome = dr["Nome"].ToString();
            medicamento.posologia = dr["Posologia"].ToString();
            medicamento.principio_ativo = dr["Principio_ativo"].ToString();
            medicamento.nro_registro = nro_registro;

            return medicamento;
        }

        // Essa funcao retorna a lista de todos os laboratoristas
        public List<Medicamento> GetAllMedicamentos()
        {
            string sql = "SELECT * FROM tbl_medicamento";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Medicamento> medicamentos = new List<Medicamento>();
            foreach (DataRow dr in dt.Rows)
            {
                Medicamento medicamento = new Medicamento();
                medicamento.nome = dr["Nome"].ToString();
                medicamento.posologia = dr["Posologia"].ToString();
                medicamento.principio_ativo = dr["Principio_ativo"].ToString();
                medicamento.nro_registro = dr["Nro_registro"].ToString();
                medicamentos.Add(medicamento);
            }
            return medicamentos;
        }

        // Essa funcao é chamada para atualizar os dados de um laboratorista
        public void UpdateMedicamentos(Medicamento medicamento)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_medicamento SET Nome = @Nome, Principio_ativo = @Principio_ativo, Posologia = @Posologia, Nro_registro = @Nro_registro WHERE Nro_registro = @Nro_registro";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Nome", medicamento.nome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Principio_ativo", medicamento.principio_ativo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Posologia", medicamento.posologia);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Nro_registro", medicamento.nro_registro);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um laboratorista do banco de dados
        public void DeleteMedicamento(string nro_registro)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_medicamento WHERE Nro_registro = @nro_registro ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("Nro_registro", nro_registro);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
    }
}
