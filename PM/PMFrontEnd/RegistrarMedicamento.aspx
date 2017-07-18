<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarMedicamento.aspx.cs" Inherits="PMFrontEnd.RegistrarMedicamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="form" style="text-align:center;" >

                <p class="message" style=" font-weight: 600;  font-size: 16px;    padding-top: 10px;    padding-bottom: 20px;">CADASTRO DE MEDICAMENTO</p>

                    <asp:TextBox class="col-xs-7 formulario" ID="tb_Nome" placeholder="Nome" runat="server"></asp:TextBox>

                    <asp:TextBox class="col-xs-7 formulario" ID="tb_Numero_Registro" placeholder="Numero de Registro" runat="server"></asp:TextBox>

                    <asp:TextBox class="col-xs-7 formulario" ID="tb_Posologia" placeholder="Posologia"  runat="server" MaxLength="11"></asp:TextBox>
      
                    <asp:TextBox class="col-xs-7 formulario" ID="tb_Principio_Ativo" placeholder="Principio Ativo" MaxLength="100" runat="server" ></asp:TextBox>

                    <asp:Label ID="Lb_Alert" runat="server" style="color:#FF0000" Text=""></asp:Label>

                    <asp:Button ID="bt_Create" runat="server" Text="Cadastrar" style="background:#0EBFE9" OnClick="bt_Create_Click"/>
          </div>
</asp:Content>
