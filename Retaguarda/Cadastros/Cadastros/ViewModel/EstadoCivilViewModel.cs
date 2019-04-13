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
    public class EstadoCivilViewModel : ViewModelBase
    {

        #region Variáveis
        public ObservableCollection<EstadoCivilDTO> ListaEstadoCivil { get; set; }
        private EstadoCivilDTO _EstadoCivilSelected;
        #endregion

        #region Construtor
        public EstadoCivilViewModel()
        {
            try
            {
                ListaEstadoCivil = new ObservableCollection<EstadoCivilDTO>();
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
        public EstadoCivilDTO EstadoCivilSelected
        {
            get { return _EstadoCivilSelected; }
            set
            {
                _EstadoCivilSelected = value;
                notifyPropertyChanged("EstadoCivilSelected");
            }
        }
        #endregion

        #region CRUD
        public void SalvarAtualizarEstadoCivil()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.SalvarAtualizarEstadoCivil(EstadoCivilSelected);
                    EstadoCivilSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaEstadoCivil(int pagina)
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaEstadoCivil.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    EstadoCivilDTO EstadoCivil = new EstadoCivilDTO();
                    if (!Filtro.Trim().Equals(""))
                    {
                        EstadoCivil.Nome = Filtro;
                    }

                    IList<EstadoCivilDTO> ListaServ = Servico.SelectEstadoCivilPagina(IndiceNavegacao, true, QuantidadePagina, true, EstadoCivil);

                    ListaEstadoCivil.Clear();

                    foreach (EstadoCivilDTO objAdd in ListaServ)
                    {
                        ListaEstadoCivil.Add(objAdd);
                    }
                    EstadoCivilSelected = null;
                }
                QuantidadeCarregada = ListaEstadoCivil.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirEstadoCivil()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.DeleteEstadoCivil(EstadoCivilSelected);
                    EstadoCivilSelected = null;
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
                EstadoCivilSelected = new EstadoCivilDTO();
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
                if (EstadoCivilSelected != null)
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
                if (EstadoCivilSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirEstadoCivil();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaEstadoCivil(IndiceNavegacao);
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
                EstadoCivilSelected = null;
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
                SalvarAtualizarEstadoCivil();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaEstadoCivil(IndiceNavegacao);
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
                AtualizarListaEstadoCivil(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoExportar()
        {
            DataGridExportacao.ItemsSource = ListaEstadoCivil;
        }

        public override void BotaoPaginaSeguinte()
        {
            AtualizarListaEstadoCivil(1);
        }

        public override void BotaoPaginaAnterior()
        {
            AtualizarListaEstadoCivil(-1);
        }
        #endregion


    }
}
