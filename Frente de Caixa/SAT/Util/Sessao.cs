using NFCe.Controller;
using NFCe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NFCe.Util
{
    public class Sessao
    {
        
        string Filtro;
        public bool MenuAberto;
        public Tipos.StatusCaixa StatusCaixa;

        public NfceOperadorDTO Usuario;
        public NfceConfiguracaoDTO Configuracao;
        public NfceMovimentoDTO Movimento;
        public NfeCabecalhoDTO VendaAtual;

        public List<NfceTipoPagamentoDTO> ListaTipoPagamento;


        private Sessao() 
        {
        }

        private static Sessao instance;

        public static Sessao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sessao();
                }
                return instance;
            }
        }

        public void PopulaObjetosPrincipais()
        {
            try
            {
                Filtro = "StatusMovimento=" + Biblioteca.QuotedStr("A") + " or StatusMovimento=" + Biblioteca.QuotedStr("T");
                Movimento = NfceMovimentoController.ConsultaNfceMovimento(Filtro);
                Configuracao = NfceConfiguracaoController.ConsultaNfceConfiguracao("Id=1");

                //Exercício: Como evitar um erro de ponteiro nulo nesses objetos?
                Configuracao.NfceConfiguracaoBalanca = new NfceConfiguracaoBalancaDTO();
                Configuracao.NfceConfiguracaoLeitorSer = new NfceConfiguracaoLeitorSerDTO();

                ListaTipoPagamento = NfceTipoPagamentoController.ConsultaNfceTipoPagamentoLista("Id>0").ToList();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static int GerarNumeroSessao()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 999999);
            return randomNumber;
        }

        public static string CodigoAtivacao()
        {
            return "12345678";
        }
    }
}
