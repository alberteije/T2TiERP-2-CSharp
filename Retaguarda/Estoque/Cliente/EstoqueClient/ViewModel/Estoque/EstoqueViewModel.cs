using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Xml.Serialization;
using CloseableTabItemDemo;
using EstoqueClient.EstoqueServiceReference;
using EstoqueClient.Model;
using Microsoft.Win32;
using SearchWindow;

namespace EstoqueClient.View.Estoque
{
    public class EstoqueViewModel : ERPViewModelBase
    {
        public Boolean isSelectedTabLista { get; set; }
        public Boolean isSelectedTabDados { get; set; }
        public ContentPresenter contentPresenterTabDados { get; set; }
        public ObservableCollection<NFeCabecalhoDTO> listaNFe { get; set; }
        public NFeCabecalhoDTO nfeSelected { get; set; }
        public ProdutoDTO produtoSelected { get; set; }
        public ColaboradorDTO colaboradorSelected { get; set; }
        private EmpresaDTO empresa { get; set; }
        public NFeDetalheDTO detalheNFe { get; set; }


        public EstoqueViewModel()
        {
            try
            {
                contentPresenterTabDados = new ContentPresenter();
                listaNFe = new ObservableCollection<NFeCabecalhoDTO>();

                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    empresa = serv.selectEmpresaId(1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool importarNFe()
        {
            try
            {
                string FORMATO_DATA = "yyyy-MM-dd";

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Arquivos Processados NF-e (*-procNFe.xml) | *-procNFe.xml"; 
                dialog.Title = "Selecione a NF-e";
                dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != true)
                {
                    return false;
                }
                string path = dialog.FileName;

                XmlSerializer serializer = new XmlSerializer(typeof(TNfeProc));
                StreamReader reader = new StreamReader(path);

                TNfeProc nfeProc = (TNfeProc)serializer.Deserialize(reader);

                nfeSelected = new NFeCabecalhoDTO();
                nfeSelected.emitente = new NFeEmitenteDTO();
                nfeSelected.listaDetalhe = new List<NFeDetalheDTO>();

                nfeSelected.tipoOperacao = "0";
                nfeSelected.codigoNumerico = nfeProc.NFe.infNFe.ide.cNF;
                nfeSelected.naturezaOperacao = nfeProc.NFe.infNFe.ide.natOp;
                //nfeSelected.indicadorFormaPagamento = nfeProc.NFe.infNFe.ide.indPag;
                nfeSelected.codigoModelo = nfeProc.NFe.infNFe.ide.mod.ToString().Replace("Item", "");
                nfeSelected.serie = nfeProc.NFe.infNFe.ide.serie;
                nfeSelected.numero = nfeProc.NFe.infNFe.ide.nNF;
                nfeSelected.dataEmissao = DateTime.ParseExact(nfeProc.NFe.infNFe.ide.dEmi, FORMATO_DATA, CultureInfo.InvariantCulture);
                nfeSelected.dataEntradaSaida = DateTime.ParseExact(nfeProc.NFe.infNFe.ide.dSaiEnt, FORMATO_DATA, CultureInfo.InvariantCulture);
                nfeSelected.horaEntradaSaida = nfeProc.NFe.infNFe.ide.hSaiEnt;
                nfeSelected.tipoEmissao = nfeProc.NFe.infNFe.ide.tpEmis.ToString().Last().ToString();
                nfeSelected.versaoProcessoEmissao = nfeProc.NFe.infNFe.ide.verProc;
                nfeSelected.finalidadeEmissao = nfeProc.NFe.infNFe.ide.finNFe.ToString().Last().ToString();
                nfeSelected.digitoChaveAcesso = nfeProc.NFe.infNFe.ide.cDV;
                nfeSelected.chaveAcesso = nfeProc.protNFe.infProt.chNFe;
                nfeSelected.formatoImpressaoDanfe = nfeProc.NFe.infNFe.ide.tpImp.ToString().Replace("Item", "");
                nfeSelected.ambiente = nfeProc.NFe.infNFe.ide.tpAmb.ToString().Replace("Item", "");

                /*Emitente*/
                nfeSelected.emitente.logradouro = nfeProc.NFe.infNFe.emit.enderEmit.xLgr;
                nfeSelected.emitente.numero = nfeProc.NFe.infNFe.emit.enderEmit.nro;
                nfeSelected.emitente.complemento = nfeProc.NFe.infNFe.emit.enderEmit.xCpl;
                nfeSelected.emitente.bairro = nfeProc.NFe.infNFe.emit.enderEmit.xBairro;
                nfeSelected.emitente.codigoMunicipio = int.Parse(nfeProc.NFe.infNFe.emit.enderEmit.cMun);
                nfeSelected.emitente.nomeMunicipio = nfeProc.NFe.infNFe.emit.enderEmit.xMun;
                nfeSelected.emitente.uf = nfeProc.NFe.infNFe.emit.enderEmit.UF.ToString();
                nfeSelected.emitente.cep = nfeProc.NFe.infNFe.emit.enderEmit.CEP;
                nfeSelected.emitente.codigoPais = 55;
                nfeSelected.emitente.nomePais = "Brasil";
                nfeSelected.emitente.telefone = nfeProc.NFe.infNFe.emit.enderEmit.fone;
                nfeSelected.emitente.crt = nfeProc.NFe.infNFe.emit.CRT.ToString().Replace("Item", "");
                nfeSelected.emitente.inscricaoEstadual = nfeProc.NFe.infNFe.emit.IE;
                nfeSelected.emitente.inscricaoEstadualSt = nfeProc.NFe.infNFe.emit.IEST;
                nfeSelected.emitente.razaoSocial = nfeProc.NFe.infNFe.emit.xNome;
                nfeSelected.emitente.fantasia = nfeProc.NFe.infNFe.emit.xFant;
                nfeSelected.emitente.cpfCnpj = nfeProc.NFe.infNFe.emit.Item;

                nfeSelected.informacoesAddFisco = nfeProc.NFe.infNFe.infAdic.infAdFisco;
                nfeSelected.informacoesAddContribuinte = nfeProc.NFe.infNFe.infAdic.infCpl;

                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    foreach (TNFeInfNFeDet detalhe in nfeProc.NFe.infNFe.det)
                    {
                        NFeDetalheDTO nfeDet = new NFeDetalheDTO();
                        nfeDet.gtin = detalhe.prod.cEAN;
                        nfeDet.nomeProduto = detalhe.prod.xProd;
                        nfeDet.valorTotal = decimal.Parse(detalhe.prod.vProd);
                        nfeDet.valorUnitarioComercial = decimal.Parse(detalhe.prod.vUnCom);
                        nfeDet.quantidadeComercial = decimal.Parse(detalhe.prod.qCom);

                        nfeSelected.listaDetalhe.Add(nfeDet);

                        List<ProdutoDTO> listaProd = serv.selectProduto(new ProdutoDTO { gtin = nfeDet.gtin });

                        if (listaProd != null && listaProd.Count > 0)
                        {
                            nfeDet.idProduto = listaProd.First().id;
                        }
                        else
                        {
                            throw new Exception("Produto não localizado, efetue o cadastramento: " + nfeDet.gtin + " - " + nfeDet.nomeProduto);
                        }

                    }
                }

                nfeSelected.baseCalculoIcms = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vBC);
                nfeSelected.valorIcms = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vICMS);
                nfeSelected.baseCalculoIcmsSt = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vBCST);
                nfeSelected.valorIcmsSt = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vST);
                nfeSelected.valorCofins = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vCOFINS);
                nfeSelected.valorTotalProdutos = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vProd);
                nfeSelected.valorFrete = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vFrete);
                nfeSelected.valorSeguro = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vSeg);
                nfeSelected.valorDespesasAcessorias = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vOutro);
                nfeSelected.valorPis = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vPIS);
                nfeSelected.valorDesconto = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vDesc);
                nfeSelected.valorTotal = decimal.Parse(nfeProc.NFe.infNFe.total.ICMSTot.vNF);

                contentPresenterTabDados.Content = new NFeDados();
                isSelectedTabDados = true;
                notifyPropertyChanged("isSelectedTabDados");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string formataValorNFe(decimal? valor)
        {
            try
            {
                if (valor == null)
                    valor = 0;

                return ((decimal)valor).ToString("0.00", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        private string formataQtdNFe(decimal? quantidade)
        {
            try
            {
                if (quantidade == null)
                    quantidade = 0;

                return ((decimal)quantidade).ToString("0.0000", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public void pesquisarProduto()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ProdutoDTO), typeof(ServicoEstoque));
                searchWindow.definirColunas(new string[] { "gtin", "nome", "valorVenda","quantidadeEstoque" });
                if (searchWindow.ShowDialog() == true)
                {
                    produtoSelected  = (ProdutoDTO)searchWindow.itemSelecionado;
                    detalheNFe = new NFeDetalheDTO();
                    notifyPropertyChanged("produtoSelected");
                    notifyPropertyChanged("detalheNFe");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void excluirCupomVinculado(int index)
        {
            try
            {
                if(nfeSelected.listaCupomFiscal.Count > index )
                    nfeSelected.listaCupomFiscal.RemoveAt(index);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void excluirDuplicata(int index)
        {
            try
            {
                if (nfeSelected.listaDuplicata.Count > index)
                    nfeSelected.listaDuplicata.RemoveAt(index);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void excluirProduto(int index)
        {
            try
            {
                if (nfeSelected.listaDetalhe.Count > index)
                {
                    nfeSelected.listaDetalhe.RemoveAt(index);
                    atualizarNumeroItemDetalhe();
                    atualizarValoresNFe();
                }
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        public void incluirCupomVinculado(NFeCupomFiscalDTO cupomVinculado)
        {
            try
            {
                if (nfeSelected.listaCupomFiscal == null)
                    nfeSelected.listaCupomFiscal = new List<NFeCupomFiscalDTO>();

                nfeSelected.listaCupomFiscal.Add(cupomVinculado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void incluirDuplicata(NFeDuplicataDTO duplicata)
        {
            try
            {
                if (nfeSelected.listaDuplicata == null)
                    nfeSelected.listaDuplicata = new List<NFeDuplicataDTO>();

                nfeSelected.listaDuplicata.Add(duplicata);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void carregarTabLista()
        {
            try
            {
                contentPresenterTabDados.Content = null;
                atualizarListaNFe();
                isSelectedTabLista = true;
                notifyPropertyChanged("isSelectedTabLista");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregarTabDados()
        {
            try
            {
                carregarNFeSelected();
                contentPresenterTabDados.Content = new NFeDados();
                isSelectedTabDados = true;
                notifyPropertyChanged("isSelectedTabDados");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregarNFeSelected()
        {
            try
            {
                if (nfeSelected != null && nfeSelected.id != 0)
                {
                    using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                    {
                        nfeSelected = serv.selectNFeCabecalhoId((int)nfeSelected.id);
                    }
                }

                if (nfeSelected.destinatario == null)
                    nfeSelected.destinatario = new NFeDestinatarioDTO();
                if (nfeSelected.listaCupomFiscal == null)
                    nfeSelected.listaCupomFiscal = new List<NFeCupomFiscalDTO>();
                if (nfeSelected.localEntrega == null)
                    nfeSelected.localEntrega = new NFeLocalEntregaDTO();
                if (nfeSelected.localRetirada == null)
                    nfeSelected.localRetirada = new NFeLocalRetiradaDTO();
                if (nfeSelected.transporte == null)
                    nfeSelected.transporte = new NFeTransporteDTO();
                if (nfeSelected.fatura == null)
                    nfeSelected.fatura = new NFeFaturaDTO();
                if (nfeSelected.listaDuplicata == null)
                    nfeSelected.listaDuplicata = new List<NFeDuplicataDTO>();
                if (nfeSelected.listaDetalhe == null)
                    nfeSelected.listaDetalhe = new List<NFeDetalheDTO>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void atualizarListaNFe()
        {
            try
            {
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    List<NFeCabecalhoDTO> listaNFeServ = serv.selectNFeCabecalho(new NFeCabecalhoDTO());

                    listaNFe.Clear();

                    foreach (NFeCabecalhoDTO nfe in listaNFeServ)
                    {
                        listaNFe.Add(nfe);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void salvarNFe()
        {
            try
            {
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    nfeSelected.idEmpresa = empresa.Id;

                    serv.salvarNFeCabecalho(nfeSelected);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void atualizarNumeroItemDetalhe()
        {
            try
            {
                int aux = 0;
                foreach (NFeDetalheDTO det in nfeSelected.listaDetalhe)
                {
                    det.numeroItem = ++aux;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void atualizarValoresNFe()
        {
            try
            {
                nfeSelected.baseCalculoIcms = 0;
                nfeSelected.valorIcms = 0;
                nfeSelected.baseCalculoIcmsSt = 0;
                nfeSelected.valorIcmsSt = 0;
                nfeSelected.valorCofins = 0;
                nfeSelected.valorTotalProdutos = 0;
                nfeSelected.valorFrete = 0;
                nfeSelected.valorSeguro = 0;
                nfeSelected.valorDespesasAcessorias = 0;
                nfeSelected.valorPis = 0;
                nfeSelected.valorDesconto = 0;
                nfeSelected.valorTotal = 0;

                foreach (NFeDetalheDTO detalhe in nfeSelected.listaDetalhe)
                {
                    nfeSelected.valorTotal += detalhe.valorTotal;
                    nfeSelected.baseCalculoIcms += detalhe.impostoIcms.BaseCalculoIcms;
                    nfeSelected.valorIcms += detalhe.impostoIcms.ValorIcms;
                    nfeSelected.valorTotalProdutos += detalhe.valorTotal;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void incluirProduto(decimal quantidade)
        {

            try
            {
                if(produtoSelected == null)
                    throw new Exception("Selecione o produto.");

                if (nfeSelected.listaDetalhe == null)
                    nfeSelected.listaDetalhe = new List<NFeDetalheDTO>();

                detalheNFe.idProduto = produtoSelected.id;
                detalheNFe.codigoProduto = produtoSelected.gtin;
                detalheNFe.gtin = produtoSelected.gtin;
                detalheNFe.valorBrutoProduto = quantidade * produtoSelected.valorVenda;
                detalheNFe.gtinUnidadeTributavel = produtoSelected.gtin;
                detalheNFe.quantidadeTributavel = quantidade;
                detalheNFe.valorUnitarioTributavel = produtoSelected.valorVenda;
                detalheNFe.nomeProduto = produtoSelected.nome;
                detalheNFe.quantidadeComercial = quantidade;
                detalheNFe.valorUnitarioComercial = produtoSelected.valorVenda;
                detalheNFe.valorSubtotal = quantidade * produtoSelected.valorVenda;
                detalheNFe.valorTotal = quantidade * produtoSelected.valorVenda;
                detalheNFe.ncm = produtoSelected.ncm;
                detalheNFe.unidadeComercial = produtoSelected.UnidadeProduto.Sigla;
                detalheNFe.unidadeTributavel = produtoSelected.UnidadeProduto.Sigla;

                // ICMS
                ViewTributacaoIcmsDTO viewIcms = new ViewTributacaoIcmsDTO();
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    viewIcms.IdTributOperacaoFiscal = nfeSelected.TributOperacaoFiscal.Id;
                    viewIcms.IdTributGrupoTributario = produtoSelected.TributGrupoTributario.Id;
                    viewIcms.UfDestino = nfeSelected.destinatario.uf;
                    viewIcms = serv.selectViewTributacaoIcms(viewIcms);

                    if (viewIcms == null)
                        throw new Exception("Não existe tributação definida para o para o produto selecionado.");
                }
                detalheNFe.cfop = viewIcms.Cfop;
                detalheNFe.impostoIcms = new NfeDetalheImpostoIcmsDTO();
                detalheNFe.impostoIcms.OrigemMercadoria = viewIcms.OrigemMercadoria;
                detalheNFe.impostoIcms.CstIcms = viewIcms.CstB;
                detalheNFe.impostoIcms.Csosn = viewIcms.CsosnB;
                detalheNFe.impostoIcms.ModalidadeBcIcms = viewIcms.ModalidadeBc;
                detalheNFe.impostoIcms.TaxaReducaoBcIcms = viewIcms.PorcentoBc;
                detalheNFe.impostoIcms.AliquotaIcms = viewIcms.Aliquota;
                detalheNFe.impostoIcms.ModalidadeBcIcmsSt = viewIcms.ModalidadeBcSt;
                detalheNFe.impostoIcms.PercentualMvaIcmsSt = viewIcms.Mva;
                detalheNFe.impostoIcms.PercentualReducaoBcIcmsSt = viewIcms.PorcentoBcSt;
                detalheNFe.impostoIcms.AliquotaIcmsSt = viewIcms.AliquotaIcmsSt;
                detalheNFe.impostoIcms.BaseCalculoIcms = produtoSelected.valorVenda;
                detalheNFe.impostoIcms.ValorIcms = (produtoSelected.valorVenda * viewIcms.Aliquota) / 100;



                ViewTributacaoPisDTO viewPis = new ViewTributacaoPisDTO();
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    viewPis.IdTributOperacaoFiscal = nfeSelected.TributOperacaoFiscal.Id;
                    viewPis.IdTributGrupoTributario = produtoSelected.TributGrupoTributario.Id;
                    viewPis = serv.selectViewTributacaoPis(viewPis);

                    detalheNFe.impostoPis = new NfeDetalheImpostoPisDTO();

                    detalheNFe.impostoPis.CstPis = viewPis.CstPis;
                    detalheNFe.impostoPis.AliquotaPisPercentual = viewPis.AliquotaPorcento;
                    detalheNFe.impostoPis.AliquotaPisReais = viewPis.AliquotaUnidade;
                    detalheNFe.impostoPis.ValorBaseCalculoPis = produtoSelected.valorVenda;
                    detalheNFe.impostoPis.ValorPis = (produtoSelected.valorVenda * viewPis.AliquotaPorcento) / 100; ;
                }

                ViewTributacaoCofinsDTO viewCofins = new ViewTributacaoCofinsDTO();
                using (ServicoEstoqueClient serv = new ServicoEstoqueClient())
                {
                    viewCofins.IdTributOperacaoFiscal = nfeSelected.TributOperacaoFiscal.Id;
                    viewCofins.IdTributGrupoTributario = produtoSelected.TributGrupoTributario.Id;
                    viewCofins = serv.selectViewTributacaoCofins(viewCofins);

                    detalheNFe.impostoCofins = new NfeDetalheImpostoCofinsDTO();

                    detalheNFe.impostoCofins.CstCofins = viewCofins.CstCofins;
                    detalheNFe.impostoCofins.AliquotaCofinsPercentual = viewCofins.AliquotaPorcento;
                    detalheNFe.impostoCofins.AliquotaCofinsReais = viewCofins.AliquotaUnidade;
                    detalheNFe.impostoCofins.BaseCalculoCofins = produtoSelected.valorVenda;
                    detalheNFe.impostoCofins.ValorCofins = (produtoSelected.valorVenda * viewCofins.AliquotaPorcento) / 100; ;
                }

                nfeSelected.listaDetalhe.Add(detalheNFe);

                atualizarNumeroItemDetalhe();
                atualizarValoresNFe();

                produtoSelected = null;
                detalheNFe = null;

                notifyPropertyChanged("produtoSelected");
                notifyPropertyChanged("detalheNFe");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in EstoquePrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                EstoquePrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

    }
}

/// EXERCICIO
///  Implemente a rotina para importar a nota diretamente do site da Sefaz
///  através da consulta à chave de acesso.
