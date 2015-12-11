using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EJ02;

namespace EJ02_GUI
{
    public partial class VentanaListaTelefonos: Form
    {
        Persona persona;

        BindingList<Telefono> iBinding;

        public VentanaListaTelefonos(Persona pPersona)
        {
            InitializeComponent();
            this.persona = pPersona;
            this.iBinding = this.persona.Telefonos.ToBindingList();
            this.dgvTelefonos.DataSource = this.iBinding;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Telefono lTelefono = new Telefono();
            VentanaTelefonos ventana = new VentanaTelefonos();
            ventana.AgregarTelefono(lTelefono);
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                this.iBinding.Add(lTelefono);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvTelefonos.SelectedRows)
            {
                Telefono telefono = ((Telefono)row.DataBoundItem);
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar el telefono " + telefono.Numero+ "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (resultado)
                {
                    case DialogResult.Yes:
                        this.iBinding.Remove(telefono);
                        //this.dgvTelefonos.Refresh();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void dgvTelefonos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTelefonos.CurrentRow;
            int lugar = row.Index;
            Telefono telefono = new Telefono();
            //using (this.uow)
            //{
            telefono = this.iBinding.SingleOrDefault<Telefono>(t => t.TelefonoId == ((int)row.Cells[0].Value));  
                
                VentanaTelefonos ventana = new VentanaTelefonos();
                ventana.ModificarTelefono(telefono);
                ventana.ShowDialog();
                if (ventana.DialogResult == DialogResult.OK)
                {
                    this.iBinding[lugar] = telefono;
                    //cFachada.Update(persona);
                }
           // }
        }

        private void VentanaListaTelefonos_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios antes de salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (resultado)
            {
                case DialogResult.Yes:
                    this.DialogResult = DialogResult.OK;
                    this.persona.Telefonos = this.iBinding;
                    break;
                case DialogResult.No:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}
