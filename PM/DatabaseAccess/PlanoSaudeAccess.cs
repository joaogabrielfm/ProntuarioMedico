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
    public class PlanoSaudeAccess : DBAccess
    {
        //Constructor function
        public PlanoSaudeAccess(string connectionString) : base(connectionString) { }
        /*
        //Esta funcao insere um plano na base de dados
        public void InsertPlanoSaude(PlanoSaude plano)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_plano_saude ";
            sSQL += " (CodPlano, Data_contratacao, Nome_operadora, Valor_atualizado, Carencia, Data_reajuste, Tipo_plano, Valor_mensal, Nome ";
            sSQL += " Values ";
            sSQL += " (@CodPlano, @Data_contratacao, @Nome_operadora, @Valor_atualizado, @Carencia, @Data_reajuste, @Tipo_plano, @Valor_mensal, @Nome) ";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;
            SqlParameter sqlparam = new SqlParameter("CodPlano", plano.CodPlano);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Data_contratacao", plano.Data_contratacao);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Nome_operadora", plano.Nome_operadora);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Valor_atualizado", plano.Valor_atualizado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Carencia", plano.Carencia);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Data_reajuste", plano.Data_reajuste);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Tipo_plano", plano.Tipo_plano);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Valor_mensal", plano.Valor_mensal);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Nome", plano.Nome);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }


        //Esta funcao retorna todas as informações do plano
        public PlanoSaude GetPlanoSaude(int codPlano)
        {
            string sSQL = "";
            sSQL += " SELECT * FROM tbl_plano_saude WHERE CodPlano = @codPlano;";
            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("codPlano", codPlano);
            sqlcomm.Parameters.Add(sqlparam);

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);

            DataRow dr = dt.Rows[0];

            PlanoSaude tempPlano = new PlanoSaude();
            tempPlano.Data_contratacao = dr["Data_contratacao"].ToString();
            tempPlano.Nome_operadora = dr["Nome_operadora"].ToString();
            tempPlano.Valor_atualizado = dr["Valor_atualizado"].ToString();
            tempPlano.Carencia = dr["Carencia"].ToString();
            tempPlano.Data_reajuste = dr["Data_reajuste"].ToString();
            tempPlano.Tipo_plano = dr["Tipo_plano"].ToString();
            tempPlano.Valor_mensal = dr[" Valor_mensal"].ToString();
            tempPlano.Nome = dr["Nome"].ToString();
            tempPlano.CodPlano = codPlano;

            return tempPlano;
        }

        // Essa funcao é chamada para atualizar os dados de um plano
        public void UpdatePlano(PlanoSaude plano)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_plano_saude SET Data_contratacao = @Data_contratacao, Nome_operadora = @Nome_operadora, Valor_atualizado = @Valor_atualizado, Carencia = @Carencia, Data_reajuste = @Data_reajuste, Tipo_plano = @Tipo_plano, Valor_mensal = @Valor_mensal, Nome = @Nome WHERE CodPlano = @CodPlano";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Data_contratacao", plano.Data_contratacao);
            sqlcomm.Parameters.Add(sqlparam);

            SqlParameter sqlparam = new SqlParameter("@Nome_operadora", plano.Nome_operadora);
            sqlcomm.Parameters.Add(sqlparam);

            SqlParameter sqlparam = new SqlParameter("@Valor_atualizado", plano.Valor_atualizado);
            sqlcomm.Parameters.Add(sqlparam);

            SqlParameter sqlparam = new SqlParameter("@Carencia", plano.Carencia);
            sqlcomm.Parameters.Add(sqlparam);

            SqlParameter sqlparam = new SqlParameter("@Data_reajuste ", plano.Data_reajuste);
            sqlcomm.Parameters.Add(sqlparam);

            SqlParameter sqlparam = new SqlParameter("@Tipo_plano", plano.Tipo_plano);
            sqlcomm.Parameters.Add(sqlparam);

            SqlParameter sqlparam = new SqlParameter("@Valor_mensal", plano.Valor_mensal);
            sqlcomm.Parameters.Add(sqlparam);

            SqlParameter sqlparam = new SqlParameter("@Nome", plano.Nome);
            sqlcomm.Parameters.Add(sqlparam);

            SqlParameter sqlparam = new SqlParameter("@CodPlano ", plano.CodPlano);
            sqlcomm.Parameters.Add(sqlparam);


            ExecNonQuery(sqlcomm);
        }

        // Essa funcao deleta um plano do banco de dados
        public void DeletePlano(int codPlano)
        {
            string sSQL = "";
            sSQL += " DELETE FROM tbl_plano_saude WHERE CodPlano = @CodPlano ;";
            SqlCommand sqlcomm = new SqlCommand();


            SqlParameter sqlparam = new SqlParameter("CodPlano", codPlano);
            sqlcomm.Parameters.Add(sqlparam);

            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            DataTable dt = new DataTable();
            dt = ExecReader(sqlcomm);
        }*/
    }
}
