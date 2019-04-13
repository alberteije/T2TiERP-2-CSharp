using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContratosClient.ContratosReference;
using ContratosClient.Command;
using SearchWindow;
using ContratosClient.Model;

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
    public class ContratoSolicitacaoServicoViewModel : ERPViewModelBase
    {
        public ObservableCollection<ContratoSolicitacaoServicoDTO> ListaContratoSolicitacaoServico { get; set; }
        private ContratoSolicitacaoServicoDTO _ContratoSolicitacaoServicoSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public ContratoSolicitacaoServicoViewModel()
        {
            try
            {
                ListaContratoSolicitacaoServico = new ObservableCollection<ContratoSolicitacaoServicoDTO>();
                primeiroResultado = 0;
                this.atualizarListaContratoSolicitacaoServico(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContratoSolicitacaoServicoDTO ContratoSolicitacaoServicoSelected
        {
            get { return _ContratoSolicitacaoServicoSelected; }
            set
            {
                _ContratoSolicitacaoServicoSelected = value;
                notifyPropertyChanged("ContratoSolicitacaoServicoSelected");
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
                            this.atualizarListaContratoSolicitacaoServico(1);
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
                            this.atualizarListaContratoSolicitacaoServico(-1);
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

        public void salvarAtualizarContratoSolicitacaoServico()
        {
            try
            {
                using (ServicoContratosClient serv = new ServicoContratosClient())
                {
                    serv.salvarAtualizarContratoSolicitacaoServico(ContratoSolicitacaoServicoSelected);
                    ContratoSolicitacaoServicoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaContratoSolicitacaoServico(int pagina)
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

                    List<ContratoSolicitacaoServicoDTO> listaServ = serv.selectContratoSolicitacaoServicoPagina(primeiroResultado, QUANTIDADE_PAGINA, new ContratoSolicitacaoServicoDTO());

                    ListaContratoSolicitacaoServico.Clear();

                    foreach (ContratoSolicitacaoServicoDTO objAdd in listaServ)
                    {
                        ListaContratoSolicitacaoServico.Add(objAdd);
                    }
                    ContratoSolicitacaoServicoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirContratoSolicitacaoServico()
        {
            try
            {
                using (ServicoContratosClient serv = new ServicoContratosClient())
                {
                    serv.deleteContratoSolicitacaoServico(ContratoSolicitacaoServicoSelected);
                    ContratoSolicitacaoServicoSelected = null;
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

        public void pesquisarSetor()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(SetorDTO),
                    typeof(ServicoContratos));

                if (searchWindow.ShowDialog() == true)
                {
                    ContratoSolicitacaoServicoSelected.Setor = (SetorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContratoSolicitacaoServicoSelected");
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
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(FornecedorDTO),
                    typeof(ServicoContratos));

                if (searchWindow.ShowDialog() == true)
                {
                    ContratoSolicitacaoServicoSelected.Fornecedor = (FornecedorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContratoSolicitacaoServicoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarCliente()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ClienteDTO),
                    typeof(ServicoContratos));

                if (searchWindow.ShowDialog() == true)
                {
                    ContratoSolicitacaoServicoSelected.Cliente = (ClienteDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContratoSolicitacaoServicoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarColaborador()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ColaboradorDTO),
                    typeof(ServicoContratos));

                if (searchWindow.ShowDialog() == true)
                {
                    ContratoSolicitacaoServicoSelected.Colaborador = (ColaboradorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContratoSolicitacaoServicoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarContratoTipoServico()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ContratoTipoServicoDTO),
                    typeof(ServicoContratos));

                if (searchWindow.ShowDialog() == true)
                {
                    ContratoSolicitacaoServicoSelected.ContratoTipoServico = (ContratoTipoServicoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContratoSolicitacaoServicoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
