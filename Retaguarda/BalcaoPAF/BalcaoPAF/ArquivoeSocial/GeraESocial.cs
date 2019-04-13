using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ContratosClient.Model
{
    class GeraESocial
    {
        public GeraESocial()
        {
        }

        //formato data: "yyyy-MM"
        public void gerarESocial1000(String dataInicio, String dataFim)
        {
            eSocial eSocial = new eSocial();
            eSocialEvtInfoEmpregador evtInfoEmpregador = new eSocialEvtInfoEmpregador();

            eSocial.evtInfoEmpregador = evtInfoEmpregador;
            evtInfoEmpregador.Id = "evtInfoEmpregador";

            TIdeCadastro ideCadastro = new TIdeCadastro();
            evtInfoEmpregador.ideEvento = ideCadastro;
            ideCadastro.tpAmb = (sbyte)3;
            ideCadastro.procEmi = (sbyte)1;
            ideCadastro.verProc = "1.0";

            TEmpregador ideEmpregador = new TEmpregador();
            evtInfoEmpregador.ideEmpregador = ideEmpregador;
            ideEmpregador.tpInsc = (sbyte)1;
            ideEmpregador.nrInsc = "0123456789";

            eSocialEvtInfoEmpregadorInfoEmpregador infoEmpregador = new eSocialEvtInfoEmpregadorInfoEmpregador();
            evtInfoEmpregador.infoEmpregador = infoEmpregador;

            eSocialEvtInfoEmpregadorInfoEmpregadorInclusao inclusao = new eSocialEvtInfoEmpregadorInfoEmpregadorInclusao();
            infoEmpregador.Item = inclusao;

            TIdePeriodo idePeriodo = new TIdePeriodo();
            inclusao.idePeriodo = idePeriodo;
            idePeriodo.iniValid = dataInicio;
            idePeriodo.fimValid = dataFim;

            TInfoEmpregador tInfoEmpregador = new TInfoEmpregador();
            inclusao.infoCadastro = tInfoEmpregador;
            tInfoEmpregador.nmRazao = "RAZAO SOCIAL DA EMPRESA";
            tInfoEmpregador.classTrib = "01";
            tInfoEmpregador.natJurid = "1234";
            tInfoEmpregador.indCoop = (sbyte)1;
            tInfoEmpregador.indConstr = (sbyte)1;
            tInfoEmpregador.indDesFolha = (sbyte)1;
            tInfoEmpregador.indOptRegEletron = (sbyte)1;
            tInfoEmpregador.multTabRubricas = "N";
            tInfoEmpregador.indEntEd = "N";
            tInfoEmpregador.indEtt = "N";
            tInfoEmpregador.nrRegEtt = "30";

            TInfoEmpregadorContato contato = new TInfoEmpregadorContato();
            tInfoEmpregador.contato = contato;
            contato.nmCtt = "NOME DO CONTATO";
            contato.cpfCtt = "11111111111";
            contato.foneFixo = "12345678";
            contato.foneCel = "12345678";
            contato.email = "email@empresa.com";

            TInfoEmpregadorSoftwareHouse softwareHouse = new TInfoEmpregadorSoftwareHouse();
            //tInfoEmpregador.softwareHouse[0] = softwareHouse;
            softwareHouse.cnpjSoftHouse = "12345678901234";
            softwareHouse.nmRazao = "T2Ti.com";
            softwareHouse.nmCont = "Claudio";
            softwareHouse.telefone = "6130425277";
            softwareHouse.email = "t2ti.com@gmail.com";

            TInfoEmpregadorInfoComplementares infoComplementares = new TInfoEmpregadorInfoComplementares();
            tInfoEmpregador.infoComplementares = infoComplementares;

            TInfoEmpregadorInfoComplementaresSituacaoPJ situacaoPJ = new TInfoEmpregadorInfoComplementaresSituacaoPJ();
            infoComplementares.situacaoPJ = situacaoPJ;
            situacaoPJ.indSitPJ = (sbyte)0;

            var serializer = new XmlSerializer(typeof(eSocial));
            using (var stream = new StreamWriter("C:\\T2Ti\\Arquivos\\eSocial_info_empregador.xml"))
                serializer.Serialize(stream, eSocial);            
        }

        //formato data: "yyyy-MM"
        public void gerarESocial1010(String dataInicio, String dataFim)
        {
            eSocial1 eSocial = new eSocial1();

            eSocialEvtTabRubrica evtTabRubrica = new eSocialEvtTabRubrica();
            eSocial.evtTabRubrica = evtTabRubrica;
            evtTabRubrica.Id = "evtTabRubrica";

            TIdeCadastro1 ideCadastro = new TIdeCadastro1();
            evtTabRubrica.ideEvento = ideCadastro;
            ideCadastro.tpAmb = (sbyte)3;
            ideCadastro.procEmi = (sbyte)1;
            ideCadastro.verProc = "1.0";

            TEmpregador1 empregador = new TEmpregador1();
            evtTabRubrica.ideEmpregador = empregador;
            empregador.tpInsc = (sbyte)1;
            empregador.nrInsc = "12345678";

            eSocialEvtTabRubricaInfoRubrica infoRubrica = new eSocialEvtTabRubricaInfoRubrica();
            evtTabRubrica.infoRubrica = infoRubrica;

            eSocialEvtTabRubricaInfoRubricaInclusao inclusao = new eSocialEvtTabRubricaInfoRubricaInclusao();
            infoRubrica.Item = inclusao;

            TIdeRubrica ideRubrica = new TIdeRubrica();
            inclusao.ideRubrica = ideRubrica;
            ideRubrica.codRubr = "codRubrica";
            ideRubrica.iniValid = dataInicio;
            ideRubrica.fimValid = dataFim;

            TDadosRubrica dadosRubrica = new TDadosRubrica();
            inclusao.dadosRubrica = dadosRubrica;
            dadosRubrica.dscRubr = "nomeDaRubrica";
            dadosRubrica.natRubr = "1000";
            dadosRubrica.tpRubr = (sbyte)1;
            dadosRubrica.codIncCP = "00";
            dadosRubrica.codIncIRRF = "00";
            dadosRubrica.codIncFGTS = "00";
            dadosRubrica.codIncSIND = "00";
            dadosRubrica.repDSR = "S";
            dadosRubrica.rep13 = "S";
            dadosRubrica.repFerias = "N";
            dadosRubrica.repAviso = "N";
            dadosRubrica.observacao = "Observações sobre a rubrica";

            var serializer = new XmlSerializer(typeof(eSocial1));
            using (var stream = new StreamWriter("C:\\T2Ti\\Arquivos\\eSocial_info_rubrica.xml"))
                serializer.Serialize(stream, eSocial); 
        }

    }

}
