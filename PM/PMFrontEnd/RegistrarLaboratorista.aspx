<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarLaboratorista.aspx.cs" Inherits="PMFrontEnd.RegistrarLaboratorista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="form" style="text-align:center;" >

                <p class="message" style=" font-weight: 600;  font-size: 16px;    padding-top: 10px;    padding-bottom: 20px;">CADASTRO DE LABORATORISTA</p>

                    <asp:TextBox class="col-xs-7 formulario" placeholder="Primeiro Nome" ID="tb_Prenome" runat="server"></asp:TextBox>

                    <asp:TextBox class="col-xs-7 formulario" placeholder="Sobrenome" ID="tb_Sobrenome" runat="server"></asp:TextBox>

                    <asp:TextBox class="col-xs-7 formulario" placeholder="CPF" ID="tb_Cpf" runat="server" MaxLength="11"></asp:TextBox>
      
                    <asp:TextBox class="col-xs-7 formulario" ID="tb_Estado" placeholder="Estado" MaxLength="2" runat="server" ></asp:TextBox>

                    <asp:TextBox class="col-xs-7 formulario" ID="tb_Cidade" placeholder="Cidade" runat="server"></asp:TextBox>

                    <asp:TextBox class="col-xs-7 formulario" ID="tb_Pais" placeholder="País" runat="server" ></asp:TextBox>

                    <asp:TextBox class="col-xs-7 formulario" ID="tb_Rua" placeholder="Rua" runat="server"></asp:TextBox>

                    <asp:TextBox class="col-xs-7 formulario" ID="tb_Cep" placeholder="CEP" runat="server" MaxLength="8"></asp:TextBox>

                    <asp:TextBox class="col-xs-7 formulario" ID="TB_Cnpj" placeholder="CNPJ do laboratório" runat="server" MaxLength="18"></asp:TextBox>

                    <asp:Label ID="Lb_Alert" runat="server" style="color:#FF0000" Text=""></asp:Label>

                    <asp:Button ID="bt_Create" runat="server" Text="Cadastrar" style="background:#0EBFE9" OnClick="bt_Create_Click"/>
          </div>
</asp:Content>
