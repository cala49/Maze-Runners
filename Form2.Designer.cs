namespace Maze_Runners
{
    partial class FormJuego
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBoxMaze = new System.Windows.Forms.PictureBox();
            this.btnGenerarLaberinto = new System.Windows.Forms.Button();
            this.lblPlayer1Score = new System.Windows.Forms.Label();
            this.lblPlayer2Score = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaze)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(595, 479);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 62);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir de la partida";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBoxMaze
            // 
            this.pictureBoxMaze.Location = new System.Drawing.Point(33, 26);
            this.pictureBoxMaze.Name = "pictureBoxMaze";
            this.pictureBoxMaze.Size = new System.Drawing.Size(506, 515);
            this.pictureBoxMaze.TabIndex = 1;
            this.pictureBoxMaze.TabStop = false;
            this.pictureBoxMaze.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMaze_Paint);
            // 
            // btnGenerarLaberinto
            // 
            this.btnGenerarLaberinto.Location = new System.Drawing.Point(595, 67);
            this.btnGenerarLaberinto.Name = "btnGenerarLaberinto";
            this.btnGenerarLaberinto.Size = new System.Drawing.Size(112, 62);
            this.btnGenerarLaberinto.TabIndex = 2;
            this.btnGenerarLaberinto.Text = "Mostrar Laberinto";
            this.btnGenerarLaberinto.UseVisualStyleBackColor = true;
            this.btnGenerarLaberinto.Click += new System.EventHandler(this.btnGenerarLaberinto_Click);
            // 
            // lblPlayer1Score
            // 
            this.lblPlayer1Score.AutoSize = true;
            this.lblPlayer1Score.Location = new System.Drawing.Point(591, 179);
            this.lblPlayer1Score.Name = "lblPlayer1Score";
            this.lblPlayer1Score.Size = new System.Drawing.Size(42, 20);
            this.lblPlayer1Score.TabIndex = 3;
            this.lblPlayer1Score.Text = "label";
            // 
            // lblPlayer2Score
            // 
            this.lblPlayer2Score.AutoSize = true;
            this.lblPlayer2Score.Location = new System.Drawing.Point(591, 228);
            this.lblPlayer2Score.Name = "lblPlayer2Score";
            this.lblPlayer2Score.Size = new System.Drawing.Size(51, 20);
            this.lblPlayer2Score.TabIndex = 4;
            this.lblPlayer2Score.Text = "label1";
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Location = new System.Drawing.Point(591, 297);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(51, 20);
            this.lblTurn.TabIndex = 5;
            this.lblTurn.Text = "label2";
            // 
            // FormJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(763, 553);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.lblPlayer2Score);
            this.Controls.Add(this.lblPlayer1Score);
            this.Controls.Add(this.btnGenerarLaberinto);
            this.Controls.Add(this.pictureBoxMaze);
            this.Controls.Add(this.btnSalir);
            this.Name = "FormJuego";
            this.Text = "Tartaria, \"El Continente Perdido\"";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBoxMaze;
        private System.Windows.Forms.Button btnGenerarLaberinto;
        private System.Windows.Forms.Label lblPlayer1Score;
        private System.Windows.Forms.Label lblPlayer2Score;
        private System.Windows.Forms.Label lblTurn;
    }
}