<%@ Page Title="Display Mercado" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Mercado.aspx.cs" Inherits="SISGMFWeb.Account.Mercado" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Display do Mercado
    </h2>
    <hr />
    <p style="text-align:right">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="20%">
                    <asp:Calendar ID="Calendario" runat="server" 
                        onselectionchanged="Calendario_SelectionChanged"></asp:Calendar>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" Width="60%">
                    <asp:label ID="LabelMensagens" runat="server" text="Label"></asp:label> 
                </asp:TableCell>
                <asp:TableCell Width="20%">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/SimboloRepublica.jpg"></asp:Image>
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
</asp:Content>