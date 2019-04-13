/********************************************************************************
Title: T2TiPDV
Description: Classe de controle de logs de importação

The MIT License

Copyright: Copyright (C) 2014 T2Ti.COM

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
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using PafEcf.Util;
using PafEcf.Infra;

namespace PafEcf.Controller
{

    public class LogImportacaoController
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        private MySqlDataReader leitor;
        public string ConsultaSQL;

        public LogImportacaoController()
        {
            conexao = dbConnection.conectarRetaguarda();
        }


        public void GravaLogImportacao(string pErro)
        {
            ConsultaSQL = " insert into LOG_IMPORTACAO (" +
                                "DATA_IMPORTACAO, " +
                                "LOG_ERRO) " +
                            " values (" +
                                "?pDATA_IMPORTACAO, " +
                                "?pLOG_ERRO)";

            try
            {
                comando = new MySqlCommand(ConsultaSQL, conexao);
                comando.Parameters.AddWithValue("?pDATA_IMPORTACAO", DateTime.Now);
                comando.Parameters.AddWithValue("?pLOG_ERRO", pErro);
                comando.ExecuteNonQuery();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
            finally
            {
            }
        }



        public bool ExcluirLog(int pId)
        {
            ConsultaSQL = "delete from LOG_IMPORTACAO  where id = ?pID ";

            try
            {
                comando = new MySqlCommand(ConsultaSQL, conexao);
                comando.Parameters.AddWithValue("?pID", pId);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                return false;
            }
            finally
            {
            }
        }


        public bool ExcluirTodos()
        {
            ConsultaSQL = "delete from LOG_IMPORTACAO";

            try
            {
                comando = new MySqlCommand(ConsultaSQL, conexao);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                return false;
            }
            finally
            {
            }
        }

    }

}
