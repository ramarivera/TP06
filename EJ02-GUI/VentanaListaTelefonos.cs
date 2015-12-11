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

        UnitOfWork uow = new UnitOfWork();

        CRUDPersonaFacade cFachada;
        public VentanaListaTelefonos(Persona pPersona)
        {
            InitializeComponent();
            this.persona = pPersona;
            this.Name = "Telefonos de "+pPersona.Nombre+" "+pPersona.Apellido;
            cFachada = new CRUDPersonaFacade(uow);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Telefono lTelefono = new Telefono();
            VentanaTelefonos ventana = new VentanaTelefonos();
            ventana.AgregarTelefono(lTelefono);
            ventana.ShowDialog();
            if (DialogResult.Yes == ventana.DialogResult)
            {

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
                        this.persona.Telefonos.Remove(telefono);
                        this.cFachada.Update(persona);
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
    }
}
