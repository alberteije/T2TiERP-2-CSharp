<script runat="server">
private bool ValidarLogin(string UserName, string Password)
{
    try
    {
        using (SISGMFWeb.ServicoSISGMFReference.ServicoSISGMFClient Servico = new SISGMFWeb.ServicoSISGMFReference.ServicoSISGMFClient())
        {
            SISGMFWeb.ServicoSISGMFReference.UsuarioDTO Usuario = Servico.SelectUsuario(UserName, Password);
            if (Usuario != null)
            {
                Session["ProvinciaNome"] = Usuario.Funcionario.Mercado.Comuna.Municipio.Provincia.Nome == null ? "" : Usuario.Funcionario.Mercado.Comuna.Municipio.Provincia.Nome;
                Session["MunicipioNome"] = Usuario.Funcionario.Mercado.Comuna.Municipio.Nome == null ? "" : Usuario.Funcionario.Mercado.Comuna.Municipio.Nome;
                Session["MunicipioAdministrador"] = Usuario.Funcionario.Mercado.Comuna.Municipio.Administrador == null ? "" : Usuario.Funcionario.Mercado.Comuna.Municipio.Administrador;
                Session["MercadoId"] = Usuario.Funcionario.Mercado.Id == null ? 0 : Usuario.Funcionario.Mercado.Id;
                Session["MercadoNome"] = Usuario.Funcionario.Mercado.Nome == null ? "" : Usuario.Funcionario.Mercado.Nome;
                Session["MercadoResponsavel"] = Usuario.Funcionario.Mercado.Responsavel == null ? "" : Usuario.Funcionario.Mercado.Responsavel;
                Session["UsuarioAdministrador"] = Usuario.Adm == null ? "" : Usuario.Adm;

                if (Usuario.Adm != "S")
                {
                    SISGMFWeb.ServicoSISGMFReference.FuncaoDTO Funcao = new SISGMFWeb.ServicoSISGMFReference.FuncaoDTO();
                    Funcao.IdUsuario = Usuario.Id;

                    List<SISGMFWeb.ServicoSISGMFReference.FuncaoDTO> ListaServ = Servico.SelectControleAcesso(Funcao);

                    foreach (SISGMFWeb.ServicoSISGMFReference.FuncaoDTO objAdd in ListaServ)
                    {
                        if (objAdd.Formulario == "DisplayGoverno")
                        {
                            Session["AcessoDisplayGoverno"] = objAdd.Acesso == null ? "" : objAdd.Acesso;
                        }
                        if (objAdd.Formulario == "DisplayAdministracao")
                        {
                            Session["AcessoDisplayAdministracao"] = objAdd.Acesso == null ? "" : objAdd.Acesso;
                        }
                        if (objAdd.Formulario == "DisplayMercado")
                        {
                            Session["AcessoDisplayMercado"] = objAdd.Acesso == null ? "" : objAdd.Acesso;
                        }
                    }
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
