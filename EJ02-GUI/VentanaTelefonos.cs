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
    /// Ventana utilizada para la gestion de teléfonos de personas de la agenda telefónica
    /// </summary>
    public partial class VentanaTelefonos : Form
    {
        private Telefono iTelefonoOriginal;

        public Telefono Telefono
        {
            get { return this.iTelefonoOriginal; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public VentanaTelefonos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permite cargar los datos de un nuevo teléfono de una persona
        /// </summary>
        /// <param name="pTelefonoNuevo">Nueva entidad</param>
        public void AgregarTelefono(Telefono pTelefonoNuevo)
        {
            this.txtId.Text = "--- Sin ID ---";
            this.txtNumero.Text = String.Empty;
            this.txtTipo.Text = String.Empty;
            this.Text = "Agregar nuevo Telefono";
            this.iTelefonoOriginal = pTelefonoNuevo;
        }

        /// <summary>
        /// Permite modificar los datos de un teléfono existente de una persona
        /// </summary>
        /// <param name="pTelefono">Entidad a modificar</param>
        public void ModificarTelefono(Telefono pTelefono)
        {
            this.txtId.Text = pTelefono.TelefonoId.ToString();
            this.txtNumero.Text = pTelefono.Numero;
            this.txtTipo.Text = pTelefono.Tipo;
            this.Text = "Modificar Telefono";
            this.iTelefonoOriginal = pTelefono;
        }


        /// <summary>
        /// Reprenseta lo que ocurre al presionar el control button correspondiente (Aceptar)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            iTelefonoOriginal.Numero = this.txtNumero.Text;
            iTelefonoOriginal.Tipo = this.txtTipo.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Reprenseta lo que ocurre al presionar el control button correspondiente (Cancelar)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show(
                                        "¿Desea salir sin guardar los cambios",
                                        "Salir",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
            switch (opcion)
            {
                case DialogResult.Yes:
                    this.DialogResult = DialogResult.No;
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
