<%@ Page Title="Display Mercado" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="MercadoConsulta.aspx.cs" Inherits="SISGMFWeb.Account.MercadoConsulta" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:label ID="LabelTitulo" runat="server" text="Label" Font-Size="Large"></asp:label> 
    </h2>
    <hr />
    <p style="text-align:right">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="20%">
                    <asp:Calendar ID="Calendario" runat="server" SelectedDate="<%# DateTime.Today %>"
                        onselectionchanged="Calendario_SelectionChanged"></asp:Calendar>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" Width="60%">
                    <asp:label ID="LabelMensagens" runat="server" text="Label" Font-Size="Large"></asp:label> 
                </asp:TableCell>
                <asp:TableCell Width="20%">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/SimboloRepublicaMenor.jpg"></asp:Image>
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