namespace Maze_Runners
{
    partial class FormPresentacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMensaje1 = new System.Windows.Forms.Label();
            this.btnCambioForm = new System.Windows.Forms.Button();
            this.btnPrologo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMensaje1
            // 
            this.lblMensaje1.AutoSize = true;
            this.lblMensaje1.Location = new System.Drawing.Point(111, 18);
            this.lblMensaje1.Name = "lblMensaje1";
            this.lblMensaje1.Size = new System.Drawing.Size(332, 20);
            this.lblMensaje1.TabIndex = 0;
            this.lblMensaje1.Text = "Bienvenido a Tartaria, \"El Continente Perdido\"";
            // 
            // btnCambioForm
            // 
            this.btnCambioForm.Location = new System.Drawing.Point(228, 144);
            this.btnCambioForm.Name = "btnCambioForm";
            this.btnCambioForm.Size = new System.Drawing.Size(124, 63);
            this.btnCambioForm.TabIndex = 1;
            this.btnCambioForm.Text = "Comenzar";
            this.btnCambioForm.UseVisualStyleBackColor = true;
            this.btnCambioForm.Click += new System.EventHandler(this.btnCambioForm_Click);
            // 
            // btnPrologo
            // 
            this.btnPrologo.Location = new System.Drawing.Point(228, 377);
            this.btnPrologo.Name = "btnPrologo";
            this.btnPrologo.Size = new System.Drawing.Size(124, 38);
            this.btnPrologo.TabIndex = 2;
            this.btnPrologo.Text = "Leeme";
            this.btnPrologo.UseVisualStyleBackColor = true;
            this.btnPrologo.Click += new System.EventHandler(this.btnPrologo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(228, 245);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(124, 63);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir del Juego";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormPresentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(578, 444);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnPrologo);
            this.Controls.Add(this.btnCambioForm);
            this.Controls.Add(this.lblMensaje1);
            this.Name = "FormPresentacion";
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje1;
        private System.Windows.Forms.Button btnCambioForm;
        private System.Windows.Forms.Button btnPrologo;
        private System.Windows.Forms.Button btnSalir;
    }
}

