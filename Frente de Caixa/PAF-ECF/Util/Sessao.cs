using PafEcf.Controller;
using PafEcf.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PafEcf.Util
{
    public class Sessao
    {
        
        string Filtro;
        public string PathIntegracao;
        public bool MenuAberto;
        public Tipos.StatusCaixa StatusCaixa;

        public EcfOperadorDTO Usuario;
        public EcfConfiguracaoDTO Configuracao;
        public EcfMovimentoDTO Movimento;
        public R01DTO R01;
        public EcfVendaCabecalhoDTO VendaAtual;

        public List<string> ECFsAutorizados;

        public List<EcfTipoPagamentoDTO> ListaTipoPagamento;
        public List<EcfImpressoraDTO> ListaImpressora;


        private Sessao() 
        {
            ECFsAutorizados = new List<string>();
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
                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");
                PathIntegracao = ArquivoXML.GetElementsByTagName("remoteApp").Item(0).InnerText.Trim();
                ECFsAutorizados.Add(Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("serie1").Item(0).InnerText.Trim()));
                //
                R01 = R01Controller.ConsultaR01("Id=1");
                Filtro = "StatusMovimento=" + Biblioteca.QuotedStr("A") + " or StatusMovimento=" + Biblioteca.QuotedStr("T");
                Movimento = EcfMovimentoController.ConsultaEcfMovimento(Filtro);
                Configuracao = EcfConfiguracaoController.ConsultaEcfConfiguracao("Id=1");
                ListaTipoPagamento = EcfTipoPagamentoController.ConsultaEcfTipoPagamentoLista("Id>0").ToList();
                ListaImpressora = EcfImpressoraController.ConsultaEcfImpressoraLista("Id>0").ToList();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }
    }
}
