using System;
using System.Collections.Generic;
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
    public class SimplesNacionalCabecalhoViewModel : ERPViewModelBase
    {
        public ObservableCollection<SimplesNacionalCabecalhoDTO> ListaSimplesNacionalCabecalho { get; set; }
        private SimplesNacionalCabecalhoDTO _SimplesNacionalCabecalhoSelected;
        public SimplesNacionalDetalheDTO SimplesNacionalDetalheSelected { get; set; }
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public SimplesNacionalCabecalhoViewModel()
        {
            try
            {
                ListaSimplesNacionalCabecalho = new ObservableCollection<SimplesNacionalCabecalhoDTO>();
                primeiroResultado = 0;
                this.atualizarListaSimplesNacionalCabecalho(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SimplesNacionalCabecalhoDTO SimplesNacionalCabecalhoSelected
        {
            get { return _SimplesNacionalCabecalhoSelected; }
            set
            {
                _SimplesNacionalCabecalhoSelected = value;
                notifyPropertyChanged("SimplesNacionalCabecalhoSelected");
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
                            this.atualizarListaSimplesNacionalCabecalho(1);
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
                            this.atualizarListaSimplesNacionalCabecalho(-1);
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

        public void salvarAtualizarSimplesNacionalCabecalho()
        {
            try
            {
                using (ServicoEscritaFiscalClient serv = new ServicoEscritaFiscalClient())
                {
                    serv.salvarAtualizarSimplesNacionalCabecalho(SimplesNacionalCabecalhoSelected);
                    SimplesNacionalCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaSimplesNacionalCabecalho(int pagina)
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

                    List<SimplesNacionalCabecalhoDTO> listaServ = serv.selectSimplesNacionalCabecalhoPagina(primeiroResultado, QUANTIDADE_PAGINA, new SimplesNacionalCabecalhoDTO());

                    ListaSimplesNacionalCabecalho.Clear();

                    foreach (SimplesNacionalCabecalhoDTO objAdd in listaServ)
                    {
                        ListaSimplesNacionalCabecalho.Add(objAdd);
                    }
                    SimplesNacionalCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirSimplesNacionalCabecalho()
        {
            try
            {
                using (ServicoEscritaFiscalClient serv = new ServicoEscritaFiscalClient())
                {
                    serv.deleteSimplesNacionalCabecalho(SimplesNacionalCabecalhoSelected);
                    SimplesNacionalCabecalhoSelected = null;
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
