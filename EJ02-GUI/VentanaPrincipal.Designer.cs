namespace EJ02_GUI
{
    partial class VentanaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.pnlBotones = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnTelefonos = new System.Windows.Forms.Button();
            this.pnlPrincipal.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.ColumnCount = 1;
            this.pnlPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlPrincipal.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.pnlPrincipal.Controls.Add(this.btnBuscar, 0, 1);
            this.pnlPrincipal.Controls.Add(this.dgvPersonas, 0, 2);
            this.pnlPrincipal.Controls.Add(this.pnlBotones, 0, 3);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.RowCount = 4;
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.16438F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.83562F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.pnlPrincipal.Size = new System.Drawing.Size(317, 276);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.11465F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.88535F));
            this.tableLayoutPanel1.Controls.Add(this.lblBuscar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBuscar, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 29);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(3, 8);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(75, 13);
            this.lblBuscar.TabIndex = 4;
            this.lblBuscar.Text = "Buscar por ID:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscar.Location = new System.Drawing.Point(94, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(203, 20);
            this.txtBuscar.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnBuscar.Location = new System.Drawing.Point(121, 38);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 21);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonas.Location = new System.Drawing.Point(3, 65);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.Size = new System.Drawing.Size(311, 169);
            this.dgvPersonas.TabIndex = 0;
            this.dgvPersonas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // pnlBotones
            // 
            this.pnlBotones.ColumnCount = 3;
            this.pnlBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlBotones.Controls.Add(this.btnAgregar, 0, 0);
            this.pnlBotones.Controls.Add(this.btnEliminar, 1, 0);
            this.pnlBotones.Controls.Add(this.btnTelefonos, 2, 0);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(3, 240);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.RowCount = 1;
            this.pnlBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBotones.Size = new System.Drawing.Size(311, 33);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.Location = new System.Drawing.Point(14, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminar.Location = new System.Drawing.Point(117, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTelefonos
            // 
            this.btnTelefonos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTelefonos.Location = new System.Drawing.Point(217, 5);
            this.btnTelefonos.Name = "btnTelefonos";
            this.btnTelefonos.Size = new System.Drawing.Size(82, 23);
            this.btnTelefonos.TabIndex = 4;
            this.btnTelefonos.Text = "Gestionar Tel.";
            this.btnTelefonos.UseVisualStyleBackColor = true;
            this.btnTelefonos.Click += new System.EventHandler(this.btnTelefonos_Click);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 276);
            this.Controls.Add(this.pnlPrincipal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(333, 315);
            this.MinimumSize = new System.Drawing.Size(333, 315);
            this.Name = "VentanaPrincipal";
            this.Text = "Gestionar Personas";
            this.pnlPrincipal.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlPrincipal;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.TableLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnTelefonos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblBuscar;
    }
}

