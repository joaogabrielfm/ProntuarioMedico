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
    public class ExameAccess : DBAccess
    {
        //Constructor function
        public ExameAccess(string connectionString) : base(connectionString) { }
        /*
        //Esta funcao insere um exame na base de dados
        public void InsertExame(Exame exame)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_exame ";
            sSQL += " (Data_hora, Resultado) ";
            sSQL += " Values ";
            sSQL += " (@Data_hora, @Resultado) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("Data_hora", exame.Data_hora);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Resultado", exame.Resultado);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }


        //Esta funcao retorna todas as informações de um exame
        public Exame GetExame(DateTime Data_hora)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_exame WHERE Data_hora = @Data_hora ;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("Data_hora", Data_hora);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Exame tempExame = new Exame();
            tempExame.Resultado = dr["Resutaldo"].ToString();
            tempExame.Data_hora = Data_hora;

            return tempExame;
        }

        // Essa funcao retorna a lista de todos os exames 
        public List<Exame> GetAllExames()
        {
            string sql = " SELECT * FROM tbl_exame";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Exame> exames = new List<Exame>();
            foreach (DataRow dr in dt.Rows)
            {
                Pessoa tempPessoa = new Pessoa();
                Exame tempExame = new Exame();
                tempExame.Data_hora = dr["Data_hora"].ToString();
                tempExame.Resultado = dr["Resultado"].ToString();
                exames.Add(tempExame);
            }
            return exames;
        }

        // Essa funcao é chamada para atualizar os dados de um exame
        public void UpdateExame(Exame exame)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_exame SET Resultado = @Resultado WHERE Data_hora = @Data_hora";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Resultado", exame.Resultado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Data_hora", exame.Data_hora);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um exame do banco de dados
        public void DeleteExame(string Data_hora)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_exame WHERE Data_hora = @Data_hora ;";
            SqlCommand sqlcomm = new SqlCommand();


            SqlParameter sqlparam = new SqlParameter("Data_hora", Data_hora);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }*/
    }
}
