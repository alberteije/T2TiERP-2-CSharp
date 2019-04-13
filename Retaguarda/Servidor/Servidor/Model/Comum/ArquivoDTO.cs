using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Servidor.Model
{
    public class ArquivoDTO
    {
        public FileInfo fileInfo { get; set; }
        public MemoryStream memoryStream { get; set; }
    }
}