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
    public partial class VentanaPersonas : Form
    {
        CRUDPersonaFacade cFachada;

        UnitOfWork uow = new UnitOfWork();

        Persona persona;

        public VentanaPersonas()
        {
            InitializeComponent();
            this.cFachada = new CRUDPersonaFacade(uow);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.persona = new Persona();
            this.persona.Nombre = this.txtNombre.Text;
            this.persona.Apellido = this.txtApellido.Text;
            this.cFachada.Create(persona);
            MessageBox.Show("Persona agregada correctamente");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
