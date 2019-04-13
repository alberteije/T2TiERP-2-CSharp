using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConciliacaoClient.ViewModel;
using ConciliacaoClient.ConciliacaoService;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using ConciliacaoClient.OFX;
using SearchWindow;
using ExportarParaArquivo;
using System.Windows.Controls;
using CloseableTabItemDemo;
using ConciliacaoClient.View.ConciliacaoBancaria;
using ConciliacaoClient.Model;

namespace ConciliacaoClient.ViewModel.ConciliacaoBancaria
{
    public class ConciliacaoBancariaViewModel : ERPViewModelBase
    {
        public ContaCaixaDTO contaCaixaSelected { get; set; }
        public string textoDataMovimento { get; set; }
        public string mensagemErro { get; set; }
        public ObservableCollection<ExtratoContaBancoDTO> listaExtrato { get; set; }
        public decimal recebimentos { get; set; }
        public decimal pagamentos { get; set; }
        public decimal saldo { get; set; }


        public ConciliacaoBancariaViewModel()
        {
            listaExtrato = new ObservableCollection<ExtratoContaBancoDTO>();
            textoDataMovimento = DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year.ToString();
        }
        public void pesquisarContaCaixa()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ContaCaixaDTO), typeof(ServicoConciliacaoBancaria));

                if (searchWindow.ShowDialog() == true)
                {
                    contaCaixaSelected = (ContaCaixaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("contaCaixaSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void importarOFX()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".ofx";
            dlg.Filter = "Arquivo OFX (.ofx)|*.ofx";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                try
                {
                    FileStream ofxFile = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                    OFXImport ofxImport = new OFXImport();
                    OFXContaDTO ofxConta = ofxImport.import(dlg.FileName);

                    List<ExtratoContaBancoDTO> listaExtratoAux = new List<ExtratoContaBancoDTO>();
                    foreach (OFXTransacaoDTO trans in ofxConta.transacoes)
                    {
                        ExtratoContaBancoDTO extrato = new ExtratoContaBancoDTO();
                        extrato.idContaCaixa = contaCaixaSelected.id;
                        DateTime data = converterData(trans.data);
                        extrato.dataBalancete = data;
                        extrato.dataMovimento = data;
                        extrato.mes = data.Month.ToString("00");
                        extrato.ano = data.Year.ToString();
                        extrato.historico = trans.historico;
                        extrato.documento = trans.numero;
                        extrato.valor = decimal.Parse(trans.valor.Replace(".", ","));

                        listaExtratoAux.Add(extrato);
                    }

                    using (ConciliacaoServiceClient conciliacaoService = new ConciliacaoServiceClient())
                    {
                        conciliacaoService.saveUpdateListaExtrato(listaExtratoAux);
                        this.atualizarListaExtrato();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private DateTime converterData(string stringData)
        {
            DateTime resultado;
            int ano = int.Parse( stringData.Substring(0, 4));
            int mes = int.Parse(stringData.Substring(4, 2));
            int dia = int.Parse(stringData.Substring(6));
            resultado = new DateTime(ano, mes, dia);
            return resultado;
        }
        public void conciliarLançamentos()
        {
            try
            {
                using (ConciliacaoServiceClient conciliacaoService = new ConciliacaoServiceClient())
                {
                    conciliacaoService.conciliarLancamentos(montarExtrato());
                    this.atualizarListaExtrato();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarExtrato()
        {
            this.atualizarListaExtrato();
        }
        public void conciliarCheques()
        {
            try
            {
                using (ConciliacaoServiceClient conciliacaoService = new ConciliacaoServiceClient())
                {
                    conciliacaoService.conciliarCheques(montarExtrato());
                    this.atualizarListaExtrato();
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
        private ExtratoContaBancoDTO montarExtrato()
        {
            ExtratoContaBancoDTO resultado = new ExtratoContaBancoDTO();
            string mes = textoDataMovimento.Split('/')[0];
            string ano = textoDataMovimento.Split('/')[1];
            resultado.ano = ano;
            resultado.mes = mes;
            return resultado;
        }
        private void atualizarListaExtrato()
        {
            try
            {
                using (ConciliacaoServiceClient conciliacaoService = new ConciliacaoServiceClient())
                {
                    List<ExtratoContaBancoDTO> listaAux = conciliacaoService.selectExtrato(montarExtrato());

                    listaExtrato.Clear();
                    recebimentos = 0;
                    pagamentos = 0;
                    foreach (ExtratoContaBancoDTO extrato in listaAux)
                    {
                        if (extrato.valor != null && extrato.valor > 0)
                            recebimentos += (decimal)extrato.valor;
                        if (extrato.valor != null && extrato.valor < 0)
                            pagamentos += (decimal)extrato.valor;

                        listaExtrato.Add(extrato);
                    }
                    saldo = recebimentos + pagamentos;
                        
             }
                notifyPropertyChanged("recebimentos");
                notifyPropertyChanged("pagamentos");
                notifyPropertyChanged("saldo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in ConciliacaoBancariaPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                ConciliacaoBancariaPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

    }
}
