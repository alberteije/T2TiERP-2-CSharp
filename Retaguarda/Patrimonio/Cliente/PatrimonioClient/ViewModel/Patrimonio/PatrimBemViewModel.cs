using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PatrimonioClient.ServicoPatrimonioReference;
using PatrimonioClient.Command;
using SearchWindow;
using PatrimonioClient.Model;

namespace PatrimonioClient.ViewModel.Patrimonio
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
    public class PatrimBemViewModel : ERPViewModelBase
    {
        public ObservableCollection<PatrimBemDTO> ListaPatrimBem { get; set; }
        private PatrimBemDTO _PatrimBemSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }
        public PatrimDepreciacaoBemDTO PatrimDepreciacaoBemSelected { get; set; }
        public PatrimMovimentacaoBemDTO PatrimMovimentacaoBemSelected { get; set; }
        public PatrimDocumentoBemDTO PatrimDocumentoBemSelected { get; set; }

        public PatrimBemViewModel()
        {
            try
            {
                ListaPatrimBem = new ObservableCollection<PatrimBemDTO>();
                primeiroResultado = 0;
                this.atualizarListaPatrimBem(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatrimBemDTO PatrimBemSelected
        {
            get { return _PatrimBemSelected; }
            set
            {
                _PatrimBemSelected = value;
                notifyPropertyChanged("PatrimBemSelected");
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
                            this.atualizarListaPatrimBem(1);
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
                            this.atualizarListaPatrimBem(-1);
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

        public void salvarAtualizarPatrimBem()
        {
            try
            {
                using (ServicoPatrimonioClient serv = new ServicoPatrimonioClient())
                {
                    serv.salvarAtualizarPatrimBem(PatrimBemSelected);
                    PatrimBemSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaPatrimBem(int pagina)
        {
            try
            {
                using (ServicoPatrimonioClient serv = new ServicoPatrimonioClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<PatrimBemDTO> listaServ = serv.selectPatrimBemPagina(primeiroResultado, QUANTIDADE_PAGINA, new PatrimBemDTO());

                    ListaPatrimBem.Clear();

                    foreach (PatrimBemDTO objAdd in listaServ)
                    {
                        ListaPatrimBem.Add(objAdd);
                    }
                    PatrimBemSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirPatrimBem()
        {
            try
            {
                using (ServicoPatrimonioClient serv = new ServicoPatrimonioClient())
                {
                    serv.deletePatrimBem(PatrimBemSelected);
                    PatrimBemSelected = null;
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
                    typeof(ServicoPatrimonio));

                if (searchWindow.ShowDialog() == true)
                {
                    PatrimBemSelected.Colaborador = (ColaboradorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("PatrimBemSelected");
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
                    typeof(ServicoPatrimonio));

                if (searchWindow.ShowDialog() == true)
                {
                    PatrimBemSelected.Fornecedor = (FornecedorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("PatrimBemSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarSetor()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(SetorDTO),
                    typeof(ServicoPatrimonio));

                if (searchWindow.ShowDialog() == true)
                {
                    PatrimBemSelected.Setor = (SetorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("PatrimBemSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarPatrimGrupoBem()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(PatrimGrupoBemDTO),
                    typeof(ServicoPatrimonio));

                if (searchWindow.ShowDialog() == true)
                {
                    PatrimBemSelected.PatrimGrupoBem = (PatrimGrupoBemDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("PatrimBemSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarPatrimEstadoConservacao()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(PatrimEstadoConservacaoDTO),
                    typeof(ServicoPatrimonio));

                if (searchWindow.ShowDialog() == true)
                {
                    PatrimBemSelected.PatrimEstadoConservacao = (PatrimEstadoConservacaoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("PatrimBemSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarPatrimTipoAquisicaoBem()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(PatrimTipoAquisicaoBemDTO),
                    typeof(ServicoPatrimonio));

                if (searchWindow.ShowDialog() == true)
                {
                    PatrimBemSelected.PatrimTipoAquisicaoBem = (PatrimTipoAquisicaoBemDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("PatrimBemSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarPatrimTipoMovimentacao()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(PatrimTipoMovimentacaoDTO),
                    typeof(ServicoPatrimonio));

                if (searchWindow.ShowDialog() == true)
                {
                    PatrimMovimentacaoBemSelected.PatrimTipoMovimentacao = (PatrimTipoMovimentacaoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("PatrimMovimentacaoBemSelected");
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
