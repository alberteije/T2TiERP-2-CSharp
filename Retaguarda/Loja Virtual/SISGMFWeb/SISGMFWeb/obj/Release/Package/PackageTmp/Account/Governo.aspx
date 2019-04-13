<%@ Page Title="Display Governo" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Governo.aspx.cs" Inherits="SISGMFWeb.Account.Governo" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Display do Governo Provincial
    </h2>
    <hr />
    <p style="text-align:right">
        <asp:Calendar ID="Calendario" runat="server" 
            onselectionchanged="Calendario_SelectionChanged"></asp:Calendar>
    </p>
    <p>
        <asp:label ID="Label1" runat="server" text="Label"></asp:label>
    </p>
    <p>
        <asp:label ID="Label2" runat="server" text="Label"></asp:label>
    </p>
</asp:Content>