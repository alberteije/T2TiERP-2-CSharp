using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using ExportarParaArquivo;
using ContasReceberClient.ContasReceberService;
using reportman;

namespace ContasReceberClient.ViewModel
{
    

    public class ERPViewModelBase : INotifyPropertyChanged
    {
        public IList<ViewControleAcessoDTO> ListaControleAcesso = new List<ViewControleAcessoDTO>();

        public EmpresaDTO Empresa = new EmpresaDTO { Id = 1 };
        public static UsuarioDTO UsuarioLogado = new UsuarioDTO();
        public ViewControleAcessoDTO ControleAcesso;
        public const int QUANTIDADE_PAGINA = 20;
        
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void notifyPropertyChanged(String propertyName)
        {
            checkIfPropertyNameExists(propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        [Conditional("DEBUG")]
        private void checkIfPropertyNameExists(String propertyName)
        {
            Type type = this.GetType();
            Debug.Assert(
              type.GetProperty(propertyName) != null,
              propertyName + " propriedade não encontrada : " + type.FullName);
        }
        
        public void exportarDataGrid(ExportarParaArquivo.Formato formato, System.Windows.Controls.DataGrid dg)
        {
            if (dg.HasItems)
            {
                Exportar exportar = new Exportar(formato);
                exportar.exportarDataGrid(dg);
            }
            else
                throw new Exception("Não há itens a serem exportados.");
        }

        public void acesso(int papel, String formulario)
        {
            try
            {
                using (ContasReceberServiceClient serv = new ContasReceberServiceClient())
                {
                    ViewControleAcessoDTO ControleAcesso = new ViewControleAcessoDTO();
                    ControleAcesso.IdPapel = papel;
                    ControleAcesso.Formulario = formulario;
                    List<ViewControleAcessoDTO> listaServ = serv.selectControleAcesso(ControleAcesso);

                    ListaControleAcesso.Clear();

                    foreach (ViewControleAcessoDTO objAdd in listaServ)
                    {
                        ListaControleAcesso.Add(objAdd);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Implementação para o primeiro ciclo do ERP
        public void exibirRelatorio(String Arquivo, String Janela, String ConsultaSQL)
        {
            try
            {
                string NomeArquivo = Arquivo + ".rep";
                //
                string parTITULORELATORIO = "Relatório - " + Janela;
                string parTITULOSOFTHOUSE = "T2Ti.COM";
                string parTITULORODAPE = "T2Ti Tecnologia da Informação Ltda. - (61)3042.5277";
                //
                string ConteudoServidor = NomeArquivo + "|" + ConsultaSQL + "|" + parTITULORELATORIO + "|" + parTITULOSOFTHOUSE + "|" + parTITULORODAPE;

                ReportManX rp = new ReportManX();

                rp.ExecuteRemote("localhost", 3060, "Admin", "", "T2Ti", ConteudoServidor);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        /*
        public bool gerarRemessa()
        {
            try
            {
                string codCarteira = "18";
                int codBanco = 1;

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Arquivos EDI remessa (*.rem) | *.rem";
                dialog.Title = "Selecione o arquivo de remessa";
                dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                dialog.FileName = dialog.InitialDirectory + "\\cnab" + codBanco + ".rem";

                if (dialog.ShowDialog() != true)
                {
                    return false;
                }
                string path = dialog.FileName;

                Boletos listaBoleto = new Boletos();
                IBanco banco = new Banco(codBanco);
                Cedente cedente = new Cedente("10.793.118/0001-78", "T2Ti.com", "4733", "3", "9446", "3");
                cedente.Convenio = 123456;
                cedente.Codigo = 12345;
                cedente.Carteira = codCarteira;
                
                foreach (ParcelaReceberDTO parcelaReceber in lancamentoReceberSelected.listaParcelaReceber)
                {
                    //                    Boleto boleto = new Boleto((DateTime)parcelaReceber.dataVencimento, (decimal)parcelaReceber.valor,
                    //                        codCarteira, "01030405001", cedente);
                    //                    Boleto boleto = new Boleto((DateTime)parcelaReceber.dataVencimento, (decimal)parcelaReceber.valor,
                    //                        codCarteira, "37465", cedente);
                    Boleto boleto = new Boleto((DateTime)parcelaReceber.dataVencimento, (decimal)parcelaReceber.valor,
                        codCarteira, "12345612345", cedente);

                    Sacado sacado = new Sacado("000.000.000-00", "Cliente");
                    EspecieDocumento especDoc = new EspecieDocumento(codBanco, 2);
                    Endereco enderecoCliente = new Endereco();
                    enderecoCliente.Bairro = "Centro";
                    enderecoCliente.Cidade = "Brasilia";
                    enderecoCliente.CEP = "71936250";
                    enderecoCliente.UF = "DF";
                    enderecoCliente.End = "Av Araucarias 1135";
                    sacado.Endereco = enderecoCliente;
                    boleto.Sacado = sacado;
                    boleto.Cedente = cedente;
                    boleto.EspecieDocumento = especDoc;
                    boleto.Banco = new Banco(codBanco);
                    boleto.DataDocumento = DateTime.Now;
                    boleto.DataVencimento = (DateTime)parcelaReceber.dataVencimento;
                    boleto.ValorBoleto = (decimal)parcelaReceber.valor;
                    boleto.NumeroDocumento = "1111111";

                    listaBoleto.Add(boleto);
                }

                FileInfo fiArquivoCNAB = new FileInfo(path);
                FileStream fsArquivoCNAB = fiArquivoCNAB.Create();

                ArquivoRemessa arquivo = new ArquivoRemessa(TipoArquivo.CNAB240);
                arquivo.GerarArquivoRemessa("0", banco, cedente, listaBoleto, fsArquivoCNAB, 1);
                fsArquivoCNAB.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool importarRetorno()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Arquivos EDI retorno (*.ret) | *.ret";
                dialog.Title = "Selecione o arquivo de retorno";
                dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != true)
                {
                    return false;
                }
                string path = dialog.FileName;
                FileStream fsArquivoRet = File.Open(path, FileMode.Open);

                int codBanco = 1;
                ArquivoRetornoCNAB240 arquivoRetorno = new ArquivoRetornoCNAB240();
                arquivoRetorno.LerArquivoRetorno(new Banco(codBanco), fsArquivoRet);

                int cont = 0;
                foreach (DetalheRetornoCNAB240 detalheRetorno in arquivoRetorno.ListaDetalhes)
                {
                     if (lancamentoReceberSelected.listaParcelaReceber.Count > cont)
                     {
                         ParcelaRecebimentoDTO parc = new ParcelaRecebimentoDTO();
                         parc.dataRecebimento = detalheRetorno.SegmentoU.DataCredito;
                         parc.historico = "Cód. Banco: " + detalheRetorno.SegmentoT.CodigoBanco + " NN: " + detalheRetorno.SegmentoT.NossoNumero;
                         parc.valorPago = detalheRetorno.SegmentoU.ValorPagoPeloSacado;

                         if (lancamentoReceberSelected.listaParcelaReceber[cont].listaParcelaRecebimento == null)
                             lancamentoReceberSelected.listaParcelaReceber[cont].listaParcelaRecebimento = new List<ParcelaRecebimentoDTO>();

                         lancamentoReceberSelected.listaParcelaReceber[cont].listaParcelaRecebimento.Add(parc);
                     }
                    cont++;
                }

                fsArquivoRet.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         */


    }
}
