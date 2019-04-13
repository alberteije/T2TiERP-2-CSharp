using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using CloseableTabItemDemo;
using ExportarParaArquivo;
using SearchWindow;
using TesourariaClient.TesourariaService;
using TesourariaClient.View.Tesouraria;

namespace TesourariaClient.ViewModel.Tesouraria
{
    public class TesourariaViewModel:ERPViewModelBase
    {
        public ObservableCollection<ViewFinResumoTesourariaDTO> listaResumo { get; set; }
        public string textoPesquisa { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public ContaCaixaDTO contaCaixaSelected { get; set; }
        public decimal? valorCheque { get; set; }
        public DateTime dataCheque { get; set; }
        public string textoDataMovimento { get; set; }
        private bool _isSelectedTabResumo;

        public TesourariaViewModel()
        {
            listaResumo = new ObservableCollection<ViewFinResumoTesourariaDTO>();
            dataInicio = DateTime.Now.AddMonths(-1);
            dataFim = DateTime.Now;
            textoDataMovimento = DateTime.Now.Month + "/" + DateTime.Now.Year;
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
            SearchWindowApp searchWindow = new SearchWindowApp(typeof(ContaCaixaDTO), typeof(TesourariaServiceClient));

            if (searchWindow.ShowDialog() == true)
            {
                contaCaixaSelected = (ContaCaixaDTO)searchWindow.itemSelecionado;
                notifyPropertyChanged("contaCaixaSelected");
            }
        }

        private void atualizarListaResumo()
        {
            try
            {
                using (TesourariaServiceClient tesourariaService = new TesourariaServiceClient())
                {
                    DateTime data = new DateTime(int.Parse( textoDataMovimento.Split('/')[1]),
                        int.Parse( textoDataMovimento.Split('/')[0]), 1);
                    List<ViewFinResumoTesourariaDTO> listaResultado = tesourariaService.selectResumoTesourariaMes(
                        new ViewFinResumoTesourariaDTO
                        {
                            DataLancamento = data
                        });
                    listaResumo.Clear();
                    foreach (ViewFinResumoTesourariaDTO resumo in listaResultado)
                        listaResumo.Add(resumo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

            foreach (TabItem tab in TesourariaPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                TesourariaPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

    }
}
