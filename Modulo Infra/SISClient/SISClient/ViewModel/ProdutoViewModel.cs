using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using SISClient.Command;
using SISClient.ServicoSISReference;
using SearchWindow;
using SISClient.Model;

namespace SISClient.ViewModel
{
    public class ProdutoViewModel : ViewModelBase
    {

        #region Variáveis

        public ObservableCollection<ProdutoDTO> ListaProduto { get; set; }
        private ProdutoDTO _ProdutoSelected;
        private bool _isEditar { get; set; }

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

        public bool IsEditar
        {
            get { return _isEditar; }
            set
            {
                _isEditar = value;
                notifyPropertyChanged("IsEditar");
                notifyPropertyChanged("IsListar");
            }
        }

        public bool IsListar
        {
            get { return !_isEditar; }
            set
            {
                _isEditar = !value;
                notifyPropertyChanged("IsEditar");
                notifyPropertyChanged("IsListar");
            }
        }

        public void PesquisarCategoriaProduto()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(CategoriaProdutoDTO),
                    typeof(ServicoSIS));

                if (searchWindow.ShowDialog() == true)
                {
                    ProdutoSelected.CategoriaProduto = (CategoriaProdutoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("ProdutoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CRUD
        public void SalvarAtualizarProduto()
        {
            try
            {
                using (ServicoSISClient Servico = new ServicoSISClient())
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
                using (ServicoSISClient Servico = new ServicoSISClient())
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

                    List<ProdutoDTO> ListaServ = Servico.SelectProdutoPagina(IndiceNavegacao, QuantidadePagina, Produto);

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
                using (ServicoSISClient Servico = new ServicoSISClient())
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
        public void BotaoInserir()
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
        
        public void BotaoAlterar()
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

        public void BotaoExcluir()
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

        public void BotaoCancelar()
        {
            try
            {
                IsEditar = false;
                ProdutoSelected = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void BotaoSalvar()
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

        public void BotaoLocalizar()
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
        #endregion

        #region Comandos Botões
        public ICommand InserirCommand
        {
            get
            {
                if (BotaoInserirCommand == null)
                {
                    BotaoInserirCommand = new RelayCommand
                    (
                        param =>
                        {
                            BotaoInserir();
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoInserirCommand;
            }
        }

        public ICommand AlterarCommand
        {
            get
            {
                if (BotaoAlterarCommand == null)
                {
                    BotaoAlterarCommand = new RelayCommand
                    (
                        param =>
                        {
                            BotaoAlterar();
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoAlterarCommand;
            }
        }

        public ICommand ExcluirCommand
        {
            get
            {
                if (BotaoExcluirCommand == null)
                {
                    BotaoExcluirCommand = new RelayCommand
                    (
                        param =>
                        {
                            BotaoExcluir();
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoExcluirCommand;
            }
        }

        public ICommand CancelarCommand
        {
            get
            {
                if (BotaoCancelarCommand == null)
                {
                    BotaoCancelarCommand = new RelayCommand
                    (
                        param =>
                        {
                            notifyPropertyChanged("ProdutoSelected");
                            BotaoCancelar();
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoCancelarCommand;
            }
        }

        public ICommand SalvarCommand
        {
            get
            {
                if (BotaoSalvarCommand == null)
                {
                    BotaoSalvarCommand = new RelayCommand
                    (
                        param =>
                        {
                            BotaoSalvar();
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoSalvarCommand;
            }
        }

        public ICommand LocalizarCommand
        {
            get
            {
                if (BotaoLocalizarCommand == null)
                {
                    BotaoLocalizarCommand = new RelayCommand
                    (
                        param =>
                        {
                            BotaoLocalizar();
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoLocalizarCommand;
            }
        }

        public ICommand ExportarXlsCommand
        {
            get
            {
                if (BotaoExportarXlsCommand == null)
                {
                    BotaoExportarXlsCommand = new RelayCommand
                    (
                        param =>
                        {
                            DataGridExportacao.ItemsSource = ListaProduto;
                            ExportarDataGrid((ExportarParaArquivo.Formato)(0));
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoExportarXlsCommand;
            }
        }

        public ICommand ExportarCsvCommand
        {
            get
            {
                if (BotaoExportarCsvCommand == null)
                {
                    BotaoExportarCsvCommand = new RelayCommand
                    (
                        param =>
                        {
                            DataGridExportacao.ItemsSource = ListaProduto;
                            ExportarDataGrid((ExportarParaArquivo.Formato)(1));
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoExportarCsvCommand;
            }
        }

        public ICommand ExportarTxtCommand
        {
            get
            {
                if (BotaoExportarTxtCommand == null)
                {
                    BotaoExportarTxtCommand = new RelayCommand
                    (
                        param =>
                        {
                            DataGridExportacao.ItemsSource = ListaProduto;
                            ExportarDataGrid((ExportarParaArquivo.Formato)(2));
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoExportarTxtCommand;
            }
        }

        public ICommand ExportarRtfCommand
        {
            get
            {
                if (BotaoExportarRtfCommand == null)
                {
                    BotaoExportarRtfCommand = new RelayCommand
                    (
                        param =>
                        {
                            DataGridExportacao.ItemsSource = ListaProduto;
                            ExportarDataGrid((ExportarParaArquivo.Formato)(3));
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return BotaoExportarRtfCommand;
            }
        }
        #endregion

        #region Comandos Navegação
        public ICommand PaginaSeguinteCommand
        {
            get
            {
                if (PagSeguinteCommand == null)
                {
                    PagSeguinteCommand = new RelayCommand
                    (
                        param =>
                        {
                            AtualizarListaProduto(1);
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return PagSeguinteCommand;
            }
        }

        public ICommand PaginaAnteriorCommand
        {
            get
            {
                if (PagAnteriorCommand == null)
                {
                    PagAnteriorCommand = new RelayCommand
                    (
                        param =>
                        {
                            AtualizarListaProduto(-1);
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return PagAnteriorCommand;
            }
        }
        #endregion


    }
}
