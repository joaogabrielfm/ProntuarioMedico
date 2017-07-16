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
    public class TelefoneLaboratorioAccess : DBAccess
    {
        //Constructor function
        public TelefoneLaboratorioAccess(string connectionString) : base(connectionString) { }

        //Esta funcao insere um telefone_laboratorio na base de dados
        public void InsertTelefoneLaboratorio(Telefone telefone_laboratorio, string cnpj)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_telefone_laboratorio ";
            sSQL += " (CNPJ, tipo, numero) ";
            sSQL += " Values ";
            sSQL += " (@CNPJ, @tipo, @numero) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("tipo", telefone_laboratorio.tipo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("numero", telefone_laboratorio.numero);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        //Esta funcao retorna todos os telefones de um laboratorio
        public List<Telefone> GetAllTelefonesLaboratorio(string CNPJ)
        {
            string sql = "SELECT * FROM tbl_telefone_laboratorio WHERE tbl_telefone_laboratorio.CNPJ = @CNPJ;";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("CNPJ", CNPJ);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = ExecReader(sqlcomm);
            List<Telefone> telefones_laboratorio = new List<Telefone>();
            foreach (DataRow dr in dt.Rows)
            {
                Telefone telefone_laboratorio = new Telefone();
                telefone_laboratorio.tipo = dr["tipo"].ToString();
                telefone_laboratorio.numero = Int32.Parse(dr["numero"].ToString());
                telefones_laboratorio.Add(telefone_laboratorio);
            }
            return telefones_laboratorio;
        }

        // Essa funcao é chamada para atualizar o tipo de telefone de um laboratorio
        public void UpdateTelefoneLaboratorio(string cnpj, int numero, string tipo)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_telefone_laboratorio SET tipo = @tipo WHERE CNPJ = @CNPJ AND numero = @numero";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@tipo", tipo);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@numero", numero);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um telefone de um laboratorio do banco de dados
        public void DeleteTelefoneLaboratorio(string cnpj, int numero)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_telefone_laboratorio WHERE CNPJ = @CNPJ AND numero = @numero ;";
            SqlCommand sqlcomm = new SqlCommand();

            SqlParameter sqlparam = new SqlParameter("CNPJ", cnpj);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("numero", numero);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }
    }
}
