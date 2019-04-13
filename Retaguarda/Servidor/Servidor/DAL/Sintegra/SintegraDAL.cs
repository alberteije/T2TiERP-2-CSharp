using System;
using System.Collections.Generic;
using ACBrFramework.Sped;
using System.IO;
using NHibernate;
using Servidor.NHibernate;
using System.Collections;
using Servidor.Util;
using Servidor.Model;


namespace Servidor.DAL
{

    public class SintegraDAL
    {
        public ACBrFramework.Sintegra.ACBrSintegra ACBrSintegra { get; set; }

        private EmpresaDTO Empresa;
        private int CodigoConvenio, FinalidadeArquivo, NaturezaInformacao, IdEmpresa, IdContador, Inventario;
        private String DataInicial, DataFinal;
        private ISession Session;

        String consultaSql = "";

        public SintegraDAL()
        {
            ACBrSintegra = new ACBrFramework.Sintegra.ACBrSintegra();
            ACBrSintegra.FileName = "C:\\T2Ti\\Arquivos\\Sintegra.txt";
        }

        #region REGISTRO TIPO 10 - MESTRE DO ESTABELECIMENTO
        public void GerarRegistro10()
        {
            Empresa = new EmpresaDAL(Session).SelectId(IdEmpresa);

            ACBrSintegra.Registro10.CNPJ = Empresa.Cnpj;
            ACBrSintegra.Registro10.Inscricao = Empresa.InscricaoEstadual;
            ACBrSintegra.Registro10.RazaoSocial = Empresa.RazaoSocial;
            ACBrSintegra.Registro10.Cidade = Empresa.EnderecoPrincipal.Cidade;
            ACBrSintegra.Registro10.Estado = Empresa.EnderecoPrincipal.Uf;
            ACBrSintegra.Registro10.Telefone = Empresa.EnderecoPrincipal.Fone;
            ACBrSintegra.Registro10.DataInicial = Convert.ToDateTime(DataInicial); 
            ACBrSintegra.Registro10.DataFinal = Convert.ToDateTime(DataFinal); 
            ACBrSintegra.Registro10.CodigoConvenio = CodigoConvenio;
            ACBrSintegra.Registro10.NaturezaInformacoes = NaturezaInformacao;
            ACBrSintegra.Registro10.FinalidadeArquivo = FinalidadeArquivo;
        }
        #endregion

        #region Registro Tipo 11 - Dados Complementares do Informante
        public void GerarRegistro11()
        {
            ACBrSintegra.Registro11.Endereco = Empresa.EnderecoPrincipal.Logradouro;
            ACBrSintegra.Registro11.Numero = Empresa.EnderecoPrincipal.Numero;
            ACBrSintegra.Registro11.Bairro = Empresa.EnderecoPrincipal.Bairro;
            ACBrSintegra.Registro11.Cep = Empresa.EnderecoPrincipal.Cep;
            ACBrSintegra.Registro11.Responsavel = Empresa.Contato;
            ACBrSintegra.Registro11.Telefone = Empresa.EnderecoPrincipal.Fone;            
        }
        #endregion

