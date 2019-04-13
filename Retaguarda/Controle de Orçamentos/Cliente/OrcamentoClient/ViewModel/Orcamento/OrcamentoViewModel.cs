using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using OrcamentoClient.View.Orcamento;
using System.Collections.ObjectModel;
using ExportarParaArquivo;
using SearchWindow;
using OrcamentoClient.OrcamentoReference;
using CloseableTabItemDemo;
using OrcamentoClient.Model;

namespace OrcamentoClient.ViewModel.Orcamento
{
    public class OrcamentoViewModel : ERPViewModelBase
    {
        public ContentPresenter contentPresenter { get; set; }
        public ObservableCollection<OrcamentoDTO> listaOrcamento { get; set; }
        public OrcamentoDTO orcamentoSelected { get; set; }

        /// EXERCICIO:
        /// Com base nas janelas Orcamento Periodo e Orcamento Empresarial
        /// Crie as janelas Orcamento Financeiro Periodo e Orcamento Financeiro de Caixa

        public OrcamentoViewModel()
        {
            contentPresenter = new ContentPresenter();
            listaOrcamento = new ObservableCollection<OrcamentoDTO>();

            carregaViewOrcamentoGrid();
        }

        public void carregaViewOrcamentoGrid()
        {
            orcamentoSelected = null;
            OrcamentoGrid orcamentoGrid = new OrcamentoGrid();
            orcamentoGrid.DataContext = this;

            contentPresenter.Content = new OrcamentoGrid();

            using (ServiceClient servico = new ServiceClient())
            {
                IList<OrcamentoDTO> listaOrcamentoAux = servico.selectOrcamento(new OrcamentoDTO());

                listaOrcamento.Clear();
                foreach (OrcamentoDTO orcamento in listaOrcamentoAux)
                {
                    listaOrcamento.Add(orcamento);
                }
            }
        }

