using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExportarParaArquivo;
using ComprasClient.ComprasService;
using System.Collections.ObjectModel;
using SearchWindow;
using System.IO;
using System.Xml;
using ComprasClient.Model;

namespace ComprasClient.ViewModel.Compras
{
    public class CotacaoViewModel : ERPViewModelBase
    {
        public Operacao operacao { get; set; }
        public string textoPesquisa { get; set; }
        private bool _isSelectedTabPrincipal;
        private bool _isSelectedTabOperacoes;
        private bool _isSelectedTabConfirma;
        private CompraCotacaoDTO _selectedItem;
        private CompraFornecedorCotacaoDTO _selectedFornecedor;
        private CompraCotacaoDetalheDTO _selectedCotacaoDetalhe;
        public ObservableCollection<CompraCotacaoDTO> listaCotacao { get; set; }
        public ObservableCollection<CompraFornecedorCotacaoDTO> listaFornecedor { get; set; }
        public ObservableCollection<CompraCotacaoDetalheDTO> listaCotacaoDetalhe { get; set; }

        public CotacaoViewModel()
        {
            listaCotacao = new ObservableCollection<CompraCotacaoDTO>();
            listaFornecedor = new ObservableCollection<CompraFornecedorCotacaoDTO>();
            listaCotacaoDetalhe = new ObservableCollection<CompraCotacaoDetalheDTO>();

            isSelectedTabPrincipal = true;
        }

