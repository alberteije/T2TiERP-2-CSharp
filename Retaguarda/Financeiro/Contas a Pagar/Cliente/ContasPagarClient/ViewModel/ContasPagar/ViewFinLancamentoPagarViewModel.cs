using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContasPagarClient.ContasPagarService;
using ContasPagarClient.Command;
using SearchWindow;
using ContasPagarClient.Model;

namespace ContasPagarClient.ViewModel.ContasPagar
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
    public class ViewFinLancamentoPagarViewModel : ERPViewModelBase
    {
        public ObservableCollection<ViewFinLancamentoPagarDTO> ListaViewFinLancamentoPagar { get; set; }
        private ViewFinLancamentoPagarDTO _ViewFinLancamentoPagarSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }
        public FinParcelaPagamentoDTO FinParcelaPagamentoSelected { get; set; }


        public ViewFinLancamentoPagarViewModel()
        {
            try
            {
                ListaViewFinLancamentoPagar = new ObservableCollection<ViewFinLancamentoPagarDTO>();
                primeiroResultado = 0;
                this.atualizarListaViewFinLancamentoPagar(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ViewFinLancamentoPagarDTO ViewFinLancamentoPagarSelected
        {
            get { return _ViewFinLancamentoPagarSelected; }
            set
            {
                _ViewFinLancamentoPagarSelected = value;
                notifyPropertyChanged("ViewFinLancamentoPagarSelected");
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
                            this.atualizarListaViewFinLancamentoPagar(1);
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
                            this.atualizarListaViewFinLancamentoPagar(-1);
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

        public void salvarAtualizarViewFinLancamentoPagar()
        {
            try
            {
                using (ContasPagarServiceClient serv = new ContasPagarServiceClient())
                {
                    serv.salvarAtualizarViewFinLancamentoPagar(ViewFinLancamentoPagarSelected);
                    ViewFinLancamentoPagarSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaViewFinLancamentoPagar(int pagina)
        {
            try
            {
                using (ContasPagarServiceClient serv = new ContasPagarServiceClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<ViewFinLancamentoPagarDTO> listaServ = serv.selectViewFinLancamentoPagarPagina(primeiroResultado, QUANTIDADE_PAGINA, new ViewFinLancamentoPagarDTO());

                    ListaViewFinLancamentoPagar.Clear();

                    foreach (ViewFinLancamentoPagarDTO objAdd in listaServ)
                    {
                        ListaViewFinLancamentoPagar.Add(objAdd);
                    }
                    ViewFinLancamentoPagarSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void pesquisarContaCaixa()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ContaCaixaDTO),
                    typeof(ServicoContasPagar));

                if (searchWindow.ShowDialog() == true)
                {
                    FinParcelaPagamentoSelected.ContaCaixa = (ContaCaixaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FinParcelaPagamentoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarFinTipoPagamento()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(FinTipoPagamentoDTO),
                    typeof(ServicoContasPagar));

                if (searchWindow.ShowDialog() == true)
                {
                    FinParcelaPagamentoSelected.FinTipoPagamento = (FinTipoPagamentoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("FinParcelaPagamentoSelected");
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

/// EXERCICIO:
/// IMPLEMENTE O LANCAMENTO DE PAGAMENTO FIXO/RECORRENTE
/// VERIFIQUE SE ESSE PAGAMENTO JA FOI MARCADO COMO FIXO E AJA DE ACORDO
///  01 - APAGUE O REGISTRO ANTERIOR E GRAVE O NOVO
///  02 - ALTERE O REGISTRO ANTERIOR
///  03 - INFORME QUE JÁ EXISE UM PAGAMENTO FIXO ARMAZENADO E QUE NÃO É POSSÍVEL REALIZAR ALTERAÇÕES
///  04 - SOLICITE UMA AÇÃO DO USUÁRIO
