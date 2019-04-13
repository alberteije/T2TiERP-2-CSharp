using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISGMFWeb.Servico;
using Uol.PagSeguro.Resources;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Exception;

namespace SISGMFWeb.Account
{
    public partial class Carrinho : System.Web.UI.Page
    {
        public VendaCabecalhoDTO VendaAtual;

        protected void Page_Load(object sender, EventArgs e)
        {

            VendaAtual = (VendaCabecalhoDTO)Session["VendaCabecalho"];
            if (VendaAtual.ListaVendaDetalhe == null)
            {
                VendaAtual.ListaVendaDetalhe = new List<VendaDetalheDTO>();
            }

            if (Request.QueryString["id_produto"] != null)
            {
                using (ServidorClient Servico = new ServidorClient())
                {

                    /// EXERCICIO: implemente a persistencia dos dados da venda
                    /// 
                    ProdutoDTO produto = new ProdutoDTO();
                    produto.Id = int.Parse(Request.QueryString["id_produto"]);
                    produto = Servico.SelectProdutoId(produto);

                    VendaAtual.ListaVendaDetalhe.Add(new VendaDetalheDTO());
                    VendaAtual.ListaVendaDetalhe[VendaAtual.ListaVendaDetalhe.Count - 1].Produto = produto;

                    if (VendaAtual.ValorTotal == null)
                    {
                        VendaAtual.ValorTotal = produto.ValorVenda;
                    }
                    else
                    {
                        VendaAtual.ValorTotal = VendaAtual.ValorTotal + produto.ValorVenda;
                    }
                }
            }

            Session["VendaCabecalho"] = VendaAtual;

            LabelMensagens.Text = "";
            AdicionarCabecalho();
            //

            if (Session["IdColaborador"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["UsuarioAdministrador"].ToString() != "S")
                {
                    Response.Redirect("SemAcesso.aspx");
                }

                LabelTitulo.Text = "Cliente Logado: " + Session["UsuarioNome"].ToString();
            }
              
            //
            LabelTitulo.Text = "Cliente Logado: " + Session["UsuarioNome"].ToString();

            CarregarDados();

        }

        private void AdicionarCabecalho()
        {
            TableHeaderRow LinhaCabecalho = new TableHeaderRow();

            LinhaCabecalho.BackColor = System.Drawing.Color.CadetBlue;
            LinhaCabecalho.ForeColor = System.Drawing.Color.White;

            TableHeaderCell ColunaCabecalhoGTIN = new TableHeaderCell();
            ColunaCabecalhoGTIN.Text = "GTIN";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoGTIN);

            TableHeaderCell ColunaCabecalhoCodigoInterno = new TableHeaderCell();
            ColunaCabecalhoCodigoInterno.Text = "Código Interno";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoCodigoInterno);

