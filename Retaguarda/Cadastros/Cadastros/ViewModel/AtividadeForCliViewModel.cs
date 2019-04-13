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
    public class AtividadeForCliViewModel : ViewModelBase
    {

        #region Variáveis
        public ObservableCollection<AtividadeForCliDTO> ListaAtividadeForCli { get; set; }
        private AtividadeForCliDTO _AtividadeForCliSelected;
        #endregion

        #region Construtor
        public AtividadeForCliViewModel()
        {
            try
            {
                ListaAtividadeForCli = new ObservableCollection<AtividadeForCliDTO>();
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
        public AtividadeForCliDTO AtividadeForCliSelected
        {
            get { return _AtividadeForCliSelected; }
            set
            {
                _AtividadeForCliSelected = value;
                notifyPropertyChanged("AtividadeForCliSelected");
            }
        }
        #endregion

        #region CRUD
        public void SalvarAtualizarAtividadeForCli()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.SalvarAtualizarAtividadeForCli(AtividadeForCliSelected);
                    AtividadeForCliSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaAtividadeForCli(int pagina)
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaAtividadeForCli.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    AtividadeForCliDTO AtividadeForCli = new AtividadeForCliDTO();
                    if (!Filtro.Trim().Equals(""))
                    {
                        AtividadeForCli.Nome = Filtro;
                    }

                    IList<AtividadeForCliDTO> ListaServ = Servico.SelectAtividadeForCliPagina(IndiceNavegacao, true, QuantidadePagina, true, AtividadeForCli);

                    ListaAtividadeForCli.Clear();

                    foreach (AtividadeForCliDTO objAdd in ListaServ)
                    {
                        ListaAtividadeForCli.Add(objAdd);
                    }
                    AtividadeForCliSelected = null;
                }
                QuantidadeCarregada = ListaAtividadeForCli.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirAtividadeForCli()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.DeleteAtividadeForCli(AtividadeForCliSelected);
                    AtividadeForCliSelected = null;
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
                AtividadeForCliSelected = new AtividadeForCliDTO();
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
                if (AtividadeForCliSelected != null)
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
                if (AtividadeForCliSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirAtividadeForCli();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaAtividadeForCli(IndiceNavegacao);
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
                AtividadeForCliSelected = null;
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
                SalvarAtualizarAtividadeForCli();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaAtividadeForCli(IndiceNavegacao);
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
                AtualizarListaAtividadeForCli(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoExportar()
        {
            DataGridExportacao.ItemsSource = ListaAtividadeForCli;
        }

        public override void BotaoPaginaSeguinte()
        {
            AtualizarListaAtividadeForCli(1);
        }

        public override void BotaoPaginaAnterior()
        {
            AtualizarListaAtividadeForCli(-1);
        }
        #endregion


    }
}
