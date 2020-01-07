using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.cajas_efectivo
{
    public partial class Imagenes : Form
    {
        public Imagenes()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Imagenes_Load(object sender, EventArgs e)
        {
            ListViewGroup grupo1 = new ListViewGroup("Cajas abiertas", HorizontalAlignment.Center);
            lista_cajas.Groups.Add(grupo1);
            lista_cajas.LargeImageList = lista_imagenes;
            lista_cajas.Items.Add(new ListViewItem("Pruebas 1",0, grupo1));
            lista_cajas.Items.Add(new ListViewItem("Pruebas 2", 0, grupo1));

        }

        private void lista_cajas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hola = lista_cajas.SelectedItems[0].Text;
            MessageBox.Show(hola);
        }
    }
}
