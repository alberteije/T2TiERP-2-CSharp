using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchWindow.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ColunaDataGrid : System.Attribute
    {
        public bool visivel;
        public string cabecalho;
        public int indicePosicao;
    }
}
