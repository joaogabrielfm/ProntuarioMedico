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
    public partial class RegistrarFarmaceutico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void bt_Create_Click(object sender, EventArgs e)
        {
            RegistrarFarmaceuticoController controller = new RegistrarFarmaceuticoController(ConfigurationManager.ConnectionStrings["DBInformation"].ToString());
            if (tb_Prenome.Text != null && tb_Sobrenome.Text != null && tb_Cpf.Text != null && tb_Estado.Text != null && tb_Cidade.Text != null &&
                tb_Pais.Text != null && tb_Rua.Text != null && tb_Cep.Text != null)
            {

                Farmaceutico farmaceutico = novoFarmaceutico();
                if (!controller.verificaFarmaceutico(farmaceutico))
                { //se o farmaceutico nao existir
                    if (!controller.verificaPessoa(farmaceutico)) //verifica se a pessoa farmaceutico nao tem cadastro
                    {
                        controller.adicionaPessoa(farmaceutico);
                        controller.RegistrarFarmaceutico(farmaceutico);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                    else // a pessoa farmaceutico tem cadastro, entao cadastra-la apenas como farmaceutico
                    {
                        controller.RegistrarFarmaceutico(farmaceutico);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                }
                else
                { //farmaceutico ja cadastrado
                    Lb_Alert.Text = "Farmaceutico já cadastrado";
                }
            }
        }
        public Farmaceutico novoFarmaceutico()
        {
            Farmaceutico farmaceutico = new Farmaceutico();
            farmaceutico.prenome = tb_Prenome.Text;
            farmaceutico.sobrenome = tb_Sobrenome.Text;
            farmaceutico.cpf = tb_Cpf.Text;
            farmaceutico.estado = tb_Estado.Text;
            farmaceutico.cidade = tb_Cidade.Text;
            farmaceutico.pais = tb_Pais.Text;
            farmaceutico.rua = tb_Rua.Text;
            farmaceutico.cep = tb_Cep.Text;
            return farmaceutico;
        }
    }
}