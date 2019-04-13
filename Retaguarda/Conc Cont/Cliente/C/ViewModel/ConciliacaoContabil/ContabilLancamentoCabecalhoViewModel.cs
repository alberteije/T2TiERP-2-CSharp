using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ConciliacaoContabilClient.ViewModel;
using ConciliacaoContabilClient.Command;
using SearchWindow;
using ConciliacaoContabilClient.Model;
using ConciliacaoContabilClient.ServicoConciliacaoContabilReference;

namespace ConciliacaoContabilClient.View.ConciliacaoContabil
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
    public class ContabilLancamentoCabecalhoViewModel : ERPViewModelBase
    {
        public ObservableCollection<ContabilLancamentoCabecalhoDTO> ListaContabilLancamentoCabecalho { get; set; }
        private ContabilLancamentoCabecalhoDTO _ContabilLancamentoCabecalhoSelected;
        public ContabilLancamentoDetalheDTO ContabilLancamentoDetalheSelected { get; set; }
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public ContabilLancamentoCabecalhoViewModel()
        {
            try
            {
                ListaContabilLancamentoCabecalho = new ObservableCollection<ContabilLancamentoCabecalhoDTO>();
                primeiroResultado = 0;
                this.atualizarListaContabilLancamentoCabecalho(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContabilLancamentoCabecalhoDTO ContabilLancamentoCabecalhoSelected
        {
            get { return _ContabilLancamentoCabecalhoSelected; }
            set
            {
                _ContabilLancamentoCabecalhoSelected = value;
                notifyPropertyChanged("ContabilLancamentoCabecalhoSelected");
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
                            this.atualizarListaContabilLancamentoCabecalho(1);
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
                            this.atualizarListaContabilLancamentoCabecalho(-1);
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

        public void atualizarListaContabilLancamentoCabecalho(int pagina)
        {
            try
            {
                using (ServicoConciliacaoContabilClient serv = new ServicoConciliacaoContabilClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<ContabilLancamentoCabecalhoDTO> listaServ = serv.selectContabilLancamentoCabecalhoPagina(primeiroResultado, QUANTIDADE_PAGINA, new ContabilLancamentoCabecalhoDTO());

                    ListaContabilLancamentoCabecalho.Clear();

                    foreach (ContabilLancamentoCabecalhoDTO objAdd in listaServ)
                    {
                        ListaContabilLancamentoCabecalho.Add(objAdd);
                    }
                    ContabilLancamentoCabecalhoSelected = null;
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
