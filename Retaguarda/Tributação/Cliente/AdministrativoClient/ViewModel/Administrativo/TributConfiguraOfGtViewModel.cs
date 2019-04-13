using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AdministrativoClient.Command;
using AdministrativoClient.Model;
using AdministrativoClient.ServicoAdministrativoReference;
using SearchWindow;

namespace AdministrativoClient.ViewModel.Administrativo
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
    public class TributConfiguraOfGtViewModel : ERPViewModelBase
    {
        public ObservableCollection<TributConfiguraOfGtDTO> ListaTributConfiguraOfGt { get; set; }
        private TributConfiguraOfGtDTO _TributConfiguraOfGtSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }

        public TributIpiDipiDTO TributIpiDipiSelected { get; set; }
        public TributIcmsUfDTO TributIcmsUfSelected { get; set; }
        public TributPisCodApuracaoDTO TributPisCodApuracaoSelected { get; set; }
        public TributCofinsCodApuracaoDTO TributCofinsCodApuracaoSelected { get; set; }

        public TributConfiguraOfGtViewModel()
        {
            try
            {
                ListaTributConfiguraOfGt = new ObservableCollection<TributConfiguraOfGtDTO>();
                primeiroResultado = 0;
                this.atualizarListaTributConfiguraOfGt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarTributOperacaoFiscal()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TributOperacaoFiscalDTO),
                    typeof(ServicoAdministrativo));

                if (searchWindow.ShowDialog() == true)
                {
                    TributConfiguraOfGtSelected.TributOperacaoFiscal = (TributOperacaoFiscalDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("TributConfiguraOfGtSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarTributGrupoTributario()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TributGrupoTributarioDTO),
                    typeof(ServicoAdministrativo));

                if (searchWindow.ShowDialog() == true)
                {
                    TributConfiguraOfGtSelected.TributGrupoTributario = (TributGrupoTributarioDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("TributConfiguraOfGtSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarTipoReceitaDipi()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TipoReceitaDipiDTO),
                    typeof(ServicoAdministrativo));

                if (searchWindow.ShowDialog() == true)
                {
                    TributIpiDipiSelected.TipoReceitaDipi = (TipoReceitaDipiDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("TributIpiDipiSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TributConfiguraOfGtDTO TributConfiguraOfGtSelected
        {
            get { return _TributConfiguraOfGtSelected; }
            set
            {
                _TributConfiguraOfGtSelected = value;
                notifyPropertyChanged("TributConfiguraOfGtSelected");
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
                            this.atualizarListaTributConfiguraOfGt(1);
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
                            this.atualizarListaTributConfiguraOfGt(-1);
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

        public void salvarAtualizarTributConfiguraOfGt()
        {
            try
            {
                using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                {
                    serv.salvarAtualizarTributConfiguraOfGt(TributConfiguraOfGtSelected);
                    TributConfiguraOfGtSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaTributConfiguraOfGt(int pagina)
        {
            try
            {
                using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<TributConfiguraOfGtDTO> listaServ = serv.selectTributConfiguraOfGtPagina(primeiroResultado, QUANTIDADE_PAGINA, new TributConfiguraOfGtDTO());

                    ListaTributConfiguraOfGt.Clear();

                    foreach (TributConfiguraOfGtDTO objAdd in listaServ)
                    {
                        ListaTributConfiguraOfGt.Add(objAdd);
                    }
                    TributConfiguraOfGtSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirTributConfiguraOfGt()
        {
            try
            {
                using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                {
                    serv.deleteTributConfiguraOfGt(TributConfiguraOfGtSelected);
                    TributConfiguraOfGtSelected = null;
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
