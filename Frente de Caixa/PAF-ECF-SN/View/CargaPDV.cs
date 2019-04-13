/********************************************************************************
Title: T2TiPDV
Description: Controle de importacao e exportacao de Arquivos

The MIT License

Copyright: Copyright (C) 2014 T2Ti.COM

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

       The author may be contacted at:
           alberteije@gmail.com

@author T2Ti.COM
@version 2.0
********************************************************************************/


using System;
using System.IO;
using System.Windows.Forms;
using PafEcf.Util;
using PafEcf.Controller;
using PafEcf.DTO;
using System.Runtime.Serialization.Json;

namespace PafEcf.View
{

    public partial class CargaPDV : Form
    {

        public static string PathLocal, PathRemoto, Procedimento, Filtro, JsonString;
        public static ProgressBar Barra;

        public CargaPDV()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            Barra = this.ProgressBar1;
            Timer1.Enabled = true;
        }

        public static bool ImportaCarga(string pRemoteApp)
        {
            return true;
        }
      
        public static void ExportarRegistro()
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Barra.Maximum = 100;
            Barra.Value = 5;

            Timer1.Enabled = false;

            MemoryStream StreamJson = new MemoryStream();

            if (Procedimento == "EXPORTA_VENDA")
            {
                Filtro = "Id = " + PAFUtil.RecuperarIdUltimaVenda();
                EcfVendaCabecalhoDTO Venda = VendaController.ConsultaEcfVendaCabecalho(Filtro);

                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(EcfVendaCabecalhoDTO));
                SerializaJson.WriteObject(StreamJson, Venda);

                PathLocal = Application.StartupPath + "\\Integracao\\VENDA_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                PathRemoto = Sessao.Instance.PathIntegracao + "VENDA_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            if (Procedimento == "EXPORTA_MOVIMENTO")
            {
                Filtro = "Id = " + Sessao.Instance.Movimento.Id;
                EcfMovimentoDTO Movimento = EcfMovimentoController.ConsultaEcfMovimento(Filtro);

                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(EcfMovimentoDTO));
                SerializaJson.WriteObject(StreamJson, Movimento);

                PathLocal = Application.StartupPath + "\\Integracao\\MOVIMENTO_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                PathRemoto = Sessao.Instance.PathIntegracao + "MOVIMENTO_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            if (Procedimento == "EXPORTA_R02")
            {
                R02DTO R02 = R02Controller.ConsultaR02(Filtro);

                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(R02DTO));
                SerializaJson.WriteObject(StreamJson, R02);

                PathLocal = Application.StartupPath + "\\Integracao\\R02_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                PathRemoto = Sessao.Instance.PathIntegracao + "R02_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            if (Procedimento == "EXPORTA_R06")
            {
                R06DTO R06 = R06Controller.ConsultaR06(Filtro);

                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(R06DTO));
                SerializaJson.WriteObject(StreamJson, R06);

                PathLocal = Application.StartupPath + "\\Integracao\\R06_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                PathRemoto = Sessao.Instance.PathIntegracao + "R06_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            if (Procedimento == "EXPORTA_SINTEGRA60M")
            {
                Sintegra60mDTO Sintegra60M = Sintegra60MController.ConsultaSintegra60M(Filtro);

                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(Sintegra60mDTO));
                SerializaJson.WriteObject(StreamJson, Sintegra60M);

                PathLocal = Application.StartupPath + "\\Integracao\\SINTEGRA60M_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                PathRemoto = Sessao.Instance.PathIntegracao + "SINTEGRA60M_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            if (Procedimento == "EXPORTA_NF")
            {
                NotaFiscalCabecalhoDTO NotaFiscal = NotaFiscalController.ConsultaNotaFiscalCabecalho(Filtro);

                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(NotaFiscalCabecalhoDTO));
                SerializaJson.WriteObject(StreamJson, NotaFiscal);

                PathLocal = Application.StartupPath + "\\Integracao\\SINTEGRA60M_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                PathRemoto = Sessao.Instance.PathIntegracao + "SINTEGRA60M_" + Sessao.Instance.Configuracao.EcfCaixa.Nome + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }

            StreamReader LerStreamJson = new StreamReader(StreamJson);
            StreamJson.Position = 0;
            JsonString = LerStreamJson.ReadToEnd();

            System.IO.File.WriteAllText(PathLocal, JsonString);
            File.Copy(PathLocal, PathRemoto, true);
            
            Barra.Value = 100;
            this.Close();
        }

    }

}
