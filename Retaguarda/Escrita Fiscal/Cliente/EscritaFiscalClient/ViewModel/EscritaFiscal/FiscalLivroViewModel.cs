using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EscritaFiscalClient.ServicoEscritaFiscalReference;
using EscritaFiscalClient.Command;

namespace EscritaFiscalClient.ViewModel.EscritaFiscal
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
    public class FiscalLivroViewModel : ERPViewModelBase
    {
        public ObservableCollection<FiscalLivroDTO> ListaFiscalLivro { get; set; }
        private FiscalLivroDTO _FiscalLivroSelected;
        public FiscalTermoDTO FiscalTermoSelected { get; set; }
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public FiscalLivroViewModel()
        {
            try
            {
                ListaFiscalLivro = new ObservableCollection<FiscalLivroDTO>();
                primeiroResultado = 0;
                this.atualizarListaFiscalLivro(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FiscalLivroDTO FiscalLivroSelected
        {
            get { return _FiscalLivroSelected; }
            set
            {
                _FiscalLivroSelected = value;
                notifyPropertyChanged("FiscalLivroSelected");
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
                            this.atualizarListaFiscalLivro(1);
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
                            this.atualizarListaFiscalLivro(-1);
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

        public void salvarAtualizarFiscalLivro()
        {
            try
            {
                using (ServicoEscritaFiscalClient serv = new ServicoEscritaFiscalClient())
                {
                    FiscalLivroSelected.Empresa = Empresa;
                    serv.salvarAtualizarFiscalLivro(FiscalLivroSelected);
                    FiscalLivroSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaFiscalLivro(int pagina)
        {
            try
            {
                using (ServicoEscritaFiscalClient serv = new ServicoEscritaFiscalClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<FiscalLivroDTO> listaServ = serv.selectFiscalLivroPagina(primeiroResultado, QUANTIDADE_PAGINA, new FiscalLivroDTO());

                    ListaFiscalLivro.Clear();

                    foreach (FiscalLivroDTO objAdd in listaServ)
                    {
                        ListaFiscalLivro.Add(objAdd);
                    }
                    FiscalLivroSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirFiscalLivro()
        {
            try
            {
                using (ServicoEscritaFiscalClient serv = new ServicoEscritaFiscalClient())
                {
                    serv.deleteFiscalLivro(FiscalLivroSelected);
                    FiscalLivroSelected = null;
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
