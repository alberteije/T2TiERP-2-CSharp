using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AdministrativoClient.ServicoAdministrativoReference;
using AdministrativoClient.Command;
using AdministrativoClient.Model;
using System.IO;
using System.Windows;
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
    public class PapelViewModel : ERPViewModelBase
    {
        public ObservableCollection<PapelDTO> ListaPapel { get; set; }
        private PapelDTO _PapelSelected;
        private int primeiroResultado;
        protected ICommand seguinteCommand;
        protected ICommand anteriorCommand;
        private bool _isEditar { get; set; }

        private ViewControleAcessoDTO _ControleAcessoSelected;
        public ObservableCollection<ViewControleAcessoDTO> ListaControleAcesso { get; set; }

        public PapelViewModel()
        {
            try
            {
                ListaPapel = new ObservableCollection<PapelDTO>();
                ListaControleAcesso = new ObservableCollection<ViewControleAcessoDTO>();
                primeiroResultado = 0;
                this.atualizarListaPapel(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PapelDTO PapelSelected
        {
            get { return _PapelSelected; }
            set
            {
                _PapelSelected = value;
                notifyPropertyChanged("PapelSelected");
            }
        }

        public ViewControleAcessoDTO ControleAcessoSelected
        {
            get { return _ControleAcessoSelected; }
            set
            {
                _ControleAcessoSelected = value;
                notifyPropertyChanged("ControleAcessoSelected");
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
                            this.atualizarListaPapel(1);
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
                            this.atualizarListaPapel(-1);
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

        public void salvarAtualizarPapel()
        {
            try
            {
                using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                {
                    serv.salvarAtualizarPapel(PapelSelected);
                }

                // grava dados das funções
                if (PapelSelected.AcessoCompleto != "S")
                {
                    for (int i = 0; i < ListaControleAcesso.Count; i++)
                    {
                        using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                        {
                            PapelFuncaoDTO papelFuncao = new PapelFuncaoDTO();
                            papelFuncao.Id = ListaControleAcesso[i].Id;
                            papelFuncao.IdPapel = ListaControleAcesso[i].IdPapel;
                            papelFuncao.IdFuncao = ListaControleAcesso[i].IdFuncao;
                            papelFuncao.Habilitado = ListaControleAcesso[i].CheckHabilitado == true ? "S" : "N";
                            serv.salvarAtualizarPapelFuncao(papelFuncao);
                        }
                    }
                }

                PapelSelected = null;

                ListaControleAcesso.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void atualizarListaPapel(int pagina)
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

                    List<PapelDTO> listaServ = serv.selectPapelPagina(primeiroResultado, QUANTIDADE_PAGINA, new PapelDTO());

                    ListaPapel.Clear();

                    foreach (PapelDTO objAdd in listaServ)
                    {
                        ListaPapel.Add(objAdd);
                    }
                    PapelSelected = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void excluirPapel()
        {
            try
            {
                using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                {
                    serv.deletePapel(PapelSelected);
                    PapelSelected = null;
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

        public void CarregarArquivoFuncoes()
        {
            string Linha = "";
            string[] LinhaQuebrada;

            try
            {
                // carrega o arquivo
                StreamReader objReader = new StreamReader("T2TiERP_Forms.TXT", Encoding.Default);

                // carrega os dados do arquivo
                while ((Linha = objReader.ReadLine()) != null)
                {
                    LinhaQuebrada = Linha.Trim().Split('|');
                    ViewControleAcessoDTO ControleAcesso = new ViewControleAcessoDTO();
                    ControleAcesso.Id = int.Parse(LinhaQuebrada[0]);
                    ControleAcesso.IdPapel = int.Parse(LinhaQuebrada[1]);
                    ControleAcesso.IdFuncao = int.Parse(LinhaQuebrada[2]);
                    ControleAcesso.Habilitado = LinhaQuebrada[3];
                    ControleAcesso.Nome = LinhaQuebrada[4];
                    ControleAcesso.Formulario = LinhaQuebrada[5];

                    ListaControleAcesso.Add(ControleAcesso);
                }
                objReader.Close();

                // busca informações já gravadas para o papel e suas funções
                for (int i = 0; i < ListaControleAcesso.Count; i++)
                {
                    using (ServicoAdministrativoClient serv = new ServicoAdministrativoClient())
                    {
                        ViewControleAcessoDTO ControleAcesso = serv.selectControleAcessoId(ListaControleAcesso[i].Id);
                        ListaControleAcesso[i].CheckHabilitado = ControleAcesso.Habilitado == "S" ? true : false;
                    }
                }

                notifyPropertyChanged("ListaControleAcesso");
            }
            catch (Exception eError)
            {
                MessageBox.Show("Ocorreu um erro: " + eError.Message);
            }
        }
    }
}
