namespace library_automation
{
    partial class EmanetDuzenle
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
            this.txtEmanetVerilenTc = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEmanetVerilenTc
            // 
            this.txtEmanetVerilenTc.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEmanetVerilenTc.Location = new System.Drawing.Point(49, 73);
            this.txtEmanetVerilenTc.MaxLength = 15;
            this.txtEmanetVerilenTc.Name = "txtEmanetVerilenTc";
            this.txtEmanetVerilenTc.Size = new System.Drawing.Size(316, 26);
            this.txtEmanetVerilenTc.TabIndex = 70;
            this.txtEmanetVerilenTc.Text = "User TC";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtId.Location = new System.Drawing.Point(49, 41);
            this.txtId.MaxLength = 15;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(316, 26);
            this.txtId.TabIndex = 69;
            this.txtId.Text = "Kitap ID";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Raleway SemiBold", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnUpdate.ForeColor = System.Drawing.Color.LightGray;
            this.btnUpdate.Location = new System.Drawing.Point(49, 114);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(316, 133);
            this.btnUpdate.TabIndex = 120;
            this.btnUpdate.Text = "Emanet Al";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // frmEmanetDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(408, 288);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtEmanetVerilenTc);
            this.Controls.Add(this.txtId);
            this.Name = "frmEmanetDuzenle";
            this.ShowIcon = false;
            this.Text = "Emanet Düzenle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtEmanetVerilenTc;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnUpdate;
    }
}