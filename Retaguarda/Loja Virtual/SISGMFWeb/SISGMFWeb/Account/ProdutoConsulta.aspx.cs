using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISGMFWeb.Servico;

namespace SISGMFWeb.Account
{
    public partial class ProdutoConsulta : System.Web.UI.Page
    {

        private string Filtro;

        protected void Page_Load(object sender, EventArgs e)
        {

            Filtro = Session["ProdutoAtual"].ToString();
            Filtro = "%" + Filtro + "%";

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

            TimerDisplay.Enabled = false;
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

            TableHeaderCell ColunaCabecalhoMarca = new TableHeaderCell();
            ColunaCabecalhoMarca.Text = "Marca";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoMarca);

            TableHeaderCell ColunaCabecalhoEstoque = new TableHeaderCell();
            ColunaCabecalhoEstoque.Text = "Estoque";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoEstoque);

            TableHeaderCell ColunaCabecalhoValor = new TableHeaderCell();
            ColunaCabecalhoValor.Text = "Valor";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoValor);

            TableHeaderCell ColunaCabecalhoAdd = new TableHeaderCell();
            ColunaCabecalhoAdd.Text = "Add";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoAdd);

            TableDados.Rows.Add(LinhaCabecalho);
        }


        private void AdicionarRodape()
        {
            TableFooterRow LinhaRodape = new TableFooterRow();
            
            LinhaRodape.Font.Bold = true;
            LinhaRodape.BackColor = System.Drawing.Color.CadetBlue;
            LinhaRodape.ForeColor = System.Drawing.Color.White;

            TableDados.Rows.Add(LinhaRodape);
        }

        protected void CarregarDados()
        {
            try
            {
                LabelMensagens.Text = "Filtro para os Produtos apresentados: " + Filtro;

                TableDados.Rows.Clear();
                AdicionarCabecalho();

                using (ServidorClient Servico = new ServidorClient())
                {
                    //Exibe os dados dos produtos
                    ProdutoDTO produto = new ProdutoDTO();
                    produto.Nome = Filtro;
                    List<ProdutoDTO> ListaProduto = Servico.SelectProduto(produto);
                    foreach (ProdutoDTO objProduto in ListaProduto)
                    {

                        TableRow Linha = new TableRow();

                        TableCell ColunaGTIN = new TableCell();
                        ColunaGTIN.Text = objProduto.Gtin;
                        Linha.Cells.Add(ColunaGTIN);

                        TableCell ColunaCodigoInterno = new TableCell();
                        ColunaCodigoInterno.HorizontalAlign = HorizontalAlign.Left;
                        ColunaCodigoInterno.Text = objProduto.CodigoInterno.ToString();
                        Linha.Cells.Add(ColunaCodigoInterno);

                        TableCell ColunaNome = new TableCell();
                        ColunaNome.HorizontalAlign = HorizontalAlign.Left;
                        ColunaNome.Text = objProduto.Nome;
                        Linha.Cells.Add(ColunaNome);

                        TableCell ColunaUnidade = new TableCell();
                        ColunaUnidade.HorizontalAlign = HorizontalAlign.Left;
                        ColunaUnidade.Text = objProduto.UnidadeProduto.Sigla;
                        Linha.Cells.Add(ColunaUnidade);

                        TableCell ColunaMarca = new TableCell();
                        ColunaMarca.HorizontalAlign = HorizontalAlign.Left;
                        ColunaMarca.Text = objProduto.ProdutoMarca.Nome;
                        Linha.Cells.Add(ColunaMarca);

                        TableCell ColunaEstoque = new TableCell();
                        ColunaEstoque.HorizontalAlign = HorizontalAlign.Right;
                        ColunaEstoque.Text = objProduto.QuantidadeEstoque.Value.ToString("#,###,##0.00");
                        Linha.Cells.Add(ColunaEstoque);

                        TableCell ColunaValor = new TableCell();
                        ColunaValor.HorizontalAlign = HorizontalAlign.Right;
                        ColunaValor.Text = objProduto.ValorVenda.Value.ToString("#,###,##0.00");
                        Linha.Cells.Add(ColunaValor);

                        /// EXERCICIO
                        ///  Caso o usuário selecione um item que já está no carrinho, incremente a quantidade
                        TableCell ColunaAdd = new TableCell();
                        ColunaAdd.HorizontalAlign = HorizontalAlign.Center;
                        string url = "Carrinho.aspx?id_produto=" + objProduto.Id.ToString();
                        ColunaAdd.Text = "<a href='" + url + "'> + </a>";
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
            Session["ProdutoAtual"] = TextBox1.Text;
            Response.Redirect("ProdutoConsulta.aspx");
        }

    }
}