<%@ Page Title="Funcionários por Mercado" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="FuncionarioConsulta.aspx.cs" Inherits="SISGMFWeb.Account.FuncionarioConsulta" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:label ID="LabelTitulo" runat="server" text="Label" Font-Size="Large"></asp:label> 
    </h2>
    <hr />

    <p>
        <asp:Table ID="TableDados" runat="server" BorderColor="Black" BorderWidth="1px" 
            Width="100%" GridLines="Both">
        </asp:Table>
    </p>
    <p> 
        <asp:LinkButton ID="LinkButtonVoltar" runat="server" Style="float: right;" 
            onclick="LinkButtonVoltar_Click1" >Voltar</asp:LinkButton>
    </p>
</asp:Content>