using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContabilidadeClient.ServicoContabilidadeReference;
using ContabilidadeClient.Command;
using SearchWindow;
using ContabilidadeClient.Model;

namespace ContabilidadeClient.ViewModel.Contabilidade
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
    public class ContabilLancamentoOrcadoViewModel : ERPViewModelBase
    {
        public ObservableCollection<ContabilLancamentoOrcadoDTO> ListaContabilLancamentoOrcado { get; set; }
        private ContabilLancamentoOrcadoDTO _ContabilLancamentoOrcadoSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public ContabilLancamentoOrcadoViewModel()
        {
            try
            {
                ListaContabilLancamentoOrcado = new ObservableCollection<ContabilLancamentoOrcadoDTO>();
                primeiroResultado = 0;
                this.atualizarListaContabilLancamentoOrcado(0);
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
                    typeof(ServicoContabilidade));

                if (searchWindow.ShowDialog() == true)
                {
                    ContabilLancamentoOrcadoSelected.ContabilConta = (ContabilContaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContabilLancamentoOrcadoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContabilLancamentoOrcadoDTO ContabilLancamentoOrcadoSelected
        {
            get { return _ContabilLancamentoOrcadoSelected; }
            set
            {
                _ContabilLancamentoOrcadoSelected = value;
                notifyPropertyChanged("ContabilLancamentoOrcadoSelected");
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
                            this.atualizarListaContabilLancamentoOrcado(1);
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
                            this.atualizarListaContabilLancamentoOrcado(-1);
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

        public void salvarAtualizarContabilLancamentoOrcado()
        {
            try
            {
                using (ServicoContabilidadeClient serv = new ServicoContabilidadeClient())
                {
                    ContabilLancamentoOrcadoSelected.Empresa = Empresa;
                    serv.salvarAtualizarContabilLancamentoOrcado(ContabilLancamentoOrcadoSelected);
                    ContabilLancamentoOrcadoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaContabilLancamentoOrcado(int pagina)
        {
            try
            {
                using (ServicoContabilidadeClient serv = new ServicoContabilidadeClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<ContabilLancamentoOrcadoDTO> listaServ = serv.selectContabilLancamentoOrcadoPagina(primeiroResultado, QUANTIDADE_PAGINA, new ContabilLancamentoOrcadoDTO());

                    ListaContabilLancamentoOrcado.Clear();

                    foreach (ContabilLancamentoOrcadoDTO objAdd in listaServ)
                    {
                        ListaContabilLancamentoOrcado.Add(objAdd);
                    }
                    ContabilLancamentoOrcadoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirContabilLancamentoOrcado()
        {
            try
            {
                using (ServicoContabilidadeClient serv = new ServicoContabilidadeClient())
                {
                    serv.deleteContabilLancamentoOrcado(ContabilLancamentoOrcadoSelected);
                    ContabilLancamentoOrcadoSelected = null;
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
