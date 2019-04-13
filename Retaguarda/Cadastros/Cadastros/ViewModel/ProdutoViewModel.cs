using Cadastros.Command;
using Cadastros.Model;
using Cadastros.ServidorReference;
using SearchWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Cadastros.ViewModel
{
    public class ProdutoViewModel : ViewModelBase
    {

        #region Variáveis
        public ObservableCollection<ProdutoDTO> ListaProduto { get; set; }
        private ProdutoDTO _ProdutoSelected;
        #endregion

        #region Construtor
        public ProdutoViewModel()
        {
            try
            {
                ListaProduto = new ObservableCollection<ProdutoDTO>();
                IndiceNavegacao = 0;
                QuantidadeCarregada = 0;
                Filtro = "";
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Infra
        public ProdutoDTO ProdutoSelected
        {
            get { return _ProdutoSelected; }
            set
            {
                _ProdutoSelected = value;
                notifyPropertyChanged("ProdutoSelected");
            }
        }
        #endregion

        #region CRUD
        public void SalvarAtualizarProduto()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.SalvarAtualizarProduto(ProdutoSelected);
                    ProdutoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaProduto(int pagina)
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaProduto.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    ProdutoDTO Produto = new ProdutoDTO();
                    if (!Filtro.Trim().Equals(""))
                    {
                        Produto.Nome = Filtro;
                    }

                    IList<ProdutoDTO> ListaServ = Servico.SelectProdutoPagina(IndiceNavegacao, true, QuantidadePagina, true, Produto);

                    ListaProduto.Clear();

                    foreach (ProdutoDTO objAdd in ListaServ)
                    {
                        ListaProduto.Add(objAdd);
                    }
                    ProdutoSelected = null;
                }
                QuantidadeCarregada = ListaProduto.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirProduto()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.DeleteProduto(ProdutoSelected);
                    ProdutoSelected = null;
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
                ProdutoSelected = new ProdutoDTO();
                IsEditar = true;
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
                if (ProdutoSelected != null)
                    IsEditar = true;
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
                if (ProdutoSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirProduto();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaProduto(IndiceNavegacao);
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
                BotaoLocalizar();
                IsEditar = false;
                ProdutoSelected = null;
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
                SalvarAtualizarProduto();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaProduto(IndiceNavegacao);
                IsEditar = false;
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
                AtualizarListaProduto(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoExportar()
        {
            DataGridExportacao.ItemsSource = ListaProduto;
        }

        public override void BotaoPaginaSeguinte()
        {
            AtualizarListaProduto(1);
        }

        public override void BotaoPaginaAnterior()
        {
            AtualizarListaProduto(-1);
        }
        #endregion

        #region Pesquisas
        public void PesquisarProdutoSubGrupo()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ProdutoSubGrupoDTO),
                    typeof(ServicoCadastros));

                if (searchWindow.ShowDialog() == true)
                {
                    ProdutoSelected.ProdutoSubGrupo = (ProdutoSubGrupoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ProdutoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PesquisarProdutoMarca()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ProdutoMarcaDTO),
                    typeof(ServicoCadastros));

                if (searchWindow.ShowDialog() == true)
                {
                    ProdutoSelected.ProdutoMarca = (ProdutoMarcaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ProdutoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PesquisarTributGrupoTributario()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TributGrupoTributarioDTO),
                    typeof(ServicoCadastros));

                if (searchWindow.ShowDialog() == true)
                {
                    ProdutoSelected.TributGrupoTributario = (TributGrupoTributarioDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ProdutoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PesquisarAlmoxarifado()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(AlmoxarifadoDTO),
                    typeof(ServicoCadastros));

                if (searchWindow.ShowDialog() == true)
                {
                    ProdutoSelected.Almoxarifado = (AlmoxarifadoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ProdutoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PesquisarUnidadeProduto()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(UnidadeProdutoDTO),
                    typeof(ServicoCadastros));

                if (searchWindow.ShowDialog() == true)
                {
                    ProdutoSelected.UnidadeProduto = (UnidadeProdutoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ProdutoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PesquisarTributIcmsCustomCab()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TributIcmsCustomCabDTO),
                    typeof(ServicoCadastros));

                if (searchWindow.ShowDialog() == true)
                {
                    ProdutoSelected.TributIcmsCustomCab = (TributIcmsCustomCabDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ProdutoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion       

    }
}
