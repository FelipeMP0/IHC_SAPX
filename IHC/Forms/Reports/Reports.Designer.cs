namespace IHC
{
    partial class Reports
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
            this.btnHorasPorMes = new System.Windows.Forms.Button();
            this.btnProjetosPorMes = new System.Windows.Forms.Button();
            this.btnCargosMaisUsados = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHorasPorMes
            // 
            this.btnHorasPorMes.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnHorasPorMes.CausesValidation = false;
            this.btnHorasPorMes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHorasPorMes.FlatAppearance.BorderSize = 0;
            this.btnHorasPorMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorasPorMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHorasPorMes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHorasPorMes.Location = new System.Drawing.Point(290, 51);
            this.btnHorasPorMes.Name = "btnHorasPorMes";
            this.btnHorasPorMes.Size = new System.Drawing.Size(213, 39);
            this.btnHorasPorMes.TabIndex = 1;
            this.btnHorasPorMes.Text = "Horas por mês";
            this.btnHorasPorMes.UseVisualStyleBackColor = false;
            this.btnHorasPorMes.Click += new System.EventHandler(this.BtnHorasPorMes_Click);
            // 
            // btnProjetosPorMes
            // 
            this.btnProjetosPorMes.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnProjetosPorMes.CausesValidation = false;
            this.btnProjetosPorMes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProjetosPorMes.FlatAppearance.BorderSize = 0;
            this.btnProjetosPorMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjetosPorMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjetosPorMes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProjetosPorMes.Location = new System.Drawing.Point(290, 292);
            this.btnProjetosPorMes.Name = "btnProjetosPorMes";
            this.btnProjetosPorMes.Size = new System.Drawing.Size(213, 39);
            this.btnProjetosPorMes.TabIndex = 2;
            this.btnProjetosPorMes.Text = "Projetos por mês";
            this.btnProjetosPorMes.UseVisualStyleBackColor = false;
            this.btnProjetosPorMes.Click += new System.EventHandler(this.BtnProjetosPorMes_Click);
            // 
            // btnCargosMaisUsados
            // 
            this.btnCargosMaisUsados.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCargosMaisUsados.CausesValidation = false;
            this.btnCargosMaisUsados.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCargosMaisUsados.FlatAppearance.BorderSize = 0;
            this.btnCargosMaisUsados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargosMaisUsados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargosMaisUsados.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCargosMaisUsados.Location = new System.Drawing.Point(290, 173);
            this.btnCargosMaisUsados.Name = "btnCargosMaisUsados";
            this.btnCargosMaisUsados.Size = new System.Drawing.Size(213, 39);
            this.btnCargosMaisUsados.TabIndex = 3;
            this.btnCargosMaisUsados.Text = "Cargos mais planejados";
            this.btnCargosMaisUsados.UseVisualStyleBackColor = false;
            this.btnCargosMaisUsados.Click += new System.EventHandler(this.BtnCargosMaisUsados_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCargosMaisUsados);
            this.Controls.Add(this.btnProjetosPorMes);
            this.Controls.Add(this.btnHorasPorMes);
            this.Name = "Reports";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHorasPorMes;
        private System.Windows.Forms.Button btnProjetosPorMes;
        private System.Windows.Forms.Button btnCargosMaisUsados;
    }
}