using System;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Diagnostics;

namespace PruebaArchivos4
{
    public partial class Form1 : Form
    {
        string sourcePath = string.Empty;
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

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);
                buscarDuplicados(files);
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            MessageBox.Show("Terminé");
            Process.Start("explorer.exe", sourcePath);
            Application.Exit();
            
        }

        private void buscarDuplicados(string[] array) {
            string[] miArray = array;
            Array.Reverse(miArray);
            int i = 0;
            int j = 0;
            string fileName1 = string.Empty;
            string fileName2 = string.Empty;

            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath, fileName1);
            string destFileOriginal = string.Empty;
            string destFileDuplicated = string.Empty;

            string targetPathNonDuplicated = sourcePath + @"\archivosUnicos";
            string targetPathDuplicated = sourcePath + @"\archivosSospechosos";
            
            for (i = 0; i < miArray.Length; i++) //toma el primer archivo para compararlo
            {
                for (j = i + 1; j < miArray.Length; j++) //toma el segundo archivo para compararlo
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName1 = Path.GetFileName(miArray[i]);
                    fileName2 = Path.GetFileName(miArray[j]);

                    int largo = fileName2.Length;
                    int inicio = fileName2.IndexOf("cop", StringComparison.CurrentCultureIgnoreCase) - 3;
                    int fin = fileName2.IndexOf(".");

                    if (inicio > 0)
                    {
                        string nombreTemp = fileName2.Remove(inicio, fin - inicio);
                        if (fileName1 == nombreTemp)
                        {
                            //resultado = "valor duplicado" : entonces creo una carpeta, y muevo al archivo 2 para ahi;
                            Directory.CreateDirectory(targetPathDuplicated);
                            destFileDuplicated = Path.Combine(targetPathDuplicated, fileName2);
                            File.Move(miArray[j], destFileDuplicated);
                        }
                    }

                    //tomo el segundo nombre y le busco parentesis
                    int foundParenthesis1 = fileName2.IndexOf("(");
                    int foundParenthesis2 = fileName2.IndexOf(")");
                    if (foundParenthesis1 != foundParenthesis2 && foundParenthesis1 >= 0)

                    {   //usar un nombre temporal para ver si es igual a fileName1 o no
                        string fileName2Temp = (fileName2.Remove(foundParenthesis1 - 9, foundParenthesis2 - foundParenthesis1 + 1)).Trim();
                        if (fileName1 == fileName2Temp)
                        {
                            //resultado = "valor duplicado" : entonces creo una carpeta, y muevo al archivo 2 para ahi;
                            Directory.CreateDirectory(targetPathDuplicated);
                            destFileDuplicated = Path.Combine(targetPathDuplicated, fileName2);
                            File.Move(miArray[j], destFileDuplicated);
                        }
                    }

                } //termina la comparación del segundo archivo y va a tomar otro.


                try
                {
                    Directory.CreateDirectory(targetPathNonDuplicated);
                    destFileOriginal = Path.Combine(targetPathNonDuplicated, fileName1);
                    File.Move(miArray[i], destFileOriginal);
                }
                catch (Exception ex)
                {

                }

            } //termina la comparacion del primer archivo y va a tomar otro.

        }        

    }
}
