using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization;

namespace ContasReceberService.Model
{
    [DataContract]
    public class BoletoHTML
    {
        [DataMember]
        public FileInfo fiLogo { get; set; }
        [DataMember]
        public MemoryStream msLogo { get; set; }

        [DataMember]
        public FileInfo fiBoleto { get; set; }
        [DataMember]
        public MemoryStream msBoleto { get; set; }

        [DataMember]
        public FileInfo fiCodBarra { get; set; }
        [DataMember]
        public MemoryStream msCodBarra { get; set; }

        [DataMember]
        public FileInfo fiBarra { get; set; }
        [DataMember]
        public MemoryStream msBarra { get; set; }
    }
}