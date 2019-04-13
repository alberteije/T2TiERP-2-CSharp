using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EstoqueClient.EstoqueServiceReference;
using EstoqueClient.Command;
using SearchWindow;
using EstoqueClient.Model;

namespace EstoqueClient.View.Estoque
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
    public class EstoqueContagemCabecalhoViewModel : ERPViewModelBase
    {
        public ObservableCollection<EstoqueContagemCabecalhoDTO> ListaEstoqueContagemCabecalho { get; set; }
        private EstoqueContagemCabecalhoDTO _EstoqueContagemCabecalhoSelected;
        public EstoqueContagemDetalheDTO EstoqueContagemDetalheSelected { get; set; }
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public EstoqueContagemCabecalhoViewModel()
        {
            try
            {
                ListaEstoqueContagemCabecalho = new ObservableCollection<EstoqueContagemCabecalhoDTO>();
                primeiroResultado = 0;
                this.atualizarListaEstoqueContagemCabecalho(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstoqueContagemCabecalhoDTO EstoqueContagemCabecalhoSelected
        {
            get { return _EstoqueContagemCabecalhoSelected; }
            set
            {
                _EstoqueContagemCabecalhoSelected = value;
                notifyPropertyChanged("EstoqueContagemCabecalhoSelected");
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
                            this.atualizarListaEstoqueContagemCabecalho(1);
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
                            this.atualizarListaEstoqueContagemCabecalho(-1);
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

        public void salvarAtualizarEstoqueContagemCabecalho()
        {
            try
            {
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    EstoqueContagemCabecalhoSelected.Empresa = Empresa;
                    serv.salvarAtualizarEstoqueContagemCabecalho(EstoqueContagemCabecalhoSelected);
                    EstoqueContagemCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaEstoqueContagemCabecalho(int pagina)
        {
            try
            {
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<EstoqueContagemCabecalhoDTO> listaServ = serv.selectEstoqueContagemCabecalhoPagina(primeiroResultado, QUANTIDADE_PAGINA, new EstoqueContagemCabecalhoDTO());

                    ListaEstoqueContagemCabecalho.Clear();

                    foreach (EstoqueContagemCabecalhoDTO objAdd in listaServ)
                    {
                        ListaEstoqueContagemCabecalho.Add(objAdd);
                    }
                    EstoqueContagemCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirEstoqueContagemCabecalho()
        {
            try
            {
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    serv.deleteEstoqueContagemCabecalho(EstoqueContagemCabecalhoSelected);
                    EstoqueContagemCabecalhoSelected = null;
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

        public void pesquisarProduto()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ProdutoDTO), typeof(ServicoEstoque));
                searchWindow.definirColunas(new string[] { "gtin", "nome", "valorVenda", "quantidadeEstoque" });
                if (searchWindow.ShowDialog() == true)
                {
                    EstoqueContagemDetalheSelected.Produto = (ProdutoDTO)searchWindow.itemSelecionado;
                    EstoqueContagemDetalheSelected.QuantidadeSistema = EstoqueContagemDetalheSelected.Produto.quantidadeEstoque;
                    notifyPropertyChanged("EstoqueContagemDetalheSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void realizarCalculos()
        {
            try
            {
                foreach (EstoqueContagemDetalheDTO detalhe in EstoqueContagemCabecalhoSelected.listaContagemDetalhe)
                {
                    //acuracidade dos registros = (registros sistema / registros contados) X 100 }
                    if (detalhe.QuantidadeContada > 0)
                    {
                        detalhe.Acuracidade = detalhe.QuantidadeSistema / detalhe.QuantidadeContada * 100;
                    }
                    else
                    {
                        detalhe.Acuracidade = 0;
                    }

                    //divergencia dos registros = ((registros contados - registros sistema) / registros sistema) X 100 }
                    if (detalhe.QuantidadeSistema != 0)
                    {
                        detalhe.Divergencia = (detalhe.QuantidadeContada - detalhe.QuantidadeSistema) / detalhe.QuantidadeSistema * 100;
                    }
                    else
                    {
                        detalhe.Divergencia = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
