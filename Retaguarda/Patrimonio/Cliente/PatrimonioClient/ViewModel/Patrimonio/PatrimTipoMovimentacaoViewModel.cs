using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PatrimonioClient.ServicoPatrimonioReference;
using PatrimonioClient.Command;

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
    public class PatrimTipoMovimentacaoViewModel : ERPViewModelBase
    {
        public ObservableCollection<PatrimTipoMovimentacaoDTO> ListaPatrimTipoMovimentacao { get; set; }
        private PatrimTipoMovimentacaoDTO _PatrimTipoMovimentacaoSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public PatrimTipoMovimentacaoViewModel()
        {
            try
            {
                ListaPatrimTipoMovimentacao = new ObservableCollection<PatrimTipoMovimentacaoDTO>();
                primeiroResultado = 0;
                this.atualizarListaPatrimTipoMovimentacao(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatrimTipoMovimentacaoDTO PatrimTipoMovimentacaoSelected
        {
            get { return _PatrimTipoMovimentacaoSelected; }
            set
            {
                _PatrimTipoMovimentacaoSelected = value;
                notifyPropertyChanged("PatrimTipoMovimentacaoSelected");
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
                            this.atualizarListaPatrimTipoMovimentacao(1);
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
                            this.atualizarListaPatrimTipoMovimentacao(-1);
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

        public void salvarAtualizarPatrimTipoMovimentacao()
        {
            try
            {
                using (ServicoPatrimonioClient serv = new ServicoPatrimonioClient())
                {
                    PatrimTipoMovimentacaoSelected.Empresa = this.Empresa;
                    serv.salvarAtualizarPatrimTipoMovimentacao(PatrimTipoMovimentacaoSelected);
                    PatrimTipoMovimentacaoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaPatrimTipoMovimentacao(int pagina)
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

                    List<PatrimTipoMovimentacaoDTO> listaServ = serv.selectPatrimTipoMovimentacaoPagina(primeiroResultado, QUANTIDADE_PAGINA, new PatrimTipoMovimentacaoDTO());

                    ListaPatrimTipoMovimentacao.Clear();

                    foreach (PatrimTipoMovimentacaoDTO objAdd in listaServ)
                    {
                        ListaPatrimTipoMovimentacao.Add(objAdd);
                    }
                    PatrimTipoMovimentacaoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirPatrimTipoMovimentacao()
        {
            try
            {
                using (ServicoPatrimonioClient serv = new ServicoPatrimonioClient())
                {
                    serv.deletePatrimTipoMovimentacao(PatrimTipoMovimentacaoSelected);
                    PatrimTipoMovimentacaoSelected = null;
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
