using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchWindow.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class SearchWindowDataSource: System.Attribute
    {
        private Type _tipoDTO;
        public SearchWindowDataSource(Type tipoDTO)
        {
            _tipoDTO = tipoDTO;
        }
        public SearchWindowDataSource(Type tipoDTO, string[] listaPro, string[] listaCab)
        {
            listaPropriedades = listaPro;
            listaCabecalhos = listaCab;
            _tipoDTO = tipoDTO;
        }
        public Type tipoDTO 
        {
            get { return _tipoDTO; }
        }

        public string[] listaPropriedades { get; set; }
        public string[] listaCabecalhos { get; set; }
    }
}
