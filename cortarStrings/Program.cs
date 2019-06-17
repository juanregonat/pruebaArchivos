using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cortarStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.remove?view=netframework-4.8#System_String_Remove_System_Int32_System_Int32_
            string name = "foto(1sasas).jpg";
            Console.WriteLine("Nombre original: '{0}'", name);

            // remove the middle name, identified by finding the spaces in the middle of the name...
            int foundS1 = name.IndexOf("("); //4            
            int foundS2 = name.IndexOf(")"); //6      borrar 4, 5, 6

            if (foundS1 != foundS2 && foundS1 >= 0)
            {                
                name = name.Remove(foundS1,foundS2 - foundS1 + 1);
                Console.WriteLine("Nombre final: '{0}'", name);
            }



            Console.ReadKey();
        }
    }
}
