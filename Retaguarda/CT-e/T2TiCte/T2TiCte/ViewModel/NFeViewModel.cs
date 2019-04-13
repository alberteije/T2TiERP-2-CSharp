using NFe.Model;
using NFe.View;
using NFe.Classes;
using NFe.Classes.Informacoes;
using NFe.Classes.Informacoes.Cobranca;
using NFe.Classes.Informacoes.Destinatario;
using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Informacoes.Pagamento;
using NFe.Classes.Informacoes.Total;
using NFe.Classes.Informacoes.Transporte;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFe.Utils;
using NFe.Utils.Assinatura;
using NFe.Utils.NFe;
using SearchWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using NFe.Util;
using NFe.AppTeste;
using T2TiCte.Servico;

namespace NFe.ViewModel
{
    public class NFeViewModel : ViewModelBase
    {

        #region Variáveis
        private static ConfiguracaoApp _configuracoes;
        private static string _protocolo;
        private const string ArquivoConfiguracao = @"\configuracao.xml";
        private static NFe.Classes.NFe _nfe;

        public Boolean IsSelectedTabLista { get; set; }
        public Boolean IsSelectedTabDados { get; set; }
        public ContentPresenter ContentPresenterTabDados { get; set; }
        public ObservableCollection<NfeCabecalhoDTO> ListaNFe { get; set; }
        public NfeCabecalhoDTO _NFeSelected { get; set; }
        public ProdutoDTO ProdutoSelected { get; set; }
        private EmpresaDTO Empresa { get; set; }
        public NfeDetalheDTO DetalheNFe { get; set; }
        #endregion

