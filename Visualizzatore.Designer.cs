namespace CopyWhileType {
    partial class Visualizzatore {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tbTesto = new System.Windows.Forms.TextBox();
            this.btnCopia = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbTesto
            // 
            this.tbTesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTesto.Location = new System.Drawing.Point(12, 41);
            this.tbTesto.Multiline = true;
            this.tbTesto.Name = "tbTesto";
            this.tbTesto.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTesto.Size = new System.Drawing.Size(361, 67);
            this.tbTesto.TabIndex = 2;
            this.tbTesto.Enter += new System.EventHandler(this.tbTesto_Enter);
            this.tbTesto.Leave += new System.EventHandler(this.tbTesto_Leave);
            // 
            // btnCopia
            // 
            this.btnCopia.Location = new System.Drawing.Point(12, 12);
            this.btnCopia.Name = "btnCopia";
            this.btnCopia.Size = new System.Drawing.Size(75, 23);
            this.btnCopia.TabIndex = 0;
            this.btnCopia.Text = "Copia";
            this.btnCopia.UseVisualStyleBackColor = true;
            this.btnCopia.Click += new System.EventHandler(this.btnCopia_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.Location = new System.Drawing.Point(298, 12);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(75, 23);
            this.btnChiudi.TabIndex = 1;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // Visualizzatore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 120);
            this.ControlBox = false;
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnCopia);
            this.Controls.Add(this.tbTesto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Visualizzatore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Visualizzatore";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.Visualizzatore_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTesto;
        private System.Windows.Forms.Button btnCopia;
        private System.Windows.Forms.Button btnChiudi;
    }
}