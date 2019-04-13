using BalcaoPAF.Command;
using BalcaoPAF.Model;
using BalcaoPAF.ServidorReference;
using SearchWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BalcaoPAF.ViewModel
{
    public class DavCabecalhoViewModel : ViewModelBase
    {

        #region Variáveis
        public ObservableCollection<DavCabecalhoDTO> ListaDavCabecalho { get; set; }
        private DavCabecalhoDTO _DavCabecalhoSelected;
        #endregion

        #region Construtor
        public DavCabecalhoViewModel()
        {
            try
            {
                ListaDavCabecalho = new ObservableCollection<DavCabecalhoDTO>();
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
        public DavCabecalhoDTO DavCabecalhoSelected
        {
            get { return _DavCabecalhoSelected; }
            set
            {
                _DavCabecalhoSelected = value;
                notifyPropertyChanged("DavCabecalhoSelected");
            }
        }
        #endregion

        #region CRUD
        public void SalvarAtualizarDavCabecalho()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.SalvarAtualizarDavCabecalho(DavCabecalhoSelected);
                    DavCabecalhoSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaDavCabecalho(int pagina)
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaDavCabecalho.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    DavCabecalhoDTO DavCabecalho = new DavCabecalhoDTO();
                    if (!Filtro.Trim().Equals(""))
                    {
                        DavCabecalho.NomeDestinatario = Filtro;
                    }

                    IList<DavCabecalhoDTO> ListaServ = Servico.SelectDavCabecalhoPagina(IndiceNavegacao, true, QuantidadePagina, true, DavCabecalho);

                    ListaDavCabecalho.Clear();

                    foreach (DavCabecalhoDTO objAdd in ListaServ)
                    {
                        ListaDavCabecalho.Add(objAdd);
                    }
                    DavCabecalhoSelected = null;
                }
                QuantidadeCarregada = ListaDavCabecalho.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ExcluirDavCabecalho()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.DeleteDavCabecalho(DavCabecalhoSelected);
                    DavCabecalhoSelected = null;
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
                DavCabecalhoSelected = new DavCabecalhoDTO();
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
                if (DavCabecalhoSelected != null)
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
                if (DavCabecalhoSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirDavCabecalho();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaDavCabecalho(IndiceNavegacao);
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
                DavCabecalhoSelected = null;
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
                SalvarAtualizarDavCabecalho();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaDavCabecalho(IndiceNavegacao);
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
                AtualizarListaDavCabecalho(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoExportar()
        {
            DataGridExportacao.ItemsSource = ListaDavCabecalho;
        }

        public override void BotaoPaginaSeguinte()
        {
            AtualizarListaDavCabecalho(1);
        }

        public override void BotaoPaginaAnterior()
        {
            AtualizarListaDavCabecalho(-1);
        }
        #endregion

        #region Pesquisas
        public void PesquisarPessoa()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(PessoaDTO),
                    typeof(ServicoBalcaoPAF));

                if (searchWindow.ShowDialog() == true)
                {
                    DavCabecalhoSelected.Pessoa = (PessoaDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("DavCabecalhoSelected");
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