            TableHeaderCell ColunaCabecalhoNome = new TableHeaderCell();
            ColunaCabecalhoNome.Text = "Nome";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoNome);

            TableHeaderCell ColunaCabecalhoUnidade = new TableHeaderCell();
            ColunaCabecalhoUnidade.Text = "Unidade";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoUnidade);

            TableHeaderCell ColunaCabecalhoQuantidade = new TableHeaderCell();
            ColunaCabecalhoQuantidade.Text = "Quantidade";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoQuantidade);

            TableHeaderCell ColunaCabecalhoValor = new TableHeaderCell();
            ColunaCabecalhoValor.Text = "Valor";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoValor);

            TableHeaderCell ColunaCabecalhoTotal = new TableHeaderCell();
            ColunaCabecalhoTotal.Text = "Total";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoTotal);

            TableHeaderCell ColunaCabecalhoAdd = new TableHeaderCell();
            ColunaCabecalhoAdd.Text = "Excluir";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoAdd);

            TableDados.Rows.Add(LinhaCabecalho);
        }


        private void AdicionarRodape()
        {
            TableFooterRow LinhaRodape = new TableFooterRow();

            LinhaRodape.Font.Bold = true;
            LinhaRodape.BackColor = System.Drawing.Color.CadetBlue;
            LinhaRodape.ForeColor = System.Drawing.Color.White;

            TableCell ColunaRodapeTotais = new TableCell();
            ColunaRodapeTotais.HorizontalAlign = HorizontalAlign.Center;
            ColunaRodapeTotais.Text = "Totais";
            LinhaRodape.Cells.Add(ColunaRodapeTotais);

            TableCell ColunaRodape2 = new TableCell();
            ColunaRodape2.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodape2.Text = "&nbsp;";
            LinhaRodape.Cells.Add(ColunaRodape2);

            TableCell ColunaRodape3 = new TableCell();
            ColunaRodape3.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodape3.Text = "&nbsp;";
            LinhaRodape.Cells.Add(ColunaRodape3);

            TableCell ColunaRodape4 = new TableCell();
            ColunaRodape4.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodape4.Text = "&nbsp;";
            LinhaRodape.Cells.Add(ColunaRodape4);

            TableCell ColunaRodape5 = new TableCell();
            ColunaRodape5.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodape5.Text = "&nbsp;";
            LinhaRodape.Cells.Add(ColunaRodape5);

            TableCell ColunaRodape6 = new TableCell();
            ColunaRodape6.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodape6.Text = "&nbsp;";
            LinhaRodape.Cells.Add(ColunaRodape6);

            TableCell ColunaRodapeTotal = new TableCell();
            ColunaRodapeTotal.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodapeTotal.Text = VendaAtual.ValorTotal.Value.ToString("#,###,##0.00");
            LinhaRodape.Cells.Add(ColunaRodapeTotal);

            TableCell ColunaRodapeExcluir = new TableCell();
            ColunaRodapeExcluir.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodapeExcluir.Text = "&nbsp;";
            LinhaRodape.Cells.Add(ColunaRodapeExcluir);

            TableDados.Rows.Add(LinhaRodape);
        }

        protected void CarregarDados()
        {
            try
            {
                LabelMensagens.Text = "Consulte os produtos inseridos no carrinho.";

                TableDados.Rows.Clear();
                AdicionarCabecalho();

                using (ServidorClient Servico = new ServidorClient())
                {
                    //Exibe os dados dos produtos que estão no carrinho
                    List<VendaDetalheDTO> ListaVenda = VendaAtual.ListaVendaDetalhe;
                    foreach (VendaDetalheDTO objVenda in ListaVenda)
                    {

                        TableRow Linha = new TableRow();

                        TableCell ColunaGTIN = new TableCell();
                        ColunaGTIN.Text = objVenda.Produto.Gtin;
                        Linha.Cells.Add(ColunaGTIN);

                        TableCell ColunaCodigoInterno = new TableCell();
                        ColunaCodigoInterno.HorizontalAlign = HorizontalAlign.Left;
                        ColunaCodigoInterno.Text = objVenda.Produto.CodigoInterno.ToString();
                        Linha.Cells.Add(ColunaCodigoInterno);

                        TableCell ColunaNome = new TableCell();
                        ColunaNome.HorizontalAlign = HorizontalAlign.Left;
                        ColunaNome.Text = objVenda.Produto.Nome;
                        Linha.Cells.Add(ColunaNome);

                        TableCell ColunaUnidade = new TableCell();
                        ColunaUnidade.HorizontalAlign = HorizontalAlign.Left;
                        ColunaUnidade.Text = objVenda.Produto.UnidadeProduto.Sigla;
                        Linha.Cells.Add(ColunaUnidade);

                        TableCell ColunaQuantidade = new TableCell();
                        ColunaQuantidade.HorizontalAlign = HorizontalAlign.Left;
                        ColunaQuantidade.Text = "1";
                        Linha.Cells.Add(ColunaQuantidade);

                        TableCell ColunaValor = new TableCell();
                        ColunaValor.HorizontalAlign = HorizontalAlign.Right;
                        ColunaValor.Text = objVenda.Produto.ValorVenda.Value.ToString("#,###,##0.00");
                        Linha.Cells.Add(ColunaValor);

                        /// EXERCICIO: calcule o total de acordo com a quantidade
                        TableCell ColunaTotal = new TableCell();
                        ColunaTotal.HorizontalAlign = HorizontalAlign.Right;
                        ColunaTotal.Text = objVenda.Produto.ValorVenda.Value.ToString("#,###,##0.00");
                        Linha.Cells.Add(ColunaTotal);

                        /// EXERCICIO: implemente a remoção do item
                        TableCell ColunaAdd = new TableCell();
                        ColunaAdd.HorizontalAlign = HorizontalAlign.Center;
                        string url = "Remover.aspx?id_produto=" + objVenda.Produto.Id.ToString();
                        ColunaAdd.Text = "<a href='" + url + "'> - </a>";
                        Linha.Cells.Add(ColunaAdd);

                        TableDados.Rows.Add(Linha);

                    } 

                }

                AdicionarRodape();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void LinkButtonHistorico_Click1(object sender, EventArgs e)
        {
            /// EXERCICIO:
            /// Conclua a integração com o PagSeguro

            /// EXERCICIO:
            /// Implemente a integração com o Paypal

            //Use global configuration
            PagSeguroConfiguration.UrlXmlConfiguration = "PagSeguroConfig.xml";

            bool isSandbox = false;
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // Instantiate a new payment request
            PaymentRequest payment = new PaymentRequest();

            // Sets the currency
            payment.Currency = Currency.Brl;

            List<VendaDetalheDTO> ListaVenda = VendaAtual.ListaVendaDetalhe;
            foreach (VendaDetalheDTO objVenda in ListaVenda)
            {
                payment.Items.Add(new Item(objVenda.Produto.CodigoInterno.ToString(), objVenda.Produto.Nome, 1, objVenda.Produto.ValorVenda.Value));
            }

            // Sets a reference code for this payment request, it is useful to identify this payment in future notifications.
            payment.Reference = "REF1234";

            // Sets shipping information for this payment request
            payment.Shipping = new Shipping();
            payment.Shipping.ShippingType = ShippingType.Sedex;

            //Passando valor para ShippingCost
            payment.Shipping.Cost = 10.00m;

            payment.Shipping.Address = new Address(
                "BRA",
                "SP",
                "Sao Paulo",
                "Jardim Paulistano",
                "01452002",
                "Av. Brig. Faria Lima",
                "1384",
                "5o andar"
            );

            // Sets your customer information.
            payment.Sender = new Sender(
                "Joao Comprador",
                "comprador@uol.com.br",
                new Phone("11", "56273440")
            );

            SenderDocument document = new SenderDocument(Documents.GetDocumentByType("CPF"), "12345678909");
            payment.Sender.Documents.Add(document);

            // Sets the url used by PagSeguro for redirect user after ends checkout process
            payment.RedirectUri = new Uri("http://www.t2ti.com");

            // Add installment without addition per payment method
            payment.AddPaymentMethodConfig(PaymentMethodConfigKeys.MaxInstallmentsNoInterest, 6, PaymentMethodGroup.CreditCard);

            // Add and remove groups and payment methods
            List<string> accept = new List<string>();
            accept.Add(ListPaymentMethodNames.DebitoItau);
            accept.Add(ListPaymentMethodNames.DebitoHSBC);
            payment.AcceptPaymentMethodConfig(ListPaymentMethodGroups.CreditCard, accept);

            List<string> exclude = new List<string>();
            exclude.Add(ListPaymentMethodNames.Boleto);
            payment.ExcludePaymentMethodConfig(ListPaymentMethodGroups.Boleto, exclude);

            try
            {
                /// Create new account credentials
                /// This configuration let you set your credentials from your ".cs" file.
                AccountCredentials credentials = new AccountCredentials("t2ti.com@gmail.com", "zxcvzxcv5CC65465487922CA498797F");

                /// @todo with you want to get credentials from xml config file uncommend the line below and comment the line above.
                //AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                Uri paymentRedirectUri = payment.Register(credentials);

                Response.Redirect(paymentRedirectUri.ToString());

                //Console.WriteLine("URL do pagamento : " + paymentRedirectUri);
                //Console.ReadKey();
            }
            catch (PagSeguroServiceException exception)
            {
                Console.WriteLine(exception.Message + "\n");

                foreach (ServiceError element in exception.Errors)
                {
                    Console.WriteLine(element + "\n");
                }
                Console.ReadKey();
            }
        }

    }
}