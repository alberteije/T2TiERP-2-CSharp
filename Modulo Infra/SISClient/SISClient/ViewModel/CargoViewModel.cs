using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using SISClient.Command;
using SISClient.ServicoSISReference;

namespace SISClient.ViewModel
{
    public class CargoViewModel : ViewModelBase
    {

        #region Variáveis

        public ObservableCollection<CargoDTO> ListaCargo { get; set; }
        private CargoDTO _CargoSelected;
        private bool _isEditar { get; set; }

        #endregion

        #region Construtor
        public CargoViewModel()
        {
            try
            {
                ListaCargo = new ObservableCollection<CargoDTO>();
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
        public CargoDTO CargoSelected
        {
            get { return _CargoSelected; }
            set
            {
                _CargoSelected = value;
                notifyPropertyChanged("CargoSelected");
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
        public void SalvarAtualizarCargo()
        {
            try
            {
                using (ServicoSISClient Servico = new ServicoSISClient())
                {
                    Servico.SalvarAtualizarCargo(CargoSelected);
                    CargoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaCargo(int pagina)
        {
            try
            {
                using (ServicoSISClient Servico = new ServicoSISClient())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaCargo.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    CargoDTO Cargo = new CargoDTO();
                    if (!Filtro.Trim().Equals(""))
                    {
                        Cargo.Nome = Filtro;
                    }

                    List<CargoDTO> ListaServ = Servico.SelectCargoPagina(IndiceNavegacao, QuantidadePagina, Cargo);

                    ListaCargo.Clear();

                    foreach (CargoDTO objAdd in ListaServ)
                    {
                        ListaCargo.Add(objAdd);
                    }
                    CargoSelected = null;
                }
                QuantidadeCarregada = ListaCargo.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ExcluirCargo()
        {
            try
            {
                using (ServicoSISClient Servico = new ServicoSISClient())
                {
                    Servico.DeleteCargo(CargoSelected);
                    CargoSelected = null;
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
                CargoSelected = new CargoDTO();
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
                if (CargoSelected != null)
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
                if (CargoSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirCargo();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaCargo(IndiceNavegacao);
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
                CargoSelected = null;
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
                SalvarAtualizarCargo();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaCargo(IndiceNavegacao);
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
                AtualizarListaCargo(0);
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
                            notifyPropertyChanged("CargoSelected");
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
                            DataGridExportacao.ItemsSource = ListaCargo;
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
                            DataGridExportacao.ItemsSource = ListaCargo;
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
                            DataGridExportacao.ItemsSource = ListaCargo;
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
                            DataGridExportacao.ItemsSource = ListaCargo;
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
                            AtualizarListaCargo(1);
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
                            AtualizarListaCargo(-1);
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
