using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMFrontEnd
{
    public partial class RegistrarMedicamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Create_Click(object sender, EventArgs e)
        {
            RegistrarMedicamentoController controller = new RegistrarMedicamentoController(ConfigurationManager.ConnectionStrings["DBInformation"].ToString());
            if (tb_Nome.Text != null && tb_Numero_Registro.Text != null && tb_Posologia.Text != null && tb_Principio_Ativo.Text != null)
            {
                Medicamento medicamento = novoMedicamento();
                //if (!controller.verificaMedicamento(medicamento))
                //{
                    controller.adicionaMedicamento(medicamento);
                    Response.Redirect("default.aspx", false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                //}
                //else {
                //    Lb_Alert.Text = "Medicamento já cadastrado";
                //}
            }
            else
                Lb_Alert.Text = "Por favor, preencha todos os campos.";
        }

        public Medicamento novoMedicamento()
        {
            Medicamento medicamento = new Medicamento();
            medicamento.nome = tb_Nome.Text;
            medicamento.nro_registro = tb_Numero_Registro.Text;
            medicamento.posologia = tb_Posologia.Text;
            medicamento.principio_ativo = tb_Principio_Ativo.Text;
           
            return medicamento;
        }
    }
}