        public void calcularTaxa()
        {
            try
            {
                foreach (OrcamentoDetalheDTO orcamentoDetalhe in orcamentoSelected.listaOrcamentoDetalhe)
                {
                    orcamentoDetalhe.valorVariacao = orcamentoDetalhe.valorRealizado - orcamentoDetalhe.valorOrcado;
                    if(orcamentoDetalhe.valorOrcado > 0 && orcamentoDetalhe.valorRealizado > 0)
                        orcamentoDetalhe.taxaVariacao = orcamentoDetalhe.valorVariacao/ orcamentoDetalhe.valorOrcado*100;
                    else
                        orcamentoDetalhe.taxaVariacao = 0;
                }
                notifyPropertyChanged("orcamentoSelected");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregaOrcado()
        {
            try
            {
                using (ServiceClient servico = new ServiceClient())
                {
                    string FORMATA_DIA = "dd/MM/yyyy";
                    string FORMATA_MES = "MM/yyyy";
                    string FORMATA_ANO = "yyyy";

                    int qtd = (int)orcamentoSelected.numeroPeriodos;
                    DateTime dataBaseInicio = (DateTime)orcamentoSelected.dataBase;
                    DateTime dataBaseFim = (DateTime)orcamentoSelected.dataBase;
                    DateTime dataComparacao = (DateTime)orcamentoSelected.dataInicial;
                    string periodoComparacao = "";
                    for (int i = 1; i < qtd; i++)
                    {
                        dataBaseInicio = dataBaseFim;

                        switch (orcamentoSelected.orcamentoPeriodo.id)
                        {
                            case 1: //diario
                                dataBaseFim = dataBaseInicio.AddDays(1);
                                dataComparacao = dataComparacao.AddDays(1);
                                periodoComparacao = dataComparacao.ToString(FORMATA_DIA);
                                break;
                            case 2: //semanal
                                dataBaseFim = dataBaseInicio.AddDays(7);
                                dataComparacao = dataComparacao.AddDays(7);
                                periodoComparacao = dataComparacao.ToString(FORMATA_DIA);
                                break;
                            case 3: //mensal
                                dataBaseFim = dataBaseInicio.AddMonths(1);
                                dataComparacao = dataComparacao.AddMonths(1);
                                periodoComparacao = dataComparacao.ToString(FORMATA_MES);
                                break;
                            case 4: //bimestral
                                dataBaseFim = dataBaseInicio.AddMonths(2);
                                dataComparacao = dataComparacao.AddMonths(2);
                                periodoComparacao = dataComparacao.ToString(FORMATA_MES);
                                break;
                            case 5: //trimestral
                                dataBaseFim = dataBaseInicio.AddMonths(3);
                                dataComparacao = dataComparacao.AddMonths(3);
                                periodoComparacao = dataComparacao.ToString(FORMATA_MES);
                                break;
                            case 6: //semestral
                                dataBaseFim = dataBaseInicio.AddMonths(6);
                                dataComparacao = dataComparacao.AddMonths(6);
                                periodoComparacao = dataComparacao.AddMonths(6).ToString(FORMATA_MES);
                                break;
                            case 7: //anual
                                dataBaseFim = dataBaseInicio.AddYears(1);
                                dataComparacao = dataComparacao.AddYears(1);
                                periodoComparacao = dataComparacao.ToString(FORMATA_ANO);
                                break;
                        }

                        

                        List<OrcamentoDetalheDTO> listaOrcamentoDetalhe = (from fd in orcamentoSelected.listaOrcamentoDetalhe
                                                                            where ((OrcamentoDetalheDTO)fd).periodo.Equals(periodoComparacao) select fd).
                                                                            ToList<OrcamentoDetalheDTO>();
                        IList<ParcelaPagarDTO> listaPagar = servico.selectLancamentosPagar(dataBaseInicio, dataBaseFim);
                        IList<ParcelaReceberDTO> listaReceber = servico.selectLancamentosReceber(dataBaseInicio, dataBaseFim);

                        foreach (OrcamentoDetalheDTO oDetalhe in listaOrcamentoDetalhe)
                        {
                            oDetalhe.valorOrcado = 0;
                            foreach (ParcelaPagarDTO parcelaPagar in listaPagar)
                            {
                                oDetalhe.valorOrcado += parcelaPagar.valor;
                            }
                            foreach (ParcelaReceberDTO parcelaReceber in listaReceber)
                            {
                                oDetalhe.valorOrcado += parcelaReceber.valor;
                            }
                        }
                    }
                }

                notifyPropertyChanged("orcamentoSelected");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void gravarOrcamento()
        {
            try
            {
                using (ServiceClient servico = new ServiceClient())
                {
                    servico.saveOrcamento(orcamentoSelected);
                }
                this.carregaViewOrcamentoGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void gerarOrcamento()
        {
            try
            {
                if (orcamentoSelected.numeroPeriodos > 0 && orcamentoSelected.orcamentoPeriodo != null)
                {

                    List<OrcamentoDetalheDTO> listaDetAux = new List<OrcamentoDetalheDTO>();

                    DateTime data = (DateTime)orcamentoSelected.dataInicial;

                    string FORMATA_DIA = "dd/MM/yyyy";
                    string FORMATA_MES = "MM/yyyy";
                    string FORMATA_ANO = "yyyy";

                    for (int i = 0; i < orcamentoSelected.numeroPeriodos; i++)
                    {
                        OrcamentoDetalheDTO oDetalhe = new OrcamentoDetalheDTO();
                        oDetalhe.taxaVariacao = 0;
                        oDetalhe.valorOrcado = 0;
                        oDetalhe.valorRealizado = 0;
                        oDetalhe.valorVariacao = 0;
                        oDetalhe.orcamento = orcamentoSelected;

                        switch (orcamentoSelected.orcamentoPeriodo.id)
                        {
                            case 1: //diario
                                oDetalhe.periodo = data.ToString(FORMATA_DIA);
                                data = data.AddDays(1);
                                break;
                            case 2: //semanal
                                oDetalhe.periodo = data.ToString(FORMATA_DIA);
                                data = data.AddDays(7);
                                break;
                            case 3: //mensal
                                oDetalhe.periodo = data.ToString(FORMATA_MES);
                                data = data.AddMonths(1);
                                break;
                            case 4: //bimestral
                                oDetalhe.periodo = data.ToString(FORMATA_MES);
                                data = data.AddMonths(2);
                                break;
                            case 5: //trimestral
                                oDetalhe.periodo = data.ToString(FORMATA_MES);
                                data = data.AddMonths(3);
                                break;
                            case 6: //semestral
                                oDetalhe.periodo = data.ToString(FORMATA_MES);
                                data = data.AddMonths(6);
                                break;
                            case 7: //anual
                                oDetalhe.periodo = data.ToString(FORMATA_ANO);
                                data = data.AddYears(1);
                                break;
                        }

                        listaDetAux.Add(oDetalhe);

                        IList<NaturezaFinanceiraDTO> listaNaturezaFinanceira = null;
                        using (ServiceClient servico = new ServiceClient())
                        {
                            listaNaturezaFinanceira = servico.selectNaturezaFinanceira(new NaturezaFinanceiraDTO());
                        }

                        orcamentoSelected.listaOrcamentoDetalhe = new List<OrcamentoDetalheDTO>();

                        foreach (OrcamentoDetalheDTO orcamentoDetalhe in listaDetAux)
                        {
                            foreach (NaturezaFinanceiraDTO naturezaFin in listaNaturezaFinanceira)
                            {
                                OrcamentoDetalheDTO oDet = new OrcamentoDetalheDTO();
                                oDet.taxaVariacao = orcamentoDetalhe.taxaVariacao;
                                oDet.valorOrcado = orcamentoDetalhe.valorOrcado;
                                oDet.valorRealizado = orcamentoDetalhe.valorRealizado;
                                oDet.valorVariacao = orcamentoDetalhe.taxaVariacao;
                                oDet.periodo = orcamentoDetalhe.periodo;
                                oDet.naturezaFinanceira = naturezaFin;
                                oDet.orcamento = orcamentoSelected;

                                orcamentoSelected.listaOrcamentoDetalhe.Add(oDet);
                            }
                        }
                    }

                    notifyPropertyChanged("orcamentoSelected");
                }
                else
                    throw new Exception("Os campos devem estar preenchidos.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregaViewOrcamentoDetalhe()
        {
            try
            {
                if (orcamentoSelected == null)
                {
                    orcamentoSelected = new OrcamentoDTO();
                    orcamentoSelected.listaOrcamentoDetalhe = new List<OrcamentoDetalheDTO>();
                }
                else
                    using (ServiceClient servico = new ServiceClient())
                    {
                        orcamentoSelected = servico.selectOrcamentoCompleto(orcamentoSelected);
                    }

                OrcamentoDetalhe oDetalhe = new OrcamentoDetalhe();
                oDetalhe.DataContext = this;

                notifyPropertyChanged("orcamentoSelected");

                contentPresenter.Content = oDetalhe;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void pesquisarPeriodo()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(OrcamentoPeriodoDTO), typeof(ServicoOrcamento));

                if (searchWindow.ShowDialog() == true)
                {
                    orcamentoSelected.orcamentoPeriodo = (OrcamentoPeriodoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("orcamentoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void exportarDataGrid(ExportarParaArquivo.Formato formato, System.Windows.Controls.DataGrid dg)
        {
            if (dg.HasItems)
            {
                Exportar exportar = new Exportar(formato);
                exportar.exportarDataGrid(dg);
            }
            else
                throw new Exception("Não há items na lista.");
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in OrcamentoPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                OrcamentoPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

    }
}
