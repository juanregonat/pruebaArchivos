using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pruebaArchivos
{
    class Archivo
    {
        StreamReader sr;
        bool abierto = false;
        //Constructor: recibe un nombre de archivo y lo abre.
        public Archivo(string filename)
        {
            try
            {
                sr = new StreamReader(filename);
                abierto = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en la apertura de \"{0}\":{1})", filename, e.ToString());                
            }            
        }

        public void Mostrar() {
            string linea;
            if (!abierto) return; //si no pudo abrir, no lee nada
            linea = sr.ReadLine();

            while (linea != null) {
                Console.WriteLine(linea);
                linea = sr.ReadLine();
            }
            sr.Close();
            abierto = false;
        }

    }
}






