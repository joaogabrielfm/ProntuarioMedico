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
    class AnamneseAccess : DBAccess
    {
        //Constructor function
        public AnamneseAccess(string connectionString) : base(connectionString) { }
        
        //Esta funcao insere uma anamnese na base de dados
        public void InsertAnamnese(Anamnese anamnese)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_anamnese ";
            sSQL += " (CPF, IdAnamnese) ";
            sSQL += " Values ";
            sSQL += " (@CPF, @Id_anamnese) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CPF", anamnese.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Id_anamnese", anamnese.idAnamnese);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta uma anamnese do banco de dados
        public void DeleteEspecializacaoLaboratorista(Anamnese anamnese)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_anamnese WHERE CPF = @CPF AND IdAnamnese= @Id_anamnese;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CPF", anamnese.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Id_anamnese", anamnese.idAnamnese);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
    }
}

