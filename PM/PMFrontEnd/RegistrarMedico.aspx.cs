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
    public partial class RegistrarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Create_Click(object sender, EventArgs e)
        {
            RegistrarMedicoController controller = new RegistrarMedicoController(ConfigurationManager.ConnectionStrings["DBInformation"].ToString());
            if (tb_Prenome.Text != null && tb_Sobrenome.Text != null && tb_Cpf.Text != null && tb_Estado.Text != null && tb_Cidade.Text != null &&
                tb_Pais.Text != null && tb_Rua.Text != null && tb_Cep.Text != null && tb_Crm.Text != null)
            {

                Medico medico = novoMedico();
                if (!controller.verificaMedico(medico))
                { //se o medico nao existir
                    if (!controller.verificaPessoa(medico)) //verifica se a pessoa médico nao tem cadastro
                    {
                        controller.adicionaPessoa(medico);
                        controller.RegistrarMedico(medico);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                    else // a pessoa médico tem cadastro, entao cadastra-la apenas como médico
                    {
                        controller.RegistrarMedico(medico);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                }
                else
                { //medico ja cadastrado
                    Lb_Alert.Text = "Médico já cadastrado";
                }
            }
            else
                Lb_Alert.Text = "Por favor, preencha todos os campos.";
        }

        public Medico novoMedico()
        {
            Medico medico = new Medico();
            medico.prenome = tb_Prenome.Text;
            medico.sobrenome = tb_Sobrenome.Text;
            medico.cpf = tb_Cpf.Text;
            medico.estado = tb_Estado.Text;
            medico.cidade = tb_Cidade.Text;
            medico.pais = tb_Pais.Text;
            medico.rua = tb_Rua.Text;
            medico.cep = tb_Cep.Text;
            medico.crm = tb_Crm.Text;
            return medico;
        }
    }
}