using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Inventario.Servico;
using Cadastros.Command;
using SearchWindow;
using EstoqueClient.Model;

namespace Cadastros.ViewModel
{
    public class EstoqueReajusteCabecalhoViewModel : ViewModelBase
    {

        #region Variáveis

        public ObservableCollection<EstoqueReajusteCabecalhoDTO> ListaEstoqueReajusteCabecalho { get; set; }
        private EstoqueReajusteCabecalhoDTO _EstoqueReajusteCabecalhoSelected;
        public EstoqueReajusteDetalheDTO EstoqueReajusteDetalheSelected { get; set; }
        private bool _isEditar { get; set; }

        #endregion

        #region Construtor
        public EstoqueReajusteCabecalhoViewModel()
        {
            try
            {
                ListaEstoqueReajusteCabecalho = new ObservableCollection<EstoqueReajusteCabecalhoDTO>();
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
        public EstoqueReajusteCabecalhoDTO EstoqueReajusteCabecalhoSelected
        {
            get { return _EstoqueReajusteCabecalhoSelected; }
            set
            {
                _EstoqueReajusteCabecalhoSelected = value;
                notifyPropertyChanged("EstoqueReajusteCabecalhoSelected");
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
        #endregion

        #region CRUD
        public void SalvarAtualizarEstoqueReajusteCabecalho()
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    Servico.SalvarAtualizarEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoSelected);
                    EstoqueReajusteCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaEstoqueReajusteCabecalho(int pagina)
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaEstoqueReajusteCabecalho.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    EstoqueReajusteCabecalhoDTO EstoqueReajusteCabecalho = new EstoqueReajusteCabecalhoDTO();

                    IList<EstoqueReajusteCabecalhoDTO> ListaServ = Servico.SelectEstoqueReajusteCabecalhoPagina(IndiceNavegacao, QuantidadePagina, EstoqueReajusteCabecalho);

                    ListaEstoqueReajusteCabecalho.Clear();

                    foreach (EstoqueReajusteCabecalhoDTO objAdd in ListaServ)
                    {
                        ListaEstoqueReajusteCabecalho.Add(objAdd);
                    }
                    EstoqueReajusteCabecalhoSelected = null;
                }
                QuantidadeCarregada = ListaEstoqueReajusteCabecalho.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ExcluirEstoqueReajusteCabecalho()
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    Servico.DeleteEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoSelected);
                    EstoqueReajusteCabecalhoSelected = null;
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
                EstoqueReajusteCabecalhoSelected = new EstoqueReajusteCabecalhoDTO();
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
                if (EstoqueReajusteCabecalhoSelected != null)
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
                if (EstoqueReajusteCabecalhoSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirEstoqueReajusteCabecalho();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaEstoqueReajusteCabecalho(IndiceNavegacao);
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
                EstoqueReajusteCabecalhoSelected = null;
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
                SalvarAtualizarEstoqueReajusteCabecalho();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaEstoqueReajusteCabecalho(IndiceNavegacao);
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
                AtualizarListaEstoqueReajusteCabecalho(0);
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
                            notifyPropertyChanged("EstoqueReajusteCabecalhoSelected");
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
                            DataGridExportacao.ItemsSource = ListaEstoqueReajusteCabecalho;
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
                            DataGridExportacao.ItemsSource = ListaEstoqueReajusteCabecalho;
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
                            DataGridExportacao.ItemsSource = ListaEstoqueReajusteCabecalho;
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
                            DataGridExportacao.ItemsSource = ListaEstoqueReajusteCabecalho;
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
                            AtualizarListaEstoqueReajusteCabecalho(1);
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
                            AtualizarListaEstoqueReajusteCabecalho(-1);
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


        #region Pesquisas

        public void pesquisarColaborador()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ColaboradorDTO), typeof(ServicoEstoque));
                if (searchWindow.ShowDialog() == true)
                {
                    EstoqueReajusteCabecalhoSelected.Colaborador = (ColaboradorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("EstoqueReajusteCabecalhoSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Actions

        public void realizarCalculos()
        {
            try
            {
                foreach (EstoqueReajusteDetalheDTO detalhe in EstoqueReajusteCabecalhoSelected.ListaEstoqueReajusteDetalhe)
                {
                    if (EstoqueReajusteCabecalhoSelected.TipoReajuste == "A")
                    {
                        detalhe.ValorReajuste = detalhe.ValorOriginal * (1 + (EstoqueReajusteCabecalhoSelected.Porcentagem / 100));
                    }
                    else
                    {
                        detalhe.ValorReajuste = detalhe.ValorOriginal * (1 - (EstoqueReajusteCabecalhoSelected.Porcentagem / 100));
                    }
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
