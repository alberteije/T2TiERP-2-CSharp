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
    public class NaturezaFinanceiraViewModel : ERPViewModelBase
    {
        public ObservableCollection<NaturezaFinanceiraDTO> ListaNaturezaFinanceira { get; set; }
        private NaturezaFinanceiraDTO _NaturezaFinanceiraSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public NaturezaFinanceiraViewModel()
        {
            try
            {
                ListaNaturezaFinanceira = new ObservableCollection<NaturezaFinanceiraDTO>();
                primeiroResultado = 0;
                this.atualizarListaNaturezaFinanceira(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NaturezaFinanceiraDTO NaturezaFinanceiraSelected
        {
            get { return _NaturezaFinanceiraSelected; }
            set
            {
                _NaturezaFinanceiraSelected = value;
                notifyPropertyChanged("NaturezaFinanceiraSelected");
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
                            this.atualizarListaNaturezaFinanceira(1);
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
                            this.atualizarListaNaturezaFinanceira(-1);
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

        public void salvarAtualizarNaturezaFinanceira()
        {
            try
            {
                using (ContasPagarServiceClient serv = new ContasPagarServiceClient())
                {
                    serv.salvarAtualizarNaturezaFinanceira(NaturezaFinanceiraSelected);
                    NaturezaFinanceiraSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaNaturezaFinanceira(int pagina)
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

                    List<NaturezaFinanceiraDTO> listaServ = serv.selectNaturezaFinanceiraPagina(primeiroResultado, QUANTIDADE_PAGINA, new NaturezaFinanceiraDTO());

                    ListaNaturezaFinanceira.Clear();

                    foreach (NaturezaFinanceiraDTO objAdd in listaServ)
                    {
                        ListaNaturezaFinanceira.Add(objAdd);
                    }
                    NaturezaFinanceiraSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirNaturezaFinanceira()
        {
            try
            {
                using (ContasPagarServiceClient serv = new ContasPagarServiceClient())
                {
                    serv.deleteNaturezaFinanceira(NaturezaFinanceiraSelected);
                    NaturezaFinanceiraSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void pesquisarContabilConta()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ContabilContaDTO),
                    typeof(ServicoContasPagar));

                if (searchWindow.ShowDialog() == true)
                {
                    NaturezaFinanceiraSelected.ContabilConta = (ContabilContaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("NaturezaFinanceiraSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarPlanoNaturezaFinanceira()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(PlanoNaturezaFinanceiraDTO),
                    typeof(ServicoContasPagar));

                if (searchWindow.ShowDialog() == true)
                {
                    NaturezaFinanceiraSelected.PlanoNaturezaFinanceira = (PlanoNaturezaFinanceiraDTO)searchWindow.itemSelecionado;
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
