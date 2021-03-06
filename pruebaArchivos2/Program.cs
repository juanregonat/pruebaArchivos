﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArchivos2
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //}


        //ESTE PROGRAMA COPIABA ARCHIVOS EN UNA CARPETA HIJA DE LA SELECCIONADA

        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-copy-delete-and-move-files-and-folders
        // Simple synchronous file copy operations with no user interface.
        // To run this sample, first create the following directories and files: //
        // C:\Users\Public\TestFolder
        // C:\Users\Public\TestFolder\test.txt
        // C:\Users\Public\TestFolder\SubDir\test.txt
        public class SimpleFileCopy
        {
            static void Main()
            {
                string fileName = "test.txt";
                //string sourcePath = @"C:\Users\Public\TestFolder";
                //string targetPath = @"C:\Users\Public\TestFolder\SubDir";
                string sourcePath = @"C:\pruebaArchivos\TestFolder";
                string targetPath = @"C:\pruebaArchivos\TestFolder\SubDir";

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                // To copy a folder's contents to a new location:
                // Create a new target folder. 
                // If the directory already exists, this method does not create a new directory.
                System.IO.Directory.CreateDirectory(targetPath);

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.                
                //System.IO.File.Copy(sourceFile, destFile, true);  


                // AHORA PROBRAMOS MOVERLO
                //https://stackoverflow.com/questions/3218910/rename-a-file-in-c-sharp
                //System.IO.File.Move("oldfilename", "newfilename");               
                System.IO.File.Move(sourceFile, destFile);
                




                // To copy all the files in one directory to another directory.
                // Get the files in the source folder. (To recursively iterate through
                // all subfolders under the current directory, see
                // "How to: Iterate Through a Directory Tree.")
                // Note: Check for target path was performed previously
                //       in this code example.
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }

                // Keep console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

            }
        }






    }
}
