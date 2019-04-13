using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContratosClient.ContratosReference;
using ContratosClient.Command;
using SearchWindow;
using ContratosClient.Model;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ContratosClient.ViewModel.Contratos
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
    public class ContratoViewModel : ERPViewModelBase
    {
        public ObservableCollection<ContratoDTO> ListaContrato { get; set; }
        private ContratoDTO _ContratoSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }
        public ContratoHistFaturamentoDTO ContratoHistFaturamentoSelected { get; set; }
        public ContratoHistoricoReajusteDTO ContratoHistoricoReajusteSelected { get; set; }
        public ContratoPrevFaturamentoDTO ContratoPrevFaturamentoSelected { get; set; }


        /// EXERCICIO:
        /// Adapte o sistema para utilizar as tabelas mestre/detalhe e armazenar mais do que um documento

        public ContratoViewModel()
        {
            try
            {
                ListaContrato = new ObservableCollection<ContratoDTO>();
                primeiroResultado = 0;
                this.atualizarListaContrato(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContratoDTO ContratoSelected
        {
            get { return _ContratoSelected; }
            set
            {
                _ContratoSelected = value;
                notifyPropertyChanged("ContratoSelected");
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
                            this.atualizarListaContrato(1);
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
                            this.atualizarListaContrato(-1);
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

        public void salvarAtualizarContrato()
        {
            try
            {
                using (ServicoContratosClient serv = new ServicoContratosClient())
                {
                    serv.salvarAtualizarContrato(ContratoSelected);
                    ContratoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaContrato(int pagina)
        {
            try
            {
                using (ServicoContratosClient serv = new ServicoContratosClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<ContratoDTO> listaServ = serv.selectContratoPagina(primeiroResultado, QUANTIDADE_PAGINA, new ContratoDTO());

                    ListaContrato.Clear();

                    foreach (ContratoDTO objAdd in listaServ)
                    {
                        ListaContrato.Add(objAdd);
                    }
                    ContratoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirContrato()
        {
            try
            {
                using (ServicoContratosClient serv = new ServicoContratosClient())
                {
                    serv.deleteContrato(ContratoSelected);
                    ContratoSelected = null;
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

        public void gerarContrato()
        {
            PessoaDTO fornecedor = ContratoSelected.ContratoSolicitacaoServico.Fornecedor.Pessoa;
            PessoaDTO cliente = ContratoSelected.ContratoSolicitacaoServico.Cliente.Pessoa;

            using (ServicoContratosClient serv = new ServicoContratosClient())
            {
                cliente = serv.selectPessoa(cliente);
                fornecedor = serv.selectPessoa(fornecedor);
            }

            string caminho = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (File.Exists(caminho + @"\"+ContratoSelected.Id+".docx"))
                File.Delete(caminho + @"\" + ContratoSelected.Id + ".docx");

            File.Copy(caminho + @"\Modelos\contrato_servico.docx", caminho + @"\" + ContratoSelected.Id + ".docx");

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(caminho + @"\" + ContratoSelected.Id + ".docx", true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                TextInfo TI = new CultureInfo("pt-BR", false).TextInfo;

                Regex regexText = new Regex("#CONTRATANTE#");
                docText = regexText.Replace(docText, TI.ToTitleCase( cliente.Nome.ToLower()));

                regexText = new Regex("#ENDERECO_CONTRATANTE#");
                docText = regexText.Replace(docText, TI.ToTitleCase(cliente.Endereco.Logradouro.ToLower()) + ", " +
                    cliente.Endereco.Numero + ", " + TI.ToTitleCase(cliente.Endereco.Bairro.ToLower()));

                regexText = new Regex("#CIDADE_CONTRATANTE#");
                docText = regexText.Replace(docText, TI.ToTitleCase(cliente.Endereco.Cidade));

                regexText = new Regex("#UF_CONTRATANTE#");
                docText = regexText.Replace(docText, TI.ToTitleCase(cliente.Endereco.Uf));

                regexText = new Regex("#CONTRATADO#");
                docText = regexText.Replace(docText, TI.ToTitleCase(fornecedor.Nome.ToLower()));

                regexText = new Regex("#ENDERECO_CONTRATADO#");
                docText = regexText.Replace(docText, TI.ToTitleCase(fornecedor.Endereco.Logradouro.ToLower()) + ", " +
                    fornecedor.Endereco.Numero + ", " + TI.ToTitleCase(fornecedor.Endereco.Bairro.ToLower()));

                regexText = new Regex("#CIDADE_CONTRATADO#");
                docText = regexText.Replace(docText, TI.ToTitleCase(cliente.Endereco.Cidade));

                regexText = new Regex("#UF_CONTRATADO#");
                docText = regexText.Replace(docText, TI.ToTitleCase(cliente.Endereco.Uf));

                regexText = new Regex("#TIPO_SERVICO#");
                docText = regexText.Replace(docText, ContratoSelected.ContratoSolicitacaoServico.Descricao);

                regexText = new Regex("#VALOR#");
                docText = regexText.Replace(docText, ContratoSelected.Valor != null ? ((decimal)ContratoSelected.Valor).ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR")) : "0,00");

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }

        public void pesquisarTipoContrato()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TipoContratoDTO),
                    typeof(ServicoContratos));

                if (searchWindow.ShowDialog() == true)
                {
                    ContratoSelected.TipoContrato = (TipoContratoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContratoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void pesquisarContratoSolicitacaoServico()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ContratoSolicitacaoServicoDTO),
                    typeof(ServicoContratos));

                if (searchWindow.ShowDialog() == true)
                {
                    ContratoSelected.ContratoSolicitacaoServico = (ContratoSolicitacaoServicoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ContratoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
