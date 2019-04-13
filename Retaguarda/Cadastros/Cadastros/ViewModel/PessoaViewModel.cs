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
    public class PessoaViewModel : ViewModelBase
    {

        #region Variáveis
        public ObservableCollection<PessoaDTO> ListaPessoa { get; set; }
        private PessoaDTO _PessoaSelected;
        #endregion

        #region Construtor
        public PessoaViewModel()
        {
            try
            {
                ListaPessoa = new ObservableCollection<PessoaDTO>();
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
        public PessoaDTO PessoaSelected
        {
            get { return _PessoaSelected; }
            set
            {
                _PessoaSelected = value;
                notifyPropertyChanged("PessoaSelected");
            }
        }
        #endregion

        #region CRUD
        public void SalvarAtualizarPessoa()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.SalvarAtualizarPessoa(PessoaSelected);
                    PessoaSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarListaPessoa(int pagina)
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    if (pagina == 0)
                        IndiceNavegacao = 0;
                    else if (pagina > 0 && ListaPessoa.Count == QuantidadePagina)
                        IndiceNavegacao += QuantidadePagina;
                    else if (pagina < 0 && IndiceNavegacao != 0)
                        IndiceNavegacao -= QuantidadePagina;

                    PessoaDTO Pessoa = new PessoaDTO();
                    if (!Filtro.Trim().Equals(""))
                    {
                        Pessoa.Nome = Filtro;
                    }

                    IList<PessoaDTO> ListaServ = Servico.SelectPessoaPagina(IndiceNavegacao, true, QuantidadePagina, true, Pessoa);

                    ListaPessoa.Clear();

                    foreach (PessoaDTO objAdd in ListaServ)
                    {
                        ListaPessoa.Add(objAdd);
                    }
                    PessoaSelected = null;
                }
                QuantidadeCarregada = ListaPessoa.Count;
                ControlarNavegacao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirPessoa()
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Servico.DeletePessoa(PessoaSelected);
                    PessoaSelected = null;
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
                PessoaSelected = new PessoaDTO();
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
                if (PessoaSelected != null)
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
                if (PessoaSelected != null)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Excluir o Registro?", "Pergunta do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ExcluirPessoa();
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarListaPessoa(IndiceNavegacao);
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
                PessoaSelected = null;
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
                SalvarAtualizarPessoa();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                AtualizarListaPessoa(IndiceNavegacao);
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
                AtualizarListaPessoa(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void BotaoExportar()
        {
            DataGridExportacao.ItemsSource = ListaPessoa;
        }

        public override void BotaoPaginaSeguinte()
        {
            AtualizarListaPessoa(1);
        }

        public override void BotaoPaginaAnterior()
        {
            AtualizarListaPessoa(-1);
        }
        #endregion

    }
}
