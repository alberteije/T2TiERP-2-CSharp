using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VendasClient.VendasReference;
using VendasClient.Command;
using SearchWindow;
using VendasClient.Model;

namespace VendasClient.ViewModel.Vendas
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
    public class OrcamentoPedidoVendaCabViewModel : ERPViewModelBase
    {
        public ObservableCollection<OrcamentoPedidoVendaCabDTO> ListaOrcamentoPedidoVendaCab { get; set; }
        private OrcamentoPedidoVendaCabDTO _OrcamentoPedidoVendaCabSelected;
        public OrcamentoPedidoVendaDetDTO OrcamentoPedidoVendaDetSelected { get; set; }
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public OrcamentoPedidoVendaCabViewModel()
        {
            try
            {
                ListaOrcamentoPedidoVendaCab = new ObservableCollection<OrcamentoPedidoVendaCabDTO>();
                primeiroResultado = 0;
                this.atualizarListaOrcamentoPedidoVendaCab(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrcamentoPedidoVendaCabDTO OrcamentoPedidoVendaCabSelected
        {
            get { return _OrcamentoPedidoVendaCabSelected; }
            set
            {
                _OrcamentoPedidoVendaCabSelected = value;
                notifyPropertyChanged("OrcamentoPedidoVendaCabSelected");
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
                            this.atualizarListaOrcamentoPedidoVendaCab(1);
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
                            this.atualizarListaOrcamentoPedidoVendaCab(-1);
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

        public void salvarAtualizarOrcamentoPedidoVendaCab()
        {
            try
            {
                using (ServicoVendasClient serv = new ServicoVendasClient())
                {
                    serv.salvarAtualizarOrcamentoPedidoVendaCab(OrcamentoPedidoVendaCabSelected);
                    OrcamentoPedidoVendaCabSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaOrcamentoPedidoVendaCab(int pagina)
        {
            try
            {
                using (ServicoVendasClient serv = new ServicoVendasClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<OrcamentoPedidoVendaCabDTO> listaServ = serv.selectOrcamentoPedidoVendaCabPagina(primeiroResultado, QUANTIDADE_PAGINA, new OrcamentoPedidoVendaCabDTO());

                    ListaOrcamentoPedidoVendaCab.Clear();

                    foreach (OrcamentoPedidoVendaCabDTO objAdd in listaServ)
                    {
                        ListaOrcamentoPedidoVendaCab.Add(objAdd);
                    }
                    OrcamentoPedidoVendaCabSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirOrcamentoPedidoVendaCab()
        {
            try
            {
                using (ServicoVendasClient serv = new ServicoVendasClient())
                {
                    serv.deleteOrcamentoPedidoVendaCab(OrcamentoPedidoVendaCabSelected);
                    OrcamentoPedidoVendaCabSelected = null;
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
        
        public void pesquisarVendedor()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(VendedorDTO),
                    typeof(ServicoVendas));

                if (searchWindow.ShowDialog() == true)
                {
                    OrcamentoPedidoVendaCabSelected.Vendedor = (VendedorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("OrcamentoPedidoVendaCabSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void pesquisarProduto()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ProdutoDTO),
                    typeof(ServicoVendas));

                if (searchWindow.ShowDialog() == true)
                {
                    OrcamentoPedidoVendaDetSelected.Produto = (ProdutoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("OrcamentoPedidoVendaCabSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void pesquisarTransportadora()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TransportadoraDTO),
                    typeof(ServicoVendas));

                if (searchWindow.ShowDialog() == true)
                {
                    OrcamentoPedidoVendaCabSelected.Transportadora = (TransportadoraDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("OrcamentoPedidoVendaCabSelected");
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
                    typeof(ServicoVendas));

                if (searchWindow.ShowDialog() == true)
                {
                    OrcamentoPedidoVendaCabSelected.Cliente = (ClienteDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("OrcamentoPedidoVendaCabSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void pesquisarCondicoesPagamento()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(CondicoesPagamentoDTO),
                    typeof(ServicoVendas));

                if (searchWindow.ShowDialog() == true)
                {
                    OrcamentoPedidoVendaCabSelected.CondicoesPagamento = (CondicoesPagamentoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("OrcamentoPedidoVendaCabSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
