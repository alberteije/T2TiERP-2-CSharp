using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PontoClient.ServicoPontoReference;
using PontoClient.Command;
using ComponentePonto;

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
    public class PontoMarcacaoViewModel : ERPViewModelBase
    {
        public ObservableCollection<PontoMarcacaoDTO> ListaPontoMarcacao { get; set; }
        private PontoMarcacaoDTO _PontoMarcacaoSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public PontoMarcacaoViewModel()
        {
            try
            {
                ListaPontoMarcacao = new ObservableCollection<PontoMarcacaoDTO>();
                primeiroResultado = 0;
                this.atualizarListaPontoMarcacao(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PontoMarcacaoDTO PontoMarcacaoSelected
        {
            get { return _PontoMarcacaoSelected; }
            set
            {
                _PontoMarcacaoSelected = value;
                notifyPropertyChanged("PontoMarcacaoSelected");
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
                            this.atualizarListaPontoMarcacao(1);
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
                            this.atualizarListaPontoMarcacao(-1);
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

        public void salvarAtualizarPontoMarcacao()
        {
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    serv.salvarAtualizarPontoMarcacao(PontoMarcacaoSelected);
                    PontoMarcacaoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaPontoMarcacao(int pagina)
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

                    List<PontoMarcacaoDTO> listaServ = serv.selectPontoMarcacaoPagina(primeiroResultado, 10, new PontoMarcacaoDTO());

                    ListaPontoMarcacao.Clear();

                    foreach (PontoMarcacaoDTO objAdd in listaServ)
                    {
                        ListaPontoMarcacao.Add(objAdd);
                    }
                    PontoMarcacaoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirPontoMarcacao()
        {
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    serv.deletePontoMarcacao(PontoMarcacaoSelected);
                    PontoMarcacaoSelected = null;
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

        public void importarArquivo(string pNomeArquivo)
        {
            ComponentePonto.ComponentePonto ponto = new ComponentePonto.ComponentePonto();
            ponto.processarArquivoAFD(pNomeArquivo);

            // pega o ID do relógio de ponto
            PontoRelogioDTO relogio = new PontoRelogioDTO();
            relogio.NumeroSerie = ponto.pontoAFD.AFDCabecalho.Campo07;
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    List<PontoRelogioDTO> listaRelogio = serv.selectPontoRelogio(relogio);

                    if (listaRelogio.Count > 0)
                    {
                        relogio = listaRelogio[0];
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            // verificar se os dados estão no banco de dados e grava os que não estão
            for (int i = 0; i < ponto.pontoAFD.ListaAFDRegistro3.Count; i++)
            {
                // pega o ID do colaborador
                ColaboradorDTO colaborador = new ColaboradorDTO();
                colaborador.PisNumero = ponto.pontoAFD.ListaAFDRegistro3[i].Campo05;
                try
                {
                    using (ServicoPontoClient serv = new ServicoPontoClient())
                    {
                        List<ColaboradorDTO> listaColaborador = serv.selectColaborador(colaborador);

                        if (listaColaborador.Count > 0)
                        {
                            colaborador = listaColaborador[0];

                            PontoMarcacaoDTO marcacao = new PontoMarcacaoDTO();
                            marcacao.Colaborador = colaborador;
                            marcacao.PontoRelogio = relogio;
                            string dataMarcacao = ponto.pontoAFD.ListaAFDRegistro3[i].Campo03.Substring(0, 2) + "/" +
                                                    ponto.pontoAFD.ListaAFDRegistro3[i].Campo03.Substring(2, 2) + "/" +
                                                    ponto.pontoAFD.ListaAFDRegistro3[i].Campo03.Substring(4, 4);
                            marcacao.DataMarcacao = System.DateTime.Parse(dataMarcacao);

                            List<PontoMarcacaoDTO> listaMarcacao = serv.selectPontoMarcacao(marcacao);
                            if (listaMarcacao.Count == 0)
                            {
                                marcacao.Nsr = int.Parse(ponto.pontoAFD.ListaAFDRegistro3[i].Campo01);

                                string horaMarcacao = ponto.pontoAFD.ListaAFDRegistro3[i].Campo04.Substring(0, 2) + ":" +
                                                        ponto.pontoAFD.ListaAFDRegistro3[i].Campo04.Substring(2, 2) + ":00";
                                marcacao.HoraMarcacao = horaMarcacao;
                                marcacao.TipoRegistro = "O";

                                serv.salvarAtualizarPontoMarcacao(marcacao);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }

        public void registrar()
        {
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    PontoMarcacaoDTO marcacao = new PontoMarcacaoDTO();
                    marcacao.Colaborador = new ColaboradorDTO();
                    marcacao.Colaborador.Id = UsuarioLogado.IdColaborador;
                    marcacao.DataMarcacao = DateTime.Today;

                    List<PontoMarcacaoDTO> listaServ = serv.selectPontoMarcacao(marcacao);

                    if (listaServ != null)
                    {
                        double resultado = listaServ.Count / 2;
                        if (listaServ.Count % 2 == 0)
                        {
                            marcacao.TipoMarcacao = "E";
                            marcacao.ParEntradaSaida = "E" + (Math.Floor(resultado) + 1);
                        }
                        else
                        {
                            marcacao.TipoMarcacao = "S";
                            marcacao.ParEntradaSaida = "S" + (Math.Floor(resultado) + 1);
                        }
                    }

                    serv.salvarAtualizarPontoMarcacao(marcacao);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
