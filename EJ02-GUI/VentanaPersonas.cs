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
    public partial class VentanaPersonas : Form
    {
        private Persona iPersonaOriginal;

        public Persona Persona
        {
            get { return this.iPersonaOriginal; }
        }

        public VentanaPersonas()
        {
            InitializeComponent();
        }

        public void AgregarPersona(Persona pPersonaNueva)
        {
            this.txtId.Text = "--- Sin ID ---";
            this.txtNombre.Text = String.Empty;
            this.txtApellido.Text = String.Empty;
            this.Text = "Agregar nueva Persona";
            this.iPersonaOriginal = pPersonaNueva;
        }

        public void ModificarPersona(Persona pPersona)
        {
            this.txtId.Text = pPersona.PersonaId.ToString();
            this.txtNombre.Text = pPersona.Nombre;
            this.txtApellido.Text = pPersona.Apellido;
            this.Text = "Modificar Persona";
            this.iPersonaOriginal = pPersona;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.iPersonaOriginal.Nombre = this.txtNombre.Text;
            this.iPersonaOriginal.Apellido = this.txtApellido.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show(
                                        "¿Desea salir sin guardar los cambios?",
                                        "Salir",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
            switch (opcion)
            {
                case DialogResult.Yes:
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
