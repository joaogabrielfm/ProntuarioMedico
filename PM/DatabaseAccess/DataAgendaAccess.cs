using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess
{
    public class DataAgendaAccess : DBAccess
    {
        // Construtor
        public DataAgendaAccess(string connectionString) : base(connectionString) { }

        public void InsertDataAgenda(DataAgenda dataAgenda)
        {
            string sSQL = "";

            sSQL += "INSERT INTO tbl_data_agenda(data,id_agenda, CPF) VALUES ";
            sSQL += " (@data, @id_agenda, @cpf) ";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("data", dataAgenda.data);
            sqlcomm.Parameters.Add(sqlparam);
            sqlparam = new SqlParameter("id_agenda", dataAgenda.id_agenda);
            sqlcomm.Parameters.Add(sqlparam);
            sqlparam = new SqlParameter("cpf", dataAgenda.cpf);
        
            // Execute the query.
            ExecNonQuery(sqlcomm);
        }
    }
}
