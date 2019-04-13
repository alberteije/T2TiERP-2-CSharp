using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ConciliacaoService.Model
{
    [DataContract]
    public class ChequeDTO
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public int? idTalonarioCheque { get; set; }
        [DataMember]
        public int? numero { get; set; }
        [DataMember]
        public string statusCheque { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> dataStatus { get; set; }
    }
}