        #region REGISTRO TIPO 50 - Nota Fiscal, modelo 1 ou 1-A (código 01), quanto ao ICMS, a critério de cada UF, Nota Fiscal do Produtor, modelo 4 (código 04), Nota Fiscal/Conta de Energia Elétrica, modelo 6 (código 06), Nota Fiscal de Serviço de Comunicação, modelo 21 (código 21), Nota Fiscal de Serviços de Telecomunicações, modelo 22 (código 22), Nota Fiscal Eletrônica, modelo 55 (código 55).
        public void GerarRegistro50()
        {
            consultaSql = "from NfeCabecalhoDTO where DataHoraEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<NfeCabecalhoDTO> ListaNFeCabecalho = new NHibernateDAL<NfeCabecalhoDTO>(Session).SelectListaSql<NfeCabecalhoDTO>(consultaSql);

            if (ListaNFeCabecalho != null)
            {
                foreach (NfeCabecalhoDTO NFeCabecalho in ListaNFeCabecalho)
                {
                    var Registro50 = new ACBrFramework.Sintegra.SintegraRegistro50();
                    Registro50.CPFCNPJ = Empresa.Cnpj;
                    Registro50.Inscricao = Empresa.InscricaoEstadual;
                    Registro50.DataDocumento = NFeCabecalho.DataHoraEmissao.Value;
                    Registro50.UF = Empresa.EnderecoPrincipal.Uf;
                    Registro50.ValorContabil = NFeCabecalho.ValorTotal.Value;
                    Registro50.Modelo = NFeCabecalho.CodigoModelo;
                    Registro50.Serie = NFeCabecalho.Serie;
                    Registro50.Numero = NFeCabecalho.Numero;
                    Registro50.EmissorDocumento = "P";
                    Registro50.BasedeCalculo = NFeCabecalho.BaseCalculoIcms.Value;
                    Registro50.Icms = NFeCabecalho.ValorIcms.Value;
                    Registro50.Outras = NFeCabecalho.ValorDespesasAcessorias.Value;
                    Registro50.Situacao = "N";
                    ACBrSintegra.Registro50.Add(Registro50);

                    // REGISTRO TIPO 51 - TOTAL DE NOTA FISCAL QUANTO AO IPI
                    // REGISTRO TIPO 53 - SUBSTITUIÇÃO TRIBUTÁRIA
                    //{ Não Implementado }

                    // REGISTRO TIPO 54 - PRODUTO
                    consultaSql = "from ViewSpedNfeDetalheDTO where IdNfeCabecalho = " + NFeCabecalho.Id;
                    IList<ViewSpedNfeDetalheDTO> ListaNFeDetalhe = new NHibernateDAL<ViewSpedNfeDetalheDTO>(Session).SelectListaSql<ViewSpedNfeDetalheDTO>(consultaSql);
                    if (ListaNFeDetalhe != null)
                    {
                        foreach (ViewSpedNfeDetalheDTO NFeDetalhe in ListaNFeDetalhe)
                        {
                            var Registro54 = new ACBrFramework.Sintegra.SintegraRegistro54();
                            Registro54.CPFCNPJ = Empresa.Cnpj;
                            Registro54.Modelo = NFeCabecalho.CodigoModelo;
                            Registro54.Serie = NFeCabecalho.Serie;
                            Registro54.Numero = NFeCabecalho.Numero;
                            Registro54.CFOP = NFeDetalhe.Cfop.ToString();
                            Registro54.CST = NFeDetalhe.CstIcms;
                            Registro54.NumeroItem = NFeDetalhe.NumeroItem;
                            Registro54.Codigo = NFeDetalhe.Gtin;
                            Registro54.Descricao = NFeDetalhe.NomeProduto;
                            Registro54.Quantidade = NFeDetalhe.QuantidadeComercial;
                            Registro54.Valor = NFeDetalhe.ValorTotal;
                            Registro54.ValorDescontoDespesa = NFeDetalhe.ValorDesconto;
                            Registro54.BasedeCalculo = NFeDetalhe.BaseCalculoIcms;
                            Registro54.BaseST = NFeDetalhe.ValorBaseCalculoIcmsSt;
                            Registro54.ValorIpi = NFeDetalhe.ValorIpi;
                            Registro54.Aliquota = NFeDetalhe.AliquotaIcms;
                            ACBrSintegra.Registro54.Add(Registro54);

                            // REGISTRO TIPO 75 - CÓDIGO DE PRODUTO OU SERVIÇO
                            var Registro75 = new ACBrFramework.Sintegra.SintegraRegistro75();
                            Registro75.DataInicial = Convert.ToDateTime(DataInicial);
                            Registro75.DataFinal = Convert.ToDateTime(DataFinal); 
                            Registro75.Codigo = NFeDetalhe.Gtin;
                            Registro75.NCM = NFeDetalhe.Ncm;
                            Registro75.Descricao = NFeDetalhe.NomeProduto;
                            Registro75.Unidade = NFeDetalhe.UnidadeComercial;
                            Registro75.AliquotaIpi = NFeDetalhe.AliquotaIpi;
                            Registro75.AliquotaICMS = NFeDetalhe.AliquotaIcms;
                            ACBrSintegra.Registro75.Add(Registro75);
                        }
                    }

                    // REGISTRO TIPO 55 - GUIA NACIONAL DE RECOLHIMENTO DE TRIBUTOS ESTADUAIS
                    // REGISTRO TIPO 56 - OPERAÇÕES COM VEÍCULOS AUTOMOTORES NOVOS
                    // REGISTRO TIPO 57 - NÚMERO DE LOTE DE FABRICAÇÃO DE PRODUTO
                    //{ Não Implementado }

                }
            }            
        }
        #endregion

