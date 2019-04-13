using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace GEDService.Model
{
    [DataContract]
    public class ArquivoDTO
    {
        private const string caminhoBaseServidor = "C:\\Inetpub\\wwwroot\\documentos\\";

        [DataMember]
        public FileInfo fileInfo { get; set; }
        [DataMember]
        public MemoryStream memoryStream { get; set; }
        [DataMember]
        public MemoryStream streamAssinatura{ get; set; }
        
        public string caminhoServidor
        {
            get 
            { 
                return caminhoBaseServidor + calcularHash() + fileInfo.Extension ;
            }
        }
        public string caminhoServidorAssinatura
        {
            get
            {
                return caminhoBaseServidor + calcularHash() + ".assinatura";
            }
        }
        
        public string caminhoCliente
        {
            get
            {
                return Path.GetTempPath() + calcularHash() + fileInfo.Extension;
            }
        }
    
        public string calcularHash()
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(memoryStream.GetBuffer());
            StringBuilder hash = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                hash.Append(retVal[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}