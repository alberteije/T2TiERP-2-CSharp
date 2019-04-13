using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;
using CloseableTabItemDemo;
using GEDClient.GEDServiceReference;
using GEDClient.Services;
using GEDClient.View.GED;
using WIA;

namespace GEDClient.ViewModel.GED
{
    public class GEDClientViewModel : ERPViewModelBase
    {
        public ObservableCollection<GedTipoDocumentoDTO> listaTipoDocumento { get; set; }
        public ObservableCollection<GedDocumentoDTO> listaDocumento { get; set; }
        public string textoPesquisa { get; set; }
        public string textoPesquisaDoc { get; set; }
        public int assinado { get; set; }
        public GedDocumentoDTO documento { get; set; }
        public GedDocumentoDTO DocumentoSelected;
        public ContentPresenter contentPresenterDocumento { get; set; }

        private bool IsSelectedTabPrincipalDocumento = true;
        private bool IsSelectedTabOperacoesDocumento = false;

        private bool IsEnableExcluirDocumento = false;
        private bool IsEnableAlterarDocumento = false;
        private bool IsEnableAbrirDocumento = false;
        private BitmapSource MiniaturaArquivo;
        private string UriImagem;
        private ObservableCollection<string> ListaNomeCertificados = new ObservableCollection<string>();
        private X509Store store;
        private IList<X509Certificate2> listaCertificados = new List<X509Certificate2>();

        /// EXERCICIO
        /// Utilize as duas tabelas do GED de modo a criar documentos mestre/detalhe

