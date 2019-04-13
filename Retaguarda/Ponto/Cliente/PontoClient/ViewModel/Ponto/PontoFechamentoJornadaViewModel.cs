using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PontoClient.ServicoPontoReference;
using PontoClient.Command;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;

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
    public class PontoFechamentoJornadaViewModel : ERPViewModelBase
    {
        public ObservableCollection<PontoFechamentoJornadaDTO> ListaPontoFechamentoJornada { get; set; }
        private PontoFechamentoJornadaDTO _PontoFechamentoJornadaSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public PontoFechamentoJornadaViewModel()
        {
            try
            {
                ListaPontoFechamentoJornada = new ObservableCollection<PontoFechamentoJornadaDTO>();
                primeiroResultado = 0;
                this.atualizarListaPontoFechamentoJornada(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PontoFechamentoJornadaDTO PontoFechamentoJornadaSelected
        {
            get { return _PontoFechamentoJornadaSelected; }
            set
            {
                _PontoFechamentoJornadaSelected = value;
                notifyPropertyChanged("PontoFechamentoJornadaSelected");
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
                            this.atualizarListaPontoFechamentoJornada(1);
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
                            this.atualizarListaPontoFechamentoJornada(-1);
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

        public void salvarAtualizarPontoFechamentoJornada()
        {
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    serv.salvarAtualizarPontoFechamentoJornada(PontoFechamentoJornadaSelected);
                    PontoFechamentoJornadaSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaPontoFechamentoJornada(int pagina)
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

                    List<PontoFechamentoJornadaDTO> listaServ = serv.selectPontoFechamentoJornadaPagina(primeiroResultado, QUANTIDADE_PAGINA, new PontoFechamentoJornadaDTO());

                    ListaPontoFechamentoJornada.Clear();

                    foreach (PontoFechamentoJornadaDTO objAdd in listaServ)
                    {
                        ListaPontoFechamentoJornada.Add(objAdd);
                    }
                    PontoFechamentoJornadaSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirPontoFechamentoJornada()
        {
            try
            {
                using (ServicoPontoClient serv = new ServicoPontoClient())
                {
                    serv.deletePontoFechamentoJornada(PontoFechamentoJornadaSelected);
                    PontoFechamentoJornadaSelected = null;
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

        public void gerarEspelho()
        {
            ColaboradorDTO colaborador = PontoFechamentoJornadaSelected.Colaborador;

            string caminho = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string arquivo = caminho + @"\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
            File.Copy(caminho + @"\Layout\LayoutPonto.docx", arquivo);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(arquivo, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                TextInfo TI = new CultureInfo("pt-BR", false).TextInfo;

                Regex regexText = new Regex("#EMPREGADOR#");
                docText = regexText.Replace(docText, TI.ToTitleCase(Empresa.RazaoSocial));

                regexText = new Regex("#ENDERECO#");
                docText = regexText.Replace(docText, TI.ToTitleCase(Empresa.CodigoIbgeCidade.ToString()));

                regexText = new Regex("#EMPREGADO#");
                docText = regexText.Replace(docText, TI.ToTitleCase(colaborador.Pessoa.Nome));

                regexText = new Regex("#ADMISSAO#");
                docText = regexText.Replace(docText, TI.ToTitleCase(colaborador.DataAdmissao.ToString()));

                regexText = new Regex("#EMITIDO_EM#");
                docText = regexText.Replace(docText, TI.ToTitleCase(DateTime.Now.ToString("dd/MM/yyyy")));

                regexText = new Regex("#PERIODO#");
                docText = regexText.Replace(docText, TI.ToTitleCase("Periodo"));

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }

                /// EXERCICIO:
                /// Gere o espelho de ponto usando o Microsoft Word - Observe o módulo Contratos

                MessageBox.Show("Arquivo " + arquivo + " gerado com sucesso!");
            }
        
        }
    }
}
