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

        BindingList<Telefono> iBinding;
        public VentanaListaTelefonos(Persona pPersona)
        {
            InitializeComponent();
            this.persona = pPersona;
            cFachada = new CRUDPersonaFacade(uow);
            this.iBinding = this.persona.Telefonos.ToBindingList();
            this.dgvTelefonos.DataSource = this.iBinding;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Telefono lTelefono = new Telefono();
            VentanaTelefonos ventana = new VentanaTelefonos();
            ventana.AgregarTelefono(lTelefono);
            DialogResult resultado = ventana.ShowDialog();
            if (DialogResult.OK == resultado)
            {
                this.persona.Telefonos.Add(lTelefono);
                /*using (uow)
                {
                    this.cFachada.Update(persona);
                }*/
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
                        this.iBinding.Remove(telefono);
                        this.dgvTelefonos.Refresh();
                        /*using (uow)
                        {
                            this.cFachada.Update(persona);
                        }*/
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
                telefono.TelefonoId = (int)row.Cells[0].Value;
                telefono.Numero = row.Cells[1].Value.ToString();
                telefono.Tipo = row.Cells[2].Value.ToString();
                VentanaTelefonos ventana = new VentanaTelefonos();
                ventana.ModificarTelefono(telefono);
                DialogResult resultado = ventana.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    persona.Telefonos.RemoveAt(lugar);
                    persona.Telefonos.Insert(lugar, telefono);
                    //cFachada.Update(persona);
                }
           // }
        }
    }
}
