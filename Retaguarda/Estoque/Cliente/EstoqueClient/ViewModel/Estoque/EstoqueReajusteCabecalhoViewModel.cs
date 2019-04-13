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
    public class EstoqueReajusteCabecalhoViewModel : ERPViewModelBase
    {
        public ObservableCollection<EstoqueReajusteCabecalhoDTO> ListaEstoqueReajusteCabecalho { get; set; }
        private EstoqueReajusteCabecalhoDTO _EstoqueReajusteCabecalhoSelected;
        public EstoqueReajusteDetalheDTO EstoqueReajusteDetalheSelected { get; set; }
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public EstoqueReajusteCabecalhoViewModel()
        {
            try
            {
                ListaEstoqueReajusteCabecalho = new ObservableCollection<EstoqueReajusteCabecalhoDTO>();
                primeiroResultado = 0;
                this.atualizarListaEstoqueReajusteCabecalho(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstoqueReajusteCabecalhoDTO EstoqueReajusteCabecalhoSelected
        {
            get { return _EstoqueReajusteCabecalhoSelected; }
            set
            {
                _EstoqueReajusteCabecalhoSelected = value;
                notifyPropertyChanged("EstoqueReajusteCabecalhoSelected");
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
                            this.atualizarListaEstoqueReajusteCabecalho(1);
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
                            this.atualizarListaEstoqueReajusteCabecalho(-1);
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

        public void salvarAtualizarEstoqueReajusteCabecalho()
        {
            try
            {
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    serv.salvarAtualizarEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoSelected);
                    EstoqueReajusteCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaEstoqueReajusteCabecalho(int pagina)
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

                    List<EstoqueReajusteCabecalhoDTO> listaServ = serv.selectEstoqueReajusteCabecalhoPagina(primeiroResultado, QUANTIDADE_PAGINA, new EstoqueReajusteCabecalhoDTO());

                    ListaEstoqueReajusteCabecalho.Clear();

                    foreach (EstoqueReajusteCabecalhoDTO objAdd in listaServ)
                    {
                        ListaEstoqueReajusteCabecalho.Add(objAdd);
                    }
                    EstoqueReajusteCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirEstoqueReajusteCabecalho()
        {
            try
            {
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    serv.deleteEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoSelected);
                    EstoqueReajusteCabecalhoSelected = null;
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
                    EstoqueReajusteDetalheSelected.Produto = (ProdutoDTO)searchWindow.itemSelecionado;
                    EstoqueReajusteDetalheSelected.ValorOriginal = EstoqueReajusteDetalheSelected.Produto.valorVenda;
                    notifyPropertyChanged("EstoqueReajusteDetalheSelected");
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
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ColaboradorDTO), typeof(ServicoEstoque));
                searchWindow.definirColunas(new string[] { "id", "nome" });
                if (searchWindow.ShowDialog() == true)
                {

                    EstoqueReajusteCabecalhoSelected.Colaborador = (ColaboradorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("EstoqueReajusteCabecalhoSelected");
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
                foreach (EstoqueReajusteDetalheDTO detalhe in EstoqueReajusteCabecalhoSelected.ListaEstoqueReajusteDetalhe)
                {
                    if (EstoqueReajusteCabecalhoSelected.TipoReajuste == "A")
                    {
                        detalhe.ValorReajuste = detalhe.ValorOriginal * (1 + (EstoqueReajusteCabecalhoSelected.Porcentagem / 100));
                    }
                    else
                    {
                        detalhe.ValorReajuste = detalhe.ValorOriginal * (1 - (EstoqueReajusteCabecalhoSelected.Porcentagem / 100));
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
/// EXERCICIO
///  Adapte essa janela para ajustar também a quantidade do estoque de forma
///  manual fornecendo uma justificativa, de acordo com o requisito 011.
///  Observe no Change-log quais campos foram adicionados nas tabelas para
///  permitir o reajuste na quantidade.
