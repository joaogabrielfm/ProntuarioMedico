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
    public class AgendaAccess : DBAccess
    {
        // Construtor
        public AgendaAccess(string connectionString) : base(connectionString) { }

        public void InsertAgenda(Agenda agenda)
        {
            string sSQL = "";

            sSQL += " INSERT INTO tbl_agenda(CPF, id_agenda) ";
            sSQL += " VALUES (@CPF, @id_agenda) ";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", agenda.cpf);
            sqlcomm.Parameters.Add(sqlparam);
            sqlparam = new SqlParameter("id_agenda", agenda.id_agenda);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);

        }
    }
}