        public GEDClientViewModel()
        {
            try
            {
                GEDServiceClient gedService = new GEDServiceClient();
                IList<GedDocumentoDTO> doc = gedService.selectDocumento(new GedDocumentoDTO());
                listaDocumento = new ObservableCollection<GedDocumentoDTO>(doc);
                IList<GedTipoDocumentoDTO> listaTipo = gedService.selectGedTipoDocumento(new GedTipoDocumentoDTO());
                listaTipoDocumento = new ObservableCollection<GedTipoDocumentoDTO>(listaTipo);

                documento = criarDocumento();
                documento.GedTipoDocumento = new GedTipoDocumentoDTO();

                contentPresenterDocumento = new ContentPresenter();

                store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certCollection = store.Certificates;

                ListaNomeCertificados.Add("Não");
                foreach (X509Certificate2 c in certCollection)
                {
                    ListaNomeCertificados.Add(c.Subject.Split('=')[1].Split(',')[0]);
                    listaCertificados.Add(c);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string textoAssinatura { get; set; }

        public ObservableCollection<string> listaNomeCertificados
        {
            get { return ListaNomeCertificados; }
            set { ListaNomeCertificados = value; }
        }

        public string visibilidadePanelImagem
        {
            get 
            {
                if (uriImagem != null && uriImagem.Length > 0)
                {
                    return "Visible";
                }
                else 
                {
                    return "Hidden";
                }   
            }
        }
        
        public string visibilidadePanelAssinado
        {
            get
            {
                if (documentoSelected != null &&
                    documentoSelected.Assinado != null && 
                    documentoSelected.Assinado == "S")
                {
                    return "Visible";
                }
                else
                {
                    return "Hidden";
                }
            }
        }
        
        public string extension
        {
            get 
            {
                return UriImagem != null ? uriImagem.Split('.').Last():"";
            }
        }
        
        public string uriImagem 
        {
            get { return UriImagem; }
            set 
            {
                UriImagem = value;
                notifyPropertyChanged("uriImagem");
                notifyPropertyChanged("extension");
                notifyPropertyChanged("visibilidadePanelImagem"); 
            }
        }
        
        public BitmapSource miniatura
        {
            get 
            {
                return MiniaturaArquivo; 
            }
            set { MiniaturaArquivo = value; notifyPropertyChanged("miniatura"); }
        }

        public GedDocumentoDTO documentoSelected
        {
            get 
            {
                return DocumentoSelected;
            }
            set 
            {
                DocumentoSelected = value;
                notifyPropertyChanged("documentoSelected");

                isEnableAlterarDocumento = false;
                isEnableExcluirDocumento = false;
                isEnableAbrirDocumento = false;
                if (DocumentoSelected != null)
                {
                    isEnableAbrirDocumento = true;
                    isEnableExcluirDocumento = true;
                    isEnableAlterarDocumento = true;
                }
            }
        }

        public bool isEnableAlterarDocumento
        {
            get
            {
                return IsEnableAlterarDocumento;
            }
            set
            {
                IsEnableAlterarDocumento = value;
                notifyPropertyChanged("isEnableAlterarDocumento");
            }
        }

        public bool isEnableExcluirDocumento
        {
            get
            {
                return IsEnableExcluirDocumento;
            }
            set
            {
                IsEnableExcluirDocumento = value;
                notifyPropertyChanged("isEnableExcluirDocumento");
            }
        }
        
        public bool isEnableAbrirDocumento
        {
            get
            {
                return IsEnableAbrirDocumento;
            }
            set
            {
                IsEnableAbrirDocumento = value;
                notifyPropertyChanged("isEnableAbrirDocumento");
            }
        }

        public bool isSelectedTabPrincipalDocumento
        {
            get
            {
                return IsSelectedTabPrincipalDocumento;
            }
            set
            {
                IsSelectedTabPrincipalDocumento = value;
                notifyPropertyChanged("isSelectedTabPrincipalDocumento");
            }
        }
        
        public bool isSelectedTabOperacoesDocumento
        {
            get
            {
                return IsSelectedTabOperacoesDocumento;
            }
            set
            {
                IsSelectedTabOperacoesDocumento = value;
                notifyPropertyChanged("isSelectedTabOperacoesDocumento");
            }
        }
        
        public void pesquisarDocumento()
        {
            try
            {
                GEDServiceClient gedService = new GEDServiceClient();
                GedDocumentoDTO docPesq = new GedDocumentoDTO { Nome = textoPesquisaDoc };
                IList<GedDocumentoDTO> listaDoc = gedService.selectDocumento(docPesq);
                listaDocumento.Clear();
                foreach (GedDocumentoDTO doc in listaDoc)
                    listaDocumento.Add(doc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregarTabPrincipalDocumento()
        {
            try
            {
                contentPresenterDocumento.Content = null;
                uriImagem = "";
                isSelectedTabPrincipalDocumento = true;
                this.pesquisarDocumento();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void carregarIncluirDocumento()
        {
            try
            {
                isSelectedTabOperacoesDocumento = true;
                contentPresenterDocumento.Content = new DocumentoIncluirView(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void carregarModuloIncluirDocumento()
        {
            try
            {
                documento = new GedDocumentoDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void carregarExcluirDocumento()
        {
            try
            {
                isSelectedTabOperacoesDocumento = true;

                carregarDocumentoSelected();

                contentPresenterDocumento.Content = new DocumentoExcluirView(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void carregarDocumentoSelected()
        {
            try
            {
                GEDServiceClient gedService = new GEDServiceClient();
                documentoSelected = gedService.selectDocumentoId(documentoSelected);

                if (documentoSelected != null)
                {
                    uriImagem = salvaArquivoTempLocal(documentoSelected.arquivo);

                    if (documentoSelected.Assinado != null && documentoSelected.Assinado == "S")
                    {
                        documentoSelected.Assinado = verificarAssinatura(documentoSelected.arquivo) ? "S" : "N";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void carregarModuloVisualizarDocumento(int idDocumento)
        {
            documentoSelected = new GedDocumentoDTO { Id = idDocumento };

            carregarDocumentoSelected();
        }
        
        public void carregarAlterarDocumento()
        {
            try
            {
                isSelectedTabOperacoesDocumento = true;

                carregarDocumentoSelected();

                contentPresenterDocumento.Content = new DocumentoAlterarView(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool verificarAssinatura(ArquivoDTO arquivo)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(arquivo.streamAssinatura);

                SignedXml signedXml = new SignedXml();

                XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

                signedXml.LoadXml((XmlElement)nodeList[0]);

                return signedXml.CheckSignature();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArquivoDTO carregarArquivo()
        {
            try
            {
                FileInfo fi = new FileInfo(uriImagem);
                FileStream fs = fi.OpenRead();
                MemoryStream ms = new MemoryStream((int)fs.Length);
                fs.CopyTo(ms);
                fs.Close();

                ArquivoDTO arquivo = new ArquivoDTO();
                arquivo.fileInfo = fi;
                arquivo.memoryStream = ms;

                return arquivo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void assinarArquivo(ArquivoDTO arquivo)
        {
            try
            {
                int index = assinado - 1;
                X509Certificate2 certificado = listaCertificados.ElementAt(index);
                RSACryptoServiceProvider crypto = (RSACryptoServiceProvider)certificado.PrivateKey;

                SignedXml signedXml = new SignedXml();
                signedXml.SigningKey = certificado.PrivateKey;

                Reference reference = new Reference();
                reference.Uri = uriImagem;
                signedXml.AddReference(reference);

                KeyInfo keyInfo = new KeyInfo();
                RSAKeyValue rsaKeyValue = new RSAKeyValue(crypto);
                keyInfo.AddClause(rsaKeyValue);
                signedXml.KeyInfo = keyInfo;

                signedXml.ComputeSignature();
                XmlElement signatureXml = signedXml.GetXml();

                arquivo.streamAssinatura = new MemoryStream();
                MemoryStream msAssinatura = new MemoryStream();
                using (XmlTextWriter signatureWriter = new XmlTextWriter(msAssinatura, new UTF8Encoding(false)))
                {
                    signatureWriter.Formatting = Formatting.Indented;
                    signatureXml.WriteTo(signatureWriter);
                    signatureWriter.Flush();

                    msAssinatura.Position = 0;
                    msAssinatura.CopyTo(arquivo.streamAssinatura);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Erro");
            }
        }

        public int incluirDocumento()
        {
            try
            {
                GEDServiceClient gedService = new GEDServiceClient();

                if (uriImagem != null)
                {
                    documento.arquivo = carregarArquivo();
                }

               // documento.GedTipoDocumento = listaTipoDocumento.ElementAt<GedTipoDocumentoDTO>(1);

                documento.Empresa = Empresa;
                documento.Assinado = "N";
                if (assinado > 0)
                {
                    assinarArquivo(documento.arquivo);
                    documento.Assinado = "S";
                }


                documento = gedService.saveDocumento(documento);
                
                int resultado = documento.Id;

                documento = criarDocumento();

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void excluirDocumento()
        {
            try
            {
                GEDServiceClient gedService = new GEDServiceClient();
                documentoSelected.DataExclusao = DateTime.Now;

                gedService.deleteDocumento(documentoSelected);
                documentoSelected = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void alterarDocumento()
        {
            try
            {
                GEDServiceClient gedService = new GEDServiceClient();

                documentoSelected.arquivo = carregarArquivo();
                documentoSelected.Assinado = "N";
                if (assinado > 0)
                {
                    assinarArquivo(documentoSelected.arquivo);
                    documentoSelected.Assinado = "S";
                }

                gedService.updateDocumento(documentoSelected);
                documentoSelected = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void browse()
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    string filename = dlg.FileName;

                    FileInfo fi = new FileInfo(filename);

                    using (FileStream fs = fi.OpenRead())
                    {
                        using (MemoryStream ms = new MemoryStream((int)fs.Length))
                        {
                            fs.CopyTo(ms);
                            filename = Path.GetTempPath() + calcularHash(ms) + fi.Extension;
                            using (FileStream fs2 = new FileStream(filename, FileMode.Create))
                            {
                                fs2.Write(ms.GetBuffer(), 0, (int)ms.Length);
                            }
                        }
                    }
                    uriImagem = filename;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public string calcularHash(Stream stream)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(stream);
                StringBuilder hash = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    hash.Append(retVal[i].ToString("x2"));
                }
                return hash.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void digitalizar()
        {
            var scanner = new ScannerService();

            try
            {
                ImageFile file = scanner.Scan();

                if (file != null)
                {
                    var converter = new ScannerImageConverter();
                    converter.ConvertScannedImage(file);
                    uriImagem = converter.fileName;
                }
                else
                {
                    uriImagem = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string salvaArquivoTempLocal(ArquivoDTO arquivo)
        {
            try
            {
                FileInfo fi = arquivo.fileInfo;
                string caminhoTemp = Path.GetTempPath() + arquivo.fileInfo.Name;

                if (!File.Exists(caminhoTemp))
                {
                    using (FileStream fs = new FileStream(caminhoTemp, FileMode.Create, FileAccess.ReadWrite))
                    {
                        arquivo.memoryStream.WriteTo(fs);
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

        public void visualizarDocumento()
        {
            try
            {
                GEDServiceClient gedService = new GEDServiceClient();
                documentoSelected = gedService.selectDocumentoId(documentoSelected);

                string caminhoTemp = salvaArquivoTempLocal(documentoSelected.arquivo);
                System.Diagnostics.Process.Start(caminhoTemp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private GedDocumentoDTO criarDocumento()
        {
            GedDocumentoDTO documento = new GedDocumentoDTO { DataExclusao = null, 
                DataFimVigencia = null };
            documento.Empresa = Empresa;
            return documento;
        }

        public void novaPagina(UserControl janela, String cabecalho)
        {
            Boolean achou = false;

            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = cabecalho;
            tabItem.Content = janela;

            foreach (TabItem tab in GEDPrincipal.TabPrincipal.Items)
            {
                if (tab.Header == tabItem.Header)
                {
                    achou = true;
                    tab.Focus();
                }
            }

            if (!achou)
            {
                GEDPrincipal.TabPrincipal.Items.Add(tabItem);
                tabItem.Focus();
            }
        }

    }
}
