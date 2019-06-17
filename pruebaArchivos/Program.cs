using System;
using System.IO;


namespace pruebaArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            //EJEMPLO 1:
            /*
            string fileName = @"C:\pruebaArchivos\temp.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Console.WriteLine(reader.ReadLine());
            }
            reader.Close();
            */


            //EJEMPLO 2:
            /*
            ReadFile readFile = new ReadFile();
            String sPath = @"C:\pruebaArchivos\";
            String sFileName = @"temp.txt";
            readFile.ReadFiles(sPath, sFileName);
            */


            //EJEMPLO 3:
            /*
            string nombre;
            Console.Write("Nombre del archivo: ");
            nombre = Console.ReadLine();
            Archivo archivo = new Archivo(nombre);
            archivo.Mostrar();
            Console.ReadLine();
            //ruta archivo: C:\pruebaArchivos\temp.txt
            */


            //EJEMPLO 5: escribiendo un archivo
            
            string fileName = @"C:\pruebaArchivos\temp2.txt";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine("Esta es la 1er linea del archivo");
            writer.Close();
            

            



        Console.ReadKey();
        }


    }
}
