using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ComprasClient.ComprasService;
using ExportarParaArquivo;
using SearchWindow;
using ComprasClient.Model;

namespace ComprasClient.ViewModel.Compras
{
    public class RequisicaoViewModel : ERPViewModelBase
    {
        public ObservableCollection<CompraRequisicaoDTO> listaRequisicaoCompra { get; set; }
        public ObservableCollection<CompraRequisicaoDetalheDTO> listaRequisicaoCompraDetalhe { get; set; }
        private CompraRequisicaoDTO _selectedItem;
        private CompraRequisicaoDetalheDTO _selectedItemDetalhe;
        public Operacao operacao { get; set; }
        public string textoPesquisa { get; set; }
        private bool _isSelectedTabPrincipal;
        private bool _isSelectedTabOperacoes;

        /// EXERCICIO: Implemente o campo OBSERVACAO

        public RequisicaoViewModel()
        {
            listaRequisicaoCompra = new ObservableCollection<CompraRequisicaoDTO>();
            isSelectedTabPrincipal = true;
        }

        public void excluirProduto()
        {
            listaRequisicaoCompraDetalhe.Remove(selectedItemDetalhe);
            notifyPropertyChanged("listaRequisicaoCompraDetalhe");
        }

        public void incluirProduto()
        {
            SearchWindowApp searchWindow = new SearchWindowApp(typeof(ProdutoDTO), typeof(ServicoCompras));

            if (searchWindow.ShowDialog() == true)
            {
                CompraRequisicaoDetalheDTO reqCompraDetalhe = new CompraRequisicaoDetalheDTO();
                reqCompraDetalhe.Produto = (ProdutoDTO)searchWindow.itemSelecionado;
                reqCompraDetalhe.Quantidade = 0;
                reqCompraDetalhe.IdCompraRequisicao = selectedItem.Id;

                listaRequisicaoCompraDetalhe.Add(reqCompraDetalhe);
                notifyPropertyChanged("listaRequisicaoCompraDetalhe");
            }
        }

        public void pesquisarTipoRequisicao()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(CompraTipoRequisicaoDTO), typeof(ServicoCompras));

                if (searchWindow.ShowDialog() == true)
                {
                    selectedItem.CompraTipoRequisicao = (CompraTipoRequisicaoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("selectedItem");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarColaborador()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ColaboradorDTO), typeof(ServicoCompras));

                if (searchWindow.ShowDialog() == true)
                {
                    selectedItem.Colaborador = (ColaboradorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("selectedItem");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void atualizarListaRequisicao()
        {
            try
            {
                using (ComprasServiceClient comprasService = new ComprasServiceClient())
                {
                    List<CompraRequisicaoDTO> listaResultado = comprasService.selectCompraRequisicao(
                        new CompraRequisicaoDTO
                        {
                            CompraTipoRequisicao = new CompraTipoRequisicaoDTO { Nome = textoPesquisa }
                        });
                    listaRequisicaoCompra.Clear();
                    foreach (CompraRequisicaoDTO reqCompra in listaResultado)
                        listaRequisicaoCompra.Add(reqCompra);
                }
                notifyPropertyChanged("listaRequisicaoCompra");
                notifyPropertyChanged("hasListaRequisicao");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompraRequisicaoDetalheDTO selectedItemDetalhe
        {
            get { return _selectedItemDetalhe; }
            set
            {
                _selectedItemDetalhe = value;
                notifyPropertyChanged("selectedItemDetalhe");
                notifyPropertyChanged("isSelectedItemDetalhe");
            }
        }

        public CompraRequisicaoDTO selectedItem 
        {
            get { return _selectedItem; }
            set 
            { 
                _selectedItem = value;
                notifyPropertyChanged("selectedItem");
                notifyPropertyChanged("isSelectedItem");
            }
        }

        public bool hasListaRequisicao
        {
            get { return listaRequisicaoCompra.Count > 0; }
        }

        public bool isSelectedItem
        {
            get { return _selectedItem != null; }
        }

        public bool isSelectedItemDetalhe
        {
            get { return _selectedItemDetalhe != null; }
        }

        public bool isSelectedTabPrincipal
        {
            get { return _isSelectedTabPrincipal; }
            set 
            {
                _isSelectedTabPrincipal = value;
                if (value)
                {
                    this.atualizarListaRequisicao();
                }
                
                notifyPropertyChanged("isSelectedTabPrincipal");
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

        public void incluir() 
        {
            operacao = Operacao.Incluir;
            selectedItem = new CompraRequisicaoDTO();
            selectedItem.Colaborador = new ColaboradorDTO();
            selectedItem.CompraTipoRequisicao = new CompraTipoRequisicaoDTO();
            listaRequisicaoCompraDetalhe = new ObservableCollection<CompraRequisicaoDetalheDTO>();
            isSelectedTabOperacoes = true;
        }

        public void excluir()
        {
            operacao = Operacao.Excluir;
            isSelectedTabOperacoes = true;
        }

        public void alterar()
        {
            operacao = Operacao.Alterar;
            listaRequisicaoCompraDetalhe = new ObservableCollection<CompraRequisicaoDetalheDTO>();
            if (selectedItem.ListaCompraRequisicaoDetalhe != null &&
                selectedItem.ListaCompraRequisicaoDetalhe.Count > 0)
            {
                foreach (CompraRequisicaoDetalheDTO reqDet in selectedItem.ListaCompraRequisicaoDetalhe)
                    listaRequisicaoCompraDetalhe.Add(reqDet);
            }
            notifyPropertyChanged("listaRequisicaoCompraDetalhe");
            isSelectedTabOperacoes = true;
        }

        public void executaOperacao()
        { 
            using(ComprasServiceClient comprasService = new ComprasServiceClient())
            {
                if (operacao == Operacao.Incluir)
                {
                    selectedItem.DataRequisicao = DateTime.Now;
                    selectedItem.ListaCompraRequisicaoDetalhe = listaRequisicaoCompraDetalhe.ToList();
                    comprasService.salvarAtualizarCompraRequisicao(selectedItem);
                }

                if (operacao == Operacao.Excluir)
                    comprasService.deleteCompraRequisicao(selectedItem);

                if (operacao == Operacao.Alterar)
                {
                    selectedItem.ListaCompraRequisicaoDetalhe = listaRequisicaoCompraDetalhe.ToList();
                    comprasService.salvarAtualizarCompraRequisicao(selectedItem);
                }
            }
            isSelectedTabPrincipal = true;
        }

        public void cancelarOperacao()
        {
            isSelectedTabPrincipal = true;
        }

        public void pesquisar()
        {
            this.atualizarListaRequisicao();
        }

        public void exportarDataGrid(ExportarParaArquivo.Formato formato, System.Windows.Controls.DataGrid dg)
        {
            Exportar exportar = new Exportar(formato);
            exportar.exportarDataGrid(dg);
        }
    }
}
