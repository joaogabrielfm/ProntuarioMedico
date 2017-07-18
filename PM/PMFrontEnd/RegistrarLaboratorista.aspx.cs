using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMFrontEnd
{
    public partial class RegistrarLaboratorista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void bt_Create_Click(object sender, EventArgs e)
        {
            RegistrarLaboratoristaController controller = new RegistrarLaboratoristaController(ConfigurationManager.ConnectionStrings["DBInformation"].ToString());
            if (tb_Prenome.Text != null && tb_Sobrenome.Text != null && tb_Cpf.Text != null && tb_Estado.Text != null && tb_Cidade.Text != null &&
                tb_Pais.Text != null && tb_Rua.Text != null && tb_Cep.Text != null && TB_Cnpj != null)
            {

                Laboratorista laboratorista = novoLaboratorista();
                if (!controller.verificaLaboratorista(laboratorista))
                { //se o laboratorista nao existir
                    if (!controller.verificaPessoa(laboratorista)) //verifica se a pessoa laboratorista nao tem cadastro
                    {
                        controller.adicionaPessoa(laboratorista);
                        controller.RegistrarLaboratorista(laboratorista);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                    else // a pessoa laboratorista tem cadastro, entao cadastra-la apenas como laboratorista
                    {
                        controller.RegistrarLaboratorista(laboratorista);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                }
                else
                { //laboratorista ja cadastrado
                    Lb_Alert.Text = "Laboratorista já cadastrado";
                }
            }
        }
        public Laboratorista novoLaboratorista()
        {
            Laboratorista laboratorista = new Laboratorista();
            laboratorista.prenome = tb_Prenome.Text;
            laboratorista.sobrenome = tb_Sobrenome.Text;
            laboratorista.cpf = tb_Cpf.Text;
            laboratorista.estado = tb_Estado.Text;
            laboratorista.cidade = tb_Cidade.Text;
            laboratorista.pais = tb_Pais.Text;
            laboratorista.rua = tb_Rua.Text;
            laboratorista.cep = tb_Cep.Text;
            laboratorista.cnpj = TB_Cnpj.Text;
            return laboratorista;
        }
    }
}