using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SAT
{
    public static class ComunicacaoSAT
    {
        [DllImport("SAT.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr EnviarDadosVenda(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string dadosVenda);

        [DllImport("SAT.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarSAT(int numeroSessao);

        [DllImport("SAT.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BloquearSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("SAT.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DesbloquearSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("SAT.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarStatusOperacional(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

    }
}
