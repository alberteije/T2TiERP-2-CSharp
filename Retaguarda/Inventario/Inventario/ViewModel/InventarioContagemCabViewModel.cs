using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Inventario.Servico;
using Cadastros.Command;

namespace Cadastros.ViewModel
{
    public class InventarioContagemCabViewModel : ViewModelBase
    {

        #region Variáveis

        public ObservableCollection<InventarioContagemCabDTO> ListaEstoqueContagemCabecalho { get; set; }
        private InventarioContagemCabDTO _EstoqueContagemCabecalhoSelected;
        public InventarioContagemDetDTO EstoqueContagemDetalheSelected { get; set; }

        private bool _isEditar { get; set; }

        #endregion

        #region Construtor
        public InventarioContagemCabViewModel()
        {
            try
            {
                ListaEstoqueContagemCabecalho = new ObservableCollection<InventarioContagemCabDTO>();
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
        public InventarioContagemCabDTO EstoqueContagemCabecalhoSelected
        {
            get { return _EstoqueContagemCabecalhoSelected; }
            set
            {
                _EstoqueContagemCabecalhoSelected = value;
                notifyPropertyChanged("EstoqueContagemCabecalhoSelected");
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
        public void SalvarAtualizarInventarioContagemCab()
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    EstoqueContagemCabecalhoSelected.Empresa = Empresa;
                    Servico.SalvarAtualizarInventarioContagemCab(EstoqueContagemCabecalhoSelected);
                    EstoqueContagemCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaEstoqueContagemCabecalho(int pagina)
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaEstoqueContagemCabecalho.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    InventarioContagemCabDTO InventarioContagemCab = new InventarioContagemCabDTO();

                    IList<InventarioContagemCabDTO> ListaServ = Servico.SelectInventarioContagemCabPagina(IndiceNavegacao, QuantidadePagina, InventarioContagemCab);

                    ListaEstoqueContagemCabecalho.Clear();

                    foreach (InventarioContagemCabDTO objAdd in ListaServ)
                    {
                        ListaEstoqueContagemCabecalho.Add(objAdd);
                    }
                    EstoqueContagemCabecalhoSelected = null;
                }
                QuantidadeCarregada = ListaEstoqueContagemCabecalho.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ExcluirInventarioContagemCab()
        {
            try
            {
                using (ServidorClient Servico = new ServidorClient())
                {
                    Servico.DeleteInventarioContagemCab(EstoqueContagemCabecalhoSelected);
                    EstoqueContagemCabecalhoSelected = null;
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
                EstoqueContagemCabecalhoSelected = new InventarioContagemCabDTO();
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
                if (EstoqueContagemCabecalhoSelected != null)
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
                if (EstoqueContagemCabecalhoSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirInventarioContagemCab();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaEstoqueContagemCabecalho(IndiceNavegacao);
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
                EstoqueContagemCabecalhoSelected = null;
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
                SalvarAtualizarInventarioContagemCab();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaEstoqueContagemCabecalho(IndiceNavegacao);
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
                AtualizarListaEstoqueContagemCabecalho(0);
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
                            notifyPropertyChanged("EstoqueContagemCabecalhoSelected");
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
                            DataGridExportacao.ItemsSource = ListaEstoqueContagemCabecalho;
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
                            DataGridExportacao.ItemsSource = ListaEstoqueContagemCabecalho;
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
                            DataGridExportacao.ItemsSource = ListaEstoqueContagemCabecalho;
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
                            DataGridExportacao.ItemsSource = ListaEstoqueContagemCabecalho;
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
                            AtualizarListaEstoqueContagemCabecalho(1);
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
                            AtualizarListaEstoqueContagemCabecalho(-1);
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

        #region Actions
        public void realizarCalculos()
        {
            /// EXERCICIO
            ///  Verifique qual dos três campos foi selecionado para o fechamento da contagem (FECHADO_CONTAGEM)
            ///  e realize o calculo bom base nesse campo

            try
            {
                foreach (InventarioContagemDetDTO detalhe in EstoqueContagemCabecalhoSelected.listaContagemDetalhe)
                {
                    //acuracidade dos registros = (registros sistema / registros contados) X 100 }
                    if (detalhe.Contagem01 > 0)
                    {
                        detalhe.Acuracidade = detalhe.QuantidadeSistema / detalhe.Contagem01 * 100;
                    }
                    else
                    {
                        detalhe.Acuracidade = 0;
                    }

                    //divergencia dos registros = ((registros contados - registros sistema) / registros sistema) X 100 }
                    if (detalhe.QuantidadeSistema != 0)
                    {
                        detalhe.Divergencia = (detalhe.Contagem01 - detalhe.QuantidadeSistema) / detalhe.QuantidadeSistema * 100;
                    }
                    else
                    {
                        detalhe.Divergencia = 0;
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
