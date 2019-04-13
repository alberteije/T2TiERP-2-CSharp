using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ConciliacaoContabilClient.ViewModel;
using ConciliacaoContabilClient.ServicoConciliacaoContabilReference;
using ConciliacaoContabilClient.Command;
using ConciliacaoContabilClient.Model;

namespace ConciliacaoContabilClient.ViewModel.ConciliacaoContabil
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
    public class ConciliaContaCaixaViewModel : ERPViewModelBase
    {
        public ObservableCollection<ContaCaixaDTO> ListaContaCaixa { get; set; }
        public ObservableCollection<FinExtratoContaBancoDTO> ListaFinExtratoContaBanco { get; set; }
        public ObservableCollection<ContabilLancamentoDetalheDTO> ListaContabilLancamentoDetalhe { get; set; }
        public ObservableCollection<LancamentoConciliadoDTO> ListaLancamentoConciliado { get; set; }

        private ContaCaixaDTO _ContaCaixaSelected;
        private FinExtratoContaBancoDTO _FinExtratoContaBancoSelected;
        private ContabilLancamentoDetalheDTO _ContabilLancamentoDetalheSelected;
        private LancamentoConciliadoDTO _LancamentoConciliadoSelected;

        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public ConciliaContaCaixaViewModel()
        {
            try
            {
                ListaContaCaixa = new ObservableCollection<ContaCaixaDTO>();
                ListaFinExtratoContaBanco = new ObservableCollection<FinExtratoContaBancoDTO>();
                ListaContabilLancamentoDetalhe = new ObservableCollection<ContabilLancamentoDetalheDTO>();
                ListaLancamentoConciliado = new ObservableCollection<LancamentoConciliadoDTO>();

                primeiroResultado = 0;
                this.atualizarListaContaCaixa(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContaCaixaDTO ContaCaixaSelected
        {
            get { return _ContaCaixaSelected; }
            set
            {
                _ContaCaixaSelected = value;
                notifyPropertyChanged("ContaCaixaSelected");
            }
        }

        public FinExtratoContaBancoDTO FinExtratoContaBancoSelected
        {
            get { return _FinExtratoContaBancoSelected; }
            set
            {
                _FinExtratoContaBancoSelected = value;
                notifyPropertyChanged("FinExtratoContaBancoSelected");
            }
        }

        public ContabilLancamentoDetalheDTO ContabilLancamentoDetalheSelected
        {
            get { return _ContabilLancamentoDetalheSelected; }
            set
            {
                _ContabilLancamentoDetalheSelected = value;
                notifyPropertyChanged("ContabilLancamentoDetalheSelected");
            }
        }

        public LancamentoConciliadoDTO LancamentoConciliadoSelected
        {
            get { return _LancamentoConciliadoSelected; }
            set
            {
                _LancamentoConciliadoSelected = value;
                notifyPropertyChanged("LancamentoConciliadoSelected");
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
                            this.atualizarListaContaCaixa(1);
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
                            this.atualizarListaContaCaixa(-1);
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

        public void atualizarListaContaCaixa(int pagina)
        {
            try
            {
                using (ServicoConciliacaoContabilClient serv = new ServicoConciliacaoContabilClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<ContaCaixaDTO> listaServ = serv.selectContaCaixaPagina(primeiroResultado, QUANTIDADE_PAGINA, new ContaCaixaDTO());

                    ListaContaCaixa.Clear();

                    foreach (ContaCaixaDTO objAdd in listaServ)
                    {
                        ListaContaCaixa.Add(objAdd);
                    }
                    ContaCaixaSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void atualizarListaFinExtratoContaBanco(int pagina)
        {
            try
            {
                using (ServicoConciliacaoContabilClient serv = new ServicoConciliacaoContabilClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<FinExtratoContaBancoDTO> listaServ = serv.selectFinExtratoContaBancoPagina(primeiroResultado, QUANTIDADE_PAGINA, new FinExtratoContaBancoDTO());

                    ListaFinExtratoContaBanco.Clear();

                    foreach (FinExtratoContaBancoDTO objAdd in listaServ)
                    {
                        ListaFinExtratoContaBanco.Add(objAdd);
                    }
                    FinExtratoContaBancoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void atualizarListaContabilLancamentoDetalhe(int pagina)
        {
            try
            {
                using (ServicoConciliacaoContabilClient serv = new ServicoConciliacaoContabilClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<ContabilLancamentoDetalheDTO> listaServ = serv.selectContabilLancamentoDetalhePagina(primeiroResultado, QUANTIDADE_PAGINA, new ContabilLancamentoDetalheDTO());

                    ListaContabilLancamentoDetalhe.Clear();

                    foreach (ContabilLancamentoDetalheDTO objAdd in listaServ)
                    {
                        ListaContabilLancamentoDetalhe.Add(objAdd);
                    }
                    ContabilLancamentoDetalheSelected = null;
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
