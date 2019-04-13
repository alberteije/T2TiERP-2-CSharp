using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContasPagarClient.ContasPagarService;
using ContasPagarClient.Command;
using SearchWindow;
using ContasPagarClient.Model;

namespace ContasPagarClient.ViewModel.ContasPagar
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
    public class FinLancamentoPagarViewModel : ERPViewModelBase
    {
        public ObservableCollection<FinLancamentoPagarDTO> ListaFinLancamentoPagar { get; set; }
        private FinLancamentoPagarDTO _FinLancamentoPagarSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }
        public FinParcelaPagarDTO FinParcelaPagarSelected { get; set; }
        public FinLctoPagarNtFinanceiraDTO NaturezaFinanceiraSelected { get; set; }


        public FinLancamentoPagarViewModel()
        {
            try
            {
                ListaFinLancamentoPagar = new ObservableCollection<FinLancamentoPagarDTO>();
                primeiroResultado = 0;
                this.atualizarListaFinLancamentoPagar(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FinLancamentoPagarDTO FinLancamentoPagarSelected
        {
            get { return _FinLancamentoPagarSelected; }
            set
            {
                _FinLancamentoPagarSelected = value;
                notifyPropertyChanged("FinLancamentoPagarSelected");
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
                            this.atualizarListaFinLancamentoPagar(1);
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
                            this.atualizarListaFinLancamentoPagar(-1);
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

        public void salvarAtualizarFinLancamentoPagar()
        {
            try
            {
                using (ContasPagarServiceClient serv = new ContasPagarServiceClient())
                {
                    serv.salvarAtualizarFinLancamentoPagar(FinLancamentoPagarSelected);
                    FinLancamentoPagarSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaFinLancamentoPagar(int pagina)
        {
            try
            {
                using (ContasPagarServiceClient serv = new ContasPagarServiceClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<FinLancamentoPagarDTO> listaServ = serv.selectFinLancamentoPagarPagina(primeiroResultado, QUANTIDADE_PAGINA, new FinLancamentoPagarDTO());

                    ListaFinLancamentoPagar.Clear();

                    foreach (FinLancamentoPagarDTO objAdd in listaServ)
                    {
                        ListaFinLancamentoPagar.Add(objAdd);
                    }
                    FinLancamentoPagarSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirFinLancamentoPagar()
        {
            try
            {
                using (ContasPagarServiceClient serv = new ContasPagarServiceClient())
                {
                    serv.deleteFinLancamentoPagar(FinLancamentoPagarSelected);
                    FinLancamentoPagarSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarFornecedor()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ViewPessoaFornecedorDTO),
                    typeof(ServicoContasPagar));

                if (searchWindow.ShowDialog() == true)
                {
                    FinLancamentoPagarSelected.Fornecedor = (ViewPessoaFornecedorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FinLancamentoPagarSelected");
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
                    typeof(ServicoContasPagar));

                if (searchWindow.ShowDialog() == true)
                {
                    FinLancamentoPagarSelected.FinDocumentoOrigem = (FinDocumentoOrigemDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FinLancamentoPagarSelected");
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
                    typeof(ServicoContasPagar));

                if (searchWindow.ShowDialog() == true)
                {
                    FinParcelaPagarSelected.ContaCaixa = (ContaCaixaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FinParcelaPagarSelected");
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
                    typeof(ServicoContasPagar));

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
    }
}