        #region Registro Tipo 60 - Cupom Fiscal, Cupom Fiscal - PDV ,e os seguintes Documentos Fiscais quando emitidos por Equipamento Emissor de Cupom Fiscal: Bilhete de Passagem Rodoviário (modelo 13), Bilhete de Passagem Aquaviário (modelo 14), Bilhete de Passagem e Nota de Bagagem (modelo 15), Bilhete de Passagem Ferroviário (modelo 16), e Nota Fiscal de Venda a Consumidor (modelo 2) 
        public void GerarRegistro60()
        {
            // Registro Tipo 60 - Mestre (60M): Identificador do equipamento
            consultaSql = "from EcfSintegra60mDTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<EcfSintegra60mDTO> Lista60M = new NHibernateDAL<EcfSintegra60mDTO>(Session).SelectListaSql<EcfSintegra60mDTO>(consultaSql);

            if (Lista60M != null)
            {
                foreach (EcfSintegra60mDTO Item60M in Lista60M)
                {
                    var Registro60M = new ACBrFramework.Sintegra.SintegraRegistro60M();
                    Registro60M.Emissao = Item60M.DataEmissao.Value;
                    Registro60M.NumSerie = Item60M.NumeroSerieEcf;
                    Registro60M.NumOrdem = Item60M.NumeroEquipamento.Value;
                    if (Item60M.ModeloDocumentoFiscal == "")
                        Registro60M.ModeloDoc = "2D";
                    else
                        Registro60M.ModeloDoc = Item60M.ModeloDocumentoFiscal;
                    Registro60M.CooInicial = Item60M.CooInicial.Value;
                    Registro60M.CooFinal = Item60M.CooFinal.Value;
                    Registro60M.CRZ = Item60M.Crz.Value;
                    Registro60M.CRO = Item60M.Cro.Value;
                    Registro60M.VendaBruta = Item60M.ValorVendaBruta.Value;
                    Registro60M.ValorGT = Item60M.ValorGrandeTotal.Value;
                    ACBrSintegra.Registro60M.Add(Registro60M);

                    // Registro Tipo 60 - Analítico (60A): Identificador de cada Situação Tributária no final do dia de cada equipamento emissor de cupom fiscal
                    consultaSql = "from EcfSintegra60aDTO where IdSintegra60M = " + Item60M.Id;
                    IList<EcfSintegra60aDTO> Lista60A = new NHibernateDAL<EcfSintegra60aDTO>(Session).SelectListaSql<EcfSintegra60aDTO>(consultaSql);
                    if (Lista60A != null)
                    {
                        foreach (EcfSintegra60aDTO Item60A in Lista60A)
                        {
                            var Registro60A = new ACBrFramework.Sintegra.SintegraRegistro60A();
                            Registro60A.Emissao = Registro60M.Emissao;
                            Registro60A.NumSerie = Item60M.NumeroSerieEcf;
                            Registro60A.Aliquota = Item60A.SituacaoTributaria;
                            Registro60A.Valor = Item60A.Valor.Value;
                            ACBrSintegra.Registro60A.Add(Registro60A);
                        }
                    }

                }
            }

            // Registro Tipo 60 - Resumo Diário (60D): Registro de mercadoria/produto ou serviço constante em documento fiscal emitido por Terminal Ponto de Venda (PDV) ou equipamento Emissor de Cupom Fiscal (ECF)
            consultaSql = "from ViewSintegra60dDTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<ViewSintegra60dDTO> Lista60D = new NHibernateDAL<ViewSintegra60dDTO>(Session).SelectListaSql<ViewSintegra60dDTO>(consultaSql);

            if (Lista60D != null)
            {
                foreach (ViewSintegra60dDTO Item60D in Lista60D)
                {
                    var Registro60D = new ACBrFramework.Sintegra.SintegraRegistro60D();
                    Registro60D.Emissao = Item60D.DataEmissao.Value;
                    Registro60D.NumSerie = Item60D.Serie;
                    Registro60D.Codigo = Item60D.Gtin;
                    Registro60D.Quantidade = Item60D.SomaQuantidade.Value;
                    Registro60D.Valor = Item60D.SomaItem.Value;
                    Registro60D.BaseDeCalculo = Item60D.SomaBaseIcms.Value;
                    Registro60D.StAliquota = Item60D.EcfIcmsSt;
                    Registro60D.ValorIcms = Item60D.SomaIcms.Value;
                    ACBrSintegra.Registro60D.Add(Registro60D);

                    // REGISTRO TIPO 75 - CÓDIGO DE PRODUTO OU SERVIÇO
                    ProdutoDTO Produto = new NHibernateDAL<ProdutoDTO>(Session).SelectObjetoSql<ProdutoDTO>("Gtin=" + Item60D.Gtin);
                    var Registro75 = new ACBrFramework.Sintegra.SintegraRegistro75();
                    Registro75.DataInicial = Convert.ToDateTime(DataInicial);
                    Registro75.DataFinal = Convert.ToDateTime(DataFinal); 
                    Registro75.Codigo = Item60D.Gtin;
                    Registro75.NCM = Produto.Ncm;
                    Registro75.Descricao = Produto.Nome;
                    Registro75.Unidade = Produto.UnidadeProduto.Sigla;
                    Registro75.AliquotaIpi = 0;
                    Registro75.AliquotaICMS = 0;
                    ACBrSintegra.Registro75.Add(Registro75);
                }
            }

            // Registro Tipo 60 - Resumo Mensal (60R): Registro de mercadoria/produto ou serviço processado em equipamento Emissor de Cupom Fiscal
            consultaSql = "from ViewSintegra60rDTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<ViewSintegra60rDTO> Lista60R = new NHibernateDAL<ViewSintegra60rDTO>(Session).SelectListaSql<ViewSintegra60rDTO>(consultaSql);

            if (Lista60R != null)
            {
                foreach (ViewSintegra60rDTO Item60R in Lista60R)
                {
                    var Registro60R = new ACBrFramework.Sintegra.SintegraRegistro60R();
                    Registro60R.MesAno = Item60R.MesEmissao.ToString() + Item60R.AnoEmissao.ToString();
                    Registro60R.Codigo = Item60R.Gtin;
                    Registro60R.Qtd = Item60R.SomaQuantidade.Value;
                    Registro60R.Valor = Item60R.SomaItem.Value;
                    Registro60R.BaseDeCalculo = Item60R.SomaBaseIcms.Value;
                    Registro60R.Aliquota = Item60R.EcfIcmsSt;
                    ACBrSintegra.Registro60R.Add(Registro60R);

                    // REGISTRO TIPO 75 - CÓDIGO DE PRODUTO OU SERVIÇO
                    ProdutoDTO Produto = new NHibernateDAL<ProdutoDTO>(Session).SelectObjetoSql<ProdutoDTO>("Gtin=" + Item60R.Gtin);
                    var Registro75 = new ACBrFramework.Sintegra.SintegraRegistro75();
                    Registro75.DataInicial = Convert.ToDateTime(DataInicial);
                    Registro75.DataFinal = Convert.ToDateTime(DataFinal); 
                    Registro75.Codigo = Item60R.Gtin;
                    Registro75.NCM = Produto.Ncm;
                    Registro75.Descricao = Produto.Nome;
                    Registro75.Unidade = Produto.UnidadeProduto.Sigla;
                    Registro75.AliquotaIpi = 0;
                    Registro75.AliquotaICMS = 0;
                    ACBrSintegra.Registro75.Add(Registro75);
                }
            }

            // Registro Tipo 60 - Item (60I): Item do documento fiscal emitido por Terminal Ponto de Venda (PDV) ou equipamento Emissor de Cupom Fiscal (ECF)
            //{ Não Implementado }

        }
        #endregion

