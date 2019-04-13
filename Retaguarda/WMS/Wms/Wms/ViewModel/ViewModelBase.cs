using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using CloseableTabItemDemo;
using ExportarParaArquivo;
using Wms.Servico;
using Cadastros.View;
using Cadastros.Command;

namespace Cadastros.ViewModel
{

    public class ViewModelBase : INotifyPropertyChanged
    {

        public static EmpresaDTO Empresa = new EmpresaDTO { Id = 1 };

        #region Infra
        public bool _isEditar { get; set; }

        [Conditional("DEBUG")]
        private void checkIfPropertyNameExists(String propertyName)
        {
            Type type = this.GetType();
            Debug.Assert(
              type.GetProperty(propertyName) != null,
              propertyName + " propriedade não encontrada : " + type.FullName);
        }

        public void NovaPagina(UserControl janela, String cabecalho)
        {
            Boolean Achou = false;

            CloseableTabItem TabItem = new CloseableTabItem();
            TabItem.Header = cabecalho;
            TabItem.Content = janela;

            foreach (TabItem tab in Principal.TabPrincipal.Items)
            {
                if (tab.Header == TabItem.Header)
                {
                    Achou = true;
                    tab.Focus();
                }
            }

            if (!Achou)
            {
                Principal.TabPrincipal.Items.Add(TabItem);
                TabItem.Focus();
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
        #endregion Infra

        #region Variáveis Command
        protected ICommand PagSeguinteCommand;
        protected ICommand PagAnteriorCommand;
        protected ICommand BotaoInserirCommand;
        protected ICommand BotaoAlterarCommand;
        protected ICommand BotaoExcluirCommand;
        protected ICommand BotaoImprimirCommand;
        protected ICommand BotaoCancelarCommand;
        protected ICommand BotaoSalvarCommand;
        protected ICommand BotaoLocalizarCommand;
        protected ICommand BotaoExportarXlsCommand;
        protected ICommand BotaoExportarCsvCommand;
        protected ICommand BotaoExportarTxtCommand;
        protected ICommand BotaoExportarRtfCommand;
        #endregion

        #region Controle de Ativação dos Botões
        public virtual void BotaoInserir()
        {
        }

        public virtual void BotaoAlterar()
        {
        }

        public virtual void BotaoExcluir()
        {
        }

        public virtual void BotaoCancelar()
        {
        }

        public virtual void BotaoSalvar()
        {
        }

        public virtual void BotaoLocalizar()
        {
        }

        public virtual void BotaoExportar()
        {
        }

        public virtual void BotaoPaginaSeguinte()
        {
        }

        public virtual void BotaoPaginaAnterior()
        {
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
        #endregion

        #region Comandos Botões Exportação
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
                            BotaoExportar();
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
                            BotaoExportar();
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
                            BotaoExportar();
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
                            BotaoExportar();
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
                            BotaoPaginaSeguinte();
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
                            BotaoPaginaAnterior();
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

        #region Controle de Acesso
        /*
        public IList<ViewControleAcessoDTO> ListaControleAcesso = new List<ViewControleAcessoDTO>();
        public static UsuarioDTO UsuarioLogado = new UsuarioDTO();
        public ViewControleAcessoDTO ControleAcesso;

        public void Acesso(int papel, String formulario)
        {
            try
            {
                using (ServicoCadastros Servico = new ServicoCadastros())
                {
                    ViewControleAcessoDTO ControleAcesso = new ViewControleAcessoDTO();
                    ControleAcesso.IdPapel = papel;
                    ControleAcesso.Formulario = formulario;
                    List<ViewControleAcessoDTO> ListaServ = Servico.SelectControleAcesso(ControleAcesso);

                    ListaControleAcesso.Clear();

                    foreach (ViewControleAcessoDTO objAdd in ListaServ)
                    {
                        ListaControleAcesso.Add(objAdd);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         */ 
        #endregion

        #region Navegação Registros
        protected int IndiceNavegacao;
        public bool NavegaPaginaAnterior { get; set; }
        public bool NavegaPaginaSeguinte { get; set; }
        
        public int QuantidadeCarregada { get; set; }
        public const int QuantidadePagina = 20;
        public string Filtro { get; set; }

        public void ControlarNavegacao() 
        {
            NavegaPaginaAnterior = IndiceNavegacao > 0;
            NavegaPaginaSeguinte = QuantidadePagina == QuantidadeCarregada;
            notifyPropertyChanged("NavegaPaginaAnterior");
            notifyPropertyChanged("NavegaPaginaSeguinte");
            //
            if (DataGridExportacao != null)
                PodeExportar = DataGridExportacao.Items.Count > 0;
            else
                PodeExportar = false;
            notifyPropertyChanged("PodeExportar");
        }
        #endregion

        #region Exportação Dados
        public static DataGrid DataGridExportacao;
        public bool PodeExportar { get; set; }

        public void ExportarDataGrid(ExportarParaArquivo.Formato formato)
        {
            if (DataGridExportacao.HasItems)
            {
                Exportar Exportar = new Exportar(formato);
                Exportar.exportarDataGrid(DataGridExportacao);
            }
            else
                throw new Exception("Não há itens a serem exportados.");
        }
        #endregion

        #region Impressão
        public System.Windows.Visibility ExibeBotaoImprimir { get; set; }

        protected string SalvarArquivoTempLocal(System.IO.MemoryStream pArquivo, string pNome)
        {
            try
            {
                string caminhoTemp = System.IO.Path.GetTempPath() + pNome;

                if (!File.Exists(caminhoTemp))
                {
                    using (FileStream fs = new FileStream(caminhoTemp, FileMode.Create, FileAccess.ReadWrite))
                    {
                        pArquivo.WriteTo(fs);
                        fs.Close();
                    }
                }
                return caminhoTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void notifyPropertyChanged(String propertyName)
        {
            checkIfPropertyNameExists(propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

}
