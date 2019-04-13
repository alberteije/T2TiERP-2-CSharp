using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContabilidadeClient.ViewModel;
using ContabilidadeClient.ServicoContabilidadeReference;
using ContabilidadeClient.Command;

namespace ContabilidadeClient.View.Contabilidade
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
    public class ContabilDreCabecalhoViewModel : ERPViewModelBase
    {
        public ObservableCollection<ContabilDreCabecalhoDTO> ListaContabilDreCabecalho { get; set; }
        private ContabilDreCabecalhoDTO _ContabilDreCabecalhoSelected;
        public ContabilDreDetalheDTO ContabilDreDetalheSelected { get; set; }
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }

        /// EXERCICIO
        ///  Implemente as rotinas automáticas no sistema

        public ContabilDreCabecalhoViewModel()
        {
            try
            {
                ListaContabilDreCabecalho = new ObservableCollection<ContabilDreCabecalhoDTO>();
                primeiroResultado = 0;
                this.atualizarListaContabilDreCabecalho(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContabilDreCabecalhoDTO ContabilDreCabecalhoSelected
        {
            get { return _ContabilDreCabecalhoSelected; }
            set
            {
                _ContabilDreCabecalhoSelected = value;
                notifyPropertyChanged("ContabilDreCabecalhoSelected");
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
                            this.atualizarListaContabilDreCabecalho(1);
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
                            this.atualizarListaContabilDreCabecalho(-1);
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

        public void salvarAtualizarContabilDreCabecalho()
        {
            try
            {
                using (ServicoContabilidadeClient serv = new ServicoContabilidadeClient())
                {
                    ContabilDreCabecalhoSelected.Empresa = Empresa;
                    serv.salvarAtualizarContabilDreCabecalho(ContabilDreCabecalhoSelected);
                    ContabilDreCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaContabilDreCabecalho(int pagina)
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

                    List<ContabilDreCabecalhoDTO> listaServ = serv.selectContabilDreCabecalhoPagina(primeiroResultado, QUANTIDADE_PAGINA, new ContabilDreCabecalhoDTO());

                    ListaContabilDreCabecalho.Clear();

                    foreach (ContabilDreCabecalhoDTO objAdd in listaServ)
                    {
                        ListaContabilDreCabecalho.Add(objAdd);
                    }
                    ContabilDreCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirContabilDreCabecalho()
        {
            try
            {
                using (ServicoContabilidadeClient serv = new ServicoContabilidadeClient())
                {
                    serv.deleteContabilDreCabecalho(ContabilDreCabecalhoSelected);
                    ContabilDreCabecalhoSelected = null;
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
