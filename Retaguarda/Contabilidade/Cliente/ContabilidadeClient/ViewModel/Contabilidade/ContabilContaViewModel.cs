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
    public class ContabilContaViewModel : ERPViewModelBase
    {
        public ObservableCollection<ContabilContaDTO> ListaContabilConta { get; set; }
        private ContabilContaDTO _ContabilContaSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public ContabilContaViewModel()
        {
            try
            {
                ListaContabilConta = new ObservableCollection<ContabilContaDTO>();
                primeiroResultado = 0;
                this.atualizarListaContabilConta(0);
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
                    ContabilContaSelected.ContabilConta = (ContabilContaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContabilContaSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarPlanoConta()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(PlanoContaDTO),
                    typeof(ServicoContabilidade));

                if (searchWindow.ShowDialog() == true)
                {
                    ContabilContaSelected.PlanoConta = (PlanoContaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContabilContaSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarPlanoContaRefSped()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(PlanoContaRefSpedDTO),
                    typeof(ServicoContabilidade));

                if (searchWindow.ShowDialog() == true)
                {
                    ContabilContaSelected.PlanoContaRefSped = (PlanoContaRefSpedDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContabilContaSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContabilContaDTO ContabilContaSelected
        {
            get { return _ContabilContaSelected; }
            set
            {
                _ContabilContaSelected = value;
                notifyPropertyChanged("ContabilContaSelected");
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
                            this.atualizarListaContabilConta(1);
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
                            this.atualizarListaContabilConta(-1);
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

        public void salvarAtualizarContabilConta()
        {
            try
            {
                using (ServicoContabilidadeClient serv = new ServicoContabilidadeClient())
                {
                    serv.salvarAtualizarContabilConta(ContabilContaSelected);
                    ContabilContaSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaContabilConta(int pagina)
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

                    List<ContabilContaDTO> listaServ = serv.selectContabilContaPagina(primeiroResultado, QUANTIDADE_PAGINA, new ContabilContaDTO());

                    ListaContabilConta.Clear();

                    foreach (ContabilContaDTO objAdd in listaServ)
                    {
                        ListaContabilConta.Add(objAdd);
                    }
                    ContabilContaSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirContabilConta()
        {
            try
            {
                using (ServicoContabilidadeClient serv = new ServicoContabilidadeClient())
                {
                    serv.deleteContabilConta(ContabilContaSelected);
                    ContabilContaSelected = null;
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
