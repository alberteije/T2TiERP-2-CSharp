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
    public class VendedorViewModel : ViewModelBase
    {

        #region Variáveis

        public ObservableCollection<VendedorDTO> ListaVendedor { get; set; }
        private VendedorDTO _VendedorSelected;
        private bool _isEditar { get; set; }

        #endregion

        #region Construtor
        public VendedorViewModel()
        {
            try
            {
                ListaVendedor = new ObservableCollection<VendedorDTO>();
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
        public VendedorDTO VendedorSelected
        {
            get { return _VendedorSelected; }
            set
            {
                _VendedorSelected = value;
                notifyPropertyChanged("VendedorSelected");
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

        public void PesquisarLocalVenda()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(LocalVendaDTO),
                    typeof(ServicoSIS));

                if (searchWindow.ShowDialog() == true)
                {
                    VendedorSelected.LocalVenda = (LocalVendaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendedorSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PesquisarTipoPagamento()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(TipoPagamentoDTO),
                    typeof(ServicoSIS));

                if (searchWindow.ShowDialog() == true)
                {
                    VendedorSelected.TipoPagamento = (TipoPagamentoDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendedorSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PesquisarSituacaoVendedor()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(SituacaoVendedorDTO),
                    typeof(ServicoSIS));

                if (searchWindow.ShowDialog() == true)
                {
                    VendedorSelected.SituacaoVendedor = (SituacaoVendedorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("VendedorSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region CRUD
        public void SalvarAtualizarVendedor()
        {
            try
            {
                using (ServicoSISClient Servico = new ServicoSISClient())
                {
                    Servico.SalvarAtualizarVendedor(VendedorSelected);
                    VendedorSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaVendedor(int pagina)
        {
            try
            {
                using (ServicoSISClient Servico = new ServicoSISClient())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaVendedor.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    VendedorDTO Vendedor = new VendedorDTO();
                    if (!Filtro.Trim().Equals(""))
                    {
                        Vendedor.Nome = Filtro;
                    }

                    List<VendedorDTO> ListaServ = Servico.SelectVendedorPagina(IndiceNavegacao, QuantidadePagina, Vendedor);

                    ListaVendedor.Clear();

                    foreach (VendedorDTO objAdd in ListaServ)
                    {
                        ListaVendedor.Add(objAdd);
                    }
                    VendedorSelected = null;
                }
                QuantidadeCarregada = ListaVendedor.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ExcluirVendedor()
        {
            try
            {
                using (ServicoSISClient Servico = new ServicoSISClient())
                {
                    Servico.DeleteVendedor(VendedorSelected);
                    VendedorSelected = null;
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
                VendedorSelected = new VendedorDTO();
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
                if (VendedorSelected != null)
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
                if (VendedorSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirVendedor();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaVendedor(IndiceNavegacao);
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
                VendedorSelected = null;
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
                SalvarAtualizarVendedor();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaVendedor(IndiceNavegacao);
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
                AtualizarListaVendedor(0);
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
                            notifyPropertyChanged("VendedorSelected");
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
                            DataGridExportacao.ItemsSource = ListaVendedor;
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
                            DataGridExportacao.ItemsSource = ListaVendedor;
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
                            DataGridExportacao.ItemsSource = ListaVendedor;
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
                            DataGridExportacao.ItemsSource = ListaVendedor;
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
                            AtualizarListaVendedor(1);
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
                            AtualizarListaVendedor(-1);
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
