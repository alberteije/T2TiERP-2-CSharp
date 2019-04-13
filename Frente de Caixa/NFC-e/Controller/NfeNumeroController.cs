/********************************************************************************
Title: T2TiNFCe
Description: Classe de controle do numero da nota

The MIT License

Copyright: Copyright (C) 2015 T2Ti.COM

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

       The author may be contacted at:
           t2ti.com@gmail.com

@author T2Ti.COM
@version 1.0
********************************************************************************/

using System;
using NFCe.DTO;
using NHibernate;
using NFCe.NHibernate;
using System.Collections.Generic;
using NFCe.Util;

namespace NFCe.Controller
{

    public class NfeNumeroController
    {

        public static NfeNumeroDTO ConsultaNfeNumero(string pFiltro)
        {
            try
            {
                NfeNumeroDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeNumeroDTO> DAL = new NHibernateDAL<NfeNumeroDTO>(Session);

                    String ConsultaSql = "from NfeNumeroDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<NfeNumeroDTO>(ConsultaSql);

                    // Se já existe um número na base, incrementa e retorna
                    if (Resultado != null)
                    {
                        Resultado.Numero = Resultado.Numero + 1;
                        GravaNfeNumero(Resultado);
                    }
                    // Se não existe um número na base, inclui com dados padrões
                    else if (Resultado != null)
                    {
                        Resultado = new NfeNumeroDTO();
                        Resultado.Serie = "001";
                        Resultado.Numero = 1;
                        Resultado.IdEmpresa = 1;
                        Resultado = GravaNfeNumero(Resultado);
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        
        public static NfeNumeroDTO GravaNfeNumero(NfeNumeroDTO pNfeNumero)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeNumeroDTO> DAL = new NHibernateDAL<NfeNumeroDTO>(Session);
                    DAL.SaveOrUpdate(pNfeNumero);
                    Session.Flush();
                }
                return pNfeNumero;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
    }

}
