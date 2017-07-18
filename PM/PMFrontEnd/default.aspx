<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PMFrontEnd.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
       <h3>Links para adicionar no banco de dados</h3>
       <ul>
          <li><a href="registrarmedico.aspx">Medico</a></li>
          <li><a href="registrarpaciente.aspx">Paciente</a></li>
          <li><a href="registrarcuidadorformal.aspx">Cuidador Formal</a></li>
          <li><a href="registrarcuidadorinformal.aspx">Cuidador Informal</a></li>
          <li><a href="registrarlaboratorista.aspx">Laboratorista</a></li>
          <li><a href="registrarfarmaceutico.aspx">Farmaceutico</a></li>
          <li><a href="registrarfamiliar.aspx">Familiar</a></li>

       </ul>

       <h3>Links para consultar do banco de dados</h3>
       <ul>
          <li><a href="consultarmedicos.aspx">Medicos</a></li>
       </ul>
</asp:Content>
