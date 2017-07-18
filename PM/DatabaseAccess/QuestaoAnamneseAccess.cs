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
	public class QuestaoAnamneseAccess : DBAccess 
	{
		//Construtor função
		public QuestaoAnamneseAccess(string connectionString) : base(connectionString){ }
        /*
		//Função que insere nova anamnese na base de dados
		public void InsertQuestaoAnamnese(Questao_anamnese newQuestaoAnamnese)
		{
			string sSQL = "";
			sSQL += " INSERT INTO tbl_questao_anamnese ";
			sSQL += " (Id_anamnese, CPF, pergunta, resposta) ";
			sSQL += " Values ";
			sSQL += " (@Id_anamnese, @CPF, @pergunta, @resposta) ";
			SqlCommand sqlcomm = new SqlCommand();
			sqlcomm.CommandText = sSQL;
			SqlParameter sqlparam = new SqlParameter("Id_anamnese", newQuestaoAnamnese.Id_anamnese);
			sqlcomm.SqlParameters.Add(sqlparam);

			sqlparam = new SqlParameter("CPF", newQuestaoAnamnese.cpf);
			sqlcomm.SqlParameters.Add(sqlparam);

			SqlParameter sqlparam = new SqlParameter("Pergunta", newQuestaoAnamnese.pergunta);
			sqlcomm.SqlParameters.Add(sqlparam);

			SqlParameter sqlparam = new SqlParameter("Resposta", newQuestaoAnamnese.resposta);
			sqlcomm.SqlParameters.Add(sqlparam);

			ExecNonQuery(sqlcomm);
		}

		//Funcao que retorna informações sobre uma anamnese atraves do cpf do paciente
		public Questao_anamnese GetQuestaoAnamneseCpf(string cpf){
			string sSQL = "";
			sSQL += " SELECT tbl_questao_anamnese.*, WHERE tbl_questao_anamnese.CPF = @cpf;";
			SqlCommand sqlcomm = new SqlCommand();

			sqlcomm.CommandText = sSQL;

			SqlParameter sqlparam = new SqlParameter("CPF", cpf);
			sqlcomm.Parameters.Add(sqlparam);

			DataTable dt = new DataTable();
			dt = ExecReader(sqlcomm);

			DataRow dr = dt.Rows[0];

			Questao_anamnese questao_anamnese = new Questao_anamnese();
			questao_anamnese.cpf = dr["ID anamnese"].ToString();
			questao_anamnese.pergunta = dr["Pergunta"].ToString();
			questao_anamnese.resposta = dr["Resposta"].ToString();

			return questao_anamnese;
		}*/
	}
} 

