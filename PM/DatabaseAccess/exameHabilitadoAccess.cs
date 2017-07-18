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
	class exameHabilitadoPlanoAccess : DBAccess
	{
		// Constructor function
		public exameHabilitadoPlanoAccess(string connectionString) : base(connectionString){ }
	/*	
		// Funcao para inserir um exame habilitado na base de dados
		public void InsertExameHabilitado(exame_habilitado_plano newExameHabilitadoPlano)
		{
			string sSQL = "";
			sSQL += " INSERT INTO tbl_exame_habilitado_plano ";
			sSQL += " (codPlano, exame_habilitado) ";
			sSQL += " Values ";
			sSQL += " (@codPlano, @exame_habilitado) ";
			
			SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("codPlano", newExameHabilitadoPlano.codPlano);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("exame_habilitado", newExameHabilitadoPlano.exame_habilitado);
            sqlcomm.Parameters.Add(sqlparam);
		} 

		// Funcao que lista todos os exames habilitados
		public List<ExameHabilitadoPlano> GetAllExameHabilitado()
		{
			string sql = "SELECT tbl_exame_habilitado_plano.*;";
			SqlCommand sqlcomm = new SqlCommand();
			sqlcomm.CommandText = sql;

			DataTable dt = ExecReader(sqlcomm);
			List<ExameHabilitadoPlano> examesHabilitados = new List<ExameHabilitadoPlano>();
			foreach (DataRow dr in dt.Rows)
			{
				ExameHabilitadoPlano exameHabilitadoPlano = new ExameHabilitadoPlano();
				exameHabilitadoPlano.codPlano = dr["Codigo plano"].ToString();
				exameHabilitadoPlano.exame_habilitado = dr["Exame"].ToString();
				examesHabilitados.Add(exameHabilitadoPlano);
			}
			return examesHabilitados;
		}

		// Funcao que retorna as informações de um plano
		public ExameHabilitadoPlano GetExameHabilitado(int codPlano)
		{
			string sSQL = "";
			sSQL += " SELECT tbl_exame_habilitado_plano.*, where tbl_exame_habilitado_plano.codPlano = @codPlano;";
			SqlCommand sqlcomm = new SqlCommand();

			sqlcomm.CommandText = sSQL;

			SqlParameter sqlparam = new SqlParameter("codPlano", codPlano);
			sqlcomm.Parameters.Add(sqlparam);

			DataTable dt = new DataTable();
			dt = ExecReader(sqlcomm);

			DataRow dr = dt.Rows[0];

			ExameHabilitadoPlano exameHabilitadoPlano = new ExameHabilitadoPlano();
			exameHabilitadoPlano.codPlano = dr["Codigo plano"].ToString();
			exameHabilitadoPlano.exame_habilitado = dr["Exame"].ToString();

			return exameHabilitadoPlano;
		}	*/
	}
}