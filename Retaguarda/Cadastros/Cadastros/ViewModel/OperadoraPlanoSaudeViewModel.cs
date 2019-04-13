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
    public class OperadoraPlanoSaudeViewModel : ViewModelBase
    {

        #region Variáveis
        public ObservableCollection<OperadoraPlanoSaudeDTO> ListaOperadoraPlanoSaude { get; set; }
        private OperadoraPlanoSaudeDTO _OperadoraPlanoSaudeSelected;
        #endregion

        #region Construtor
        public OperadoraPlanoSaudeViewModel()
        {
            try
            {
                ListaOperadoraPlanoSaude = new ObservableCollection<OperadoraPlanoSaudeDTO>();
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
        public OperadoraPlanoSaudeDTO OperadoraPlanoSaudeSelected
        {
            get { return _OperadoraPlanoSaudeSelected; }
            set
            {
                _OperadoraPlanoSaudeSelected = value;
                notifyPropertyChanged("OperadoraPlanoSaudeSelected");
            }
        }
        #endregion

        #region CRUD
        public void SalvarAtualizarOperadoraPlanoSaude()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.SalvarAtualizarOperadoraPlanoSaude(OperadoraPlanoSaudeSelected);
                    OperadoraPlanoSaudeSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaOperadoraPlanoSaude(int pagina)
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaOperadoraPlanoSaude.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    OperadoraPlanoSaudeDTO OperadoraPlanoSaude = new OperadoraPlanoSaudeDTO();
                    if (!Filtro.Trim().Equals(""))
                    {
                        OperadoraPlanoSaude.Nome = Filtro;
                    }

                    IList<OperadoraPlanoSaudeDTO> ListaServ = Servico.SelectOperadoraPlanoSaudePagina(IndiceNavegacao, true, QuantidadePagina, true, OperadoraPlanoSaude);

                    ListaOperadoraPlanoSaude.Clear();

                    foreach (OperadoraPlanoSaudeDTO objAdd in ListaServ)
                    {
                        ListaOperadoraPlanoSaude.Add(objAdd);
                    }
                    OperadoraPlanoSaudeSelected = null;
                }
                QuantidadeCarregada = ListaOperadoraPlanoSaude.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirOperadoraPlanoSaude()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.DeleteOperadoraPlanoSaude(OperadoraPlanoSaudeSelected);
                    OperadoraPlanoSaudeSelected = null;
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
                OperadoraPlanoSaudeSelected = new OperadoraPlanoSaudeDTO();
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
                if (OperadoraPlanoSaudeSelected != null)
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
                if (OperadoraPlanoSaudeSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirOperadoraPlanoSaude();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaOperadoraPlanoSaude(IndiceNavegacao);
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
                OperadoraPlanoSaudeSelected = null;
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
                SalvarAtualizarOperadoraPlanoSaude();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaOperadoraPlanoSaude(IndiceNavegacao);
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
                AtualizarListaOperadoraPlanoSaude(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoExportar()
        {
            DataGridExportacao.ItemsSource = ListaOperadoraPlanoSaude;
        }

        public override void BotaoPaginaSeguinte()
        {
            AtualizarListaOperadoraPlanoSaude(1);
        }

        public override void BotaoPaginaAnterior()
        {
            AtualizarListaOperadoraPlanoSaude(-1);
        }
        #endregion

    }
}
