using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContratosClient.ContratosReference;
using ContratosClient.Command;

namespace ContratosClient.ViewModel.Contratos
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
	/// Autor: Miguel Kojiio (t2ti.com@gmail.com)
	/// Version: 1.0
    public class TipoContratoViewModel : ERPViewModelBase
    {
        public ObservableCollection<TipoContratoDTO> ListaTipoContrato { get; set; }
        private TipoContratoDTO _TipoContratoSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public TipoContratoViewModel()
        {
            try
            {
                ListaTipoContrato = new ObservableCollection<TipoContratoDTO>();
                primeiroResultado = 0;
                this.atualizarListaTipoContrato(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoContratoDTO TipoContratoSelected
        {
            get { return _TipoContratoSelected; }
            set
            {
                _TipoContratoSelected = value;
                notifyPropertyChanged("TipoContratoSelected");
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
                            this.atualizarListaTipoContrato(1);
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
                            this.atualizarListaTipoContrato(-1);
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

        public void salvarAtualizarTipoContrato()
        {
            try
            {
                using (ServicoContratosClient serv = new ServicoContratosClient())
                {
                    TipoContratoSelected.Empresa = this.Empresa;
                    serv.salvarAtualizarTipoContrato(TipoContratoSelected);
                    TipoContratoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaTipoContrato(int pagina)
        {
            try
            {
                using (ServicoContratosClient serv = new ServicoContratosClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<TipoContratoDTO> listaServ = serv.selectTipoContratoPagina(primeiroResultado, QUANTIDADE_PAGINA, new TipoContratoDTO());

                    ListaTipoContrato.Clear();

                    foreach (TipoContratoDTO objAdd in listaServ)
                    {
                        ListaTipoContrato.Add(objAdd);
                    }
                    TipoContratoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirTipoContrato()
        {
            try
            {
                using (ServicoContratosClient serv = new ServicoContratosClient())
                {
                    serv.deleteTipoContrato(TipoContratoSelected);
                    TipoContratoSelected = null;
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
