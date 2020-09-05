using System;
using SISClient.ServicoSISReference;

namespace SISClient.ViewModel
{

    public class UsuarioViewModel : ViewModelBase
    {

        public UsuarioViewModel()
        {
        }

        public bool Login(String login, String senha)
        {
            try
            {
                using (ServicoSISClient Servico = new ServicoSISClient())
                {
                    UsuarioDTO Usuario = Servico.SelectUsuario(login, senha);
                    if (Usuario != null)
                    {
                        UsuarioLogado = Usuario;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

    }
}
