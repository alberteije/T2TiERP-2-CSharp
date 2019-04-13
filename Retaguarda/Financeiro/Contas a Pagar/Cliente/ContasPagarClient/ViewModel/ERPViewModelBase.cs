using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using ExportarParaArquivo;
using ContasPagarClient.ContasPagarService;
using reportman;

namespace ContasPagarClient.ViewModel
{
    

    public class ERPViewModelBase : INotifyPropertyChanged
    {
        public IList<ViewControleAcessoDTO> ListaControleAcesso = new List<ViewControleAcessoDTO>();

        public EmpresaDTO Empresa = new EmpresaDTO { Id = 1 };
        public static UsuarioDTO UsuarioLogado = new UsuarioDTO();
        public ViewControleAcessoDTO ControleAcesso;
        public const int QUANTIDADE_PAGINA = 20;
        
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

        [Conditional("DEBUG")]
        private void checkIfPropertyNameExists(String propertyName)
        {
            Type type = this.GetType();
            Debug.Assert(
              type.GetProperty(propertyName) != null,
              propertyName + " propriedade não encontrada : " + type.FullName);
        }
        
        public void exportarDataGrid(ExportarParaArquivo.Formato formato, System.Windows.Controls.DataGrid dg)
        {
            if (dg.HasItems)
            {
                Exportar exportar = new Exportar(formato);
                exportar.exportarDataGrid(dg);
            }
            else
                throw new Exception("Não há itens a serem exportados.");
        }

        public void acesso(int papel, String formulario)
        {
            try
            {
                using (ContasPagarServiceClient serv = new ContasPagarServiceClient())
                {
                    ViewControleAcessoDTO ControleAcesso = new ViewControleAcessoDTO();
                    ControleAcesso.IdPapel = papel;
                    ControleAcesso.Formulario = formulario;
                    List<ViewControleAcessoDTO> listaServ = serv.selectControleAcesso(ControleAcesso);

                    ListaControleAcesso.Clear();

                    foreach (ViewControleAcessoDTO objAdd in listaServ)
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

        // Implementação para o primeiro ciclo do ERP
        public void exibirRelatorio(String Arquivo, String Janela, String ConsultaSQL)
        {
            try
            {
                string NomeArquivo = Arquivo + ".rep";
                //
                string parTITULORELATORIO = "Relatório - " + Janela;
                string parTITULOSOFTHOUSE = "T2Ti.COM";
                string parTITULORODAPE = "T2Ti Tecnologia da Informação Ltda. - (61)3042.5277";
                //
                string ConteudoServidor = NomeArquivo + "|" + ConsultaSQL + "|" + parTITULORELATORIO + "|" + parTITULOSOFTHOUSE + "|" + parTITULORODAPE;

                ReportManX rp = new ReportManX();

                rp.ExecuteRemote("localhost", 3060, "Admin", "", "T2Ti", ConteudoServidor);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
