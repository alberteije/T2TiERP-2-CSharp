using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using CaixaBancosClient.CaixaBancosService;
using reportman;
using SearchWindow;
using System.Windows.Controls;
using CloseableTabItemDemo;
using CaixaBancosClient.View.CaixaBancos;
using CaixaBancosClient.Model;

namespace CaixaBancosClient.ViewModel.CaixaBancos
{
    public class CaixaBancosViewModel : ERPViewModelBase
    {
        public ObservableCollection<ViewFinMovimentoCaixaBancoDTO> listaMovimento { get; set; }
        public ObservableCollection<ContaCaixaDTO> listaContaCaixa { get; set; }
        public ContaCaixaDTO contaCaixaSelected { get; set; }
        public FinFechamentoCaixaBancoDTO fechamentoCaixaBancoAtual { get; set; }
        public string textoDataMovimento { get; set; }
        public string MensagemErro;

        public CaixaBancosViewModel()
        {
            listaMovimento = new ObservableCollection<ViewFinMovimentoCaixaBancoDTO>();
            listaContaCaixa = new ObservableCollection<ContaCaixaDTO>();
            textoDataMovimento = DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.Year;

            this.atualizarListaContaCaixa();
        }

        public bool isSelectedMovimento
        {
            get { return listaMovimento.Count > 0; }
        }

        public void fecharMovimento()
        { 
            try
            {
                using (CaixaBancosServiceClient caixaBancoService = new CaixaBancosServiceClient())
                {
                    caixaBancoService.salvarAtualizarFinFechamentoCaixaBanco(fechamentoCaixaBancoAtual);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarMovimento()
        {
            try
            {
                int mes = int.Parse(textoDataMovimento.Split('/')[0]);
                int ano = int.Parse(textoDataMovimento.Split('/')[1]);
                DateTime dataPagoRecebidoAux = new DateTime(ano, mes, 1);
                using (CaixaBancosServiceClient caixaBancoService = new CaixaBancosServiceClient())
                {
                    ViewFinMovimentoCaixaBancoDTO movimentoAux = new ViewFinMovimentoCaixaBancoDTO();
                    movimentoAux.IdContaCaixa = contaCaixaSelected.Id;
                    movimentoAux.DataPagoRecebido = dataPagoRecebidoAux;
                    List<ViewFinMovimentoCaixaBancoDTO> listaCCAux = caixaBancoService.selectPeriodoMovimentoCaixaBanco(movimentoAux);

                    fechamentoCaixaBancoAtual = caixaBancoService.selectFinFechamentoCaixaBanco(
                        new FinFechamentoCaixaBancoDTO {
                            IdContaCaixa = contaCaixaSelected.Id,
                            Ano = dataPagoRecebidoAux.Year.ToString(),
                            Mes = dataPagoRecebidoAux.Month.ToString()
                        });


                    dataPagoRecebidoAux = dataPagoRecebidoAux.AddMonths(-1);
                    FinFechamentoCaixaBancoDTO fechamentoCaixaBancoAnterior = caixaBancoService.
                        selectFinFechamentoCaixaBanco(new FinFechamentoCaixaBancoDTO
                            {
                                IdContaCaixa = contaCaixaSelected.Id,
                                Ano = dataPagoRecebidoAux.Year.ToString(),
                                Mes = dataPagoRecebidoAux.Month.ToString()
                            });

                    if (fechamentoCaixaBancoAtual == null)
                        fechamentoCaixaBancoAtual = new FinFechamentoCaixaBancoDTO();

                    fechamentoCaixaBancoAtual.IdContaCaixa = contaCaixaSelected.Id;
                    fechamentoCaixaBancoAtual.DataFechamento = DateTime.Now;
                    fechamentoCaixaBancoAtual.Ano = ano.ToString();
                    fechamentoCaixaBancoAtual.Mes = mes.ToString();
                    fechamentoCaixaBancoAtual.SaldoAnterior = 0;
                    if(fechamentoCaixaBancoAnterior!=null)
                        fechamentoCaixaBancoAtual.SaldoAnterior = fechamentoCaixaBancoAnterior.SaldoDisponivel;
                    fechamentoCaixaBancoAtual.Recebimentos = 0;
                    fechamentoCaixaBancoAtual.Pagamentos = 0;
                    listaMovimento.Clear();
                    foreach (ViewFinMovimentoCaixaBancoDTO movimento in listaCCAux)
                    {
                        listaMovimento.Add(movimento);

                        if (movimento.Operacao.Equals("E"))
                            fechamentoCaixaBancoAtual.Recebimentos += movimento.Valor;
                        else
                            fechamentoCaixaBancoAtual.Pagamentos += movimento.Valor;
                    }
                    fechamentoCaixaBancoAtual.SaldoConta = fechamentoCaixaBancoAtual.Recebimentos -
                        fechamentoCaixaBancoAtual.Pagamentos;
                    fechamentoCaixaBancoAtual.SaldoDisponivel = fechamentoCaixaBancoAtual.SaldoAnterior +
                        fechamentoCaixaBancoAtual.SaldoConta;
                    
                    notifyPropertyChanged("fechamentoCaixaBancoAtual");
                    notifyPropertyChanged("isSelectedMovimento");
                }
            }
            catch (FormatException ex)
            {
                mensagemErro = "Digite uma data válida";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void atualizarListaContaCaixa()
        {
            try
            {
                using (CaixaBancosServiceClient caixaBancoService = new CaixaBancosServiceClient())
                {
                    List<ContaCaixaDTO> listaCCAux = caixaBancoService.selectContaCaixa(new ContaCaixaDTO());

                    listaContaCaixa.Clear();
                    foreach (ContaCaixaDTO contaCaixa in listaCCAux)
                        listaContaCaixa.Add(contaCaixa);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public string mensagemErro
        {
            get { return MensagemErro;}
            set 
            {
                MensagemErro = value;
                notifyPropertyChanged("mensagemErro");
            }
        }


        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in CaixaBancosPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                CaixaBancosPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

        public void pesquisarContaCaixa()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ContaCaixaDTO),
                    typeof(ServicoCaixaBancos));

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


    }
}
