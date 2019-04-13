using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContasReceberClient.ContasReceberService;
using ContasReceberClient.Command;
using SearchWindow;
using ContasReceberClient.Model;
using System.IO;

namespace ContasReceberClient.ViewModel.ContasReceber
{
	/// 
	/// The MIT License
	///
	/// Copyright: Copyright (C) 2010 T2Ti.COM
	///
	/// Permission is hereby granted, free of charge, to any person
	/// obtaining a copy of this software and associated documentation
	/// files (the "Software"), to deal in the Software without
	/// restriction, including without limitation the rights to use,
	/// copy, modify, merge, publish, distribute, sublicense, and/or sell
	/// copies of the Software, and to permit persons to whom the
	/// Software is furnished to do so, subject to the following
	/// conditions:
	///
	/// The above copyright notice and this permission notice shall be
	/// included in all copies or substantial portions of the Software.
	///
	/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
	/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
	/// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
	/// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
	/// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
	/// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
	/// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
	/// OTHER DEALINGS IN THE SOFTWARE.
	///
	///        The author may be contacted at:
	///            t2ti.com@gmail.com
	///
	/// Autor: Albert Eije (t2ti.com@gmail.com)
	/// Version: 1.0
    public class FinLancamentoReceberViewModel : ERPViewModelBase
    {
        public ObservableCollection<FinLancamentoReceberDTO> ListaFinLancamentoReceber { get; set; }
        private FinLancamentoReceberDTO _FinLancamentoReceberSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }
        public FinParcelaReceberDTO FinParcelaReceberSelected { get; set; }
        public FinLctoReceberNtFinanceiraDTO NaturezaFinanceiraSelected { get; set; }


        public FinLancamentoReceberViewModel()
        {
            try
            {
                ListaFinLancamentoReceber = new ObservableCollection<FinLancamentoReceberDTO>();
                primeiroResultado = 0;
                this.atualizarListaFinLancamentoReceber(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FinLancamentoReceberDTO FinLancamentoReceberSelected
        {
            get { return _FinLancamentoReceberSelected; }
            set
            {
                _FinLancamentoReceberSelected = value;
                notifyPropertyChanged("FinLancamentoReceberSelected");
            }
        }

        public ICommand paginaSeguinteCommand
        {
            get
            {
                if (seguinteCommand == null)
                {
                    seguinteCommand = new RelayCommand
                    (
                        param =>
                        {
                            this.atualizarListaFinLancamentoReceber(1);
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return seguinteCommand;
            }
        }

        public ICommand paginaAnteriorCommand
        {
            get
            {
                if (anteriorCommand == null)
                {
                    anteriorCommand = new RelayCommand
                    (
                        param =>
                        {
                            this.atualizarListaFinLancamentoReceber(-1);
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return anteriorCommand;
            }
        }

        public void salvarAtualizarFinLancamentoReceber()
        {
            try
            {
                using (ContasReceberServiceClient serv = new ContasReceberServiceClient())
                {
                    serv.salvarAtualizarFinLancamentoReceber(FinLancamentoReceberSelected);
                    FinLancamentoReceberSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaFinLancamentoReceber(int pagina)
        {
            try
            {
                using (ContasReceberServiceClient serv = new ContasReceberServiceClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<FinLancamentoReceberDTO> listaServ = serv.selectFinLancamentoReceberPagina(primeiroResultado, QUANTIDADE_PAGINA, new FinLancamentoReceberDTO());

                    ListaFinLancamentoReceber.Clear();

                    foreach (FinLancamentoReceberDTO objAdd in listaServ)
                    {
                        ListaFinLancamentoReceber.Add(objAdd);
                    }
                    FinLancamentoReceberSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirFinLancamentoReceber()
        {
            try
            {
                using (ContasReceberServiceClient serv = new ContasReceberServiceClient())
                {
                    serv.deleteFinLancamentoReceber(FinLancamentoReceberSelected);
                    FinLancamentoReceberSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarCliente()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ViewPessoaClienteDTO),
                    typeof(ServicoContasReceber));

                if (searchWindow.ShowDialog() == true)
                {
                    FinLancamentoReceberSelected.Cliente = (ViewPessoaClienteDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FinLancamentoReceberSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarFinDocumentoOrigem()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(FinDocumentoOrigemDTO),
                    typeof(ServicoContasReceber));

                if (searchWindow.ShowDialog() == true)
                {
                    FinLancamentoReceberSelected.FinDocumentoOrigem = (FinDocumentoOrigemDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FinLancamentoReceberSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarContaCaixa()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ContaCaixaDTO),
                    typeof(ServicoContasReceber));

                if (searchWindow.ShowDialog() == true)
                {
                    FinParcelaReceberSelected.ContaCaixa = (ContaCaixaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FinParcelaReceberSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarNaturezaFinanceira()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(NaturezaFinanceiraDTO),
                    typeof(ServicoContasReceber));

                if (searchWindow.ShowDialog() == true)
                {
                    NaturezaFinanceiraSelected.NaturezaFinanceira = (NaturezaFinanceiraDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("NaturezaFinanceiraSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsEditar
        {
            get { return _isEditar; }
            set
            {
                _isEditar = value;
                notifyPropertyChanged("IsEditar");
                notifyPropertyChanged("IsListar");
            }
        }

        public bool IsListar
        {
            get { return !_isEditar; }
            set
            {
                _isEditar = !value;
                notifyPropertyChanged("IsEditar");
                notifyPropertyChanged("IsListar");
            }
        }


        public void gerarBoleto()
        {
            try
            {
                using (ContasReceberServiceClient contasReceberService = new ContasReceberServiceClient())
                {
                    FinParcelaReceberDTO parcelaBoleto = contasReceberService.gerarBoleto(FinParcelaReceberSelected);
                    BoletoHTML bol = parcelaBoleto.boletoHTML;

                    salvaArquivoTempLocal(bol.fiBarra, bol.msBarra);
                    salvaArquivoTempLocal(bol.fiCodBarra, bol.msCodBarra);
                    salvaArquivoTempLocal(bol.fiLogo, bol.msLogo);
                    string caminhoBoleto = salvaArquivoTempLocal(bol.fiBoleto, bol.msBoleto);
                    System.Diagnostics.Process.Start(caminhoBoleto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string salvaArquivoTempLocal(FileInfo fi, MemoryStream ms)
        {
            try
            {
                string caminhoTemp = Path.GetTempPath() + fi.Name;


                if (File.Exists(caminhoTemp))
                    File.Delete(caminhoTemp);

                using (FileStream fs = new FileStream(caminhoTemp, FileMode.Create, FileAccess.ReadWrite))
                {
                    ms.WriteTo(fs);
                    fs.Close();
                }
                return caminhoTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
