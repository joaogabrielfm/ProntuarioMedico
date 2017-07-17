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
    public partial class RegistrarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void bt_Create_Click(object sender, EventArgs e)
        {
            RegistrarPacienteController controller = new RegistrarPacienteController(ConfigurationManager.ConnectionStrings["DBInformation"].ToString());
            if (tb_Prenome.Text != null && tb_Sobrenome.Text != null && tb_Cpf.Text != null && tb_Estado.Text != null && tb_Cidade.Text != null &&
                tb_Pais.Text != null && tb_Rua.Text != null && tb_Cep.Text != null )
            {

                Paciente paciente = novoPaciente();
                if (!controller.verificaPaciente(paciente))
                { //se o paciente nao existir
                    if (!controller.verificaPessoa(paciente)) //verifica se a pessoa paciente nao tem cadastro
                    {
                        controller.adicionaPessoa(paciente);
                        controller.RegistrarPaciente(paciente);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                    else // a pessoa paciente tem cadastro, entao cadastra-la apenas como paciente
                    {
                        controller.RegistrarPaciente(paciente);
                        Response.Redirect("default.aspx", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cadastro realizado com sucesso.", "alert('Cadastro realizado com sucesso.')", true);
                    }
                }
                else
                { //paciente ja cadastrado
                    Lb_Alert.Text = "Médico já cadastrado";
                }
            }
        }
        public Paciente novoPaciente()
        {
            Paciente paciente = new Paciente();
            paciente.prenome = tb_Prenome.Text;
            paciente.sobrenome = tb_Sobrenome.Text;
            paciente.cpf = tb_Cpf.Text;
            paciente.estado = tb_Estado.Text;
            paciente.cidade = tb_Cidade.Text;
            paciente.pais = tb_Pais.Text;
            paciente.rua = tb_Rua.Text;
            paciente.cep = tb_Cep.Text;
            return paciente;
        }
    }
}