        #region Registro Tipo 61 - REGISTRO TIPO 61: Para os documentos fiscais descritos a seguir, quando não emitidos por equipamento emissor de cupom fiscal : Bilhete de Passagem Aquaviário (modelo 14), Bilhete de Passagem e Nota de Bagagem (modelo 15), Bilhete de Passagem Ferroviário (modelo 16), Bilhete de Passagem Rodoviário (modelo 13) e Nota Fiscal de Venda a Consumidor (modelo 2), Nota Fiscal de Produtor (modelo 4), para as unidades da Federação que não o exigirem na forma prevista no item 11         
        public void GerarRegistro61()
        {

            consultaSql = "from EcfNotaFiscalCabecalhoDTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<EcfNotaFiscalCabecalhoDTO> ListaNF2Cabecalho = new NHibernateDAL<EcfNotaFiscalCabecalhoDTO>(Session).SelectListaSql<EcfNotaFiscalCabecalhoDTO>(consultaSql);
            if (ListaNF2Cabecalho != null)
            {
                foreach (EcfNotaFiscalCabecalhoDTO NF2Cabecalho in ListaNF2Cabecalho)
                {
                    var Registro61 = new ACBrFramework.Sintegra.SintegraRegistro61();
                    Registro61.Emissao = NF2Cabecalho.DataEmissao.Value;
                    Registro61.Modelo = "02";
                    Registro61.NumOrdemInicial = int.Parse(NF2Cabecalho.Numero);
                    Registro61.NumOrdemFinal = int.Parse(NF2Cabecalho.Numero);
                    Registro61.Serie = NF2Cabecalho.Serie;
                    Registro61.SubSerie = NF2Cabecalho.Subserie;
                    Registro61.Valor = NF2Cabecalho.TotalNf.Value;
                    Registro61.BaseDeCalculo = NF2Cabecalho.BaseIcms.Value;
                    Registro61.ValorIcms = NF2Cabecalho.Icms.Value;
                    Registro61.Outras = NF2Cabecalho.IcmsOutras.Value;
                    ACBrSintegra.Registro61.Add(Registro61);
                }
            }

            // Registro Tipo 61 - Resumo Mensal por Item (61R): Registro de mercadoria/produto ou serviço comercializados através de Nota Fiscal de Produtor ou Nota Fiscal de Venda a Consumidor não emitida por ECF
            consultaSql = "from ViewSintegra61rDTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<ViewSintegra61rDTO> Lista61R = new NHibernateDAL<ViewSintegra61rDTO>(Session).SelectListaSql<ViewSintegra61rDTO>(consultaSql);

            if (Lista61R != null)
            {
                foreach (ViewSintegra61rDTO Item61R in Lista61R)
                {
                    var Registro61R = new ACBrFramework.Sintegra.SintegraRegistro61R();
                    Registro61R.MesAno = Item61R.MesEmissao.ToString() + Item61R.AnoEmissao.ToString();
                    Registro61R.Codigo = Item61R.Gtin;
                    Registro61R.Qtd = Item61R.SomaQuantidade.Value;
                    Registro61R.Valor = Item61R.SomaItem.Value;
                    Registro61R.BaseDeCalculo = Item61R.SomaBaseIcms.Value;
                    Registro61R.Aliquota = 0;
                    ACBrSintegra.Registro61R.Add(Registro61R);

                    // REGISTRO TIPO 75 - CÓDIGO DE PRODUTO OU SERVIÇO
                    ProdutoDTO Produto = new NHibernateDAL<ProdutoDTO>(Session).SelectObjetoSql<ProdutoDTO>("Gtin=" + Item61R.Gtin);
                    var Registro75 = new ACBrFramework.Sintegra.SintegraRegistro75();
                    Registro75.DataInicial = Convert.ToDateTime(DataInicial);
                    Registro75.DataFinal = Convert.ToDateTime(DataFinal); 
                    Registro75.Codigo = Item61R.Gtin;
                    Registro75.NCM = Produto.Ncm;
                    Registro75.Descricao = Produto.Nome;
                    Registro75.Unidade = Produto.UnidadeProduto.Sigla;
                    Registro75.AliquotaIpi = 0;
                    Registro75.AliquotaICMS = 0;
                    ACBrSintegra.Registro75.Add(Registro75);
                }
            }
        }
        #endregion

