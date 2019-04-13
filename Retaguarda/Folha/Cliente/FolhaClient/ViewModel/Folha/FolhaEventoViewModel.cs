using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FolhaClient.ServicoFolhaReference;
using FolhaClient.Command;

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
    public class FolhaEventoViewModel : ERPViewModelBase
    {
        public ObservableCollection<FolhaEventoDTO> ListaFolhaEvento { get; set; }
        private FolhaEventoDTO _FolhaEventoSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public FolhaEventoViewModel()
        {
            try
            {
                ListaFolhaEvento = new ObservableCollection<FolhaEventoDTO>();
                primeiroResultado = 0;
                this.atualizarListaFolhaEvento(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FolhaEventoDTO FolhaEventoSelected
        {
            get { return _FolhaEventoSelected; }
            set
            {
                _FolhaEventoSelected = value;
                notifyPropertyChanged("FolhaEventoSelected");
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
                            this.atualizarListaFolhaEvento(1);
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
                            this.atualizarListaFolhaEvento(-1);
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

        public void salvarAtualizarFolhaEvento()
        {
            try
            {
                using (ServicoFolhaClient serv = new ServicoFolhaClient())
                {
                    FolhaEventoSelected.Empresa = Empresa;
                    serv.salvarAtualizarFolhaEvento(FolhaEventoSelected);
                    FolhaEventoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaFolhaEvento(int pagina)
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

                    List<FolhaEventoDTO> listaServ = serv.selectFolhaEventoPagina(primeiroResultado, QUANTIDADE_PAGINA, new FolhaEventoDTO());

                    ListaFolhaEvento.Clear();

                    foreach (FolhaEventoDTO objAdd in listaServ)
                    {
                        ListaFolhaEvento.Add(objAdd);
                    }
                    FolhaEventoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirFolhaEvento()
        {
            try
            {
                using (ServicoFolhaClient serv = new ServicoFolhaClient())
                {
                    serv.deleteFolhaEvento(FolhaEventoSelected);
                    FolhaEventoSelected = null;
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

/// EXERCICIO
///  Inclua na tela os seguintes campos
///  [+] Tabela FOLHA_EVENTO. Campo RUBRICA_ESOCIAL incluído.
///  [+] Tabela FOLHA_EVENTO. Campo COD_INCIDENCIA_PREVIDENCIA incluído.
///  [+] Tabela FOLHA_EVENTO. Campo COD_INCIDENCIA_IRRF incluído.
///  [+] Tabela FOLHA_EVENTO. Campo COD_INCIDENCIA_FGTS incluído.
///  [+] Tabela FOLHA_EVENTO. Campo COD_INCIDENCIA_SINDICATO incluído.
///  [+] Tabela FOLHA_EVENTO. Campo REPERCUTE_DSR incluído.
///  [+] Tabela FOLHA_EVENTO. Campo REPERCUTE_13 incluído.
///  [+] Tabela FOLHA_EVENTO. Campo REPERCUTE_FERIAS incluído.
///  [+] Tabela FOLHA_EVENTO. Campo REPERCUTE_AVISO incluído.
