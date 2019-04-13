<%@ Page Title="Formulário de Contato" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Contato.aspx.cs" Inherits="SISGMFWeb.Account.Contato" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:label ID="LabelTitulo" runat="server" text="Label" Font-Size="Large"></asp:label> 
    </h2>
    <hr />
    <p style="text-align:right">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow Width="940">
                <asp:TableCell Width="140">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logoMenor.png"></asp:Image>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" Width="800">
                    <asp:label ID="LabelMensagens" runat="server" text="Label" Font-Size="Large"></asp:label> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>
    <hr />
    <p>
        <form name="formulario" action="http://scripts.redehost.com.br/formmail.aspx" method="post">
        <input type=hidden name="destino" value="EmailQueVaiReceberAsMensagens">
        <input type=hidden name="enviado" value="http://www.seudominio.xxx.yy/enviado.htm">
        <p><b>Nome:</b><br>
        <input type=text name="nome" size="45"></p><br>
        <p><b>Email:</b><br>
        <input type=text name="email" size="45"></p><br>
        <p><b>Assunto:</b><br>
        <input type=text name="assunto" size="45"></p><br>
        <p><b>Mensagem:</b><br>
        <textarea name="Mensagem" rows="10" cols="60" wrap="virtual"></textarea></p><br>
        <p><input type="submit" value="Enviar Email"> <input type="reset" value="Limpar Formulário"></p>
        </form>
    </p>
 </asp:Content>

