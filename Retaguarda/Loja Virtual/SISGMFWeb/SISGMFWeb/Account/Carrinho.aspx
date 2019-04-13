<%@ Page Title="Carrinho" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Carrinho.aspx.cs" Inherits="SISGMFWeb.Account.Carrinho" %>

<script runat="server" type="text/c#">
</script>

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
        <asp:Table ID="TableDados" runat="server" BorderColor="Black" BorderWidth="1px" 
            Width="100%" GridLines="Both">
        </asp:Table>
    </p>
    <p> 
        <asp:LinkButton ID="LinkButtonHistorico" runat="server" Style="float: right;" 
            onclick="LinkButtonHistorico_Click1" >Pagar</asp:LinkButton>
    </p>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>

