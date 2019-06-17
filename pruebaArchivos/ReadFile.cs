using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pruebaArchivos
{
    public class ReadFile
    {
        public void ReadFiles(string sPath, string sFileName) {
            //sPath = @"C:\pruebaArchivos\";
            //sFileName = sPath + @"temp.txt";
            string fullFileName = sPath + sFileName;

            //verificamos que el archivo exite:
            if (File.Exists(fullFileName)) {
                FileStream fs = new FileStream(fullFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                //leo todo el archivo:
                string sContent = sr.ReadToEnd();
                //cierro el obj:
                fs.Close();
                sr.Close();
                Console.Write("Contenido = " + sContent);
            }

        }

    }
}