        public void importar()
        {
            try
            {
                    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                    dlg.DefaultExt = ".xml";
                    dlg.Filter = "Arquivo XML(.xml)|*.xml";

                    Nullable<bool> result = dlg.ShowDialog();

                    if (result == true)
                    {
                        FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                        XmlDocument cotacaoFornecedor = new XmlDocument();
                        cotacaoFornecedor.Load(fs);
                        XmlNodeList nodeListCotacao = cotacaoFornecedor.GetElementsByTagName("selectedItem");
                        selectedFornecedor.PrazoEntrega =  nodeListCotacao[0].ChildNodes[0].InnerText;
                        selectedFornecedor.VendaCondicoesPagamento = nodeListCotacao[0].ChildNodes[1].InnerText;
                        selectedFornecedor.ValorSubtotal = decimal.Parse(nodeListCotacao[0].ChildNodes[2].InnerText);
                        selectedFornecedor.TaxaDesconto = decimal.Parse(nodeListCotacao[0].ChildNodes[3].InnerText);
                        selectedFornecedor.ValorDesconto = decimal.Parse(nodeListCotacao[0].ChildNodes[4].InnerText);
                        selectedFornecedor.Total = decimal.Parse(nodeListCotacao[0].ChildNodes[5].InnerText);

                        XmlNodeList nodeListDetalhes = cotacaoFornecedor.GetElementsByTagName("item");

                        foreach (XmlNode item in nodeListDetalhes)
                        {
                            int id = int.Parse(item.FirstChild.ChildNodes[0].InnerText);

                            foreach(CompraCotacaoDetalheDTO cotacaoDetalhe in selectedFornecedor.listaCotacaoCompraDetalhe)
                            {
                                if (cotacaoDetalhe.Produto.Id == id)
                                {
                                    cotacaoDetalhe.Quantidade = decimal.Parse(item.ChildNodes[1].InnerText);
                                    cotacaoDetalhe.ValorUnitario = decimal.Parse(item.ChildNodes[2].InnerText);
                                    cotacaoDetalhe.ValorSubtotal = decimal.Parse(item.ChildNodes[3].InnerText);
                                    cotacaoDetalhe.TaxaDesconto = decimal.Parse(item.ChildNodes[4].InnerText);
                                    cotacaoDetalhe.ValorDesconto = decimal.Parse(item.ChildNodes[5].InnerText);
                                    cotacaoDetalhe.ValorTotal = decimal.Parse(item.ChildNodes[6].InnerText);
                                    break;
                                }
                            }
                        }
                        notifyPropertyChanged("selectedItem");
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void executarOperacao()
        {
            try
            {
            using(ComprasServiceClient comprasService = new ComprasServiceClient())
            {
                if (operacao == Operacao.Incluir)
                {
                    selectedItem.listaFornecedor = listaFornecedor.ToList();
                    foreach (CompraFornecedorCotacaoDTO fornecedor in selectedItem.listaFornecedor)
                    {
                        fornecedor.listaCotacaoCompraDetalhe = listaCotacaoDetalhe.ToList();
                    }

                    comprasService.saveCotacaoCompra(selectedItem);
                }

                if (operacao == Operacao.Excluir)
                    comprasService.deleteCotacaoCompra(selectedItem);

                if (operacao == Operacao.Alterar)
                {
                    selectedItem.listaFornecedor = listaFornecedor.ToList();
                    foreach (CompraFornecedorCotacaoDTO fornecedor in selectedItem.listaFornecedor)
                    {
                        fornecedor.listaCotacaoCompraDetalhe = listaCotacaoDetalhe.ToList();
                    }

                    comprasService.updateCotacaoCompra(selectedItem);
                }

                if (operacao == Operacao.ConfirmarCotacao)
                {
                    comprasService.updateCotacaoCompra(selectedItem);
                }
            }
            isSelectedTabPrincipal = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cancelarOperacao()
        {
            isSelectedTabPrincipal = true;
        }

        public void excluirCotacaoDetalhe()
        {
            listaCotacaoDetalhe.Remove(selectedCotacaoDetalhe);
        }

        public void incluirCotacaoDetalhe()
        {
            SearchWindowApp searchWindow = new SearchWindowApp(typeof(CompraRequisicaoDetalheDTO), typeof(ServicoCompras));

            if (searchWindow.ShowDialog() == true)
            {
                CompraCotacaoDetalheDTO cotacaoDetalhe = new CompraCotacaoDetalheDTO();

                CompraRequisicaoDetalheDTO reqDet = (CompraRequisicaoDetalheDTO)searchWindow.itemSelecionado;

                cotacaoDetalhe.Produto = reqDet.Produto;
                cotacaoDetalhe.Quantidade = reqDet.Quantidade;

                listaCotacaoDetalhe.Add(cotacaoDetalhe);
                notifyPropertyChanged("listaCotacaoDetalhe");
            }
        }

        public void excluirFornecedor()
        {
            listaFornecedor.Remove(selectedFornecedor);
        }

        public void incluirFornecedor()
        {
            SearchWindowApp searchWindow = new SearchWindowApp(typeof(ViewPessoaFornecedorDTO), typeof(ServicoCompras));

            if (searchWindow.ShowDialog() == true)
            {
                CompraFornecedorCotacaoDTO fornecedor = new CompraFornecedorCotacaoDTO();
                fornecedor.Fornecedor = (ViewPessoaFornecedorDTO)searchWindow.itemSelecionado;
                listaFornecedor.Add(fornecedor);
                
                notifyPropertyChanged("listaFornecedor");
            }
        }

        public void incluir()
        {
            operacao = Operacao.Incluir;
            selectedItem = new CompraCotacaoDTO();
            listaFornecedor = new ObservableCollection<CompraFornecedorCotacaoDTO>();
            listaCotacaoDetalhe = new ObservableCollection<CompraCotacaoDetalheDTO>();
            notifyPropertyChanged("visibilidadeEdicao");
            isSelectedTabOperacoes = true;
        }

        public void excluir()
        {
            operacao = Operacao.Excluir;
            carregarCotacaoCompleta();
            isSelectedTabOperacoes = true;
        }

        public void alterar()
        {
            operacao = Operacao.Alterar;
            carregarCotacaoCompleta();
            isSelectedTabOperacoes = true;
        }

        public void confirmarCotacao()
        {
            operacao = Operacao.ConfirmarCotacao;
            carregarCotacaoCompleta();
            selectedFornecedor = selectedItem.listaFornecedor.First();
            isSelectedTabConfirma = true;
        }

        private void carregarCotacaoCompleta()
        {
            selecionarCotacaoCompleta();
            listaFornecedor = new ObservableCollection<CompraFornecedorCotacaoDTO>(
                selectedItem.listaFornecedor);
            listaCotacaoDetalhe = new ObservableCollection<CompraCotacaoDetalheDTO>(
                selectedItem.listaFornecedor.First().listaCotacaoCompraDetalhe);
            notifyPropertyChanged("listaFornecedor");
            notifyPropertyChanged("listaCotacaoDetalhe");
            notifyPropertyChanged("visibilidadeEdicao");
        }

        private void selecionarCotacaoCompleta()
        {
            try
            {
                using (ComprasServiceClient comprasService = new ComprasServiceClient())
                {
                    selectedItem = comprasService.selectCotacaoCompraId(selectedItem);
                }
                notifyPropertyChanged("selectedItem");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool hasListaCotacaoDetalhe
        {
            get { return listaCotacaoDetalhe.Count > 0; }
        }

        public CompraCotacaoDetalheDTO selectedCotacaoDetalhe
        {
            get { return _selectedCotacaoDetalhe; }
            set
            {
                _selectedCotacaoDetalhe = value;
                notifyPropertyChanged("selectedCotacaoDetalhe");
                notifyPropertyChanged("isSelectedCotacaoDetalhe");
            }
        }

        public bool isSelectedCotacaoDetalhe
        {
            get { return _selectedCotacaoDetalhe != null; }
        } 
       
        public void pesquisar()
        {
            this.atualizarListaCotacao();
        }

        public bool hasListaFornecedor
        {
            get { return listaFornecedor.Count > 0; }
        }

        public CompraFornecedorCotacaoDTO selectedFornecedor
        {
            get { return _selectedFornecedor; }
            set
            {
                _selectedFornecedor = value;
                notifyPropertyChanged("selectedFornecedor");
                notifyPropertyChanged("isSelectedFornecedor");
            }
        }

        public bool isSelectedFornecedor
        {
            get { return _selectedFornecedor != null; }
        } 
       
        public bool hasListaCotacao
        {
            get { return listaCotacao.Count > 0; }
        }

        public bool isSelectedItem
        {
            get { return _selectedItem != null; }
        }

        public string visibilidadeEdicao
        {
            get 
            { 
                return operacao == Operacao.Excluir ? "HIDDEN" : "VISIBLE"; 
            }
        }

        public CompraCotacaoDTO selectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                notifyPropertyChanged("selectedItem");
                notifyPropertyChanged("isSelectedItem");
            }
        }

        public bool isSelectedTabPrincipal 
        {
            get { return _isSelectedTabPrincipal; }
            set
            {
                _isSelectedTabPrincipal = value;
                if (value)
                {
                    textoPesquisa = null;
                    atualizarListaCotacao();
                }

                notifyPropertyChanged("isSelectedTabPrincipal");
            }
        }

        private void atualizarListaCotacao()
        {
            try
            {
                using (ComprasServiceClient comprasService = new ComprasServiceClient())
                {
                    List<CompraCotacaoDTO> listaResultado = comprasService.selectCotacaoCompra(
                        new CompraCotacaoDTO { Descricao = textoPesquisa});
                    listaCotacao.Clear();
                    foreach (CompraCotacaoDTO cotacao in listaResultado)
                        listaCotacao.Add(cotacao);
                }
                notifyPropertyChanged("listaCotacao");
                notifyPropertyChanged("hasListaCotacao");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool isSelectedTabOperacoes
        {
            get { return _isSelectedTabOperacoes; }
            set
            {
                _isSelectedTabOperacoes = value;
                notifyPropertyChanged("isSelectedTabOperacoes");
            }
        }

        public bool isSelectedTabConfirma
        {
            get { return _isSelectedTabConfirma; }
            set
            {
                _isSelectedTabConfirma = value;
                notifyPropertyChanged("isSelectedTabConfirma");
            }
        }

        public void exportarDataGrid(ExportarParaArquivo.Formato formato, System.Windows.Controls.DataGrid dg)
        {
            Exportar exportar = new Exportar(formato);
            exportar.exportarDataGrid(dg);
        }

    }
}
