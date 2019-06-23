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
        string sourcePath = string.Empty;
        string targetPathNonDuplicated = string.Empty;
        string targetPathDuplicated = string.Empty;
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
            string destFileOriginal = string.Empty;
            string destFileDuplicated = string.Empty;


            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                //COMPARADOR:
                string[] miArray = files;
                //Array.Sort(miArray);
                Array.Reverse(miArray);
                int i = 0;
                int j = 0;

                for (i = 0; i < miArray.Length; i++) //toma el primer archivo para compararlo
                {
                    for (j = i + 1; j < miArray.Length; j++) //toma el segundo archivo para compararlo
                    {

                        // Use static Path methods to extract only the file name from the path.
                        fileName1 = Path.GetFileName(miArray[i]);
                        fileName2 = Path.GetFileName(miArray[j]);


                        int largo = fileName2.Length;              //22
                        int inicio = fileName2.IndexOf("cop", StringComparison.CurrentCultureIgnoreCase) - 3; // donde comienza: 9
                        int fin = fileName2.IndexOf(".");          // 18, cuantos recorto?: archivo 1 - Copiar.txt largo - (inicio + fin)

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
                        //resultado = "valor único". Ya comparamos el archivo 1 con todos los demás y ahora lo ponemos en "originales" y tomamos otro archivo.
                        Directory.CreateDirectory(targetPathNonDuplicated);
                        destFileOriginal = Path.Combine(targetPathNonDuplicated, fileName1);
                        File.Move(miArray[i], destFileOriginal);
                    } catch (Exception ex)
                    {

                    }

                } //termina la comparacion del primer archivo y va a tomar otro.


            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            MessageBox.Show("Terminé");
            Application.Exit();
            
        }
    }
}
