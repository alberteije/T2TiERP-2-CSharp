using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PontoClient.ServicoPontoReference;
using PontoClient.Command;

namespace PontoClient.ViewModel.Ponto
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
    public class PontoClassificacaoJornadaViewModel : ERPViewModelBase
    {
        public ObservableCollection<PontoClassificacaoJornadaDTO> ListaPontoClassificacaoJornada { get; set; }
        private PontoClassificacaoJornadaDTO _PontoClassificacaoJornadaSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public PontoClassificacaoJornadaViewModel()
        {
            try
            {
                ListaPontoClassificacaoJornada = new ObservableCollection<PontoClassificacaoJornadaDTO>();
                primeiroResultado = 0;
                this.atualizarListaPontoClassificacaoJornada(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PontoClassificacaoJornadaDTO PontoClassificacaoJornadaSelected
        {
            get { return _PontoClassificacaoJornadaSelected; }
            set
            {
                _PontoClassificacaoJornadaSelected = value;
                notifyPropertyChanged("PontoClassificacaoJornadaSelected");
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
                            this.atualizarListaPontoClassificacaoJornada(1);
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
                            this.atualizarListaPontoClassificacaoJornada(-1);
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

        public void salvarAtualizarPontoClassificacaoJornada()
        {
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    PontoClassificacaoJornadaSelected.Empresa = Empresa;
                    serv.salvarAtualizarPontoClassificacaoJornada(PontoClassificacaoJornadaSelected);
                    PontoClassificacaoJornadaSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaPontoClassificacaoJornada(int pagina)
        {
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<PontoClassificacaoJornadaDTO> listaServ = serv.selectPontoClassificacaoJornadaPagina(primeiroResultado, QUANTIDADE_PAGINA, new PontoClassificacaoJornadaDTO());

                    ListaPontoClassificacaoJornada.Clear();

                    foreach (PontoClassificacaoJornadaDTO objAdd in listaServ)
                    {
                        ListaPontoClassificacaoJornada.Add(objAdd);
                    }
                    PontoClassificacaoJornadaSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirPontoClassificacaoJornada()
        {
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    serv.deletePontoClassificacaoJornada(PontoClassificacaoJornadaSelected);
                    PontoClassificacaoJornadaSelected = null;
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
