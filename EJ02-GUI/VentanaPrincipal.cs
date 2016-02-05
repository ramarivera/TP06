﻿using System;
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

namespace EJ02.UI
{
    public partial class VentanaPrincipal : Form
    {
        CRUDPersonaFacade iFachada;

        BindingList<Persona> iBinding;

        Persona persona;

        public VentanaPrincipal(CRUDPersonaFacade pFachada)
        {
            InitializeComponent();
            this.iFachada = pFachada;

        }
        public VentanaPrincipal()
        {
            InitializeComponent();
            this.iFachada = new CRUDPersonaFacade();
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            this.RefreshBinding();
            this.dgvPersonas.Enter += dgvPersonas_Leave;
        }

        private void Rebind()
        {
            this.dgvPersonas.DataSource = null;
            this.RefreshBinding();
            this.dgvPersonas.DataSource = this.iBinding;
        }

        private void InicializarDataGridView()
        {
            this.Rebind();

            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            if (dgvPersonas.Columns["Teléfonos"] != null)
            {
                dgvPersonas.Columns.Remove(dgvPersonas.Columns["Teléfonos"]);
            }


            /*DataGridViewButtonColumn btnGestionar = new DataGridViewButtonColumn();
            btnGestionar.Name = "Teléfonos";
            btnGestionar.Text = "Gestionar" + DateTime.Now.Second.ToString();
            btnGestionar.UseColumnTextForButtonValue = true;
            btnGestionar.FlatStyle = FlatStyle.Standard;

            if (dgvPersonas.Columns["Telefonos"] != null)
            {
                dgvPersonas.Columns.Remove(dgvPersonas.Columns["Telefonos"]);
                dgvPersonas.Columns.Add(btnGestionar);
            }

            dgvPersonas.CellClick += DgvPersonas_CellClick; */

            EtiquetarDataGridView();

        }

        private void EtiquetarDataGridView()
        {
            foreach (DataGridViewRow row in this.dgvPersonas.Rows)
            {
                row.Tag = row.Cells[0].Value;
            }
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
                iBinding.Add(persona);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.iBinding.Clear();
            this.iBinding.Add(iFachada.GetById(int.Parse(this.txtBuscar.Text)));
            EtiquetarDataGridView();

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
            this.persona = this.iBinding.Single<Persona>(p => p.PersonaId == (int)row.Tag);
            VentanaPersonas ventana = new VentanaPersonas();
            ventana.ModificarPersona(persona);
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                iFachada.Update(persona);
            }

        }

        private void btnTelefonos_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvPersonas.CurrentRow;
            this.persona = this.iBinding.Single<Persona>(p => p.PersonaId == (int)row.Tag);
            VentanaListaTelefonos ventana = new VentanaListaTelefonos(persona);
            ventana.ShowDialog();

            if (ventana.DialogResult == DialogResult.OK)
            {
                iFachada.Update(persona);
            }
        }

        private void RefreshBinding()
        {
            this.iBinding = this.iFachada.GetAll().ToBindingList<Persona>();       
        }

        private void dgvPersonas_Leave(object sender, EventArgs e)
        {
            this.InicializarDataGridView();
        }
    }
}
 