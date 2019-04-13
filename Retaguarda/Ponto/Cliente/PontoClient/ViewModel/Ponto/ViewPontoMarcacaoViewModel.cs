using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PontoClient.ServicoPontoReference;
using PontoClient.Command;
using ComponentePonto;
using Microsoft.Win32;
using System.Windows;
using System.Globalization;

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
    public class ViewPontoMarcacaoViewModel : ERPViewModelBase
    {
        public ObservableCollection<ViewPontoMarcacaoDTO> ListaViewPontoMarcacao { get; set; }
        private ViewPontoMarcacaoDTO _ViewPontoMarcacaoSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public ViewPontoMarcacaoViewModel()
        {
            try
            {
                ListaViewPontoMarcacao = new ObservableCollection<ViewPontoMarcacaoDTO>();
                primeiroResultado = 0;
                this.atualizarListaViewPontoMarcacao(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ViewPontoMarcacaoDTO ViewPontoMarcacaoSelected
        {
            get { return _ViewPontoMarcacaoSelected; }
            set
            {
                _ViewPontoMarcacaoSelected = value;
                notifyPropertyChanged("ViewPontoMarcacaoSelected");
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
                            this.atualizarListaViewPontoMarcacao(1);
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
                            this.atualizarListaViewPontoMarcacao(-1);
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
                    for (int i = 0; i < ListaViewPontoMarcacao.Count; i++)
                    {
                        PontoMarcacaoDTO marcacao = new PontoMarcacaoDTO();

                        marcacao.Id = ListaViewPontoMarcacao[i].Id;
                        marcacao.Colaborador = new ColaboradorDTO {Id = ListaViewPontoMarcacao[i].IdColaborador};
                        marcacao.PontoRelogio = new PontoRelogioDTO { Id = ListaViewPontoMarcacao[i].IdPontoRelogio.Value };
                        marcacao.Nsr = ListaViewPontoMarcacao[i].Nsr;
                        marcacao.DataMarcacao = ListaViewPontoMarcacao[i].DataMarcacao;
                        marcacao.HoraMarcacao = ListaViewPontoMarcacao[i].HoraMarcacao;
                        marcacao.TipoMarcacao = ListaViewPontoMarcacao[i].TipoMarcacao;
                        marcacao.TipoRegistro = ListaViewPontoMarcacao[i].TipoRegistro;
                        marcacao.ParEntradaSaida = ListaViewPontoMarcacao[i].ParEntradaSaida;
                        marcacao.Justificativa = ListaViewPontoMarcacao[i].Justificativa;

                        serv.salvarAtualizarPontoMarcacao(marcacao);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaViewPontoMarcacao(int pagina)
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

                    List<ViewPontoMarcacaoDTO> listaServ = serv.selectViewPontoMarcacaoPagina(primeiroResultado, QUANTIDADE_PAGINA, new ViewPontoMarcacaoDTO());

                    ListaViewPontoMarcacao.Clear();

                    foreach (ViewPontoMarcacaoDTO objAdd in listaServ)
                    {
                        ListaViewPontoMarcacao.Add(objAdd);
                    }
                    ViewPontoMarcacaoSelected = null;
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

        public void gerarAFDT(string pDataIni, string pDataFim)
        {
            ComponentePonto.ComponentePonto ponto = new ComponentePonto.ComponentePonto();

            AFDT_Cabecalho AFDTCabecalho = new AFDT_Cabecalho();

            // Registro 1 - Cabecalho
            /*
            Campo01: String; // Seqüencial do registro no arquivo.
            Campo02: String; // Tipo do registro, “1”.
            Campo03: String; // Tipo de identificador do empregador, “1” para CNPJ ou “2” para CPF.
            Campo04: String; // CNPJ ou CPF do empregador.
            Campo05: String; // CEI do empregador, quando existir.
            Campo06: String; // Razão social ou nome do empregador.
            Campo07: String; // Data inicial dos registros no arquivo, no formato “ddmmaaaa”.
            Campo08: String; // Data final dos registros no arquivo, no formato “ddmmaaaa”.
            Campo09: String; // Data de geração do arquivo, no formato “ddmmaaaa”.
            Campo10: String; // Horário da geração do arquivo, no formato “hhmm”.
            */
            AFDTCabecalho.Campo03 = "1";
            AFDTCabecalho.Campo04 = Empresa.Cnpj;
            AFDTCabecalho.Campo05 = "";
            AFDTCabecalho.Campo06 = Empresa.RazaoSocial;
            AFDTCabecalho.Campo07 = System.DateTime.Parse(pDataIni).ToString("ddMMyyyy");
            AFDTCabecalho.Campo08 = System.DateTime.Parse(pDataFim).ToString("ddMMyyyy");
            AFDTCabecalho.Campo09 = DateTime.Today.ToString("ddMMyyyy");
            AFDTCabecalho.Campo10 = DateTime.Now.ToString("HHmm");
            ponto.AFDTCabecalho = AFDTCabecalho;


            List<AFDT_Registro2> listaAFDTRegistro2 = new List<AFDT_Registro2>();
            for (int i = 0; i < ListaViewPontoMarcacao.Count; i++)
            {
                // Registro 2 - Detalhe
                /*
                Campo01: String; // Seqüencial do registro no arquivo.
                Campo02: String; // Tipo do registro, “2”.
                Campo03: String; // Data da marcação do ponto, no formato “ddmmaaaa”.
                Campo04: String; // Horário da marcação do ponto, no formato “hhmm”.
                Campo05: String; // Número do PIS do empregado.
                Campo06: String; // Número de fabricação do REP onde foi feito o registro.
                Campo07: String; // Tipo de marcação, “E” para ENTRADA, “S” para SAÍDA ou “D” para registro a ser DESCONSIDERADO.
                Campo08: String; // Número seqüencial por empregado e jornada para o conjunto Entrada/Saída. Vide observação.
                Campo09: String; // Tipo de registro: “O” para registro eletrônico ORIGINAL, “I” para registro INCLUÍDO por digitação, “P” para intervalo PRÉ-ASSINALADO.
                Campo10: String; // Motivo: Campo a ser preenchido se o campo 7 for “D” ou se o campo 9 for “I”.
                */

                AFDT_Registro2 AFDTRegistro2 = new AFDT_Registro2();

                AFDTRegistro2.Campo03 = ListaViewPontoMarcacao[i].DataMarcacao.Value.ToString("ddMMyyyy");
                AFDTRegistro2.Campo04 = ListaViewPontoMarcacao[i].HoraMarcacao;
                AFDTRegistro2.Campo05 = ListaViewPontoMarcacao[i].PisNumero;
                AFDTRegistro2.Campo06 = ListaViewPontoMarcacao[i].NumeroSerie;
                AFDTRegistro2.Campo07 = ListaViewPontoMarcacao[i].TipoMarcacao;
                AFDTRegistro2.Campo08 = ListaViewPontoMarcacao[i].ParEntradaSaida;
                AFDTRegistro2.Campo09 = ListaViewPontoMarcacao[i].TipoRegistro;
                AFDTRegistro2.Campo10 = ListaViewPontoMarcacao[i].Justificativa;

                listaAFDTRegistro2.Add(AFDTRegistro2);
            }
            ponto.ListaAFDTRegistro2 = listaAFDTRegistro2;


            AFDT_Trailer AFDTTrailer = new AFDT_Trailer();
            ponto.AFDTTrailer = AFDTTrailer;


            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Arquivo AFDT (*.txt) | *.txt";
            dialog.Title = "Selecione o arquivo";
            dialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (dialog.ShowDialog() == true)
            {
                ponto.gerarArquivoAFDT(dialog.FileName);
            }

        }


        public void gerarACJEF(string pDataIni, string pDataFim)
        {
            ComponentePonto.ComponentePonto ponto = new ComponentePonto.ComponentePonto();

            ACJEF_Cabecalho ACJEFCabecalho = new ACJEF_Cabecalho();

            // Registro 1 - Cabecalho
            /*
            Campo01: String; // “000000000”.
            Campo02: String; // Tipo do registro, “1”.
            Campo03: String; // Tipo de identificador do empregador, “1” para CNPJ ou “2” para CPF.
            Campo04: String; // CNPJ ou CPF do empregador.
            Campo05: String; // CEI do empregador, quando existir.
            Campo06: String; // Razão social ou nome do empregador.
            Campo07: String; // Data inicial dos registros no arquivo, no formato “ddmmaaaa”.
            Campo08: String; // Data final dos registros no arquivo, no formato “ddmmaaaa”.
            Campo09: String; // Data de geração do arquivo, no formato “ddmmaaaa”.
            Campo10: String; // Horário da geração do arquivo, no formato “hhmm”.
            */
            ACJEFCabecalho.Campo03 = "1";
            ACJEFCabecalho.Campo04 = Empresa.Cnpj;
            ACJEFCabecalho.Campo05 = "";
            ACJEFCabecalho.Campo06 = Empresa.RazaoSocial;
            ACJEFCabecalho.Campo07 = System.DateTime.Parse(pDataIni).ToString("ddMMyyyy");
            ACJEFCabecalho.Campo08 = System.DateTime.Parse(pDataFim).ToString("ddMMyyyy");
            ACJEFCabecalho.Campo09 = DateTime.Today.ToString("ddMMyyyy");
            ACJEFCabecalho.Campo10 = DateTime.Now.ToString("HHmm");
            ponto.ACJEFCabecalho = ACJEFCabecalho;


            List<PontoHorarioDTO> listaPontoHorario = new List<PontoHorarioDTO>();
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    PontoHorarioDTO horario = new PontoHorarioDTO();
                    horario.Empresa = Empresa;
                   listaPontoHorario = serv.selectPontoHorario(horario); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (listaPontoHorario.Count > 0)
            {
                List<ACJEF_Registro2> listaACJEFRegistro2 = new List<ACJEF_Registro2>();
                for (int i = 0; i < listaPontoHorario.Count; i++)
                {
                    // Registro 2 - Horários Contratuais
                    /*
                    Campo01: String; // NSR.
                    Campo02: String; // Tipo do registro, “2”.
                    Campo03: String; // Código do Horário (CH), no formato “nnnn”.
                    Campo04: String; // Entrada, no formato “hhmm”.
                    Campo05: String; // Saída, no formato “hhmm”.
                    Campo06: String; // Início intervalo, no formato “hhmm”.
                    Campo07: String; // Fim intervalo, no formato “hhmm”.
                    */

                    ACJEF_Registro2 ACJEFRegistro2 = new ACJEF_Registro2();

                    ACJEFRegistro2.Campo03 = listaPontoHorario[i].Codigo;
                    if (listaPontoHorario[i].HoraInicioJornada.Trim().Length == 8)
                        ACJEFRegistro2.Campo04 = listaPontoHorario[i].HoraInicioJornada.Substring(0, 2) + listaPontoHorario[i].HoraInicioJornada.Substring(3, 2);
                    if (listaPontoHorario[i].HoraFimJornada.Trim().Length == 8)
                        ACJEFRegistro2.Campo05 = listaPontoHorario[i].HoraFimJornada.Substring(0, 2) + listaPontoHorario[i].HoraFimJornada.Substring(3, 2);
                    if (listaPontoHorario[i].Saida01.Trim().Length == 8)
                        ACJEFRegistro2.Campo06 = listaPontoHorario[i].Saida01.Substring(0, 2) + listaPontoHorario[i].Saida01.Substring(3, 2);
                    if (listaPontoHorario[i].Entrada02.Trim().Length == 8)
                        ACJEFRegistro2.Campo07 = listaPontoHorario[i].Entrada02.Substring(0, 2) + listaPontoHorario[i].Entrada02.Substring(3, 2);

                    listaACJEFRegistro2.Add(ACJEFRegistro2);
                }
                ponto.ListaACJEFRegistro2 = listaACJEFRegistro2;
            }


            List<ACJEF_Registro3> listaACJEFRegistro3 = new List<ACJEF_Registro3>();
            PontoFechamentoJornadaViewModel fechamento = new PontoFechamentoJornadaViewModel();

            for (int i = 0; i < fechamento.ListaPontoFechamentoJornada.Count; i++)
            {
                // Registro 3 - Detalhe
                /*
                Campo01: String; // NSR.
                Campo02: String; // tipo do registro, “3”.
                Campo03: String; // Número do PIS do empregado.
                Campo04: String; // Data de início da jornada, no formato “ddmmaaaa”.
                Campo05: String; // Primeiro horário de entrada da jornada, no formato “hhmm”.
                Campo06: String; // Código do horário (CH) previsto para a jornada, no formato “nnnn”.
                Campo07: String; // Horas diurnas não extraordinárias, no formato “hhmm”.
                Campo08: String; // Horas noturnas não extraordinárias, no formato “hhmm”.
                Campo09: String; // Horas extras 1, no formato “hhmm”.
                Campo10: String; // Percentual do adicional de horas extras 1, onde as 3 primeiras posições indicam a parte inteira e a seguinte a fração decimal.
                Campo11: String; // Modalidade da hora extra 1, assinalado com “D” se as horas extras forem diurnas e “N” se forem noturnas.
                Campo12: String; // Horas extras 2, no formato “hhmm”.
                Campo13: String; // Percentual do adicional de horas extras 2, onde as 3 primeiras posições indicam a parte inteira e a seguinte a fração decimal.
                Campo14: String; // Modalidade da hora extra 2, assinalado com “D” se as horas extras forem diurnas e “N” se forem noturnas.
                Campo15: String; // Horas extras 3, no formato “hhmm”.
                Campo16: String; // Percentual do adicional de horas extras 3, onde as 3 primeiras posições indicam a parte inteira e a seguinte a fração decimal.
                Campo17: String; // Modalidade da hora extra 3, assinalado com “D” se as horas extras forem diurnas e “N” se forem noturnas.
                Campo18: String; // Horas extras 4, no formato “hhmm”.
                Campo19: String; // Percentual do adicional de horas extras 4, onde as 3 primeiras posições indicam a parte inteira e a seguinte a fração decimal.
                Campo20: String; // Modalidade da hora extra 4, assinalado com “D” se as horas extras forem diurnas e “N” se forem noturnas.
                Campo21: String; // Horas de faltas e/ou atrasos.
                Campo22: String; // Sinal de horas para compensar. “1” se for horas a maior e “2” se for horas a menor.
                Campo23: String; // Saldo de horas para compensar no formato “hhmm”.
                */

                ACJEF_Registro3 ACJEFRegistro3 = new ACJEF_Registro3();

                ACJEFRegistro3.Campo03 = fechamento.ListaPontoFechamentoJornada[i].Colaborador.PisNumero;
                ACJEFRegistro3.Campo04 = fechamento.ListaPontoFechamentoJornada[i].DataFechamento.Value.ToString("ddMMyyyy");
                if (fechamento.ListaPontoFechamentoJornada[i].Entrada01.Trim().Length == 8)
                    ACJEFRegistro3.Campo05 = fechamento.ListaPontoFechamentoJornada[i].Entrada01.Substring(0, 2) + fechamento.ListaPontoFechamentoJornada[i].Entrada01.Substring(3, 2);
                ACJEFRegistro3.Campo06 = fechamento.ListaPontoFechamentoJornada[i].CodigoHorario;
                if (String.IsNullOrEmpty(fechamento.ListaPontoFechamentoJornada[i].CargaHorariaDiurna).ToString().Trim().Length == 8)
                    ACJEFRegistro3.Campo07 = fechamento.ListaPontoFechamentoJornada[i].CargaHorariaDiurna.Substring(0, 2) + fechamento.ListaPontoFechamentoJornada[i].CargaHorariaDiurna.Substring(3, 2);
                if (String.IsNullOrEmpty(fechamento.ListaPontoFechamentoJornada[i].CargaHorariaNoturna).ToString().Trim().Length == 8)
                    ACJEFRegistro3.Campo08 = fechamento.ListaPontoFechamentoJornada[i].CargaHorariaNoturna.Substring(0, 2) + fechamento.ListaPontoFechamentoJornada[i].CargaHorariaNoturna.Substring(3, 2);
                
                if (String.IsNullOrEmpty(fechamento.ListaPontoFechamentoJornada[i].HoraExtra01).ToString().Trim().Length == 8)
                    ACJEFRegistro3.Campo09 = fechamento.ListaPontoFechamentoJornada[i].HoraExtra01.Substring(0, 2) + fechamento.ListaPontoFechamentoJornada[i].HoraExtra01.Substring(3, 2);
                ACJEFRegistro3.Campo10 = fechamento.ListaPontoFechamentoJornada[i].PercentualHoraExtra01.Value.ToString("000") + "0";
                ACJEFRegistro3.Campo11 = fechamento.ListaPontoFechamentoJornada[i].ModalidadeHoraExtra01;

                if (String.IsNullOrEmpty(fechamento.ListaPontoFechamentoJornada[i].HoraExtra02).ToString().Trim().Length == 8)
                    ACJEFRegistro3.Campo12 = fechamento.ListaPontoFechamentoJornada[i].HoraExtra02.Substring(0, 2) + fechamento.ListaPontoFechamentoJornada[i].HoraExtra02.Substring(3, 2);
                ACJEFRegistro3.Campo13 = fechamento.ListaPontoFechamentoJornada[i].PercentualHoraExtra02.Value.ToString("000") + "0";
                ACJEFRegistro3.Campo14 = fechamento.ListaPontoFechamentoJornada[i].ModalidadeHoraExtra02;

                if (String.IsNullOrEmpty(fechamento.ListaPontoFechamentoJornada[i].HoraExtra03).ToString().Trim().Length == 8)
                    ACJEFRegistro3.Campo15 = fechamento.ListaPontoFechamentoJornada[i].HoraExtra03.Substring(0, 2) + fechamento.ListaPontoFechamentoJornada[i].HoraExtra03.Substring(3, 2);
                ACJEFRegistro3.Campo16 = fechamento.ListaPontoFechamentoJornada[i].PercentualHoraExtra03.Value.ToString("000") + "0";
                ACJEFRegistro3.Campo17 = fechamento.ListaPontoFechamentoJornada[i].ModalidadeHoraExtra03;

                if (String.IsNullOrEmpty(fechamento.ListaPontoFechamentoJornada[i].HoraExtra04).ToString().Trim().Length == 8)
                    ACJEFRegistro3.Campo18 = fechamento.ListaPontoFechamentoJornada[i].HoraExtra04.Substring(0, 2) + fechamento.ListaPontoFechamentoJornada[i].HoraExtra04.Substring(3, 2);
                ACJEFRegistro3.Campo19 = fechamento.ListaPontoFechamentoJornada[i].PercentualHoraExtra04.Value.ToString("000") + "0";
                ACJEFRegistro3.Campo20 = fechamento.ListaPontoFechamentoJornada[i].ModalidadeHoraExtra04;

                if (String.IsNullOrEmpty(fechamento.ListaPontoFechamentoJornada[i].FaltaAtraso).ToString().Trim().Length == 8)
                    ACJEFRegistro3.Campo21 = fechamento.ListaPontoFechamentoJornada[i].FaltaAtraso.Substring(0, 2) + fechamento.ListaPontoFechamentoJornada[i].FaltaAtraso.Substring(3, 2);
                
                ACJEFRegistro3.Campo22 = fechamento.ListaPontoFechamentoJornada[i].Compensar;

                if (String.IsNullOrEmpty(fechamento.ListaPontoFechamentoJornada[i].BancoHoras).ToString().Trim().Length == 8)
                    ACJEFRegistro3.Campo23 = fechamento.ListaPontoFechamentoJornada[i].BancoHoras.Substring(0, 2) + fechamento.ListaPontoFechamentoJornada[i].BancoHoras.Substring(3, 2);
                
                listaACJEFRegistro3.Add(ACJEFRegistro3);
            }
            ponto.ListaACJEFRegistro3 = listaACJEFRegistro3;


            ACJEF_Trailer ACJEFTrailer = new ACJEF_Trailer();
            ponto.ACJEFTrailer = ACJEFTrailer;


            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Arquivo ACJEF (*.txt) | *.txt";
            dialog.Title = "Selecione o arquivo";
            dialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (dialog.ShowDialog() == true)
            {
                ponto.gerarArquivoACJEF(dialog.FileName);
            }

        }

        public void processarFechamento()
        {
            try
            {
                // verifica se já existe um fechamento para o dia
                PontoClassificacaoJornadaDTO classificacao = new PontoClassificacaoJornadaDTO { Id = 1 };
                PontoFechamentoJornadaDTO fechamento = new PontoFechamentoJornadaDTO();
                fechamento.PontoClassificacaoJornada = classificacao;
                fechamento.Colaborador = new ColaboradorDTO { Id = ViewPontoMarcacaoSelected.IdColaborador };
                fechamento.DataFechamento = ViewPontoMarcacaoSelected.DataMarcacao;
                try
                {
                    using (ServicoPontoClient serv = new ServicoPontoClient())
                    {
                        //pega o horário comercial
                        PontoHorarioDTO horario = new PontoHorarioDTO { Nome = "COMERCIAL" };
                        List<PontoHorarioDTO> listaHorario = serv.selectPontoHorario(horario);
                        horario = listaHorario[0];

                        List<PontoFechamentoJornadaDTO> listaFechamento = serv.selectPontoFechamentoJornada(fechamento);

                        if (listaFechamento.Count > 0)
                        {
                            fechamento = listaFechamento[0];
                        }
                        fechamento.DiaSemana = fechamento.DataFechamento.Value.ToString("ddd", new CultureInfo("pt-BR"));
                        fechamento.CodigoHorario = horario.Codigo;
                        fechamento.CargaHorariaEsperada = horario.CargaHoraria;
                        fechamento.HoraInicioJornada = horario.HoraInicioJornada;
                        fechamento.HoraFimJornada = horario.HoraFimJornada;

                        serv.salvarAtualizarPontoFechamentoJornada(fechamento);

                        new PontoFechamentoJornadaViewModel().atualizarListaPontoFechamentoJornada(0);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
