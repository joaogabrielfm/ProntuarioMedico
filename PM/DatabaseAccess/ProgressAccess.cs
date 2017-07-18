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
    class ProgressoAccess : DBAccess
    {
        public ProgressoAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um Progresso na base de dados
        public void InsertProgresso(Progresso progresso)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_progresso ";
            sSQL += " (Data, Descricao) ";
            sSQL += " Values ";
            sSQL += " (@Data, @Descricao) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("Data", progresso.data);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Descricao", progresso.descricao);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        private void ExecNonQuery(SqlCommand sqlcomm)
        {
            throw new NotImplementedException();
        }

        //Esta funcao retorna todas as informações sobre um progresso
        public Progresso GetProgresso(String Data)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_progresso WHERE Data = @Data ;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("data", Data);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            Progresso tempProgresso = new Progresso();
            tempProgresso.descricao = dr["descricao"].ToString();
            tempProgresso.data = Data;

            return tempProgresso;
        }

        // Essa funcao retorna a lista de todas os Progressos
        public List<Progresso> GetAllProgresso()
        {
            string sql = " SELECT * FROM tbl_progresso";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            DataTable dt = ExecReader(sqlcomm);
            List<Progresso> progresso = new List<Progresso>();
            foreach (DataRow dr in dt.Rows)
            {
                Progresso tempProgresso = new Progresso();
                tempProgresso.descricao = dr["descricao"].ToString();
                tempProgresso.data = dr["data"].ToString();
                progresso.Add(tempProgresso);
            }
            return progresso;
        }

        private DataTable ExecReader(SqlCommand sqlcomm)
        {
            throw new NotImplementedException();
        }

        // Essa funcao é chamada para atualizar os dados de um progresso
        public void UpdateProgresso(Progresso progresso)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_progresso SET descricao = @descricao WHERE Data = @Data";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@descricao", progresso.descricao);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Data", progresso.data);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um hospital do banco de dados
        public void DeleteProgresso(string data)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_progresso WHERE Data = @Data ;";
            SqlCommand sqlcomm = new SqlCommand();


            SqlParameter sqlparam = new SqlParameter("Data", data);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
    }
}