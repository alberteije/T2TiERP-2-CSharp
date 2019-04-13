using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EscritaFiscalClient.Command;
using EscritaFiscalClient.ServicoEscritaFiscalReference;

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
    public class FiscalApuracaoIcmsViewModel : ERPViewModelBase
    {
        public ObservableCollection<FiscalApuracaoIcmsDTO> ListaFiscalApuracaoIcms { get; set; }
        private FiscalApuracaoIcmsDTO _FiscalApuracaoIcmselected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public FiscalApuracaoIcmsViewModel()
        {
            try
            {
                ListaFiscalApuracaoIcms = new ObservableCollection<FiscalApuracaoIcmsDTO>();
                primeiroResultado = 0;
                this.atualizarListaFiscalApuracaoIcms(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FiscalApuracaoIcmsDTO FiscalApuracaoIcmselected
        {
            get { return _FiscalApuracaoIcmselected; }
            set
            {
                _FiscalApuracaoIcmselected = value;
                notifyPropertyChanged("FiscalApuracaoIcmselected");
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
                            this.atualizarListaFiscalApuracaoIcms(1);
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
                            this.atualizarListaFiscalApuracaoIcms(-1);
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

        public void salvarAtualizarFiscalApuracaoIcms()
        {
            try
            {
                using (ServicoEscritaFiscalClient serv = new ServicoEscritaFiscalClient())
                {
                    serv.salvarAtualizarFiscalApuracaoIcms(FiscalApuracaoIcmselected);
                    FiscalApuracaoIcmselected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaFiscalApuracaoIcms(int pagina)
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

                    List<FiscalApuracaoIcmsDTO> listaServ = serv.selectFiscalApuracaoIcmsPagina(primeiroResultado, QUANTIDADE_PAGINA, new FiscalApuracaoIcmsDTO());

                    ListaFiscalApuracaoIcms.Clear();

                    foreach (FiscalApuracaoIcmsDTO objAdd in listaServ)
                    {
                        ListaFiscalApuracaoIcms.Add(objAdd);
                    }
                    FiscalApuracaoIcmselected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirFiscalApuracaoIcms()
        {
            try
            {
                using (ServicoEscritaFiscalClient serv = new ServicoEscritaFiscalClient())
                {
                    serv.deleteFiscalApuracaoIcms(FiscalApuracaoIcmselected);
                    FiscalApuracaoIcmselected = null;
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
