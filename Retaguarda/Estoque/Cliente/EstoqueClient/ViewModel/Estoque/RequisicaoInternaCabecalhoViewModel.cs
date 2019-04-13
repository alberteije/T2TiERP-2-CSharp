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
    public class RequisicaoInternaCabecalhoViewModel : ERPViewModelBase
    {
        public ObservableCollection<RequisicaoInternaCabecalhoDTO> ListaRequisicaoInternaCabecalho { get; set; }
        private RequisicaoInternaCabecalhoDTO _RequisicaoInternaCabecalhoSelected;
        public RequisicaoInternaDetalheDTO RequisicaoInternaDetalheSelected { get; set; }
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public RequisicaoInternaCabecalhoViewModel()
        {
            try
            {
                ListaRequisicaoInternaCabecalho = new ObservableCollection<RequisicaoInternaCabecalhoDTO>();
                primeiroResultado = 0;
                this.atualizarListaRequisicaoInternaCabecalho(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RequisicaoInternaCabecalhoDTO RequisicaoInternaCabecalhoSelected
        {
            get { return _RequisicaoInternaCabecalhoSelected; }
            set
            {
                _RequisicaoInternaCabecalhoSelected = value;
                notifyPropertyChanged("RequisicaoInternaCabecalhoSelected");
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
                            this.atualizarListaRequisicaoInternaCabecalho(1);
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
                            this.atualizarListaRequisicaoInternaCabecalho(-1);
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

        public void salvarAtualizarRequisicaoInternaCabecalho()
        {
            try
            {
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    RequisicaoInternaCabecalhoSelected.Situacao = "A";
                    serv.salvarAtualizarRequisicaoInternaCabecalho(RequisicaoInternaCabecalhoSelected);
                    RequisicaoInternaCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaRequisicaoInternaCabecalho(int pagina)
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

                    List<RequisicaoInternaCabecalhoDTO> listaServ = serv.selectRequisicaoInternaCabecalhoPagina(primeiroResultado, QUANTIDADE_PAGINA, new RequisicaoInternaCabecalhoDTO());

                    ListaRequisicaoInternaCabecalho.Clear();

                    foreach (RequisicaoInternaCabecalhoDTO objAdd in listaServ)
                    {
                        ListaRequisicaoInternaCabecalho.Add(objAdd);
                    }
                    RequisicaoInternaCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirRequisicaoInternaCabecalho()
        {
            try
            {
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    serv.deleteRequisicaoInternaCabecalho(RequisicaoInternaCabecalhoSelected);
                    RequisicaoInternaCabecalhoSelected = null;
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

        public void pesquisarColaborador()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ColaboradorDTO), typeof(ServicoEstoque));
                searchWindow.definirColunas(new string[] { "id", "nome" });
                if (searchWindow.ShowDialog() == true)
                {

                    RequisicaoInternaCabecalhoSelected.Colaborador = (ColaboradorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("RequisicaoInternaCabecalhoSelected");
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
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ProdutoDTO), typeof(ServicoEstoque));
                searchWindow.definirColunas(new string[] { "gtin", "nome", "valorVenda", "quantidadeEstoque" });
                if (searchWindow.ShowDialog() == true)
                {
                    RequisicaoInternaDetalheSelected.Produto = (ProdutoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("RequisicaoInternaDetalheSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
