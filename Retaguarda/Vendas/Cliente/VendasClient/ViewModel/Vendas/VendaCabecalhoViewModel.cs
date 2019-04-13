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
    public class VendaCabecalhoViewModel : ERPViewModelBase
    {
        public ObservableCollection<VendaCabecalhoDTO> ListaVendaCabecalho { get; set; }
        private VendaCabecalhoDTO _VendaCabecalhoSelected;
        public VendaDetalheDTO VendaDetalheSelected { get; set; } 
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public VendaCabecalhoViewModel()
        {
            try
            {
                ListaVendaCabecalho = new ObservableCollection<VendaCabecalhoDTO>();
                primeiroResultado = 0;
                this.atualizarListaVendaCabecalho(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VendaCabecalhoDTO VendaCabecalhoSelected
        {
            get { return _VendaCabecalhoSelected; }
            set
            {
                _VendaCabecalhoSelected = value;
                notifyPropertyChanged("VendaCabecalhoSelected");
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
                            this.atualizarListaVendaCabecalho(1);
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
                            this.atualizarListaVendaCabecalho(-1);
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

        public void salvarAtualizarVendaCabecalho()
        {
            try
            {
                using (ServicoVendasClient serv = new ServicoVendasClient())
                {
                    serv.salvarAtualizarVendaCabecalho(VendaCabecalhoSelected);
                    VendaCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaVendaCabecalho(int pagina)
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

                    List<VendaCabecalhoDTO> listaServ = serv.selectVendaCabecalhoPagina(primeiroResultado, QUANTIDADE_PAGINA, new VendaCabecalhoDTO());

                    ListaVendaCabecalho.Clear();

                    foreach (VendaCabecalhoDTO objAdd in listaServ)
                    {
                        ListaVendaCabecalho.Add(objAdd);
                    }
                    VendaCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirVendaCabecalho()
        {
            try
            {
                using (ServicoVendasClient serv = new ServicoVendasClient())
                {
                    serv.deleteVendaCabecalho(VendaCabecalhoSelected);
                    VendaCabecalhoSelected = null;
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
        public void pesquisarTipoNotaFiscal()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TipoNotaFiscalDTO),
                    typeof(ServicoVendas));

                if (searchWindow.ShowDialog() == true)
                {
                    VendaCabecalhoSelected.TipoNotaFiscal = (TipoNotaFiscalDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendaCabecalhoSelected");
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
                    VendaCabecalhoSelected.Transportadora = (TransportadoraDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendaCabecalhoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    VendaCabecalhoSelected.Vendedor = (VendedorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendaCabecalhoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void pesquisarOrcamentoPedidoVendaCab()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(OrcamentoPedidoVendaCabDTO),
                    typeof(ServicoVendas));

                if (searchWindow.ShowDialog() == true)
                {
                    VendaCabecalhoSelected.OrcamentoPedidoVendaCab = (OrcamentoPedidoVendaCabDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendaCabecalhoSelected");
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
                    VendaCabecalhoSelected.Cliente = (ClienteDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendaCabecalhoSelected");
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
                    VendaDetalheSelected.Produto = (ProdutoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendaDetalheSelected");
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
                    VendaCabecalhoSelected.CondicoesPagamento = (CondicoesPagamentoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendaCabecalhoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

/// EXERCICIO
/// INTEGRAÇÃO NF-E
///  Faça a integração com o sistema NF-e
///  OBS: lembre que o NF-e já integra com o Financeiro
///
/// DEVOLUÇÃO
///  A devolução deve ser feita no sistema NF-e informando a natureza da operação devida.
///  Nesse momento deve-se alterar a situação da venda para Devolução e estornar os lançamentos do financeiro.
