using System;
using System.Collections.Generic;
using System.IO;

namespace ComponenteSpedContribuicoes
{
	public class SpedUtil {

		private String delimitador;
		private String crlf;

		public SpedUtil() {
			delimitador = "|";
			crlf = "\r";
		}

		public String fill(String valor) {
			return valor == null ? delimitador : delimitador + valor.Trim();
		}

		public String fill(DateTime valor) {
            return valor == null ? delimitador : delimitador + valor.ToString("ddMMyyyy");
		}

		public String fill(int valor) {
			return valor == null ? delimitador : delimitador + valor;
		}

		public String fill(decimal valor) {
			return valor == null ? delimitador : delimitador + valor.ToString("0.00");
		}

		public String getDelimitador() {
			return delimitador;
		}

		public void setDelimitador(String delimitador) {
			this.delimitador = delimitador;
		}

		public String getCrlf() {
			return crlf;
		}

		public void setCrlf(String crlf) {
			this.crlf = crlf;
		}


        /// <summary>
        /// Create a new txt file and writes lines to it.
        /// </summary>
        /// <param name="directory">Directory where the new file will be created.</param>
        /// <param name="filename">file name</param>
        /// <param name="lines">Lines to write</param>
        public static void WriteLines(DirectoryInfo directory, String filename, List<String> lines)
        {
            var filePath = directory.FullName + filename;
            StreamWriter streamWriter = File.CreateText(filePath);

            try
            {
                foreach (String line in lines)
                {
                    streamWriter.WriteLine(line);
                }
            }
            finally
            {
                streamWriter.Close();
            }
        }

    }
}