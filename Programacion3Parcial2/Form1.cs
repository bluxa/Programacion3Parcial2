using Programacion3Parcial2.ArbolAVL;
using Programacion3Parcial2.ArbolBinario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Programacion3Parcial2
{
    public partial class Form1 : Form
    {
        ArbolAvl miArbol = new ArbolAvl();
        List<string> auxId = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //label1.Parent = panel1;
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                txtUrlArchivo.Text = buscar.FileName;

                string extension = System.IO.Path.GetExtension(buscar.FileName);
                if (!extension.Equals(".csv"))
                {
                    MessageBox.Show("Sólo se admiten archivos en formato .csv ");
                    return;
                }
            }
            string linea;

            StreamReader archivo = new StreamReader(txtUrlArchivo.Text);
            char delimitador = ';';
            

            while ((linea = archivo.ReadLine()) != null)
            {
                string[] aux = linea.Split(delimitador);
                ClsEstudiante objEstudiante = new ClsEstudiante(aux[0], aux[1],aux[2],aux[3], Convert.ToDouble(aux[4]),
                    Convert.ToDouble(aux[5]), Convert.ToDouble(aux[6]), Convert.ToDouble(aux[7]));

                auxId.Add(aux[3]);

                miArbol.insertarDato(objEstudiante);
                
            }
            archivo.Close();
        }

        public void limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtLab1.Clear();
            txtLab2.Clear();
            txtLab3.Clear();
            txtLab4.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string linea;

            StreamReader archivo = new StreamReader(txtUrlArchivo.Text);
            char delimitador = ';';
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] aux = linea.Split(delimitador);
                
                if (aux[2] == txtEmail.Text)
                {
                    ClsEstudiante objEstudiante = new ClsEstudiante("", "", txtEmail.Text, aux[3], 0,0, 0, 0);

                    ClsEstudiante obj;
                    obj = (ClsEstudiante)miArbol.buscarDato(objEstudiante).valorNodo();
                    txtId.Text = obj.id;
                    txtNombre.Text = obj.nombre + obj.apellidos;
                    txtLab1.Text = Convert.ToString(obj.notaLab1);
                    txtLab2.Text = Convert.ToString(obj.notaLab2);
                    txtLab3.Text = Convert.ToString(obj.notaLab3);
                    txtLab4.Text = Convert.ToString(obj.notaLab4);
                    double r = (obj.notaLab1 + obj.notaLab2 + obj.notaLab3 + obj.notaLab4) / 4;
                    txtPromedio.Text = Convert.ToString(r);
                    if (r >= 6)
                        lbResultado.Text = "APROBADO";
                    else
                        lbResultado.Text = "REPROBADO";
                    MessageBox.Show("Nodos recorridos  " + miArbol.contador() );
                }
             
            }
            archivo.Close();



        }

        private void btnPreOrden_Click(object sender, EventArgs e)
        {
            txtMostrar.Clear();
            txtMostrar.Text = ArbolAVL.ArbolAvl.preOrden(miArbol.raizArbolAvl());
        }

        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            txtMostrar.Clear();
            txtMostrar.Text = ArbolAVL.ArbolAvl.postOrden(miArbol.raizArbolAvl());
        }

        private void btnEnOrden_Click(object sender, EventArgs e)
        {
            txtMostrar.Clear();
            txtMostrar.Text = ArbolAVL.ArbolAvl.inOrden(miArbol.raizArbolAvl());
        }
    }
}
