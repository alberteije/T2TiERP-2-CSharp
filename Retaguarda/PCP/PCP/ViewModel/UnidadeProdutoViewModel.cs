using Cadastros.Command;
using Cadastros.Model;
using PCP.Servico;
using SearchWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Cadastros.ViewModel
{
    public class UnidadeProdutoViewModel : ViewModelBase
    {

        #region Variáveis
        public ObservableCollection<UnidadeProdutoDTO> ListaUnidadeProduto { get; set; }
        private UnidadeProdutoDTO _UnidadeProdutoSelected;
        #endregion

        #region Construtor
        public UnidadeProdutoViewModel()
        {
            try
            {
                ListaUnidadeProduto = new ObservableCollection<UnidadeProdutoDTO>();
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
        public UnidadeProdutoDTO UnidadeProdutoSelected
        {
            get { return _UnidadeProdutoSelected; }
            set
            {
                _UnidadeProdutoSelected = value;
                notifyPropertyChanged("UnidadeProdutoSelected");
            }
        }
        #endregion

        #region CRUD
        public void SalvarAtualizarUnidadeProduto()
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    Servico.SalvarAtualizarUnidadeProduto(UnidadeProdutoSelected);
                    UnidadeProdutoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaUnidadeProduto(int pagina)
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaUnidadeProduto.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    UnidadeProdutoDTO UnidadeProduto = new UnidadeProdutoDTO();
                    if (!Filtro.Trim().Equals(""))
                    {
                        UnidadeProduto.Sigla = Filtro;
                    }

                    IList<UnidadeProdutoDTO> ListaServ = Servico.SelectUnidadeProdutoPagina(IndiceNavegacao, QuantidadePagina, UnidadeProduto);

                    ListaUnidadeProduto.Clear();

                    foreach (UnidadeProdutoDTO objAdd in ListaServ)
                    {
                        ListaUnidadeProduto.Add(objAdd);
                    }
                    UnidadeProdutoSelected = null;
                }
                QuantidadeCarregada = ListaUnidadeProduto.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirUnidadeProduto()
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    Servico.DeleteUnidadeProduto(UnidadeProdutoSelected);
                    UnidadeProdutoSelected = null;
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
                UnidadeProdutoSelected = new UnidadeProdutoDTO();
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
                if (UnidadeProdutoSelected != null)
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
                if (UnidadeProdutoSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirUnidadeProduto();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaUnidadeProduto(IndiceNavegacao);
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
                UnidadeProdutoSelected = null;
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
                SalvarAtualizarUnidadeProduto();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaUnidadeProduto(IndiceNavegacao);
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
                AtualizarListaUnidadeProduto(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoExportar()
        {
            DataGridExportacao.ItemsSource = ListaUnidadeProduto;
        }

        public override void BotaoPaginaSeguinte()
        {
            AtualizarListaUnidadeProduto(1);
        }

        public override void BotaoPaginaAnterior()
        {
            AtualizarListaUnidadeProduto(-1);
        }
        #endregion


    }
}
