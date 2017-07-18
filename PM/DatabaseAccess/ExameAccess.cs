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

        //Esta funcao insere um exame na base de dados
        public void InsertExame(Exame exame)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_exame ";
            sSQL += " (DataHora, Resultado) ";
            sSQL += " Values ";
            sSQL += " (@Data_hora, @Resultado) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("Data_hora", exame.dataHora);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Resultado", exame.resultado);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um exame do banco de dados
        public void DeleteExame(Exame exame)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_exame WHERE DataHora = @Data_hora;";
            SqlCommand sqlcomm = new SqlCommand();


            SqlParameter sqlparam = new SqlParameter("Data_hora", exame.dataHora);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
    }
}
