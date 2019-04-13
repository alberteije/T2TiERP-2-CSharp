/********************************************************************************
Title: T2TiPDV
Description: Classe de conexão com o banco de dados

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

@author Albert Eije
@version 1.0
********************************************************************************/

using FirebirdSql.Data.FirebirdClient;
using System;
using System.Windows.Forms;


namespace ConfiguraPAFECF.Util
{
    public static class dbConnection
    {
        private static FbConnection conexao;

        public static FbConnection conectar()
        {
            try
            {
                if (conexao == null)
                {
                    //string connStr = "server=localhost;user=root;password=root;database=pafecfc;port=3306;pooling=true;min pool size =2;connection timeout=10000;";
                    string connStr = "User=SYSDBA;" + "Password=masterkey;" + "Database=" + "c:\\T2Ti\\Dados\\PAFECF_C.FDB;" + "DataSource=127.0.0.1;" + "Port=3050;" + "Dialect=3;" + "Charset=UTF8;";
                    conexao = new FbConnection(connStr);
                    conexao.Open();
                    return conexao;
                }
                else
                {
                    return conexao;
                }
            }
            catch (Exception eError)
            {
                MessageBox.Show(eError.Message);
                return null;
            }
        }


    }
}
