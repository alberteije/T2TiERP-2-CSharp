using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISGMFWeb.ServicoSISGMFReference;

namespace SISGMFWeb.Account
{
    public partial class Governo : System.Web.UI.Page
    {
        private long RodapeTotalVendedores;
        private long RodapeTotalPresencas;
        private long RodapeTotalAusencias;
        private decimal RodapeTotalTaxas;
        private decimal RodapeTotalPagamentos;
        private decimal RodapeTotalDevido;
        //
        private long MunicipioTotalVendedores;
        private long MunicipioTotalPresencas;
        private long MunicipioTotalAusencias;
        private decimal MunicipioTotalTaxas;
        private decimal MunicipioTotalPagamentos;
        private decimal MunicipioTotalDevido;

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelMensagens.Text = "";
            AdicionarCabecalho();
            //
            RodapeTotalVendedores = 0;
            RodapeTotalPresencas = 0;
            RodapeTotalAusencias = 0;
            RodapeTotalTaxas = 0;
            RodapeTotalPagamentos = 0;
            RodapeTotalDevido = 0;
            //
            MunicipioTotalVendedores = 0;
            MunicipioTotalPresencas = 0;
            MunicipioTotalAusencias = 0;
            MunicipioTotalTaxas = 0;
            MunicipioTotalPagamentos = 0;
            MunicipioTotalDevido = 0;
            //
            if (Session["ProvinciaNome"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["UsuarioAdministrador"].ToString() != "S")
                {
                    if (Session["AcessoDisplayGoverno"].ToString() != "S")
                    {
                        Response.Redirect("SemAcesso.aspx");
                    }
                }

                LabelTitulo.Text = "Display do Governo Provincial: " + Session["ProvinciaNome"].ToString();
            }
            //
            CarregarDados();
            TimerDisplay.Enabled = true;
        }

        private void AdicionarCabecalho()
        {
            TableHeaderRow LinhaCabecalho = new TableHeaderRow();

            LinhaCabecalho.BackColor = System.Drawing.Color.CadetBlue;
            LinhaCabecalho.ForeColor = System.Drawing.Color.White;

            TableHeaderCell ColunaCabecalhoMercado = new TableHeaderCell();
            ColunaCabecalhoMercado.Text = "Municípios";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoMercado);

