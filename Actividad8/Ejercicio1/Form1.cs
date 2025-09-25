using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Ejercicio1.Models;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Vehiculo> vehiculos = new List<Vehiculo>();

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "C:\\Users\\Alumno\\Desktop\\vehiculos.txt";
            string[] lineas = File.ReadAllLines(path);

            foreach (string line in lineas)
            {
                string[] s = line.Split(';');

                textBox1.Text += s[0] + " " + s[1] + "\r\n";
            }

            OpenFileDialog odf = new OpenFileDialog();

            if (odf.ShowDialog() == DialogResult.OK)
            {
                string name = odf.FileName;
                FileStream fs = null;
                StreamReader sr = null;

                try
                {
                    fs = new FileStream(name, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);

                    sr.ReadLine();

                    while (sr.EndOfStream != true)
                    {
                        string cadena = sr.ReadLine().Trim();
                        string[] separator = cadena.Split(';');

                        string patente = separator[0];
                        string importe = separator[1];

                        Vehiculo vehiculo = new Vehiculo(patente, importe);

                        vehiculos.Add(vehiculo);
                    }

                    foreach (Vehiculo v in vehiculos)
                    {
                        comboBox1.Items.Add(v.Patente);
                    }
                }
                catch (PatenteException ex) 
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();
                }
            }

        }
    }
}
