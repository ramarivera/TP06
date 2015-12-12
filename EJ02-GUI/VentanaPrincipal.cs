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
    public partial class VentanaPrincipal : Form
    { 
        CRUDPersonaFacade iFachada;

        BindingList<Persona> iBinding;

        Persona persona;

        public VentanaPrincipal()
        {
            InitializeComponent();
            iFachada = new CRUDPersonaFacade();
            this.iBinding = this.iFachada.GetAll().ToBindingList();
            this.dgvPersonas.DataSource = this.iBinding;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            persona = new Persona();
            VentanaPersonas ventana = new VentanaPersonas();
            ventana.AgregarPersona(persona);
            DialogResult resultado = ventana.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                    iFachada.Create(persona);
            }
             

        }

        private void button4_Click(object sender, EventArgs e)
        {
                this.iBinding.Clear();
                this.iBinding.Add(iFachada.GetById(int.Parse(this.txtBuscar.Text)));
                this.dgvPersonas.Refresh();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
                foreach (DataGridViewRow row in this.dgvPersonas.SelectedRows)
                {
                    Persona persona = ((Persona)row.DataBoundItem);
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar a " + persona.Nombre + " " + " " + persona.Apellido + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    switch (resultado)
                    {
                        case DialogResult.Yes:
                            this.iFachada.Delete(persona);
                            this.iBinding.Remove(persona);
                            break;
                        case DialogResult.No:
                            break;
                    }
            }
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvPersonas.CurrentRow;
                this.persona = iFachada.GetById((int)row.Cells[0].Value);
                VentanaPersonas ventana = new VentanaPersonas();
                ventana.ModificarPersona(persona);
                DialogResult resultado = ventana.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    iFachada.Update(persona);
                }
            
        }

        private void btnTelefonos_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvPersonas.CurrentRow;
                this.persona = iFachada.GetById((int)row.Cells[0].Value);
                VentanaListaTelefonos ventana = new VentanaListaTelefonos(persona);
                this.DialogResult = ventana.ShowDialog();
                if (this.DialogResult == DialogResult.OK)
                {
                    iFachada.Update(persona);
                }
        }
    }
}
