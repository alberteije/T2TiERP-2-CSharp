using System;
using AdministrativoClient.ServicoAdministrativoReference;
using System.Collections.Generic;
using System.Windows.Input;
using AdministrativoClient.Command;
using System.Collections.ObjectModel;
using SearchWindow;
using AdministrativoClient.Model;
using System.Security.Cryptography;
using System.Text;

namespace AdministrativoClient.ViewModel.Administrativo
{
	/// 
	/// The MIT License
	///
	/// Copyright: Copyright (C) 2010 T2Ti.COM
	///
	/// Permission is hereby granted, free of charge, to any person
	/// obtaining a copy of this software and associated documentation
	/// files (the "Software"), to deal in the Software without
	/// restriction, including without limitation the rights to use,
	/// copy, modify, merge, publish, distribute, sublicense, and/or sell
	/// copies of the Software, and to permit persons to whom the
	/// Software is furnished to do so, subject to the following
	/// conditions:
	///
	/// The above copyright notice and this permission notice shall be
	/// included in all copies or substantial portions of the Software.
	///
	/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
	/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
	/// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
	/// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
	/// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
	/// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
	/// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
	/// OTHER DEALINGS IN THE SOFTWARE.
	///
	///        The author may be contacted at:
	///            t2ti.com@gmail.com
	///
	/// Autor: Albert Eije (t2ti.com@gmail.com)
	/// Version: 1.0
    public class UsuarioViewModel : ERPViewModelBase
    {

        public ObservableCollection<UsuarioDTO> ListaUsuario { get; set; }
        private UsuarioDTO _UsuarioSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }


        public UsuarioViewModel()
        {
            try
            {
                ListaUsuario = new ObservableCollection<UsuarioDTO>();
                primeiroResultado = 0;
                this.atualizarListaUsuario(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioDTO UsuarioSelected
        {
            get { return _UsuarioSelected; }
            set
            {
                _UsuarioSelected = value;
                notifyPropertyChanged("UsuarioSelected");
            }
        }

        public ICommand paginaSeguinteCommand
        {
            get
            {
                if (seguinteCommand == null)
                {
                    seguinteCommand = new RelayCommand
                    (
                        param =>
                        {
                            this.atualizarListaUsuario(1);
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return seguinteCommand;
            }
        }

        public ICommand paginaAnteriorCommand
        {
            get
            {
                if (anteriorCommand == null)
                {
                    anteriorCommand = new RelayCommand
                    (
                        param =>
                        {
                            this.atualizarListaUsuario(-1);
                        },
                        param =>
                        {
                            return true;
                        }
                    );
                }
                return anteriorCommand;
            }
        }

        public void salvarAtualizarUsuario()
        {
            try
            {
                using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                {
                    UsuarioSelected.Senha = MD5String(UsuarioSelected.Login + UsuarioSelected.Senha);
                    UsuarioSelected.DataCadastro = DateTime.Now;
                    serv.salvarAtualizarUsuario(UsuarioSelected);
                    UsuarioSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaUsuario(int pagina)
        {
            try
            {
                using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                {
                    if (pagina == 0)
                        primeiroResultado = 0;
                    else if (pagina > 0)
                        primeiroResultado += QUANTIDADE_PAGINA;
                    else if (pagina < 0)
                        primeiroResultado -= QUANTIDADE_PAGINA;

                    List<UsuarioDTO> listaServ = serv.selectUsuarioPagina(primeiroResultado, QUANTIDADE_PAGINA, new UsuarioDTO());

                    ListaUsuario.Clear();

                    foreach (UsuarioDTO objAdd in listaServ)
                    {
                        ListaUsuario.Add(objAdd);
                    }
                    UsuarioSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirUsuario()
        {
            try
            {
                using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                {
                    serv.deleteUsuario(UsuarioSelected);
                    UsuarioSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        public void pesquisarPapel()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(PapelDTO),
                    typeof(ServicoAdministrativo));

                if (searchWindow.ShowDialog() == true)
                {
                    UsuarioSelected.Papel = (PapelDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("UsuarioSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pesquisarColaborador()
        {
            try
            {
                SearchWindowApp searchWindow = new SearchWindowApp(typeof(ColaboradorDTO),
                    typeof(ServicoAdministrativo));

                if (searchWindow.ShowDialog() == true)
                {
                    UsuarioSelected.Colaborador = (ColaboradorDTO)searchWindow.itemSelecionado;
                    notifyPropertyChanged("UsuarioSelected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool login(String login, String senha)
        {
            try
            {
                using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                {
                    UsuarioDTO usuario = serv.selectUsuario(login, senha);
                    if (usuario != null)
                    {
                        UsuarioLogado = usuario;
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


        private static string MD5String(string texto)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteArray = Encoding.ASCII.GetBytes(texto);

            byteArray = md5.ComputeHash(byteArray);

            StringBuilder hashedValue = new StringBuilder();

            foreach (byte b in byteArray)
            {
                hashedValue.Append(b.ToString("x2"));
            }

            return hashedValue.ToString();
        }

    }
}
