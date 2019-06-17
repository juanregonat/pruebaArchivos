using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap MyPhoto =   new Bitmap(@"C:\Users\Juan\Pictures\Camera Roll\foto1.jpg");
            PropertyItem[] props = MyPhoto.PropertyItems;
            foreach (PropertyItem prop in props)
            {
                MessageBox.Show(
                    "ID: " + prop.Id.ToString() + " " + 
                    "Len: " +  prop.Len.ToString()
                    );
            }

        }
    }
}
