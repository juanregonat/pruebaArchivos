using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PruebaArchivos4
{
    public partial class Form1 : Form
    {
        string fileName1 = string.Empty;
        string fileName2 = string.Empty;
        string sourcePath = string.Empty;//@"C:\pruebaArchivos\TestFolder";
        string targetPathNonDuplicated = string.Empty;// @"C:\pruebaArchivos\TestFolder\SubDir";
        string targetPathDuplicated = string.Empty;// @"C:\pruebaArchivos\TestFolder\SubDir";
        private bool carpetaElegida = false;

        public Form1()
        {
            InitializeComponent();         
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        public void ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sourcePath = folderBrowserDialog1.SelectedPath;
                targetPathNonDuplicated = sourcePath + @"\archivosUnicos";
                targetPathDuplicated = sourcePath + @"\archivosSospechosos";
                carpetaElegida = true;
                textBox1.Text = folderBrowserDialog1.SelectedPath;

            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!carpetaElegida)
            {
                return;
            }


            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath, fileName1);
            string destFileOriginal = string.Empty;// Path.Combine(targetPathNonDuplicated, fileName1);
            string destFileDuplicated = string.Empty;// Path.Combine(targetPathDuplicated, fileName2);

            // To copy a folder's contents to a new location:
            // Create a new target folder. 
            // If the directory already exists, this method does not create a new directory.
            //Directory.CreateDirectory(targetPathNonDuplicated);
            //Directory.CreateDirectory(targetPathDuplicated);
            
            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously in this code example.
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                //COMPARADOR:     
                string[] miArray = files;
                //Array.Sort(miArray);
                Array.Reverse(miArray);
                int i = 0;
                int j = 0;
                //int contador = 1;                

                for (i = 0; i < miArray.Length; i++)
                {
                    for (j = i + 1; j < miArray.Length; j++)
                    {

                        // Use static Path methods to extract only the file name from the path.
                        fileName1 = Path.GetFileName(miArray[i]);
                        fileName2 = Path.GetFileName(miArray[j]);

                        int found2a = fileName2.IndexOf("(");
                        int found2b = fileName2.IndexOf(")");

                        if (found2a != found2b && found2a >= 0)
                        {   //usar un nombre temporal para ver si es igual a fileName1 o no
                            string fileName2Temp = (fileName2.Remove(found2a, found2b - found2a + 1)).Trim();

                            if (fileName1 == fileName2Temp)
                            {
                                //resultado = "valor duplicado";
                                Directory.CreateDirectory(targetPathDuplicated);
                                destFileDuplicated = Path.Combine(targetPathDuplicated, fileName2);
                                File.Move(miArray[j], destFileDuplicated);
                            }
                        }
                    }


                //resultado = "valor único". Ya comparamos el archivo 1 con todos los demás y ahora lo ponemos en "originales" y tomamos otro archivo.
                    Directory.CreateDirectory(targetPathNonDuplicated);
                    destFileOriginal = Path.Combine(targetPathNonDuplicated, fileName1);
                    //File.Move(miArray[j], destFileOriginal);
                    File.Move(miArray[i], destFileOriginal);

                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }


            Application.Exit();
            
        }
    }
}
