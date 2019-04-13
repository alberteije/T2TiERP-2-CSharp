<script runat="server">
private bool ValidarLogin(string UserName, string Password)
{
    try
    {
        using (SISGMFWeb.Servico.ServidorClient Servico = new SISGMFWeb.Servico.ServidorClient())
        {
            SISGMFWeb.Servico.UsuarioDTO Usuario = Servico.SelectUsuario(UserName, Password);
            if (Usuario != null)
            {
                Session["UsuarioNome"] = "Joao Paulo"; /// EXERCICIO: Pegue o nome do usuário a partir do banco de dados e ponha na sessão
                Session["UsuarioAdministrador"] = Usuario.Administrador == null ? "" : Usuario.Administrador;
                Session["IdColaborador"] = Usuario.IdColaborador.ToString();
                Session["VendaCabecalho"] = new SISGMFWeb.Servico.VendaCabecalhoDTO();

                if (Usuario.Administrador != "S")
                {
                    /// EXERCICIO: adapte essa função para o cliente. Caso o cliente tenha
                    /// algum tipo de flag, habilite ou desabilite algumas opções da loja
                }
                
                return true;
            }
        }
        return false;
    }
    catch (Exception ex)
    {
        return false;
        throw ex;
    }
}

private void OnAuthenticate(object sender, AuthenticateEventArgs e)
{
    bool Authenticated = false;
    Authenticated = ValidarLogin(LoginUser.UserName, LoginUser.Password);

    e.Authenticated = Authenticated;
}
</script>

<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SISGMFWeb.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Formulário de Login
    </h2>
    <hr />
    <p>
        Informe seu nome de usuário e senha.
    </p>
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false" OnAuthenticate="OnAuthenticate">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Informações da Conta</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="Nome do Usuário Obrigatório." ToolTip="Nome do Usuário Obrigatório." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Senha Obrigatória." ToolTip="Senha Obrigatória." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Mantenha-me logado.</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
