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
    public partial class RegistrarCuidadorInformal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void bt_Create_Click(object sender, EventArgs e)
        {
            RegistrarCuidadorInformalControler controller = new RegistrarCuidadorInformalControler(ConfigurationManager.ConnectionStrings["DBInformation"].ToString());
            if (tb_Prenome.Text != null && tb_Sobrenome.Text != null && tb_Cpf.Text != null && tb_Estado.Text != null && tb_Cidade.Text != null &&
                tb_Pais.Text != null && tb_Rua.Text != null && tb_Cep.Text != null)
            {

                CuidadorInformal cuidadorInformal = novoCuidadorInformal();
                if (!controller.verificaCuidadorInformal(cuidadorInformal))
                { //se o cuidadorInformal nao existir
                    if (!controller.verificaPessoa(cuidadorInformal)) //verifica se a pessoa cuidadorInformal nao tem cadastro
                    {
                        controller.adicionaPessoa(cuidadorInformal);
                        controller.RegistrarCuidadorInformal(cuidadorInformal);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                    else // a pessoa cuidadorInformal tem cadastro, entao cadastra-la apenas como cuidadorInformal
                    {
                        controller.RegistrarCuidadorInformal(cuidadorInformal);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                }
                else
                { //cuidadorInformal ja cadastrado
                    Lb_Alert.Text = "CuidadorInformal já cadastrado";
                }
            }
        }
        public CuidadorInformal novoCuidadorInformal()
        {
            CuidadorInformal cuidadorInformal = new CuidadorInformal();
            cuidadorInformal.prenome = tb_Prenome.Text;
            cuidadorInformal.sobrenome = tb_Sobrenome.Text;
            cuidadorInformal.cpf = tb_Cpf.Text;
            cuidadorInformal.estado = tb_Estado.Text;
            cuidadorInformal.cidade = tb_Cidade.Text;
            cuidadorInformal.pais = tb_Pais.Text;
            cuidadorInformal.rua = tb_Rua.Text;
            cuidadorInformal.cep = tb_Cep.Text;
            return cuidadorInformal;
        }
    }
}