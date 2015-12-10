using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using EJ02;

namespace EJ02_GUI
{
    public partial class Form1 : Form
    {
        CRUDPersonaFacade cFachada;

        UnitOfWork ouw = new UnitOfWork();

        BindingList<Persona> iBinding;
        public Form1()
        {
            InitializeComponent();
            //this.iBinding = this.cFachada.GetAll().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VentanaPersonas ventana = new VentanaPersonas();
            ventana.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = cFachada.GetById(int.Parse(this.txtBuscar.Text));
            this.dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                Persona persona = ((Persona)row.DataBoundItem);
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar a " + persona.Nombre + " " + " " + persona.Apellido+ "?","Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (resultado)
                {
                    case DialogResult.Yes:
                        this.cFachada.Delete(persona);
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
    }
}
