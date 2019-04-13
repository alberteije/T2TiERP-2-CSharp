using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using CloseableTabItemDemo;
using ExportarParaArquivo;
using FluxoCaixaClient.View.FluxoCaixa;
using SearchWindow;
using FluxoCaixaClient.FluxoCaixaReference;
using FluxoCaixaClient.Model;

namespace FluxoCaixaClient.ViewModel.FluxoCaixa
{
    public class FluxoCaixaViewModel:ERPViewModelBase
    {
        public ObservableCollection<ViewFinFluxoCaixaDTO> listaResumo { get; set; }
        public string textoPesquisa { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public ContaCaixaDTO contaCaixaSelected { get; set; }
        public decimal? ResumoAReceber { get; set; }
        public decimal? ResumoAPagar { get; set; }
        public decimal? ResumoSaldo { get; set; }
        public string textoDataMovimento { get; set; }
        private bool _isSelectedTabResumo;

        public FluxoCaixaViewModel()
        {
            listaResumo = new ObservableCollection<ViewFinFluxoCaixaDTO>();
            dataInicio = DateTime.Now.AddMonths(-1);
            dataFim = DateTime.Now;
            textoDataMovimento = DateTime.Now.Month + "/" + DateTime.Now.Year;
            ResumoAReceber = 0;
            ResumoAPagar = 0;
            ResumoSaldo = 0;
        }

        public bool isSelectedTabResumo
        {
            get { return _isSelectedTabResumo; }
            set
            {
                _isSelectedTabResumo = value;
                if (_isSelectedTabResumo)
                {
                    atualizarListaResumo();
                }
            }
        }

        public void pesquisarContaCaixa()
        {
            SearchWindowApp searchWindow = new SearchWindowApp(typeof(ContaCaixaDTO), typeof(ServicoFluxoCaixa));

            if (searchWindow.ShowDialog() == true)
            {
                contaCaixaSelected = (ContaCaixaDTO)searchWindow.itemSelecionado;
                notifyPropertyChanged("contaCaixaSelected");
            }
        }

        private void atualizarListaResumo()
        {
            if (contaCaixaSelected != null)
            {
                try
                {
                    using (ServiceClient FluxoCaixaService = new ServiceClient())
                    {
                        DateTime data = new DateTime(int.Parse(textoDataMovimento.Split('/')[1]),
                            int.Parse(textoDataMovimento.Split('/')[0]), 1);
                        List<ViewFinFluxoCaixaDTO> listaResultado = FluxoCaixaService.selectFluxoCaixaMes(new ViewFinFluxoCaixaDTO
                            {
                                DataLancamento = data,
                                IdContaCaixa = contaCaixaSelected.id.Value
                            });
                        listaResumo.Clear();
                        foreach (ViewFinFluxoCaixaDTO resumo in listaResultado)
                        {
                            listaResumo.Add(resumo);
                            if (resumo.Operacao == "E")
                                ResumoAReceber = ResumoAReceber + resumo.Valor;
                            else
                                ResumoAPagar = ResumoAPagar + resumo.Valor;
                        }
                        ResumoSaldo = ResumoAReceber - ResumoAPagar;
                    }
                    notifyPropertyChanged("ResumoAReceber");
                    notifyPropertyChanged("ResumoAPagar");
                    notifyPropertyChanged("ResumoSaldo");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void exportarDataGrid(ExportarParaArquivo.Formato formato, System.Windows.Controls.DataGrid dg)
        {
            Exportar exportar = new Exportar(formato);
            exportar.exportarDataGrid(dg);
        }

        public void pesquisarResumo()
        {
            this.atualizarListaResumo();
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in FluxoCaixaPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                FluxoCaixaPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

    }
}
/// EXERCICIO: FAÇA O COMPARATIVO ENTRE O ORÇADO E REALIZADO.
///  PARA ISSO CRIE UMA NOVA VIEW PEGUE OS DADOS DAS TABELAS DE LANCAMENTO E DO QUE FOI EFETIVAMENTE RECEBIDO
///  OU FAÇA USO DAS VIEWS EXISTENTES - ANALISE OS DADOS COM ATENCAO