using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FolhaClient.ServicoFolhaReference;
using FolhaClient.Command;
using SearchWindow;
using FolhaClient.Model;

namespace FolhaClient.ViewModel.Folha
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
    public class FolhaPlanoSaudeViewModel : ERPViewModelBase
    {
        public ObservableCollection<FolhaPlanoSaudeDTO> ListaFolhaPlanoSaude { get; set; }
        private FolhaPlanoSaudeDTO _FolhaPlanoSaudeSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public FolhaPlanoSaudeViewModel()
        {
            try
            {
                ListaFolhaPlanoSaude = new ObservableCollection<FolhaPlanoSaudeDTO>();
                primeiroResultado = 0;
                this.atualizarListaFolhaPlanoSaude(0);
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
                    typeof(ServicoFolha));

                if (searchWindow.ShowDialog() == true)
                {
                    FolhaPlanoSaudeSelected.Colaborador = (ColaboradorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FolhaPlanoSaudeSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void pesquisarOperadoraPlanoSaude()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(OperadoraPlanoSaudeDTO),
                    typeof(ServicoFolha));

                if (searchWindow.ShowDialog() == true)
                {
                    FolhaPlanoSaudeSelected.OperadoraPlanoSaude = (OperadoraPlanoSaudeDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FolhaPlanoSaudeSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FolhaPlanoSaudeDTO FolhaPlanoSaudeSelected
        {
            get { return _FolhaPlanoSaudeSelected; }
            set
            {
                _FolhaPlanoSaudeSelected = value;
                notifyPropertyChanged("FolhaPlanoSaudeSelected");
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
                            this.atualizarListaFolhaPlanoSaude(1);
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
                            this.atualizarListaFolhaPlanoSaude(-1);
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

        public void salvarAtualizarFolhaPlanoSaude()
        {
            try
            {
                using (ServicoFolhaClient serv = new ServicoFolhaClient())
                {
                    serv.salvarAtualizarFolhaPlanoSaude(FolhaPlanoSaudeSelected);
                    FolhaPlanoSaudeSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaFolhaPlanoSaude(int pagina)
        {
            try
            {
                using (ServicoFolhaClient serv = new ServicoFolhaClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<FolhaPlanoSaudeDTO> listaServ = serv.selectFolhaPlanoSaudePagina(primeiroResultado, QUANTIDADE_PAGINA, new FolhaPlanoSaudeDTO());

                    ListaFolhaPlanoSaude.Clear();

                    foreach (FolhaPlanoSaudeDTO objAdd in listaServ)
                    {
                        ListaFolhaPlanoSaude.Add(objAdd);
                    }
                    FolhaPlanoSaudeSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirFolhaPlanoSaude()
        {
            try
            {
                using (ServicoFolhaClient serv = new ServicoFolhaClient())
                {
                    serv.deleteFolhaPlanoSaude(FolhaPlanoSaudeSelected);
                    FolhaPlanoSaudeSelected = null;
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
