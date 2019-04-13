<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SISGMFWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Bem vindo ao SISGMF!
    </h2>
    <hr />

    <p align="center">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/SimboloRepublica.jpg"></asp:Image>
    </p>

    <hr />

    <h2>
        Laurindo, insira algum conteúdo na página principal.
    </h2>

</asp:Content>