        #region Construtor
        public NFeViewModel()
        {
            try
            {
                _configuracoes = new ConfiguracaoApp();
                ConfiguraNfe();

                ContentPresenterTabDados = new ContentPresenter();
                ListaNFe = new ObservableCollection<NfeCabecalhoDTO>();

                using (ServidorClient Servico = new ServidorClient())
                {
                    Empresa = Servico.SelectObjetoEmpresa("Id=1");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Infra
        public NfeCabecalhoDTO NFeSelected
        {
            get { return _NFeSelected; }
            set
            {
                _NFeSelected = value;
                notifyPropertyChanged("NFeSelected");
            }
        }

        public void CarregarTabLista()
        {
            try
            {
                ContentPresenterTabDados.Content = null;
                AtualizarListaNFe();
                IsSelectedTabLista = true;
                notifyPropertyChanged("IsSelectedTabLista");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CarregarTabDados()
        {
            try
            {
                CarregarNFeSelected();
                ContentPresenterTabDados.Content = new NFeDados();
                IsSelectedTabDados = true;
                notifyPropertyChanged("IsSelectedTabDados");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CarregarNFeSelected()
        {
            try
            {
                if (NFeSelected != null && NFeSelected.Id != 0)
                {
                    using (ServidorClient serv = new ServidorClient())
                    {
                        NFeSelected = serv.SelectNfeCabecalhoId((int)NFeSelected.Id);
                    }
                }

                if(NFeSelected.NfeDestinatario == null)
                    NFeSelected.NfeDestinatario = new NfeDestinatarioDTO();
                if (NFeSelected.ListaNfeCupomFiscalReferenciado == null)
                    NFeSelected.ListaNfeCupomFiscalReferenciado = new List<NfeCupomFiscalReferenciadoDTO>();
                if (NFeSelected.NfeLocalEntrega == null)
                    NFeSelected.NfeLocalEntrega = new NfeLocalEntregaDTO();
                if (NFeSelected.NfeLocalRetirada == null)
                    NFeSelected.NfeLocalRetirada = new NfeLocalRetiradaDTO();
                if (NFeSelected.NfeTransporte == null)
                    NFeSelected.NfeTransporte = new NfeTransporteDTO();
                if (NFeSelected.NfeFatura == null)
                    NFeSelected.NfeFatura = new NfeFaturaDTO();
                if (NFeSelected.ListaNfeDuplicata == null)
                    NFeSelected.ListaNfeDuplicata = new List<NfeDuplicataDTO>();
                if (NFeSelected.ListaNfeDetalhe == null)
                    NFeSelected.ListaNfeDetalhe = new List<NfeDetalheDTO>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaNFe()
        {
            try
            {
                using (ServidorClient serv = new ServidorClient())
                {
                    List<NfeCabecalhoDTO> listaNFeServ = serv.SelectNfeCabecalho(new NfeCabecalhoDTO());

                    ListaNFe.Clear();

                    foreach (NfeCabecalhoDTO nfe in listaNFeServ)
                    {
                        ListaNFe.Add(nfe);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void AtualizarNumeroItemDetalhe()
        {
            try
            {
                int aux = 0;
                foreach (NfeDetalheDTO det in NFeSelected.ListaNfeDetalhe)
                {
                    det.NumeroItem = ++aux;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AtualizarValoresNFe()
        {
            try
            {
                NFeSelected.BaseCalculoIcms = 0;
                NFeSelected.ValorIcms = 0;
                NFeSelected.BaseCalculoIcmsSt = 0;
                NFeSelected.ValorIcmsSt = 0;
                NFeSelected.ValorCofins = 0;
                NFeSelected.ValorTotalProdutos = 0;
                NFeSelected.ValorFrete = 0;
                NFeSelected.ValorSeguro = 0;
                NFeSelected.ValorDespesasAcessorias = 0;
                NFeSelected.ValorPis = 0;
                NFeSelected.ValorDesconto = 0;
                NFeSelected.ValorTotal = 0;

                foreach(NfeDetalheDTO detalhe in NFeSelected.ListaNfeDetalhe)
                {
                    NFeSelected.ValorTotal += detalhe.ValorTotal;
                    NFeSelected.BaseCalculoIcms += detalhe.NfeDetalheImpostoIcms.BaseCalculoIcms;
                    NFeSelected.ValorIcms += detalhe.NfeDetalheImpostoIcms.ValorIcms;
                    NFeSelected.ValorTotalProdutos += detalhe.ValorTotal;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CRUD
        public void SalvarAtualizarNFe()
        {
            try
            {
                if (NFeSelected.TributOperacaoFiscal == null)
                    throw new Exception("Selecione a Operação Fiscal.");

                using (ServidorClient serv = new ServidorClient())
                {
                    NFeSelected.IdEmpresa = Empresa.Id;
                    NFeSelected.VersaoProcessoEmissao = "100";
                    NFeSelected.NfeDestinatario.InscricaoEstadual = "";

                    if (NFeSelected.NfeEmitente == null)
                    {
                        NfeEmitenteDTO Emitente = new NfeEmitenteDTO();
                        Emitente.CpfCnpj = Empresa.Cnpj;
                        Emitente.Nome = Empresa.RazaoSocial;
                        Emitente.Fantasia = Empresa.NomeFantasia;
                        Emitente.Logradouro = Empresa.EnderecoPrincipal.Logradouro;
                        Emitente.Numero = Empresa.EnderecoPrincipal.Numero;
                        Emitente.Complemento = Empresa.EnderecoPrincipal.Complemento;
                        Emitente.Bairro = Empresa.EnderecoPrincipal.Bairro;
                        Emitente.CodigoMunicipio = Empresa.EnderecoPrincipal.MunicipioIbge;
                        Emitente.NomeMunicipio = Empresa.EnderecoPrincipal.Cidade;
                        Emitente.Uf = Empresa.EnderecoPrincipal.Uf;
                        Emitente.Cep = Empresa.EnderecoPrincipal.Cep;
                        Emitente.Crt = Empresa.Crt;
                        Emitente.CodigoPais = 1058;
                        Emitente.NomePais = "Brasil";
                        Emitente.Telefone = Empresa.EnderecoPrincipal.Fone;
                        Emitente.InscricaoEstadual = Empresa.InscricaoEstadual;
                        Emitente.InscricaoEstadualSt = Empresa.InscricaoEstadualSt;
                        Emitente.InscricaoMunicipal = Empresa.InscricaoMunicipal;

                        NFeSelected.NfeEmitente = Emitente;
                    }

                    serv.SalvarAtualizarNfeCabecalho(NFeSelected);
                    NFeSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaNFe(int pagina)
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaNFe.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    NfeCabecalhoDTO NFe = new NfeCabecalhoDTO();

                    IList<NfeCabecalhoDTO> ListaServ = Servico.SelectNfeCabecalhoPagina(IndiceNavegacao, QuantidadePagina, NFe);

                    ListaNFe.Clear();

                    foreach (NfeCabecalhoDTO objAdd in ListaServ)
                    {
                        ListaNFe.Add(objAdd);
                    }
                    NFeSelected = null;
                }
                QuantidadeCarregada = ListaNFe.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirNFe()
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    Servico.DeleteNfeCabecalho(NFeSelected);
                    NFeSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Controle de Ativação dos Botões
        public override void BotaoInserir()
        {
            try
            {
                NFeSelected = new NfeCabecalhoDTO();
                CarregarTabDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoAlterar()
        {
            try
            {
                if (NFeSelected != null)
                    CarregarTabDados();
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoExcluir()
        {
            try
            {
                if (NFeSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirNFe();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaNFe(IndiceNavegacao);
                    }
                }
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoCancelar()
        {
            try
            {
                CarregarTabLista();
                BotaoLocalizar();
                NFeSelected = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoSalvar()
        {
            try
            {
                SalvarAtualizarNFe();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaNFe(IndiceNavegacao);
                CarregarTabLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoLocalizar()
        {
            try
            {
                AtualizarListaNFe(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoExportar()
        {
            DataGridExportacao.ItemsSource = ListaNFe;
        }

        public override void BotaoPaginaSeguinte()
        {
            AtualizarListaNFe(1);
        }

        public override void BotaoPaginaAnterior()
        {
            AtualizarListaNFe(-1);
        }
        #endregion

        #region Pesquisas
        public void PesquisarProduto()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ProdutoDTO), typeof(NFe.Model.ServicoNFe));
                searchWindow.definirColunas(new string[] { "Gtin", "Nome", "ValorVenda" });
                if (searchWindow.ShowDialog() == true)
                {
                    ProdutoSelected = (ProdutoDTO)searchWindow.itemSelecionado;
                    DetalheNFe = new NfeDetalheDTO();
                    notifyPropertyChanged("ProdutoSelected");
                    notifyPropertyChanged("DetalheNFe");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PesquisarOperacaoFiscal()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TributOperacaoFiscalDTO), typeof(NFe.Model.ServicoNFe));
                searchWindow.definirColunas(new string[] { "Id", "Descricao", "DescricaoNaNf" });
                if (searchWindow.ShowDialog() == true)
                {
                    NFeSelected.TributOperacaoFiscal = (TributOperacaoFiscalDTO)searchWindow.itemSelecionado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Exclusões Internas
        public void ExcluirCupomVinculado(int index)
        {
            try
            {
                if (NFeSelected.ListaNfeCupomFiscalReferenciado.Count > index)
                    NFeSelected.ListaNfeCupomFiscalReferenciado.RemoveAt(index);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirDuplicata(int index)
        {
            try
            {
                if (NFeSelected.ListaNfeDuplicata.Count > index)
                    NFeSelected.ListaNfeDuplicata.RemoveAt(index);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirProduto(int index)
        {
            try
            {
                if (NFeSelected.ListaNfeDetalhe.Count > index)
                {
                    NFeSelected.ListaNfeDetalhe.RemoveAt(index);
                    AtualizarNumeroItemDetalhe();
                    AtualizarValoresNFe();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Inclusões Internas
        public void IncluirCupomVinculado(NfeCupomFiscalReferenciadoDTO cupomVinculado)
        {
            try
            {
                if (NFeSelected.ListaNfeCupomFiscalReferenciado == null)
                    NFeSelected.ListaNfeCupomFiscalReferenciado = new List<NfeCupomFiscalReferenciadoDTO>();

                NFeSelected.ListaNfeCupomFiscalReferenciado.Add(cupomVinculado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IncluirDuplicata(NfeDuplicataDTO duplicata)
        {
            try
            {
                if (NFeSelected.ListaNfeDuplicata == null)
                    NFeSelected.ListaNfeDuplicata = new List<NfeDuplicataDTO>();

                NFeSelected.ListaNfeDuplicata.Add(duplicata);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IncluirProduto(decimal quantidade)
        {
            // Exercício: Implemente os cálculos de imposto

            try
            {
                if (ProdutoSelected == null)
                    throw new Exception("Selecione o produto.");

                if (NFeSelected.ListaNfeDetalhe == null)
                    NFeSelected.ListaNfeDetalhe = new List<NfeDetalheDTO>();

                DetalheNFe.IdProduto = ProdutoSelected.Id;
                DetalheNFe.CodigoProduto = ProdutoSelected.Gtin;
                DetalheNFe.Gtin = ProdutoSelected.Gtin;
                DetalheNFe.ValorBrutoProduto = quantidade * ProdutoSelected.ValorVenda;
                DetalheNFe.GtinUnidadeTributavel = ProdutoSelected.Gtin;
                DetalheNFe.QuantidadeTributavel = quantidade;
                DetalheNFe.ValorUnitarioTributavel = ProdutoSelected.ValorVenda;
                DetalheNFe.NomeProduto = ProdutoSelected.Nome;
                DetalheNFe.QuantidadeComercial = quantidade;
                DetalheNFe.ValorUnitarioComercial = ProdutoSelected.ValorVenda;
                DetalheNFe.ValorSubtotal = quantidade * ProdutoSelected.ValorVenda;
                DetalheNFe.ValorTotal = quantidade * ProdutoSelected.ValorVenda;
                DetalheNFe.Ncm = ProdutoSelected.Ncm;
                DetalheNFe.UnidadeComercial = ProdutoSelected.UnidadeProduto.Sigla;
                DetalheNFe.UnidadeTributavel = ProdutoSelected.UnidadeProduto.Sigla;

                // ICMS
                ViewTributacaoIcmsDTO viewIcms = new ViewTributacaoIcmsDTO();
                using (ServidorClient serv = new ServidorClient())
                {
                    viewIcms.IdTributOperacaoFiscal = NFeSelected.TributOperacaoFiscal.Id;
                    viewIcms.IdTributGrupoTributario = ProdutoSelected.TributGrupoTributario.Id;
                    viewIcms.UfDestino = NFeSelected.NfeDestinatario.Uf;
                    viewIcms = serv.SelectViewTributacaoIcms(viewIcms);

                    if (viewIcms == null)
                        throw new Exception("Não existe tributação definida para o para o produto selecionado.");
                }
                DetalheNFe.Cfop = viewIcms.Cfop;
                DetalheNFe.NfeDetalheImpostoIcms = new NfeDetalheImpostoIcmsDTO();
                DetalheNFe.NfeDetalheImpostoIcms.OrigemMercadoria = int.Parse(viewIcms.OrigemMercadoria);
                DetalheNFe.NfeDetalheImpostoIcms.CstIcms = viewIcms.CstB;
                DetalheNFe.NfeDetalheImpostoIcms.Csosn = viewIcms.CsosnB;
                DetalheNFe.NfeDetalheImpostoIcms.ModalidadeBcIcms = int.Parse(viewIcms.ModalidadeBc);
                DetalheNFe.NfeDetalheImpostoIcms.TaxaReducaoBcIcms = viewIcms.PorcentoBc;
                DetalheNFe.NfeDetalheImpostoIcms.AliquotaIcms = viewIcms.Aliquota;
                //DetalheNFe.NfeDetalheImpostoIcms.ModalidadeBcIcmsSt = int.Parse(viewIcms.ModalidadeBcSt);
                DetalheNFe.NfeDetalheImpostoIcms.PercentualMvaIcmsSt = viewIcms.Mva;
                DetalheNFe.NfeDetalheImpostoIcms.PercentualReducaoBcIcmsSt = viewIcms.PorcentoBcSt;
                DetalheNFe.NfeDetalheImpostoIcms.AliquotaIcmsSt = viewIcms.AliquotaIcmsSt;
                DetalheNFe.NfeDetalheImpostoIcms.BaseCalculoIcms = ProdutoSelected.ValorVenda;
                DetalheNFe.NfeDetalheImpostoIcms.ValorIcms = (ProdutoSelected.ValorVenda * viewIcms.Aliquota) / 100;



                ViewTributacaoPisDTO viewPis = new ViewTributacaoPisDTO();
                using (ServidorClient serv = new ServidorClient())
                {
                    viewPis.IdTributOperacaoFiscal = NFeSelected.TributOperacaoFiscal.Id;
                    viewPis.IdTributGrupoTributario = ProdutoSelected.TributGrupoTributario.Id;
                    viewPis = serv.SelectViewTributacaoPis(viewPis);

                    DetalheNFe.NfeDetalheImpostoPis = new NfeDetalheImpostoPisDTO();

                    DetalheNFe.NfeDetalheImpostoPis.CstPis = viewPis.CstPis;
                    DetalheNFe.NfeDetalheImpostoPis.AliquotaPisPercentual = viewPis.AliquotaPorcento;
                    DetalheNFe.NfeDetalheImpostoPis.AliquotaPisReais = viewPis.AliquotaUnidade;
                    DetalheNFe.NfeDetalheImpostoPis.ValorBaseCalculoPis = ProdutoSelected.ValorVenda;
                    DetalheNFe.NfeDetalheImpostoPis.ValorPis = (ProdutoSelected.ValorVenda * viewPis.AliquotaPorcento) / 100; ;
                }

                ViewTributacaoCofinsDTO viewCofins = new ViewTributacaoCofinsDTO();
                using (ServidorClient serv = new ServidorClient())
                {
                    viewCofins.IdTributOperacaoFiscal = NFeSelected.TributOperacaoFiscal.Id;
                    viewCofins.IdTributGrupoTributario = ProdutoSelected.TributGrupoTributario.Id;
                    viewCofins = serv.SelectViewTributacaoCofins(viewCofins);

                    DetalheNFe.NfeDetalheImpostoCofins = new NfeDetalheImpostoCofinsDTO();

                    DetalheNFe.NfeDetalheImpostoCofins.CstCofins = viewCofins.CstCofins;
                    DetalheNFe.NfeDetalheImpostoCofins.AliquotaCofinsPercentual = viewCofins.AliquotaPorcento;
                    DetalheNFe.NfeDetalheImpostoCofins.AliquotaCofinsReais = viewCofins.AliquotaUnidade;
                    DetalheNFe.NfeDetalheImpostoCofins.BaseCalculoCofins = ProdutoSelected.ValorVenda;
                    DetalheNFe.NfeDetalheImpostoCofins.ValorCofins = (ProdutoSelected.ValorVenda * viewCofins.AliquotaPorcento) / 100; ;
                }

                NFeSelected.ListaNfeDetalhe.Add(DetalheNFe);

                AtualizarNumeroItemDetalhe();
                AtualizarValoresNFe();

                ProdutoSelected = null;
                DetalheNFe = null;

                notifyPropertyChanged("ProdutoSelected");
                notifyPropertyChanged("DetalheNFe");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Demais procedimentos para a CT-e
        public void ConfiguraNfe()
        {
            // Exercício: carregue as configurações a partir do banco de dados
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                _configuracoes = !File.Exists(path + ArquivoConfiguracao) ? new ConfiguracaoApp() : FuncoesXml.ArquivoXmlParaClasse<ConfiguracaoApp>(path + ArquivoConfiguracao);
                if (_configuracoes.CfgServico.TimeOut == 0)
                    _configuracoes.CfgServico.TimeOut = 100;//mínimo
            }
            catch (Exception ex)
            {
                if (!String.IsNullOrEmpty(ex.Message))
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ConsultarStatusServico()
        {
            var servicoNFe = new ServicosNFe(_configuracoes.CfgServico);
            var retornoStatus = servicoNFe.NfeStatusServico();

            string mensagem = "";

            foreach (var atributos in Funcoes.LerPropriedades(retornoStatus.Retorno))
            {
                mensagem += atributos.Key + " = " + atributos.Value + "\r";
            }
            MessageBox.Show(mensagem, "Informação do Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        /// EXERCICIO: selecione um local apropriado para inutilizar notas.
        public void Inutilizar()
        {
            var ano = Funcoes.InpuBox(null, "Inutilizar Numeração", "Ano");
            if (string.IsNullOrEmpty(ano)) throw new Exception("O Ano deve ser informado!");
            if (ano.Length > 2) throw new Exception("O Ano deve ter dois números apenas!");

            var modelostr = Funcoes.InpuBox(null, "Inutilizar Numeração", "Modelo");
            if (string.IsNullOrEmpty(modelostr)) throw new Exception("O Modelo deve ser informado!");

            var modelo = (ModeloDocumento)Convert.ToInt16(modelostr);

            var serie = Funcoes.InpuBox(null, "Inutilizar Numeração", "Série");
            if (string.IsNullOrEmpty(serie)) throw new Exception("A série deve ser informada!");

            var numeroInicial = Funcoes.InpuBox(null, "Inutilizar Numeração", "Número Inicial");
            if (string.IsNullOrEmpty(numeroInicial)) throw new Exception("O Número Inicial deve ser informado!");

            var numeroFinal = Funcoes.InpuBox(null, "Inutilizar Numeração", "Número Final");
            if (string.IsNullOrEmpty(numeroFinal)) throw new Exception("O Número Final deve ser informado!");

            var justificativa = Funcoes.InpuBox(null, "Inutilizar Numeração", "Justificativa");
            if (string.IsNullOrEmpty(justificativa)) throw new Exception("A Justificativa deve ser informada!");

            var servicoNFe = new ServicosNFe(_configuracoes.CfgServico);
            var retornoConsulta = servicoNFe.NfeInutilizacao(_configuracoes.Emitente.CNPJ, Convert.ToInt16(ano),
                modelo, Convert.ToInt16(serie), Convert.ToInt16(numeroInicial),
                Convert.ToInt16(numeroFinal), justificativa);

            string mensagem = "";

            foreach (var atributos in Funcoes.LerPropriedades(retornoConsulta.Retorno))
            {
                mensagem += atributos.Key + " = " + atributos.Value + "\r";
            }
            MessageBox.Show(mensagem, "Informação do Sistema", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        // EXERCICIO: Faça as devidas adaptações na CC-e de acordo com sua necessidade
        public void CCe()
        {
            var idlote = Funcoes.InpuBox(null, "Carta de correção", "Identificador de controle do Lote de envio:");
            if (string.IsNullOrEmpty(idlote)) throw new Exception("A Id do Lote deve ser informada!");

            var sequenciaEvento = Funcoes.InpuBox(null, "Carta de correção", "Número sequencial do evento:");
            if (string.IsNullOrEmpty(sequenciaEvento))
                throw new Exception("O número sequencial deve ser informado!");

            var chave = Funcoes.InpuBox(null, "Carta de correção", "Chave da NFe:");
            if (string.IsNullOrEmpty(chave)) throw new Exception("A Chave deve ser informada!");
            if (chave.Length != 44) throw new Exception("Chave deve conter 44 caracteres!");

            var correcao = Funcoes.InpuBox(null, "Carta de correção", "Correção");
            if (string.IsNullOrEmpty(correcao)) throw new Exception("A Correção deve ser informada!");

            var servicoNFe = new ServicosNFe(_configuracoes.CfgServico);
            var cpfcnpj = string.IsNullOrEmpty(_configuracoes.Emitente.CNPJ)
                ? _configuracoes.Emitente.CPF
                : _configuracoes.Emitente.CNPJ;
            var retornoCartaCorrecao = servicoNFe.RecepcaoEventoCartaCorrecao(Convert.ToInt16(idlote),
                Convert.ToInt16(sequenciaEvento), chave, correcao, cpfcnpj);

            string mensagem = "";

            foreach (var atributos in Funcoes.LerPropriedades(retornoCartaCorrecao.Retorno))
            {
                mensagem += atributos.Key + " = " + atributos.Value + "\r";
            }
            MessageBox.Show(mensagem, "Informação do Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void GerarXmlNfe()
        {

            // EXERCICIO: trate os retornos da Sefaz e armazene o status da nota de acordo
            NFeSelected.StatusNota = 4;
            SalvarAtualizarNFe();


            infNFe InfNFe = new infNFe
            {
                versao = Auxiliar.VersaoServicoParaString(_configuracoes.CfgServico.VersaoNFeAutorizacao),
                ide = GetIdentificacao(),
                emit = GetEmitente(),
                transp = GetTransporte()
            };

            if (NFeSelected.NfeDestinatario.CpfCnpj != null)
                InfNFe.dest = GetDestinatario();

            for (var i = 0; i < 1; i++)
            {
                InfNFe.det.Add(GetDetalhe(i, InfNFe.emit.CRT));
            }

            InfNFe.total = GetTotal();

            _nfe = new NFe.Classes.NFe();
            _nfe.infNFe = InfNFe;

            _nfe.Assina();
            string nomeArquivoXml = @"C:\T2Ti\NFe\XML\" + NFeSelected.ChaveAcesso + NFeSelected.DigitoChaveAcesso + ".xml";
            _nfe.SalvarArquivoXml(nomeArquivoXml);
            var servicoNFe = new ServicosNFe(_configuracoes.CfgServico);
            var retornoEnvio = servicoNFe.NFeAutorizacao(1, IndicadorSincronizacao.Assincrono, new List<NFe.Classes.NFe> { _nfe });

            // consultar protocolo
            var retornoConsulta = servicoNFe.NfeConsultaProtocolo(NFeSelected.ChaveAcesso + NFeSelected.DigitoChaveAcesso);

            _protocolo = retornoConsulta.Retorno.protNFe.infProt.nProt;

            string mensagem = "";

            foreach (var atributos in Funcoes.LerPropriedades(retornoEnvio.Retorno))
            {
                mensagem += atributos.Key + " = " + atributos.Value + "\r";
            }
            MessageBox.Show(mensagem, "Informação do Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected ide GetIdentificacao()
        {
            var ide = new ide
            {
                cUF = Estado.DF,
                natOp = "VENDA",
                indPag = IndicadorPagamento.ipVista,
                mod = ModeloDocumento.NFe,
                serie = 1,
                nNF = int.Parse(NFeSelected.Numero),
                tpNF = TipoNFe.tnSaida,
                cMunFG = 5300108,
                tpEmis = _configuracoes.CfgServico.tpEmis,
                tpImp = TipoImpressao.tiRetrato,
                cNF = NFeSelected.CodigoNumerico,
                tpAmb = _configuracoes.CfgServico.tpAmb,
                finNFe = FinalidadeNFe.fnNormal,
                verProc = "3.000"
            };


            /// EXERCICIO: implemente a contingência de acordo com sua necessidade
            if (ide.tpEmis != TipoEmissao.teNormal)
            {
                ide.dhCont = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
                ide.xJust = "TESTE DE CONTIGÊNCIA PARA NFe/NFCe";
            }

            ide.idDest = DestinoOperacao.doInterna;
            ide.dhEmi = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            ide.procEmi = ProcessoEmissao.peAplicativoContribuinte;
            ide.indFinal = ConsumidorFinal.cfConsumidorFinal;
            ide.indPres = PresencaComprador.pcPresencial;

            return ide;
        }

        protected emit GetEmitente()
        {
            var emit = _configuracoes.Emitente;
            emit.enderEmit = GetEnderecoEmitente();
            return emit;
        }

        protected enderEmit GetEnderecoEmitente()
        {
            var enderEmit = _configuracoes.EnderecoEmitente;
            enderEmit.cPais = 1058;
            enderEmit.xPais = "BRASIL";
            return enderEmit;
        }

        protected dest GetDestinatario()
        {
            dest dest = new dest(_configuracoes.CfgServico.VersaoNFeAutorizacao);
            dest.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"; //NFeSelected.NfeDestinatario.Nome
            dest.indIEDest = indIEDest.NaoContribuinte;
            dest.email = NFeSelected.NfeDestinatario.Email;
            dest.CPF = NFeSelected.NfeDestinatario.CpfCnpj;
            dest.enderDest = GetEnderecoDestinatario();

            return dest;
        }

        protected enderDest GetEnderecoDestinatario()
        {
            var enderDest = new enderDest
            {
                xLgr = "RUA ...",
                nro = "S/N",
                xBairro = "CENTRO",
                cMun = 5300108,
                xMun = "brasilia",
                UF = "DF",
                CEP = "71925000",
                cPais = 1058,
                xPais = "BRASIL"
            };
            /*
            var enderDest = new enderDest
            {
                xLgr = NFeSelected.NfeDestinatario.Logradouro,
                nro = NFeSelected.NfeDestinatario.Numero,
                xBairro = NFeSelected.NfeDestinatario.Bairro,
                cMun = NFeSelected.NfeDestinatario.CodigoMunicipio.Value,
                xMun = NFeSelected.NfeDestinatario.NomeMunicipio,
                UF = NFeSelected.NfeDestinatario.Uf,
                CEP = NFeSelected.NfeDestinatario.Cep,
                cPais = 1058,
                xPais = "BRASIL"
            };
             */ 
            return enderDest;
        }

        protected det GetDetalhe(int i, CRT crt)
        {
            var det = new det
            {
                nItem = NFeSelected.ListaNfeDetalhe[i].NumeroItem.Value,
                prod = GetProduto(i),
                imposto = new imposto
                {
                    vTotTrib = decimal.Parse(NFeSelected.ListaNfeDetalhe[i].NfeDetalheImpostoIcms.ValorIcms.Value.ToString("N2")),
                    ICMS = new ICMS
                    {
                        TipoICMS = crt == CRT.SimplesNacional ? InformarCSOSN(Csosnicms.Csosn102) : InformarICMS(Csticms.Cst00, i)
                    },
                    COFINS = new COFINS { TipoCOFINS = new COFINSOutr { CST = CSTCOFINS.cofins99, pCOFINS = 0, vBC = 0, vCOFINS = 0 } },
                    PIS = new PIS { TipoPIS = new PISOutr { CST = CSTPIS.pis99, pPIS = 0, vBC = 0, vPIS = 0 } }
                }
            };

            return det;
        }

        protected prod GetProduto(int i)
        {
            var p = new prod
            {
                cProd = NFeSelected.ListaNfeDetalhe[i].Gtin,
                cEAN = NFeSelected.ListaNfeDetalhe[i].Gtin,
                xProd = NFeSelected.ListaNfeDetalhe[i].NomeProduto,
                NCM = NFeSelected.ListaNfeDetalhe[i].Ncm,
                CFOP = NFeSelected.ListaNfeDetalhe[i].Cfop.Value,
                uCom = NFeSelected.ListaNfeDetalhe[i].UnidadeComercial,
                qCom = NFeSelected.ListaNfeDetalhe[i].QuantidadeComercial.Value,
                vUnCom = decimal.Parse(NFeSelected.ListaNfeDetalhe[i].ValorUnitarioComercial.Value.ToString("N2")),
                vProd = decimal.Parse(NFeSelected.ListaNfeDetalhe[i].ValorTotal.Value.ToString("N2")),
                //vDesc = NFeSelected.ListaNfeDetalhe[i].ValorDesconto.Value,
                cEANTrib = NFeSelected.ListaNfeDetalhe[i].Gtin,
                uTrib = NFeSelected.ListaNfeDetalhe[i].UnidadeTributavel,
                qTrib = NFeSelected.ListaNfeDetalhe[i].QuantidadeTributavel.Value,
                vUnTrib = decimal.Parse(NFeSelected.ListaNfeDetalhe[i].ValorUnitarioTributavel.Value.ToString("N2")),
                indTot = IndicadorTotal.ValorDoItemCompoeTotalNF,
            };
            return p;
        }

        protected ICMSBasico InformarICMS(Csticms CST, int i)
        {
            switch (CST)
            {
                case Csticms.Cst00:
                    return new ICMS00
                    {
                        CST = Csticms.Cst00,
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        orig = OrigemMercadoria.OmNacional,
                        pICMS = decimal.Parse(NFeSelected.ListaNfeDetalhe[i].NfeDetalheImpostoIcms.AliquotaIcms.Value.ToString("N2")),
                        vBC = decimal.Parse(NFeSelected.ListaNfeDetalhe[i].NfeDetalheImpostoIcms.BaseCalculoIcms.Value.ToString("N2")),
                        vICMS = decimal.Parse(NFeSelected.ListaNfeDetalhe[i].NfeDetalheImpostoIcms.ValorIcms.Value.ToString("N2")),
                    };
                //Outros casos aqui
            }

            return new ICMS10();
        }

        protected ICMSBasico InformarCSOSN(Csosnicms CST)
        {
            switch (CST)
            {
                case Csosnicms.Csosn101:
                    return new ICMSSN101
                    {
                        CSOSN = Csosnicms.Csosn101,
                        orig = OrigemMercadoria.OmNacional
                    };
                case Csosnicms.Csosn102:
                    return new ICMSSN102
                    {
                        CSOSN = Csosnicms.Csosn102,
                        orig = OrigemMercadoria.OmNacional
                    };
                //Outros casos aqui
                default:
                    return new ICMSSN201();
            }
        }

        protected total GetTotal()
        {
            var icmsTot = new ICMSTot
            {
                vProd = decimal.Parse(NFeSelected.ValorTotalProdutos.Value.ToString("N2")),
                vNF = decimal.Parse(NFeSelected.ValorTotal.Value.ToString("N2")),
                vDesc = decimal.Parse(NFeSelected.ValorDesconto.Value.ToString("N2")),
                vTotTrib = decimal.Parse(NFeSelected.ValorIcms.Value.ToString("N2")),
                vBC = decimal.Parse(NFeSelected.BaseCalculoIcms.Value.ToString("N2")),
                vICMS = decimal.Parse(NFeSelected.ValorIcms.Value.ToString("N2")),
                vICMSDeson = 0
            };

            var t = new total { ICMSTot = icmsTot };
            return t;
        }

        protected transp GetTransporte()
        {
            var t = new transp
            {
                modFrete = ModalidadeFrete.mfSemFrete
            };

            return t;
        }

        // Exercício: Implemente os demais métodos para emissão da NF-e

        public void ImprimirDANFE()
        {
            // EXERCICIO: Solicite a justificativa para o usuário
            string Justificativa = "Alguma justificativa";

            // EXERCICIO: Faça com que a justificativa apareça no DANFE reimpresso.
            // EXERCICIO: Implemente um relatório com as estatísticas de reimpressões na sua suite preferida
            // EXERCICIO: Verifique se existem problemas no procedimento a seguir e corrija-os
            NFeSelected.QuantidadeImpressaoDanfe = NFeSelected.QuantidadeImpressaoDanfe + 1;
            NFeSelected.InformacoesAddContribuinte = "DANFE impresso pela " + NFeSelected.QuantidadeImpressaoDanfe.ToString() + "ª vez. Justificativa: " + Justificativa + ".";
            SalvarAtualizarNFe();

            //Imprime usando Unidanfe
            try
            {
                string nomeArquivoXml = @"C:\T2Ti\NFe\XML\" + NFeSelected.ChaveAcesso + NFeSelected.DigitoChaveAcesso + ".xml";
                Process unidanfe = new Process();
                unidanfe.StartInfo.FileName = @"C:\Unimake\UniNFe\unidanfe.exe";
                unidanfe.StartInfo.Arguments = " arquivo=" + nomeArquivoXml;
                unidanfe.Start();
                unidanfe.WaitForExit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion



    }
}