        #region Gerar Arquivo
        public bool GerarArquivoSintegra(string pDataIni, string pDataFim, int pCodigoConvenio, int pFinalidade, int pNaturezaInformacao, int pIdEmpresa, int pInventario, int pIdContador)
        {
            DataInicial = System.DateTime.Parse(pDataIni).ToString("yyyy-MM-dd");
            DataFinal = System.DateTime.Parse(pDataFim).ToString("yyyy-MM-dd");
            CodigoConvenio = pCodigoConvenio;
            FinalidadeArquivo = pFinalidade;
            NaturezaInformacao = pNaturezaInformacao;
            IdEmpresa = pIdEmpresa;
            Inventario = pInventario;
            IdContador = pIdContador;

            using (Session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                GerarRegistro10();
                GerarRegistro11();
                GerarRegistro50();
                GerarRegistro60();
                GerarRegistro61();

                // REGISTRO TIPO 70 - Nota Fiscal de Serviço de Transporte E OUTRAS
                // REGISTRO TIPO 71 - Informações da Carga Transportada
                // REGISTRO TIPO 74 - REGISTRO DE INVENTÁRIO
                // REGISTRO TIPO 76 - NOTA FISCAL DE SERVIÇOS DE COMUNICAÇÃO E OUTRAS
                // REGISTRO TIPO 77 - SERVIÇOS DE COMUNICAÇÃO E TELECOMUNICAÇÃO
                // REGISTRO TIPO 85 - Informações de Exportações
                // REGISTRO TIPO 86 - Informações Complementares de Exportações
                //{ Não Implementado }

            }

            ACBrSintegra.VersaoValidador = (ACBrFramework.Sintegra.VersaoValidador)1;
            ACBrSintegra.GeraArquivo();
            return true;
        }
        #endregion

    }

}
