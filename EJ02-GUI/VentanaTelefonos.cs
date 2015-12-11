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
    public partial class VentanaTelefonos : Form
    {
        private Telefono iTelefonoOriginal;

        public Telefono Telefono
        {
            get { return this.iTelefonoOriginal; }
        }

        public VentanaTelefonos()
        {
            InitializeComponent();
        }

        public void AgregarTelefono(Telefono pTelefonoNuevo)
        {
            this.txtId.Text = "--- Sin ID ---";
            this.txtNumero.Text = String.Empty;
            this.txtTipo.Text = String.Empty;
            this.Text = "Agregar nuevo Telefono";
            this.iTelefonoOriginal = pTelefonoNuevo;
        }

        public void ModificarTelefono(Telefono pTelefono)
        {
            this.txtId.Text = pTelefono.TelefonoId.ToString();
            this.txtNumero.Text = pTelefono.Numero;
            this.txtTipo.Text = pTelefono.Tipo;
            this.Text = "Modificar Telefono";
            this.iTelefonoOriginal = pTelefono;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Telefono telefono = new Telefono();
            telefono.Numero = this.txtNumero.Text;
            telefono.Tipo = this.txtTipo.Text;
            this.persona.Telefonos.Add(telefono);
            cFachada.Update(this.persona);
            MessageBox.Show("Telefono agregado correctamente");
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("¿Desea salir sin guardar los cambios", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (opcion)
            {
                case DialogResult.Yes:
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
