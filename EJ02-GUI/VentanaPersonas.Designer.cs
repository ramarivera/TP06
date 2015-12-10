namespace EJ02_GUI
{
    partial class VentanaPersonas
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
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBotones = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLinea3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.pnlLinea2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLinea1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.pnlLinea3.SuspendLayout();
            this.pnlLinea2.SuspendLayout();
            this.pnlLinea1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(4, 8);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtApellido.Location = new System.Drawing.Point(73, 4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(170, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.Location = new System.Drawing.Point(29, 9);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Aceptar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(154, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.ColumnCount = 1;
            this.pnlPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPrincipal.Controls.Add(this.pnlLinea1, 0, 1);
            this.pnlPrincipal.Controls.Add(this.pnlBotones, 0, 7);
            this.pnlPrincipal.Controls.Add(this.pnlLinea3, 0, 5);
            this.pnlPrincipal.Controls.Add(this.pnlLinea2, 0, 3);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.RowCount = 8;
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.pnlPrincipal.Size = new System.Drawing.Size(270, 218);
            this.pnlPrincipal.TabIndex = 7;
            // 
            // pnlBotones
            // 
            this.pnlBotones.ColumnCount = 5;
            this.pnlBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.pnlBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.pnlBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.pnlBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.pnlBotones.Controls.Add(this.btnGuardar, 1, 0);
            this.pnlBotones.Controls.Add(this.btnCancelar, 3, 0);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(3, 173);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.RowCount = 1;
            this.pnlBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBotones.Size = new System.Drawing.Size(264, 42);
            this.pnlBotones.TabIndex = 0;
            // 
            // pnlLinea3
            // 
            this.pnlLinea3.ColumnCount = 2;
            this.pnlLinea3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlLinea3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pnlLinea3.Controls.Add(this.lblApellido, 0, 0);
            this.pnlLinea3.Controls.Add(this.txtApellido, 1, 0);
            this.pnlLinea3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLinea3.Location = new System.Drawing.Point(3, 118);
            this.pnlLinea3.Name = "pnlLinea3";
            this.pnlLinea3.RowCount = 1;
            this.pnlLinea3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLinea3.Size = new System.Drawing.Size(264, 29);
            this.pnlLinea3.TabIndex = 9;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(4, 8);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombre.Location = new System.Drawing.Point(73, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(170, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // pnlLinea2
            // 
            this.pnlLinea2.ColumnCount = 2;
            this.pnlLinea2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlLinea2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pnlLinea2.Controls.Add(this.txtNombre, 1, 0);
            this.pnlLinea2.Controls.Add(this.lblNombre, 0, 0);
            this.pnlLinea2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLinea2.Location = new System.Drawing.Point(3, 68);
            this.pnlLinea2.Name = "pnlLinea2";
            this.pnlLinea2.RowCount = 1;
            this.pnlLinea2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLinea2.Size = new System.Drawing.Size(264, 29);
            this.pnlLinea2.TabIndex = 8;
            // 
            // pnlLinea1
            // 
            this.pnlLinea1.ColumnCount = 2;
            this.pnlLinea1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlLinea1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pnlLinea1.Controls.Add(this.txtId, 1, 0);
            this.pnlLinea1.Controls.Add(this.lblId, 0, 0);
            this.pnlLinea1.Location = new System.Drawing.Point(3, 18);
            this.pnlLinea1.Name = "pnlLinea1";
            this.pnlLinea1.RowCount = 1;
            this.pnlLinea1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLinea1.Size = new System.Drawing.Size(264, 29);
            this.pnlLinea1.TabIndex = 9;
            // 
            // txtId
            // 
            this.txtId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtId.Location = new System.Drawing.Point(73, 4);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(170, 20);
            this.txtId.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(17, 8);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // VentanaPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 218);
            this.Controls.Add(this.pnlPrincipal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(286, 257);
            this.MinimumSize = new System.Drawing.Size(286, 257);
            this.Name = "VentanaPersonas";
            this.Text = "Agregar/Modificar Persona";
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.pnlLinea3.ResumeLayout(false);
            this.pnlLinea3.PerformLayout();
            this.pnlLinea2.ResumeLayout(false);
            this.pnlLinea2.PerformLayout();
            this.pnlLinea1.ResumeLayout(false);
            this.pnlLinea1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TableLayoutPanel pnlPrincipal;
        private System.Windows.Forms.TableLayoutPanel pnlLinea3;
        private System.Windows.Forms.TableLayoutPanel pnlBotones;
        private System.Windows.Forms.TableLayoutPanel pnlLinea2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TableLayoutPanel pnlLinea1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
    }
}