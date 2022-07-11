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

namespace Level_Presentation
{
    public partial class Form1 : Form
    {
        bool FileStatus = false;

        public Form1()
        {
            InitializeComponent();


        }

      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                bunifuFlatButton1.Enabled = false;

                bunifuFlatButton2.Enabled = false;

                bunifuFlatButton3.Enabled = false;
            }
            else
            {
                bunifuFlatButton1.Enabled = true;

                bunifuFlatButton2.Enabled = true;

                bunifuFlatButton3.Enabled = true;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color colorSelect = colorDialog1.Color;

                textBox1.ForeColor = colorSelect;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {

                Font fontSelect = fontDialog1.Font;

                textBox1.Font = fontSelect;
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            if(FileStatus == false) {

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {

                    TextWriter TextCreate = new StreamWriter(folderBrowserDialog1.SelectedPath + "/" + textBox2.Text + ".txt");

                    TextCreate.WriteLine(textBox1.Text);

                    TextCreate.Close();

                    MessageBox.Show("El Archivo De Texto Fue Creado Correctamente", "Archivo Creado");

                    textBox2.Text = folderBrowserDialog1.SelectedPath + "/" + textBox2.Text + ".txt";

                    FileStatus = true;
                }

            }

            else
            {
                TextWriter TextUpdate = new StreamWriter(textBox2.Text);

                TextUpdate.WriteLine(textBox1.Text);

                TextUpdate.Close();

                MessageBox.Show("El Archivo De Texto Fue Actualizado Correctamente", "Archivo Actualizado");
            }

           
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                textBox2.Text = openFileDialog1.FileName;

                string FileText = System.IO.File.ReadAllText(@openFileDialog1.FileName);

                label1.Text = "Ruta Del Archivo:";

                textBox1.Text = FileText;

                FileStatus = true;

                textBox1.Enabled = true;

                textBox2.Enabled = true;
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            textBox2.Text = "Nuevo Archivo de Texto";

            label1.Text = "Nombre Del Archivo:";

            FileStatus = false;

            textBox1.Enabled = true;

            textBox2.Enabled = true;
        }

       
    }
}

