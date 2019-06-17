using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompararElementosArrays
{
    class Program
    {

        static void Main(string[] args)
        {

            string[] miArray = { "uno", "dos", "tres", "tres", "uno" };

            //string resultado = string.Empty;
            //int i = 0;
            //int j = 0;
            //int contador = 1;

            //for (i = 0; i < miArray.Length; i++)
            //{
            //    Console.WriteLine("Comparaciones con el {0} ", miArray[i]);
            //    for (j = i + 1; j < miArray.Length; j++)
            //    {
            //        if (miArray[i] == miArray[j])
            //        {
            //            resultado = "valor duplicado";
            //        }
            //        else
            //        {
            //            resultado = "valor único";
            //        }

            //        Console.WriteLine("Comparacion {0} es {1}", contador, resultado);
            //        contador++;
            //    }

            //    //Console.WriteLine("Comparacion {0} es {1}" , i + j, resultado);
            //}

            comparador(miArray);

            Console.WriteLine("Pulse una tecla para salir");
            Console.ReadKey();
        }

        static void comparador(string[] array)
        {
            string resultado = string.Empty;
            int i = 0;
            int j = 0;
            int contador = 1;
            string[] miArray = array;


            for (i = 0; i < miArray.Length; i++)
            {
                Console.WriteLine("Comparaciones con el {0} ", miArray[i]);
                for (j = i + 1; j < miArray.Length; j++)
                {
                    if (miArray[i] == miArray[j])
                    {
                        resultado = "valor duplicado";
                    }
                    else
                    {
                        resultado = "valor único";
                    }
                    Console.WriteLine("Comparacion {0} con el {1}", miArray[i], miArray[j]);
                    Console.WriteLine("El valor es {0} ", resultado);
                    contador++;
                }

                Console.WriteLine(" ");
            }



            
        }



    }   
}
