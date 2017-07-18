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
    public class HorarioMedicamentoAccess : DBAccess
    {
        //Constructor function
        public HorarioMedicamentoAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um HorarioMedicamento na base de dados
        public void InsertHorarioMedicamento(HorarioMedicamento newHorarioMedicamento)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_horariomedicamento ";
            sSQL += " (CPF_Medico, CPF_Paciente, Data, Valor, Hora) ";
            sSQL += " Values ";
            sSQL += " (@CPF_Medico, @CPF_Paciente, @Data, @Valor, @Hora) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("Nro_registro", newHorarioMedicamento.nro_registro);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Horario", newHorarioMedicamento.horario);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }       

        //Esta funcao retorna todas as informações pessoais sobre um HorarioMedicamento
        public HorarioMedicamento GetHorarioMedicamento(string nro_registro)
        {
            string sSQL = "";
            sSQL += " SELECT tbl_medicamento.*, tbl_HorarioMedicamento.Horario FROM tbl_medicamento, tbl_HorarioMedicamento WHERE tbl_HorarioMedicamento.Nro_registro = @nro_registro AND tbl_pessoa.Nro_registro = tbl_HorarioMedicamento.Nro_registro;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("Nro_registro", nro_registro);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            HorarioMedicamento HorarioMedicamento = new HorarioMedicamento();
            HorarioMedicamento.nome = dr["Nome"].ToString();
            HorarioMedicamento.principio_ativo = dr["Principio_ativo"].ToString();
            HorarioMedicamento.posologia = dr["Posologia"].ToString();
            HorarioMedicamento.horario = dr["Horario"].ToString();

            return HorarioMedicamento;
        }

        //Listar o nome de todos os medicamentos para um determinado horário
        public List<string> GetAllHorarioMedicamentos()
        {
            string sql = "SELECT tbl_medicamento.*, tbl_HorarioMedicamento.Horario FROM tbl_medicamento, tbl_HorarioMedicamento;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<string> Medicamentos = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string medicamento;
                medicamento = dr["Nome"].ToString();
                Medicamentos.Add(medicamento);
            }
            return Medicamentos;
        }

        // Essa funcao é chamada para atualizar os dados de um HorarioMedicamento
        public void UpdateHorarioMedicamento(HorarioMedicamento HorarioMedicamento)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_medicamento SET Nome = @Nome, Principio_ativo = @Principio_ativo, Posologia = @Posologia WHERE Nro_registro = @Nro_registro";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Nome", HorarioMedicamento.nome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Principio_ativo", HorarioMedicamento.principio_ativo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Posologia", HorarioMedicamento.posologia);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);

            sSQL = "";
            sSQL += " UPDATE tbl_HorarioMedicamento SET Horario = @Horario WHERE Nro_registro = @Nro_registro";

            sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            sqlparam = new SqlParameter("@Horario", HorarioMedicamento.horario);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um HorarioMedicamento do banco de dados
        public void DeleteHorarioMedicamento(string nro_registro)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_HorarioMedicamento WHERE Nro_registro = @Nro_registro ;";
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