            TableHeaderCell ColunaCabecalhoTotalVendedores = new TableHeaderCell();
            ColunaCabecalhoTotalVendedores.Text = "Total Vendedores";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoTotalVendedores);

            TableHeaderCell ColunaCabecalhoPresencas = new TableHeaderCell();
            ColunaCabecalhoPresencas.Text = "Presenças";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoPresencas);

            TableHeaderCell ColunaCabecalhoAusencias = new TableHeaderCell();
            ColunaCabecalhoAusencias.Text = "Ausencias";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoAusencias);

            TableHeaderCell ColunaCabecalhoTaxas = new TableHeaderCell();
            ColunaCabecalhoTaxas.Text = "Total Taxas";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoTaxas);

            TableHeaderCell ColunaCabecalhoValorPago = new TableHeaderCell();
            ColunaCabecalhoValorPago.Text = "Total Valor Pago";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoValorPago);

            TableHeaderCell ColunaCabecalhoValorDevido = new TableHeaderCell();
            ColunaCabecalhoValorDevido.Text = "Total Valor Devido";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoValorDevido);

            TableDados.Rows.Add(LinhaCabecalho);
        }


        private void AdicionarRodape()
        {
            TableFooterRow LinhaRodape = new TableFooterRow();
            
            LinhaRodape.Font.Bold = true;
            LinhaRodape.BackColor = System.Drawing.Color.CadetBlue;
            LinhaRodape.ForeColor = System.Drawing.Color.White;

            TableCell ColunaRodapeMercado = new TableCell();
            ColunaRodapeMercado.HorizontalAlign = HorizontalAlign.Center;
            ColunaRodapeMercado.Text = "Totais";
            LinhaRodape.Cells.Add(ColunaRodapeMercado);

            TableCell ColunaRodapeTotalVendedores = new TableCell();
            ColunaRodapeTotalVendedores.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodapeTotalVendedores.Text = RodapeTotalVendedores.ToString();
            LinhaRodape.Cells.Add(ColunaRodapeTotalVendedores);

            TableCell ColunaRodapePresencas = new TableCell();
            ColunaRodapePresencas.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodapePresencas.Text = RodapeTotalPresencas.ToString();
            LinhaRodape.Cells.Add(ColunaRodapePresencas);

            TableCell ColunaRodapeAusencias = new TableCell();
            ColunaRodapeAusencias.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodapeAusencias.Text = RodapeTotalAusencias.ToString();
            LinhaRodape.Cells.Add(ColunaRodapeAusencias);

            TableCell ColunaRodapeTaxas = new TableCell();
            ColunaRodapeTaxas.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodapeTaxas.Text = RodapeTotalTaxas.ToString("#,###,##0.00");
            LinhaRodape.Cells.Add(ColunaRodapeTaxas);

            TableCell ColunaRodapeValorPago = new TableCell();
            ColunaRodapeValorPago.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodapeValorPago.Text = RodapeTotalPagamentos.ToString("#,###,##0.00");
            LinhaRodape.Cells.Add(ColunaRodapeValorPago);

            TableCell ColunaRodapeValorDevido = new TableCell();
            ColunaRodapeValorDevido.HorizontalAlign = HorizontalAlign.Right;
            ColunaRodapeValorDevido.Text = RodapeTotalDevido.ToString("#,###,##0.00");
            LinhaRodape.Cells.Add(ColunaRodapeValorDevido);

            TableDados.Rows.Add(LinhaRodape);

            if (RodapeTotalPresencas > 0)
            {
                if (!RodapeTotalPresencas.ToString().Equals(TotalPresencasHidden.Value))
                {
                    TotalPresencasHidden.Value = RodapeTotalPresencas.ToString();
                    System.Media.SystemSounds.Asterisk.Play();
                }
            }

            if (RodapeTotalPagamentos > 0)
            {
                if (!RodapeTotalPagamentos.ToString().Equals(TotalPagamentosHidden.Value))
                {
                    TotalPagamentosHidden.Value = RodapeTotalPagamentos.ToString();
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }
        }

        private void AdicionarLinhaMunicipio(string pNomeMunicipio)
        {
            TableFooterRow LinhaMunicipio = new TableFooterRow();

            LinhaMunicipio.Font.Bold = true;
            LinhaMunicipio.BackColor = System.Drawing.Color.LightGray;

            TableCell ColunaMunicipioMercado = new TableCell();
            ColunaMunicipioMercado.HorizontalAlign = HorizontalAlign.Center;
            ColunaMunicipioMercado.Text = pNomeMunicipio;
            LinhaMunicipio.Cells.Add(ColunaMunicipioMercado);

            TableCell ColunaMunicipioTotalVendedores = new TableCell();
            ColunaMunicipioTotalVendedores.HorizontalAlign = HorizontalAlign.Right;
            ColunaMunicipioTotalVendedores.Text = MunicipioTotalVendedores.ToString();
            LinhaMunicipio.Cells.Add(ColunaMunicipioTotalVendedores);

            TableCell ColunaMunicipioPresencas = new TableCell();
            ColunaMunicipioPresencas.HorizontalAlign = HorizontalAlign.Right;
            ColunaMunicipioPresencas.Text = MunicipioTotalPresencas.ToString();
            LinhaMunicipio.Cells.Add(ColunaMunicipioPresencas);

            TableCell ColunaMunicipioAusencias = new TableCell();
            ColunaMunicipioAusencias.HorizontalAlign = HorizontalAlign.Right;
            ColunaMunicipioAusencias.Text = MunicipioTotalAusencias.ToString();
            LinhaMunicipio.Cells.Add(ColunaMunicipioAusencias);

            TableCell ColunaMunicipioTaxas = new TableCell();
            ColunaMunicipioTaxas.HorizontalAlign = HorizontalAlign.Right;
            ColunaMunicipioTaxas.Text = MunicipioTotalTaxas.ToString("#,###,##0.00");
            LinhaMunicipio.Cells.Add(ColunaMunicipioTaxas);

            TableCell ColunaMunicipioValorPago = new TableCell();
            ColunaMunicipioValorPago.HorizontalAlign = HorizontalAlign.Right;
            ColunaMunicipioValorPago.Text = MunicipioTotalPagamentos.ToString("#,###,##0.00");
            LinhaMunicipio.Cells.Add(ColunaMunicipioValorPago);

            TableCell ColunaMunicipioValorDevido = new TableCell();
            ColunaMunicipioValorDevido.HorizontalAlign = HorizontalAlign.Right;
            ColunaMunicipioValorDevido.Text = MunicipioTotalDevido.ToString("#,###,##0.00");
            LinhaMunicipio.Cells.Add(ColunaMunicipioValorDevido);

            TableDados.Rows.Add(LinhaMunicipio);
        
            //
            MunicipioTotalVendedores = 0;
            MunicipioTotalPresencas = 0;
            MunicipioTotalAusencias = 0;
            MunicipioTotalTaxas = 0;
            MunicipioTotalPagamentos = 0;
            MunicipioTotalDevido = 0;
        }

        protected void CarregarDados()
        {
            try
            {
                LabelMensagens.Text = "Apresentando os dados para o dia " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");

                TableDados.Rows.Clear();
                AdicionarCabecalho();

                using (ServicoSISGMFClient Servico = new ServicoSISGMFClient())
                {
                    //Para cada Município pega os dados das Views
                    List<MunicipioDTO> ListaMunicipio = Servico.SelectMunicipio(new MunicipioDTO());
                    foreach (MunicipioDTO objMunicipio in ListaMunicipio)
                    {
                        // Total de Vendedores por Município
                        ViewTotalVendedorMunicipioDTO TotalVendedorMunicipio = new ViewTotalVendedorMunicipioDTO();
                        TotalVendedorMunicipio.IdMunicipio = objMunicipio.Id;
                        List<ViewTotalVendedorMunicipioDTO> ListaServ = Servico.SelectViewTotalVendedorMunicipio(TotalVendedorMunicipio);

                        // Para cada Mercado monta uma linha na Table
                        foreach (ViewTotalVendedorMunicipioDTO objAdd in ListaServ)
                        {
                            TableRow Linha = new TableRow();

                            TableCell ColunaMercado = new TableCell();
                            ColunaMercado.Text = objAdd.Nome;
                            Linha.Cells.Add(ColunaMercado);

                            TableCell ColunaTotalVendedores = new TableCell();
                            ColunaTotalVendedores.HorizontalAlign = HorizontalAlign.Right;
                            ColunaTotalVendedores.Text = objAdd.TotalVendedor.ToString();
                            Linha.Cells.Add(ColunaTotalVendedores);
                            RodapeTotalVendedores = RodapeTotalVendedores + objAdd.TotalVendedor;
                            MunicipioTotalVendedores = MunicipioTotalVendedores + objAdd.TotalVendedor;

                            // Presenças e Ausencias
                            ViewTotalPresencaMunicipioDTO TotalPresenca = new ViewTotalPresencaMunicipioDTO();
                            TotalPresenca.IdMercado = objAdd.Id;
                            TotalPresenca.DataPresenca = DateTime.Today;
                            List<ViewTotalPresencaMunicipioDTO> ListaPresenca = Servico.SelectViewTotalPresencaMunicipio(TotalPresenca);

                            if (ListaPresenca.Count > 0)
                            {
                                TotalPresenca = ListaPresenca[0];
                            }
                            else
                            {
                                TotalPresenca.TotalPresenca = 0;
                            }

                            TableCell ColunaTotalPresencas = new TableCell();
                            ColunaTotalPresencas.HorizontalAlign = HorizontalAlign.Right;
                            ColunaTotalPresencas.Text = TotalPresenca.TotalPresenca.ToString();
                            Linha.Cells.Add(ColunaTotalPresencas);
                            RodapeTotalPresencas = RodapeTotalPresencas + TotalPresenca.TotalPresenca;
                            MunicipioTotalPresencas = MunicipioTotalPresencas + TotalPresenca.TotalPresenca;

                            TableCell ColunaTotalAusencias = new TableCell();
                            ColunaTotalAusencias.HorizontalAlign = HorizontalAlign.Right;
                            ColunaTotalAusencias.Text = (objAdd.TotalVendedor - TotalPresenca.TotalPresenca).ToString();
                            Linha.Cells.Add(ColunaTotalAusencias);
                            RodapeTotalAusencias = RodapeTotalAusencias + (objAdd.TotalVendedor - TotalPresenca.TotalPresenca);
                            MunicipioTotalAusencias = MunicipioTotalAusencias + (objAdd.TotalVendedor - TotalPresenca.TotalPresenca);


                            // Pagamentos e Inadimplências
                            ViewTotalPagamentoMunicipioDTO TotalPagamento = new ViewTotalPagamentoMunicipioDTO();
                            TotalPagamento.IdMercado = objAdd.Id;
                            TotalPagamento.DataPagamento = DateTime.Today;
                            List<ViewTotalPagamentoMunicipioDTO> ListaPagamento = Servico.SelectViewTotalPagamentoMunicipio(TotalPagamento);

                            if (ListaPagamento.Count > 0)
                            {
                                TotalPagamento = ListaPagamento[0];
                            }
                            else
                            {
                                TotalPagamento.TotalPagamento = 0;
                                TotalPagamento.TotalTaxa = 0;
                            }

                            TableCell ColunaTotalTaxas = new TableCell();
                            ColunaTotalTaxas.HorizontalAlign = HorizontalAlign.Right;
                            ColunaTotalTaxas.Text = TotalPagamento.TotalTaxa.Value.ToString("#,###,##0.00");
                            Linha.Cells.Add(ColunaTotalTaxas);
                            RodapeTotalTaxas = RodapeTotalTaxas + TotalPagamento.TotalTaxa.Value;
                            MunicipioTotalTaxas = MunicipioTotalTaxas + TotalPagamento.TotalTaxa.Value;

                            TableCell ColunaTotalPagamentos = new TableCell();
                            ColunaTotalPagamentos.HorizontalAlign = HorizontalAlign.Right;
                            ColunaTotalPagamentos.Text = TotalPagamento.TotalPagamento.Value.ToString("#,###,##0.00");
                            Linha.Cells.Add(ColunaTotalPagamentos);
                            RodapeTotalPagamentos = RodapeTotalPagamentos + TotalPagamento.TotalPagamento.Value;
                            MunicipioTotalPagamentos = MunicipioTotalPagamentos + TotalPagamento.TotalPagamento.Value;

                            TableCell ColunaTotalDevido = new TableCell();
                            ColunaTotalDevido.HorizontalAlign = HorizontalAlign.Right;
                            ColunaTotalDevido.Text = (TotalPagamento.TotalTaxa - TotalPagamento.TotalPagamento).Value.ToString("#,###,##0.00");
                            Linha.Cells.Add(ColunaTotalDevido);
                            RodapeTotalDevido = RodapeTotalDevido + (TotalPagamento.TotalTaxa.Value - TotalPagamento.TotalPagamento.Value);
                            MunicipioTotalDevido = MunicipioTotalDevido + (TotalPagamento.TotalTaxa.Value - TotalPagamento.TotalPagamento.Value);

                            TableDados.Rows.Add(Linha);

                        } //foreach (ViewTotalVendedorMunicipioDTO objAdd in ListaServ)

                        //Linha com dados do Município
                        AdicionarLinhaMunicipio(objMunicipio.Nome);

                    } //foreach (MunicipioDTO objMunicipio in ListaMunicipio)

                }

                AdicionarRodape();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
        private void TimerDisplay_Tick(object sender, EventArgs e)
        {
            CarregarDados();
        }
        */
        protected void LinkButtonHistorico_Click1(object sender, EventArgs e)
        {
            Response.Redirect("GovernoConsulta.aspx");
        }

    }
}