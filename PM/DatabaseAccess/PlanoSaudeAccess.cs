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
        
        //Esta funcao insere um plano na base de dados
        public void InsertPlanoSaude(PlanoSaude plano)
        {
            string sSQL = "";
            sSQL += " INSERT INTO tbl_plano_saude ";
            sSQL += " (CPF, CodPlano, DataContratacao, NomeOperadora, ValorAtualizado, Carencia, DataReajuste, TipoPlano, ValorMensal, Nome ";
            sSQL += " Values ";
            sSQL += " (@CPF, @Cod_plano, @Data_contratacao, @Nome_operadora, @Valor_atualizado, @Carencia, @Data_reajuste, @Tipo_plano, @Valor_mensal, @Nome) ";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("Cod_plano", plano.cpf);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Cod_plano", plano.codPlano);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Data_contratacao", plano.dataContratacao);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Nome_operadora", plano.nomeOperadora);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Valor_atualizado", plano.valorAtualizado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Carencia", plano.carencia);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Data_reajuste", plano.dataReajuste);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Tipo_plano", plano.tipoPlano);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Valor_mensal", plano.valorMensal);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Nome", plano.nome);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        // Essa funcao é chamada para atualizar os dados de um plano
        public void UpdatePlano(PlanoSaude plano)
        {
            string sSQL = "";
            sSQL += " UPDATE tbl_plano_saude SET DataContratacao = @Data_contratacao, NomeOperadora = @Nome_operadora, ValorAtualizado = @Valor_atualizado, Carencia = @Carencia, DataReajuste = @Data_reajuste, TipoPlano = @Tipo_plano, ValorMensal = @Valor_mensal, Nome = @Nome WHERE CodPlano = @Cod_plano";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sSQL;

            SqlParameter sqlparam = new SqlParameter("@Data_contratacao", plano.dataContratacao);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Nome_operadora", plano.nomeOperadora);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Valor_atualizado", plano.valorAtualizado);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Carencia", plano.carencia);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Data_reajuste ", plano.dataReajuste);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Tipo_plano", plano.tipoPlano);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Valor_mensal", plano.valorMensal);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@Nome", plano.nome);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("@CodPlano ", plano.codPlano);
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
        }
    }
}
