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

namespace EJ02.UI
{
    /// <summary>
    /// Ventana que muestra los teléfonos de una persona de la agenda telefónica
    /// </summary>
    public partial class VentanaListaTelefonos: Form
    {
        Persona persona;

        /// <summary>
        /// Fuente de datos del control dataGridView de la forma
        /// </summary>
        BindingList<Telefono> iBinding;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pPersona">Persona a la cual le pertenecen los teléfonos mostrados</param>
        public VentanaListaTelefonos(Persona pPersona)
        {
            InitializeComponent();
            this.persona = pPersona;
            this.iBinding = this.persona.Telefonos.ToBindingList();
            this.dgvTelefonos.DataSource = this.iBinding;
        }

        /// <summary>
        /// Reprenseta lo que ocurre al presionar el control button correspondiente (Agregar)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Reprenseta lo que ocurre al presionar el control button correspondiente (Eliminar)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Reprenseta lo que ocurre al hacer doble click en una fila del control dataGridView 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTelefonos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTelefonos.CurrentRow;
            int lugar = row.Index;
            Telefono telefono = new Telefono();
            //using (this.uow)
            //{
            telefono = this.iBinding.SingleOrDefault<Telefono>(t => t.TelefonoId == ((int)row.Cells[0].Value));  
            // TODO problema al querer editar un telefono sin haber guardado
                
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

        /// <summary>
        /// Reprenseta lo que ocurre al hacer click en el botón cerrar de la forma 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VentanaListaTelefonos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.dgvTelefonos.RowCount != 0)
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
}
