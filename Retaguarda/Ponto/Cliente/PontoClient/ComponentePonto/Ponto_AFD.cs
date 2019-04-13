using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class Ponto_AFD
    {

        public AFD_Cabecalho AFDCabecalho { get; set; }
        public AFD_Registro2 AFDRegistro2 { get; set; }
        public List<AFD_Registro3> ListaAFDRegistro3 { get; set; }
        public List<AFD_Registro4> ListaAFDRegistro4 { get; set; }
        public List<AFD_Registro5> ListaAFDRegistro5 { get; set; }
        public AFD_Trailer AFDTrailer { get; set; }

        public Ponto_AFD()
        {
            AFDCabecalho = new AFD_Cabecalho();
            AFDRegistro2 = new AFD_Registro2();
            ListaAFDRegistro3 = new List<AFD_Registro3>();
            ListaAFDRegistro4 = new List<AFD_Registro4>();
            ListaAFDRegistro5 = new List<AFD_Registro5>();
            AFDTrailer = new AFD_Trailer();
        }

    }
}
