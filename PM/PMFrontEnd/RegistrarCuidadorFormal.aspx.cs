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
    public partial class RegistrarCuidadorFormal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void bt_Create_Click(object sender, EventArgs e)
        {
            RegistrarCuidadorFormalControler controller = new RegistrarCuidadorFormalControler(ConfigurationManager.ConnectionStrings["DBInformation"].ToString());
            if (tb_Prenome.Text != null && tb_Sobrenome.Text != null && tb_Cpf.Text != null && tb_Estado.Text != null && tb_Cidade.Text != null &&
                tb_Pais.Text != null && tb_Rua.Text != null && tb_Cep.Text != null)
            {

                CuidadorFormal cuidadorFormal = novoCuidadorFormal();
                if (!controller.verificaCuidadorFormal(cuidadorFormal))
                { //se o cuidadorFormal nao existir
                    if (!controller.verificaPessoa(cuidadorFormal)) //verifica se a pessoa cuidadorFormal nao tem cadastro
                    {
                        controller.adicionaPessoa(cuidadorFormal);
                        controller.RegistrarCuidadorFormal(cuidadorFormal);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                    else // a pessoa cuidadorFormal tem cadastro, entao cadastra-la apenas como cuidadorFormal
                    {
                        controller.RegistrarCuidadorFormal(cuidadorFormal);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                }
                else
                { //cuidadorFormal ja cadastrado
                    Lb_Alert.Text = "Médico já cadastrado";
                }
            }
        }
        public CuidadorFormal novoCuidadorFormal()
        {
            CuidadorFormal cuidadorFormal = new CuidadorFormal();
            cuidadorFormal.prenome = tb_Prenome.Text;
            cuidadorFormal.sobrenome = tb_Sobrenome.Text;
            cuidadorFormal.cpf = tb_Cpf.Text;
            cuidadorFormal.estado = tb_Estado.Text;
            cuidadorFormal.cidade = tb_Cidade.Text;
            cuidadorFormal.pais = tb_Pais.Text;
            cuidadorFormal.rua = tb_Rua.Text;
            cuidadorFormal.cep = tb_Cep.Text;
            return cuidadorFormal;
        }
    }
}